using System.Collections.Generic;
using System.Linq;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Core.Models;
using Abituriyent.Info.Repository.Abstract;
using Abituriyent.Info.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Abituriyent.Info.Repository.Concret
{
    public class TestAnswerRepository : Repository<TestAnswer>, ITestAnswerRepository
    {
        private readonly IRepository<Answer> _answerRepository;
        private readonly IRepository<CourseLessonTest> _courseLessonTestRepository;

        public TestAnswerRepository(DbContext context, IRepository<Answer> answerRepository, IRepository<CourseLessonTest> courseLessonTestRepository) : base(context)
        {
            _answerRepository = answerRepository;
            _courseLessonTestRepository = courseLessonTestRepository;
        }

        public override void Dispose()
        {
            base.Dispose();
            _answerRepository.Dispose();
        }

        public IEnumerable<TestCorrectness> CheckTestAnswers(IEnumerable<ClosedTestAnswer> closedTestAnswers, IEnumerable<OpenTestAnswer> openTestAnswers, out int totalScore)
        {
            var results = (from closedTestAnswer in closedTestAnswers
                           //let test= Context.Set<CourseLessonTest>().FirstOrDefault(clt=>clt.TestId==closedTestAnswer.TestId)
                           let testAnswer =
                           Context.Set<TestAnswer>().FirstOrDefault(ta => ta.TestId == closedTestAnswer.TestId)
                           select
                           new TestCorrectness
                           {
                               TestId = closedTestAnswer.TestId,
                               AnswerId = testAnswer.AnswerId,
                               TestType = TestType.Closed,
                               IsCorrect = closedTestAnswer.AnswerId == testAnswer.AnswerId
                           }
                    ).ToList();

            foreach (var openTestAnswer in openTestAnswers)
            {
                var test = Context.Set<CourseLessonTest>().FirstOrDefault(clt => clt.Id == openTestAnswer.TestId);
                var testAnswer = Context.Set<TestAnswer>().FirstOrDefault(ta => ta.TestId == test.TestId);

                var findAnswer = _answerRepository.GetSingle(a => a.TestId == testAnswer.TestId && a.Text == openTestAnswer.AnswerText);
                if (findAnswer != null)
                {
                    results.Add(new TestCorrectness
                        {
                            TestId = openTestAnswer.TestId,
                            AnswerId = 0,
                            AnswerText =  _answerRepository.GetSingle(a=>a.TestId == testAnswer.TestId && a.Id == testAnswer.AnswerId).Text,
                            TestType = TestType.OpenValue,
                            IsCorrect = findAnswer.Id == testAnswer.AnswerId
                        });
                }
                else
                {
                    results.Add(new TestCorrectness
                    {
                        TestId = openTestAnswer.TestId,
                        AnswerId = 0,
                        AnswerText = _answerRepository.GetSingle(a => a.TestId == testAnswer.TestId && a.Id == testAnswer.AnswerId).Text,
                        TestType = TestType.OpenValue,
                        IsCorrect = false
                    });
                }
            }

          
            var courseLessonTests = _courseLessonTestRepository.FindBy(clt => results.Any(r => r.TestId == clt.Id), clt => clt.CourseLesson.Course).ToList();

            var score = 0;

            foreach (var courseLessonTest in courseLessonTests)
            {
                var testCorrectness = results.First(r => r.TestId == courseLessonTest.Id);
                if (testCorrectness.IsCorrect)
                {
                    score += courseLessonTest.CourseLesson.Course.ScoreRate;
                }
                else if(testCorrectness.TestType==TestType.Closed)
                {
                    score -= courseLessonTest.CourseLesson.Course.ScoreRate/4;
                }
            }

            totalScore = score;

            return results;
        }
    }
}
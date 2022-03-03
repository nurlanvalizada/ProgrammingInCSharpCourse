using System.Linq;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Abstract;
using Abituriyent.Info.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Abituriyent.Info.Repository.Concret
{
    public class StudentLessonTestAnswerRepository : Repository<StudentLessonTestAnswer>, IStudentLessonTestAnswerRepository
    {
        private readonly IRepository<Answer> _answerRepository;

        public StudentLessonTestAnswerRepository(DbContext context, IRepository<Answer> answerRepository) : base(context)
        {
            _answerRepository = answerRepository;
        }

        public override void Dispose()
        {
            base.Dispose();
            _answerRepository.Dispose();
        }

        public bool IsAlreadyAnswered(int studentId, int lessonId)
        {
            var tests = Context.Set<CourseLessonTest>().Where(clt => clt.CourseLessonId == lessonId).ToList();
            var answers = _answerRepository.FindBy(a => tests.Any(t => t.TestId == a.TestId)).ToList();
            return Context.Set<StudentLessonTestAnswer>().Any(slta => (slta.StudentId == studentId) && answers.Any(answer => answer.Id == slta.AnswerId));
        }
    }
}
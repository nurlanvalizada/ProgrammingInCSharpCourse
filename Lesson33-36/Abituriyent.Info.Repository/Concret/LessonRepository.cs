using System;
using System.Linq;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Abstract;
using Abituriyent.Info.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Abituriyent.Info.Repository.Concret
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        private readonly IStudentLessonRepository _studentLessonRepository;
        public LessonRepository(DbContext context, IStudentLessonRepository studentLessonRepository) : base(context)
        {
            _studentLessonRepository = studentLessonRepository;
        }

        public int GetActiveStudentsCount(int courseId)
        {
            var courseLessonIds = Context.Set<CourseLesson>().Where(cl => cl.CourseId == courseId).Select(cl=>cl.Id).ToList();
            return _studentLessonRepository.GetActiveStudentsCount(courseLessonIds);
        }

        public Lesson GetSingleWithoutPdf(int id)
        {
            return Context.Set<Lesson>()
                .Where(l => l.Id == id)
                .Select(l => new Lesson
                {
                    Id = l.Id,
                    Name = l.Name,
                    SubjectId = l.SubjectId,
                    Status = l.Status,
                    VideoUrl = l.VideoUrl
                }).SingleOrDefault();
        }

        public Tuple<string, byte[]> GetLessonPdf(int id)
        {
            return Context.Set<Lesson>()
                .Where(l => l.Id == id)
                .Select(l => new Tuple<string, byte[]>(l.PdfContentType, l.PdfFile))
                .SingleOrDefault();
        }

        public void UpdateWithoutPdfFile(Lesson lesson)
        {
            Context.Entry(lesson).State = EntityState.Modified;
            Context.Entry(lesson).Property(l => l.PdfContentType).IsModified = false;
            Context.Entry(lesson).Property(l => l.PdfFile).IsModified = false;
        }
    }
}
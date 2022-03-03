using System;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Base;

namespace Abituriyent.Info.Repository.Abstract
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        int GetActiveStudentsCount(int courseId);

        Lesson GetSingleWithoutPdf(int id);

        Tuple<string, byte[]> GetLessonPdf(int id);

        void UpdateWithoutPdfFile(Lesson lesson);
    }
}
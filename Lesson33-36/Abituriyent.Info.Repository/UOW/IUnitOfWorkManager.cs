using System;
using Abituriyent.Info.Core;
using Abituriyent.Info.Repository.Abstract;
using Abituriyent.Info.Repository.Base;

namespace Abituriyent.Info.Repository.UOW
{
    public interface IUnitOfWorkManager : IDisposable
    {
        ICourseRepository CourseRepository { get; }
        IGroupExamRepository GroupExamRepository { get; }
        ILessonRepository LessonRepository { get; }
        INewsRepository NewsRepository { get; }
        ISamplesRepository SamplesRepository { get; }
        IStudentLessonRepository StudentLessonRepository { get; }
        IStudentLessonTestAnswerRepository StudentLessonTestAnswerRepository { get; }
        IStudentRepository StudentRepository { get; }
        ITestAnswerRepository TestAnswerRepository { get; }

        IRepository<TEntity> Repository<TEntity>() where TEntity : Entity;

        void Commit();
    }
}

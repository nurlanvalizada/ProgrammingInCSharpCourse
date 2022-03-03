using System;
using System.Collections.Generic;
using System.Linq;
using Abituriyent.Info.Core;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Abstract;
using Abituriyent.Info.Repository.Base;
using Abituriyent.Info.Repository.Concret;
using Microsoft.EntityFrameworkCore;

namespace Abituriyent.Info.Repository.UOW
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private readonly Dictionary<Type, object> _repositories;
        private readonly DbContext _context;
        private bool _disposed;

        private ICourseRepository _courseRepository;
        private IGroupExamRepository _groupExamRepository;
        private ILessonRepository _lessonRepository;
        private INewsRepository _newsRepository;
        private ISamplesRepository _samplesRepository;
        private IStudentLessonRepository _studentLessonRepository;
        private IStudentLessonTestAnswerRepository _studentLessonTestAnswerRepository;
        private IStudentRepository _studentRepository;
        private ITestAnswerRepository _testAnswerRepository;

        public IStudentLessonRepository StudentLessonRepository => _studentLessonRepository ?? (_studentLessonRepository = new StudentLessonRepository(_context));
        public ILessonRepository LessonRepository => _lessonRepository ?? (_lessonRepository = new LessonRepository(_context, StudentLessonRepository));
        public ICourseRepository CourseRepository => _courseRepository ?? (_courseRepository = new CourseRepository(_context, LessonRepository));
        public IGroupExamRepository GroupExamRepository => _groupExamRepository ?? (_groupExamRepository = new GroupExamRepository(_context));
        public INewsRepository NewsRepository => _newsRepository ?? (_newsRepository = new NewsRepository(_context));
        public ISamplesRepository SamplesRepository => _samplesRepository ?? (_samplesRepository = new SamplesRepository(_context));
        public IStudentLessonTestAnswerRepository StudentLessonTestAnswerRepository => _studentLessonTestAnswerRepository ?? (_studentLessonTestAnswerRepository = new StudentLessonTestAnswerRepository(_context, Repository<Answer>()));
        public IStudentRepository StudentRepository => _studentRepository ?? (_studentRepository = new StudentRepository(_context));
        public ITestAnswerRepository TestAnswerRepository => _testAnswerRepository ?? (_testAnswerRepository = new TestAnswerRepository(_context, Repository<Answer>(), Repository<CourseLessonTest>()));
        
        public UnitOfWorkManager(DbContext context)
        {
            _repositories = new Dictionary<Type, object>();
            _context = context;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity :  Entity
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }
            IRepository<TEntity> repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
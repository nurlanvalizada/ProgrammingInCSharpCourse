using System;
using System.Linq;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Abstract;
using Abituriyent.Info.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Abituriyent.Info.Repository.Concret
{
    public class GroupExamRepository : Repository<GroupExam>, IGroupExamRepository
    {
        public GroupExamRepository(DbContext context) : base(context) { }

        public bool IsExamAvailable(int studentGroupId, int examId)
        {
            return Context.Set<GroupExam>().Any(
                e => e.Id == examId
                     && e.Exam.Date == DateTime.Today
                     && e.Exam.StartTime <= DateTime.Now.TimeOfDay
                     && e.Exam.EndTime >= DateTime.Now.TimeOfDay
                     && e.GroupId == studentGroupId);
        }
    }
}
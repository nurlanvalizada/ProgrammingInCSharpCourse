using System.Collections.Generic;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Core.Models;
using Abituriyent.Info.Repository.Base;

namespace Abituriyent.Info.Repository.Abstract
{
    public interface ITestAnswerRepository : IRepository<TestAnswer>
    {
        IEnumerable<TestCorrectness> CheckTestAnswers(IEnumerable<ClosedTestAnswer> closedTestAnswers, IEnumerable<OpenTestAnswer> openTestAnswers, out int totalScore);
    }
}
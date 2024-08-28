using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKA.Cupido.Entities;

namespace VKA.Cupido.Persistence.Interfaces
{
    public interface IQuestionRepository
    {
        public Task<List<QuestionEntity>> GetQuestions();
    }
}

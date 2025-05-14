using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesKPL.Models
{
    class MultipleChoiceQuestion<T>
    {
        public string QuestionText { get; set; }
        public List<T> Options { get; set; } = new List<T>();
        public T CorrectAnswer { get; set; }
    }
}

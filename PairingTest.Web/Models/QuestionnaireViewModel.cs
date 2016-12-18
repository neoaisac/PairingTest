using System.Collections.Generic;

namespace PairingTest.Web.Models
{
    public class QuestionnaireViewModel : ViewModel
    {
        public string QuestionnaireTitle { get; set; }
        public IList<string> QuestionsText { get; set; }
        public IList<string> AnswersText { get; set; }
    }
}
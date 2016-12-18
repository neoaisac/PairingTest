using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PairingTest.Web.Models
{
    public abstract class ViewModel
    {
        public string ApplicationName { get { return "Questionnaire application"; } }

        public string PageTitle { get; set; }
    }
}
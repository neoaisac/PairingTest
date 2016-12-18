using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace PairingTest.Web.Models
{
    public class ErrorViewModel : ViewModel
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public ErrorViewModel(HttpStatusCode httpStatusCode, string message)
        {
            StatusCode = httpStatusCode;
            Message = message;
        }
    }
}
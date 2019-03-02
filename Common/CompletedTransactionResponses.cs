using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiccoTest2.Common
{
    public partial class CompletedTransactionResponses
    {
        public CompletedTransactionResponses()
        {
            this.Message = "";
            this.WasSuccessfull = false;

        }


        public string Message { get; set; }
        public bool WasSuccessfull { get; set; }
    }


}
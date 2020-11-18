using CabInvoice.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoice.Exceptions
{
    class CabInvoiceExceptions : Exception
    {
        public ExceptionEnums.ExceptionType exceptionType;

        public CabInvoiceExceptions(ExceptionEnums.ExceptionType NO_SUCH_USER) : base(NO_SUCH_USER.ToString())
        {
            this.exceptionType = NO_SUCH_USER;
        }
    }
}

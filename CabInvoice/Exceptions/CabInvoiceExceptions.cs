// <copyright file="CabInvoiceExceptions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoice.Exceptions
{
    using CabInvoice.Enums;
    using System;

    public class CabInvoiceExceptions : Exception
    {
        public ExceptionEnums.ExceptionType exceptionType;

        public CabInvoiceExceptions(ExceptionEnums.ExceptionType NO_SUCH_USER) : base(NO_SUCH_USER.ToString())
        {
            this.exceptionType = NO_SUCH_USER;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CarRental.Common.Extensions;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public IList<ValidationError> Errors { get; }

        public override string Message => Errors?.Select(x => x.Message).JoinString(Environment.NewLine);

        public ValidationException(IList<ValidationError> errors)
        {
            Errors = errors;
        }
    }
}
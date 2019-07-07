using CarRental.Common.Extensions;

namespace CarRental.Common.Validation.Responses
{
    public class ValidationError
    {
        public ValidationType Type { get; set; } = ValidationType.Invalid;
        public bool IsFieldError => Field.IsNotNullOrWhiteSpace();
        public string Field { get; set; }
        public string Message { get; set; }

        public ValidationError() { }

        public ValidationError(string message)
        {
            Message = message;
        }
        public ValidationError(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}
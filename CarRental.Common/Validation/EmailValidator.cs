using System.Text.RegularExpressions;

namespace CarRental.Common.Validation
{
    public static class EmailValidator
    {
        // see http://stackoverflow.com/questions/201323/using-a-regular-expression-to-validate-an-email-address/1917982
        private static readonly Regex Regex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");

        /// <summary>
        /// Validates an string as being a valid email, it will validate null as false.
        /// </summary>
        public static bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email);
        }
    }
}

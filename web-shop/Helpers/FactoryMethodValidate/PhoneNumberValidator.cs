using System.Text.RegularExpressions;

namespace web_shop.Helpers.FactoryMethodValidate
{
    public class PhoneNumberValidator : Validator
    {
        public static bool IsPhoneNumber(string number)
        {
            string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            return Regex.IsMatch(number, motif);
        }

        public bool validate(string inputString)
        {
            return IsPhoneNumber(inputString);
        }
    }
}

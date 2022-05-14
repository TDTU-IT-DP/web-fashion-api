using System.Net.Mail;

namespace web_shop.Helpers.FactoryMethodValidate
{
    public class EmailValidator : Validator
    {
        static bool isValid(String email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public bool validate(string inputString)
        {
            return isValid(inputString);
        }
    }
}

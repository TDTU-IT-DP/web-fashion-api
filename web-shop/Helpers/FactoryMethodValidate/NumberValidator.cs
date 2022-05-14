using System.Text.RegularExpressions;

namespace web_shop.Helpers.FactoryMethodValidate
{
    public class NumberValidator : Validator
    {
        public bool validate(string inputString)
        {
            try
            {
                Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                return regex.IsMatch(inputString);

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

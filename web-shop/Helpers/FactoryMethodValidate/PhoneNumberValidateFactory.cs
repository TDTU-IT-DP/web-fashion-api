namespace web_shop.Helpers.FactoryMethodValidate
{
    public class PhoneNumberValidateFactory : ValidateFactory
    {
        public override Notifier GetNotifier()
        {
            return new PhoneNumberNotifier();
        }

        public override Validator GetValidator()
        {
            return new PhoneNumberValidator();
        }
    }
}

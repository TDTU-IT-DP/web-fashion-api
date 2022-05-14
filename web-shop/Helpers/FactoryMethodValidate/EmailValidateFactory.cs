namespace web_shop.Helpers.FactoryMethodValidate
{
    public class EmailValidateFactory : ValidateFactory
    {
        public override Notifier GetNotifier()
        {
            return new EmailNotifier();
        }

        public override Validator GetValidator()
        {
            return new EmailValidator();
        }
    }
}

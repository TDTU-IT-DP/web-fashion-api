namespace web_shop.Helpers.FactoryMethodValidate
{
    public class NumberValidateFactory : ValidateFactory
    {
        public override Notifier GetNotifier()
        {
            return new NumberNotifier();
        }

        public override Validator GetValidator()
        {
            return new NumberValidator();
        }
    }
}

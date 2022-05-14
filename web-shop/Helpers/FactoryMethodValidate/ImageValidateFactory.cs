namespace web_shop.Helpers.FactoryMethodValidate
{
    public class ImageValidateFactory : ValidateFactory
    {
        public override Notifier GetNotifier()
        {
            return new ImageNotifier();
        }

        public override Validator GetValidator()
        {
            return new ImageValidator();
        }
    }
}

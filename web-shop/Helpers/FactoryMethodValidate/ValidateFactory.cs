namespace web_shop.Helpers.FactoryMethodValidate
{
    public abstract class ValidateFactory
    {
        public abstract Validator GetValidator();
        public abstract Notifier GetNotifier();

        public string messageValidate(bool isCorrect)
        {
            string messageValidate = "";
            Notifier notifier = GetNotifier();

            if (isCorrect)
            {
                messageValidate = notifier.onSuccess();
            }
            else
            {
                messageValidate = notifier.onError() + notifier.example();
            }
            return messageValidate;
        }
        public bool validateInput(string inputValidate)
        {
            Validator validator = GetValidator();
            return validator.validate(inputValidate);
        }
    }
}

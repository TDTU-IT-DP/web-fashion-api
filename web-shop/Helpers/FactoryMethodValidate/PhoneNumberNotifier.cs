namespace web_shop.Helpers.FactoryMethodValidate
{
    public class PhoneNumberNotifier : Notifier
    {
        public string example()
        {
            return " Phone number : 0123456789";
        }

        public string onError()
        {
            return "This is not phone number ! ";
        }

        public string onSuccess()
        {
            return "";
        }
    }
}

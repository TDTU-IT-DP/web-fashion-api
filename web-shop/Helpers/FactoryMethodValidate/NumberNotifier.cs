namespace web_shop.Helpers.FactoryMethodValidate
{
    public class NumberNotifier : Notifier
    {
        public string example()
        {
            return " Number is in [0-9]";
        }

        public string onError()
        {
            return "Not Number ! ";
        }

        public string onSuccess()
        {
            return "";
        }
    }
}

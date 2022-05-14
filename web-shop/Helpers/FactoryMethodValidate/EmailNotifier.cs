namespace web_shop.Helpers.FactoryMethodValidate
{
    public class EmailNotifier : Notifier
    {
        public string example()
        {
            return " Email like: abc@gmail.com";
        }

        public string onError()
        {
            return "Invalid Email! ";
        }

        public string onSuccess()
        {
            return "";
        }
    }
}

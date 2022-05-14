namespace web_shop.Helpers.FactoryMethodValidate
{
    public class ImageNotifier : Notifier
    {
        public string example()
        {
            return "Image : .jpg/.png/....";
        }

        public string onError()
        {
            return "Just support image file !";
        }

        public string onSuccess()
        {
            return "";
        }
    }
}

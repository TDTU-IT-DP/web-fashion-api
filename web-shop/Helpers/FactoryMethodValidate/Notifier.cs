namespace web_shop.Helpers.FactoryMethodValidate
{
    public interface Notifier
    {
        string onSuccess();
        string onError();
        string example();
    }
}

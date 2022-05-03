namespace web_shop.Helpers.AdapterMethodAccess
{
    public interface ConvertData<T, U>
    {
        public U getConvert(T data);
    }
}

using MongoDB.Driver;

namespace web_shop.Helpers.StrategyMethodDataAccess
{
    public interface StrategyMethod<T>
    {
        Task add(T data);
        Task<List<T>> getSearch(string query);
        Task<UpdateResult> Update(T data, string Id);
        Task<DeleteResult> Delete(string Id);
    }
}

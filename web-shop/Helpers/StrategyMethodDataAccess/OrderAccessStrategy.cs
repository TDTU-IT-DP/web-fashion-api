using MongoDB.Driver;
using web_shop.DataAccess;
using web_shop.Models;

namespace web_shop.Helpers.StrategyMethodDataAccess
{
    public class OrderAccessStrategy : StrategyMethod<Order>
    {
        MongoDataAccess db = DataAccess.MongoDataAccess.getInstance();
        private const string OrderCollection = "Order";
        public Task add(Order data)
        {
            var orderCartCollection = db.CollectionToMongo<Order>(OrderCollection);
            return orderCartCollection.InsertOneAsync(data);
        }

        public async Task<DeleteResult> Delete(string Id)
        {
            var orderCartCollection = db.CollectionToMongo<Order>(OrderCollection);
            return await orderCartCollection.DeleteOneAsync(a => a.Id == Id);
        }

        public async Task<List<Order>> getSearch(string keySearch="")
        {
            var orderCartCollection = db.CollectionToMongo<Order>(OrderCollection);

            if (keySearch != "")
            {
                return await orderCartCollection.FindSync(c =>c.productCart[0].UserId==keySearch).ToListAsync();
            }
            return await orderCartCollection.FindSync(_ => true).ToListAsync();
        }

        public async Task<UpdateResult> Update(Order data, string Id)
        {
            var productcartCollection = db.CollectionToMongo<Order>(OrderCollection);
            var filter = Builders<Order>.Filter.Eq(s => s.productCart.ToList()[0].Id, Id);
            var update = Builders<Order>.Update.Set(s => s.totalPrice, data.totalPrice)
                                                   .Set(s => s.productCart, data.productCart)
                                                   .Set(s=>s.Status,data.Status)
                                                   .Set(s=>s.AdminConfirm,data.AdminConfirm)
                                                   .Set(s=>s.CusConfirm,data.CusConfirm)
                                                   .Set(s => s.CusName, data.CusName);
            return await productcartCollection.UpdateOneAsync(filter, update);
        }
    }
}

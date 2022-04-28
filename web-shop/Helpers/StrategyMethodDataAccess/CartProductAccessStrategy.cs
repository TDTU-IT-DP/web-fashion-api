using MongoDB.Driver;
using shop.DataAccess;
using shop.Models;

using MongoDB.Driver;
using shop.DataAccess;
using shop.Models;

namespace shop.Helpers.StrategyMethodDataAccess
{
    public class CartProductAccessStrategy : StrategyMethod<productCart>
    {
        MongoDataAccess db = DataAccess.MongoDataAccess.getInstance();
        private const string ProductCartCollection = "productCart";
        public Task add(productCart data)
        {
            var productCartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            return productCartCollection.InsertOneAsync(data);
        }

        public async Task<DeleteResult> Delete(string Id)
        {
            var productCartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            return await productCartCollection.DeleteOneAsync(a => a.Id == Id);
        }

        public async Task<List<productCart>> getSearch(string keySearch)
        {
            var productCartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);

            if (keySearch != "")
            {
                return await productCartCollection.FindSync(c => c.UserId == keySearch).ToListAsync();
            }
            return await productCartCollection.FindSync(_ => true).ToListAsync();
        }

        public async Task<UpdateResult> Update(productCart data, string Id)
        {
            var productcartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            var filter = Builders<productCart>.Filter.Eq(s => s.Product.Id, Id);
            var update = Builders<productCart>.Update.Set(s => s.Product, data.Product)
                                                   .Set(s => s.amount, data.amount)
                                                   .Set(s => s.UserId, data.UserId);
            return await productcartCollection.UpdateOneAsync(filter, update);
        }
    }
}

{
    public class CartProductAccessStrategy : StrategyMethod<productCart>
    {
        MongoDataAccess db = DataAccess.MongoDataAccess.getInstance();
        private const string ProductCartCollection = "productCart";
        public Task add(productCart data)
        {
            var productCartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            return productCartCollection.InsertOneAsync(data);
        }

        public async Task<DeleteResult> Delete(string Id)
        {
            var productCartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            return await productCartCollection.DeleteOneAsync(a => a.Id == Id);
        }

        public async Task<List<productCart>> getSearch(string keySearch)
        {
            var productCartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);

            if (keySearch != "")
            {
                return await productCartCollection.FindSync(c => c.UserId == keySearch).ToListAsync();
            }
            return await productCartCollection.FindSync(_ => true).ToListAsync();
        }

        public async Task<UpdateResult> Update(productCart data, string Id)
        {
            var productcartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            var filter = Builders<productCart>.Filter.Eq(s => s.Product.Id, Id);
            var update = Builders<productCart>.Update.Set(s => s.Product, data.Product)
                                                   .Set(s => s.amount, data.amount)
                                                   .Set(s => s.UserId, data.UserId);
            return await productcartCollection.UpdateOneAsync(filter, update);
        }
    }
}

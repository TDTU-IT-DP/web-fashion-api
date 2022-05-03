using MongoDB.Driver;
using web_shop.Models;

namespace web_shop.DataAccess
{
    public class ProductCartDataAccess
    {
        MongoDataAccess db = DataAccess.MongoDataAccess.getInstance();
        private const string ProductCartCollection = "productCart";

        public async Task<ReplaceOneResult> UpdateCart(productCart data, string UserId)
        {
            var productCartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            var filter = Builders<productCart>.Filter.Eq(s => s.UserId, UserId);
            return await productCartCollection.ReplaceOneAsync(filter, data);
        }
        public async Task<DeleteResult> DeleteCart(string productCartId)
        {
            var productCartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            return await productCartCollection.DeleteOneAsync(a => a.Id == productCartId);
        }

        //show or search product
        public async Task<List<productCart>> ShowProductCart(string keySearch = "")
        {
            var productCartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);

            if (keySearch != "")
            {
                return await productCartCollection.FindSync(c => c.UserId == keySearch).ToListAsync();
            }
            return await productCartCollection.FindSync(_ => true).ToListAsync();
        }
        public Task AddProductCart(productCart productCart)
        {
            var productCartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            return productCartCollection.InsertOneAsync(productCart);
        }
    }
}

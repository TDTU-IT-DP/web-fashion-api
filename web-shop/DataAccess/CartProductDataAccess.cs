using MongoDB.Driver;
using web_shop.Models;

namespace web_shop.DataAccess
{
    public class CartProductDataAccess
    {
        MongoDataAccess db = DataAccess.MongoDataAccess.getInstance();
        private const string ProductCartCollection = "productCart";
        public int CheckAmount(string productID, int amount)
        {
            var productCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            if (productCollection.Find(c => c.Product.Id == productID).ToList()[0].amount >= amount)
            {
                return 0;
            }
            return 1;
        }
        public int CheckExsits(string userid, string productId)
        {
            var productCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            if (productCollection.Find(c => c.Product.Id == productId && c.UserId == userid).ToList().Count > 0)
            {
                return 0;
            }
            return 1;
        }
        public async Task<DeleteResult> DeleteMany(string Id)
        {
            var productCartCollection = db.CollectionToMongo<productCart>(ProductCartCollection);
            return await productCartCollection.DeleteManyAsync(a => a.UserId == Id);
        }
    }
}

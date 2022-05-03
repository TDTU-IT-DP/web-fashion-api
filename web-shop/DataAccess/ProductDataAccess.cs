using MongoDB.Driver;
using web_shop.FormData;
using web_shop.Models;

namespace web_shop.DataAccess
{
    public class ProductDataAccess
    {
        MongoDataAccess db = DataAccess.MongoDataAccess.getInstance();
        private const string ProductCollection = "product";

        public async Task<List<Product>> CheckProduct(AddProduct product)
        {
            var productCollection = db.CollectionToMongo<Product>(ProductCollection);
            if (productCollection.Find(c => c.ProductId == product.ProductId).ToList().Count > 0)
            {
                return await productCollection.FindAsync(c => c.ProductId == product.ProductId).Result.ToListAsync();
            }
            return new List<Product>();
        }

    }
}

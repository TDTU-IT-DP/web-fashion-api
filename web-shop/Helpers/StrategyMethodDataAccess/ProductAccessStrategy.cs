using MongoDB.Driver;
using web_shop.DataAccess;
using web_shop.Helpers.FactoryMethodValidate;
using web_shop.Models;

namespace web_shop.Helpers.StrategyMethodDataAccess
{
    public class ProductAccessStrategy : StrategyMethod<Product>
    {
        MongoDataAccess db = DataAccess.MongoDataAccess.getInstance();
        private const string ProductCollection = "product";
        public Task add(Product data)
        {
            var productCollection = db.CollectionToMongo<Product>(ProductCollection);
            return productCollection.InsertOneAsync(data);
        }

        public async Task<DeleteResult> Delete(string Id)
        {
            var productCollection = db.CollectionToMongo<Product>(ProductCollection);
            return await productCollection.DeleteOneAsync(a => a.Id == Id);
        }

        public async Task<List<Product>> getSearch(string keySearch = "")
        {
            var productCollection = db.CollectionToMongo<Product>(ProductCollection);

            if (keySearch != "")
            {
                ValidateFactory numberValidate = new NumberValidateFactory();
                if (numberValidate.validateInput(keySearch))
                {
                    return await productCollection.FindSync(c => c.Price == int.Parse(keySearch) || c.Amount == int.Parse(keySearch)
                    || c.ProductName == keySearch || c.ProductId == keySearch
                    || c.TypeProduct == keySearch).ToListAsync();
                }
                else if (keySearch.Length == 24)
                {
                    return await productCollection.FindSync(c => c.Id == keySearch).ToListAsync();
                }
                return await productCollection.FindSync(c => c.ProductName == keySearch || c.ProductId == keySearch || c.TypeProduct == keySearch).ToListAsync();
            }
            return await productCollection.FindSync(_ => true).ToListAsync();
        }

        public async Task<UpdateResult> Update(Product product, string productId)
        {
            var productCollection = db.CollectionToMongo<Product>(ProductCollection);
            var filter = Builders<Product>.Filter.Eq(s => s.Id, productId);
            var update = Builders<Product>.Update.Set(s => s.ProductId, product.ProductId)
                                                   .Set(s => s.ProductName, product.ProductName)
                                                   .Set(s => s.Amount, product.Amount)
                                                   .Set(s => s.Price, product.Price)
                                                   .Set(s => s.Description, product.Description)
                                                   .Set(s => s.Subtitle, product.Subtitle)
                                                   .Set(s => s.TypeProduct, product.TypeProduct)
                                                   .Set(s => s.ImgLink, product.ImgLink)
                                                   .Set(s => s.Discount, product.Discount)
                                                   .Set(s => s.Size, product.Size);
            return await productCollection.UpdateOneAsync(filter, update);
        }
    }
}

using MongoDB.Driver;
using shop.DataAccess;
using shop.Helpers.FactoryMethodValidate;
using shop.Models;

namespace web_shop.Helpers.StrategyMethodDataAccess
{
    public class UserAccessStrategy : StrategyMethod<User>
    {
        MongoDataAccess db = DataAccess.MongoDataAccess.getInstance();
        private const string UserCollection = "users";
        public Task add(User data)
        {
            var userCollecton = db.CollectionToMongo<User>(UserCollection);

            return userCollecton.InsertOneAsync(data);
        }

        public async Task<DeleteResult> Delete(string Id)
        {
            var userCollection = db.CollectionToMongo<User>(UserCollection);
            return await userCollection.DeleteOneAsync(a => a.Id == Id);
        }

        public async Task<List<User>> getSearch(string key="")
        {
            var userCollecton = db.CollectionToMongo<User>(UserCollection);
            ValidateFactory numberValidate = new NumberValidateFactory();
            if (key != "")
            {
                if (numberValidate.validateInput(key))
                {
                    return await userCollecton.FindAsync(c => c.TypeUser == int.Parse(key)).Result.ToListAsync();
                }
                if (key.Length == 24)
                {
                    return await userCollecton.FindAsync(c => c.Id == key).Result.ToListAsync();
                }
                return await userCollecton.FindAsync(c => c.Name == key || c.Username == key || c.Email == key || c.PhoneNumber == key || c.TypeUser == int.Parse(key)).Result.ToListAsync();
            }
            return await userCollecton.FindAsync(_ => true).Result.ToListAsync();
        }
        public async Task<UpdateResult> Update(User data, string Id)
        {
            var userCollection = db.CollectionToMongo<User>(UserCollection);
            var filter = Builders<User>.Filter.Eq(s => s.Id, Id);

            if (data.Password != null)
            {
                var update = Builders<User>.Update.Set(s => s.Username, data.Username)
                                                   .Set(s => s.Name, data.Name)
                                                   .Set(s => s.PhoneNumber, data.PhoneNumber)
                                                   .Set(s => s.TypeUser, data.TypeUser)
                                                   .Set(s => s.Email, data.Email)
                                                   .Set(s => s.Address, data.Address)
                                                   .Set(s => s.Password, data.Password);
                return await userCollection.UpdateOneAsync(filter, update);
            }
            else
            {
                var update = Builders<User>.Update.Set(s => s.Username, data.Username)
                                                .Set(s => s.Name, data.Name)
                                                .Set(s => s.PhoneNumber, data.PhoneNumber)
                                                .Set(s => s.TypeUser, data.TypeUser)
                                                .Set(s => s.Email, data.Email)
                                                .Set(s => s.Address, data.Address);
                return await userCollection.UpdateOneAsync(filter, update);
            }
        }
    }
}

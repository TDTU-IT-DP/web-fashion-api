using MongoDB.Driver;
namespace web_shop.DataAccess
{
    public class MongoDataAccess
    {
        private const string connectionString = "mongodb+srv://Khanhpro1250:khanhpro1250@cluster0.ypxdo.mongodb.net/Shop_fashion?retryWrites=true&w=majority"; // mongodb clound
        //private const string connectionString = "mongodb://localhost:27017"; //mongodb local
        private const string databaseName = "Shop_fashion";
        private static MongoDataAccess _instance;
        private MongoDataAccess() { }
        public static MongoDataAccess getInstance()
        {
            if(_instance == null)
            {
                _instance=new MongoDataAccess();
            }
            return _instance;
        }
        public IMongoCollection<T> CollectionToMongo<T>(in string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            return db.GetCollection<T>(collection);
        }
    }
}

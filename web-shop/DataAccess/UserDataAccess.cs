using MongoDB.Driver;
using Org.BouncyCastle.Crypto.Generators;
using web_shop.FormData;
using web_shop.Models;

namespace web_shop.DataAccess
{
    public class UserDataAccess
    {
        MongoDataAccess db = DataAccess.MongoDataAccess.getInstance();

        private const string UserCollection = "users";
        //Check User exist
        public async Task<int> CheckUserRegister(RegisterData user)
        {
            var userCollecton = db.CollectionToMongo<User>(UserCollection);
            List<User> a = await userCollecton.FindAsync(c => c.Email == user.Email).Result.ToListAsync();
            List<User> b = await userCollecton.FindAsync(c => c.Username == user.Username).Result.ToListAsync();
            if (a.Count > 0)
            {
                return 1;
            }
            else if (b.Count > 0)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        //Check User Login
        public async Task<List<User>> CheckUserLogin(LoginData loginData)
        {
            var userCollecton = db.CollectionToMongo<User>(UserCollection);
            string passwordHash;
            List<User> UserLogin = await userCollecton.FindAsync(c => c.Username == loginData.Username).Result.ToListAsync();
            passwordHash = UserLogin[0].Password;
            if (userCollecton.Find(c => c.Username == loginData.Username).ToList().Count > 0)
            {

                bool checkPass = BCrypt.Net.BCrypt.Verify(loginData.Password, passwordHash);
                if (checkPass)
                {
                    return await userCollecton.FindAsync(c => c.Username == loginData.Username).Result.ToListAsync();
                }
            }
            return new List<User>();
        }
        public async Task<List<User>> CheckUserChangePass(ChangePass data)
        {
            var userCollecton = db.CollectionToMongo<User>(UserCollection);
            string passwordHash;
            List<User> UserLogin = await userCollecton.FindAsync(c => c.Id == data.UserId).Result.ToListAsync();
            passwordHash = UserLogin[0].Password;
            if (userCollecton.Find(c => c.Id == data.UserId).ToList().Count > 0)
            {

                bool checkPass = BCrypt.Net.BCrypt.Verify(data.OldPassword, passwordHash);
                if (checkPass)
                {
                    return await userCollecton.FindAsync(c => c.Id == data.UserId).Result.ToListAsync();
                }
            }
            return new List<User>();
        }
    }
}

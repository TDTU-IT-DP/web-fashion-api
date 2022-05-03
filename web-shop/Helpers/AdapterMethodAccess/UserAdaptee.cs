using web_shop.FormData;
using web_shop.Models;

namespace web_shop.Helpers.AdapterMethodAccess
{
    public class UserAdaptee
    {
        public User convert(RegisterData registerData)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerData.Password);
            User userRegister = new User();
            userRegister.Password = passwordHash;
            userRegister.Email = registerData.Email;
            userRegister.PhoneNumber = registerData.PhoneNumber;
            userRegister.Address = registerData.Address;
            userRegister.Name = registerData.Name;
            userRegister.TypeUser = registerData.TypeUser;
            userRegister.Username = registerData.Username;
            return userRegister;
        }
    }
}

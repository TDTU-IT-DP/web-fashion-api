using web_shop.FormData;
using web_shop.Models;

namespace web_shop.Helpers.AdapterMethodAccess
{
    public class UserUpdateAdaptee
    {
        public User convert(UpdateUserData userUpdate)
        {
            User updateUser = new User();
            updateUser.Username = userUpdate.Username;
            updateUser.Email = userUpdate.Email;
            updateUser.PhoneNumber = userUpdate.PhoneNumber;
            updateUser.Address = userUpdate.Address;
            updateUser.TypeUser = userUpdate.TypeUser;
            updateUser.Name = userUpdate.Name;
            return updateUser;
        }
    }
}

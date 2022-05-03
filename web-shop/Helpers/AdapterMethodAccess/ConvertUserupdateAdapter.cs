using web_shop.FormData;
using web_shop.Models;

namespace web_shop.Helpers.AdapterMethodAccess
{
    public class ConvertUserupdateAdapter : ConvertData<UpdateUserData, User>
    {
        private UserUpdateAdaptee userUpdateAdaptee;
        public ConvertUserupdateAdapter(UserUpdateAdaptee userUpdateAdaptee)
        {
            this.userUpdateAdaptee = userUpdateAdaptee;
        }
        public User getConvert(UpdateUserData data)
        {
            return userUpdateAdaptee.convert(data);
        }
    }
}

using web_shop.FormData;
using web_shop.Models;

namespace web_shop.Helpers.AdapterMethodAccess
{
    public class ConvertUserAdapter : ConvertData<RegisterData, User>
    {
        private UserAdaptee userAdaptee;
        public ConvertUserAdapter(UserAdaptee userAdaptee)
        {
            this.userAdaptee = userAdaptee;
        }
        public User getConvert(RegisterData data)
        {
            return userAdaptee.convert(data);
        }
    }
}

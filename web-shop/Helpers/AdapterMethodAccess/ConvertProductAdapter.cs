using web_shop.FormData;
using web_shop.Models;

namespace web_shop.Helpers.AdapterMethodAccess
{
    public class ConvertProductAdapter : ConvertData<AddProduct, Product>
    {
        private ProductAdaptee productAdaptee;
        public ConvertProductAdapter(ProductAdaptee productAdaptee)
        {
            this.productAdaptee = productAdaptee;
        }
        public Product getConvert(AddProduct data)
        {
            return productAdaptee.convert(data);
        }
    }
}

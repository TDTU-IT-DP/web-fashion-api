using web_shop.FormData;
using web_shop.Models;

namespace web_shop.Helpers.AdapterMethodAccess
{
    public class ProductAdaptee
    {
        public Product convert(AddProduct data)
        {
            Product product = new Product();
            product.ProductId = data.ProductId;
            product.ProductName = data.ProductName;
            product.Price = int.Parse(data.Price);
            product.Description = data.Description;
            product.TypeProduct = data.TypeProduct;
            product.Amount = int.Parse(data.Amount);
            product.Discount = int.Parse(data.Discount);
            product.Size = data.Size;
            product.Subtitle = data.Subtitle;
            product.ImgLink = data.ImgLink;
            return product;
        }
    }
}

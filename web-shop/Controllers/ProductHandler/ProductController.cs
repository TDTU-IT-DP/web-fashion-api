using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using web_shop.DataAccess;
using web_shop.FormData;
using web_shop.Helpers.AdapterMethodAccess;
using web_shop.Helpers.FactoryMethodValidate;
using web_shop.Helpers.StrategyMethodDataAccess;
using web_shop.Models;

namespace web_shop.Controllers.ProductHandler
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductDataAccess db = new ProductDataAccess();
        ProductAccessStrategy productAccess = new ProductAccessStrategy();

        [Route("admin/product/add")]
        [HttpPost]
        public ActionResult<messResult> AddProcduct([FromBody] AddProduct addproduct)
        {
            var messResult = new messResult();
            ValidateFactory numberValidate = new NumberValidateFactory();
            bool isPrice = numberValidate.validateInput(addproduct.Price);
            bool isAmount = numberValidate.validateInput(addproduct.Amount);
            bool isDiscount = numberValidate.validateInput(addproduct.Discount);
            if (!isPrice || !isAmount || !isDiscount)
            {
                messResult.code = 1;
                messResult.message = "Price, Discount, Amount must be type Number!";
            }
            else if (db.CheckProduct(addproduct).Result.Count != 0)
            {
                messResult.code = 1;
                messResult.message = "Product ID must be Unique. Please check again!";
            }
            else
            {
                Product product = new Product();
                ConvertProductAdapter convertProduct = new ConvertProductAdapter(new ProductAdaptee());
                product = convertProduct.getConvert(addproduct);
                productAccess.add(product);
                messResult.code = 0;
                messResult.message = "Add product success";
            }
            return new ObjectResult(new { code = messResult.code, message = messResult.message });
        }
        [Route("product/getall")]
        [HttpGet]
        public ActionResult<messResult> getAllProduct()
        {
            var messResult = new messResult();
            List<Product> products = productAccess.getSearch().Result;
            if (products.Count == 0)
            {
                messResult.code = 1;
                messResult.message = "Don't have any product !";
                return new ObjectResult(new { code = messResult.code, message = messResult.message });
            }
            else
            {
                messResult.code = 0;
                messResult.message = "Success";
                messResult.listProducts = products;
            }
            return new ObjectResult(new { code = messResult.code, message = messResult.message, products = messResult.listProducts, count = messResult.listProducts.Count });
        }
        [Route("product/search")]
        [HttpGet]
        public ActionResult<messResult> getSearchProduct(string key)
        {
            var messResult = new messResult();
            List<Product> products = productAccess.getSearch(key).Result;
            if (products.Count == 0)
            {
                messResult.code = 1;
                messResult.message = "Don't have any product !";
                return new ObjectResult(new { code = messResult.code, message = messResult.message });
            }
            else
            {
                messResult.code = 0;
                messResult.message = "Success";
                messResult.listProducts = products;
            }
            return new ObjectResult(new { code = messResult.code, message = messResult.message, products = messResult.listProducts, count = messResult.listProducts.Count });
        }
        [Route("admin/product/delete")]
        [HttpDelete]
        public ActionResult<messResult> DeleteProduct(string key)
        {
            try
            {
                var deleteresult = productAccess.Delete(key).Result.ToString;
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { code = 1, message = "Delete Fail" });
            }

            return new ObjectResult(new { code = 0, message = "Delete Success" });
        }
        [Route("admin/product/update")]
        [HttpPut]
        public ActionResult<messResult> updateProduct(AddProduct data, [FromQuery] string productId)
        {

            ConvertProductAdapter convertProductAdapter = new ConvertProductAdapter(new ProductAdaptee());
            Product updateProduct = convertProductAdapter.getConvert(data);

            UpdateResult s;
            try
            {
                s = productAccess.Update(updateProduct, productId).Result;
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { code = 1, message = "Update Fail", fail = ex.Message });
            }

            return new ObjectResult(new { code = 0, message = "Update Success" });
        }
    }
}


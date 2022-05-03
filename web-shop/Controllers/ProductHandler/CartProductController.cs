using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_shop.DataAccess;
using web_shop.Helpers.StrategyMethodDataAccess;
using web_shop.Models;

namespace web_shop.Controllers.ProductHandler
{
    [ApiController]
    public class CartProductController : ControllerBase
    {
        CartProductAccessStrategy cartProduct = new CartProductAccessStrategy();
        CartProductDataAccess db = new CartProductDataAccess();

        [Route("product/addCart")]
        [HttpPost]
        public ActionResult<messResult> AddCart([FromBody] productCart productCart)
        {
            var mess = new messResult();
            if (db.CheckExsits(productCart.UserId, productCart.Product.Id) == 0)
            {
                try
                {
                    cartProduct.Update(productCart, productCart.Product.Id);
                    mess.code = 0;
                    mess.message = "Success";
                }
                catch (Exception ex)
                {
                    mess.code = 1;
                    mess.message = ex.Message;
                }
            }
            else
            {
                try
                {
                    cartProduct.add(productCart);
                    mess.code = 0;
                    mess.message = "Success";
                }
                catch (Exception ex)
                {
                    mess.code = 1;
                    mess.message = ex.Message;
                }
            }

            return new ObjectResult(new { code = mess.code, message = mess.message });
        }
        [Route("product/getcartproduct")]
        [HttpGet]
        public ActionResult<messResult> getSearchCartProduct(string UserId)
        {
            var mess = new messResult();
            try
            {
                List<productCart> rs = cartProduct.getSearch(UserId).Result;
                mess.code = 0;
                mess.message = "Success";
                mess.listProductsCart = rs;
            }
            catch (Exception ex)
            {
                mess.code = 1;
                mess.message = ex.Message;
            }
            return new ObjectResult(new { code = mess.code, message = mess.message, listcartProduct = mess.listProductsCart, count = mess.listProductsCart.Count });
        }
        [Route("product/updatecartproduct")]
        [HttpPut]
        public ActionResult<messResult> updateCart([FromBody] productCart productCart)
        {
            var mess = new messResult();
            try
            {
                cartProduct.Update(productCart, productCart.Product.Id);
                mess.code = 0;
                mess.message = "Success";
            }
            catch (Exception ex)
            {
                mess.code = 1;
                mess.message = ex.Message;
            }
            return new ObjectResult(new { code = mess.code, message = mess.message });
        }
        [Route("product/delete")]
        [HttpDelete]
        public ActionResult<messResult> deleteCart(string id)
        {
            var mess = new messResult();
            try
            {
                var a = cartProduct.Delete(id);
                mess.code = 0;
                mess.message = "Success";
            }
            catch (Exception ex)
            {
                mess.code = 1;
                mess.message = ex.Message;
            }
            return new ObjectResult(new { code = mess.code, message = mess.message });
        }
        [Route("product/deleteAll")]
        [HttpDelete]
        public ActionResult<messResult> deleteAllCart(string id)
        {
            var mess = new messResult();
            try
            {
                var a = db.DeleteMany(id);
                mess.code = 0;
                mess.message = "Success";
            }
            catch (Exception ex)
            {
                mess.code = 1;
                mess.message = ex.Message;
            }
            return new ObjectResult(new { code = mess.code, message = mess.message });
        }
    }
}

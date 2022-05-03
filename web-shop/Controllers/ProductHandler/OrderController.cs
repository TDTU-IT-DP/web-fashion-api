using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_shop.Helpers.StrategyMethodDataAccess;
using web_shop.Models;

namespace web_shop.Controllers.ProductHandler
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderAccessStrategy orderAccess = new OrderAccessStrategy();
        [Route("product/payment")]
        [HttpPost]
        public ActionResult<messResult> AddOrder([FromBody] Order order)
        {
            var mess = new messResult();
            try
            {
                var a = orderAccess.add(order);
                mess.code = 0;
                mess.message = "Payment Success!";
            }
            catch (Exception ex)
            {
                mess.code = 1;
                mess.message = ex.Message;
            }

            return new ObjectResult(new { code = mess.code, message = mess.message });
        }
        [Route("product/updateOrder")]
        [Route("admin/product/updateOrder")]
        [HttpPut]
        public ActionResult<messResult> UpdateOrder([FromBody] Order order, string id)
        {
            var mess = new messResult();
            try
            {
                var a = orderAccess.Update(order, id);
                mess.code = 0;
                mess.message = "Update Success!";
            }
            catch (Exception ex)
            {
                mess.code = 1;
                mess.message = ex.Message;
            }

            return new ObjectResult(new { code = mess.code, message = mess.message });
        }
        [Route("admin/product/deleteorder")]
        [HttpDelete]
        public ActionResult<messResult> DeleteOrder(string key)
        {
            try
            {
                var deleteresult = orderAccess.Delete(key).Result.ToString;
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { code = 1, message = "Delete Fail" });
            }

            return new ObjectResult(new { code = 0, message = "Delete Success" });
        }
        [Route("admin/product/getallOder")]
        [HttpGet]
        public ActionResult<messResult> getAllOrder()
        {
            var messResult = new messResult();
            List<Order> orders = orderAccess.getSearch().Result;
            if (orders.Count == 0)
            {
                messResult.code = 1;
                messResult.message = "Don't have any order !";
                return new ObjectResult(new { code = messResult.code, message = messResult.message });
            }
            else
            {
                messResult.code = 0;
                messResult.message = "Success";
                messResult.listOrder = orders;
            }
            return new ObjectResult(new { code = messResult.code, message = messResult.message, listOrder = messResult.listOrder, count = messResult.listOrder.Count });
        }
        [Route("product/getorder")]
        [HttpGet]
        public ActionResult<messResult> getOrder(string userId)
        {
            var messResult = new messResult();
            List<Order> orders = orderAccess.getSearch(userId).Result;
            if (orders.Count == 0)
            {
                messResult.code = 1;
                messResult.message = "Don't have any order !";
                return new ObjectResult(new { code = messResult.code, message = messResult.message });
            }
            else
            {
                messResult.code = 0;
                messResult.message = "Success";
                messResult.listOrder = orders;
            }
            return new ObjectResult(new { code = messResult.code, message = messResult.message, listOrder = messResult.listOrder, count = messResult.listOrder.Count });
        }
    }
}


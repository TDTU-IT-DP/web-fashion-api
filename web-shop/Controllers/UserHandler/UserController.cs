using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Org.BouncyCastle.Crypto.Generators;
using web_shop.DataAccess;
using web_shop.FormData;
using web_shop.Helpers.AdapterMethodAccess;
using web_shop.Helpers.FactoryMethodValidate;
using web_shop.Helpers.StrategyMethodDataAccess;
using web_shop.Models;

namespace web_shop.Controllers.UserHandler
{
    [ApiController]
    public class UserController : ControllerBase
    {
        UserDataAccess db = new UserDataAccess();


        UserAccessStrategy userAccess = new UserAccessStrategy();
        [Route("account/register")]
        [HttpPost]
        public ActionResult<messResult> CreateUser([FromBody] RegisterData user)
        {
            var message = new messResult();
            ValidateFactory emailValidate = new EmailValidateFactory();
            ValidateFactory phoneNumberValidator = new PhoneNumberValidateFactory();

            if (!emailValidate.validateInput(user.Email))
            {
                message.code = 1;
                message.message = emailValidate.messageValidate(emailValidate.validateInput(user.Email));
            }
            else if (!phoneNumberValidator.validateInput(user.PhoneNumber))
            {
                message.code = 1;
                message.message = phoneNumberValidator.messageValidate(phoneNumberValidator.validateInput(user.PhoneNumber));
            }
            else if (user.Password != user.ConfirmPassword)
            {
                message.code = 1;
                message.message = "Password wasn't match. Please check again !";
            }
            else if (db.CheckUserRegister(user).Result == 1)
            {
                message.code = 1;
                message.message = "Email alreadly exsits!";
            }
            else if (db.CheckUserRegister(user).Result == 2)
            {
                message.code = 1;
                message.message = "Username alreadly exsits!";
            }
            else
            {
                ConvertUserAdapter convertUserAdapter = new ConvertUserAdapter(new UserAdaptee());
                User userRegister = convertUserAdapter.getConvert(user);
                userAccess.add(userRegister);
                message.code = 0;
                message.message = "Success";
            }

            return new OkObjectResult(new { code = message.code, message = message.message });

        }


        [AllowAnonymous]
        [Route("account/login")]
        [HttpPost]
        public ActionResult<messResult> Login([FromBody] LoginData loginData)
        {
            messResult mess = new messResult();
            List<User> data = new List<User>();
            try
            {
                data = db.CheckUserLogin(loginData).Result;
            }
            catch (Exception ex)
            {

            }

            if (data.Count > 0)
            {

                mess.code = 0;
                mess.message = "Login Success";
                mess.typeUser = data[0].TypeUser;
                mess.userId = data[0].Id;
                mess.user = data[0];
            }
            else
            {
                mess.code = 1;
                mess.message = "Invalid username or password !";
            }
            return new OkObjectResult(new { code = mess.code, message = mess.message, typeUser = mess.typeUser, userId = mess.userId, user = mess.user });
        }
        [Route("admin/account/getall")]
        [HttpGet]
        public ActionResult<messResult> getAllUser()
        {
            var mess = new messResult();
            List<User> users = userAccess.getSearch().Result;
            if (users.Count == 0)
            {
                mess.code = 1;
                mess.message = "Don't have any user !";
                return new OkObjectResult(new { code = mess.code, message = mess.message });
            }
            else
            {
                mess.code = 0;
                mess.message = "Success";
                mess.listUsers = users;
            }
            return new OkObjectResult(new { code = mess.code, message = mess.message, users = mess.listUsers, count = mess.listUsers.Count });
        }
        [Route("admin/account/search")]
        [HttpGet]
        public ActionResult<messResult> getSearchUser(string key)
        {
            var mess = new messResult();
            try
            {
                List<User> users = userAccess.getSearch(key).Result;
                if (users.Count == 0)
                {
                    mess.code = 1;
                    mess.message = "Don't have any user !";
                    return new OkObjectResult(new { code = mess.code, message = mess.message });
                }
                else
                {
                    mess.code = 0;
                    mess.message = "Success";
                    mess.listUsers = users;
                }
            }
            catch (Exception ex)
            {
                mess.code = 1;
                mess.message = "Don't have any user !";
                return new OkObjectResult(new { code = mess.code, message = mess.message, err = ex.Message });
            }


            return new OkObjectResult(new { code = mess.code, message = mess.message, users = mess.listUsers, count = mess.listUsers.Count });
        }
        [Route("admin/account/delete")]
        [HttpDelete]
        public ActionResult<messResult> DeleteAccount(string key)
        {
            try
            {
                var deleteresult = userAccess.Delete(key).Result.ToString;
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { code = 1, message = "Delete Fail", err = ex.Message });
            }

            return new ObjectResult(new { code = 0, message = "Delete Success" });
        }
        [Route("admin/account/update")]
        [Route("account/update")]
        [HttpPut]
        public ActionResult<messResult> updateAccount(UpdateUserData data, [FromQuery] string UserId)
        {
            ConvertUserupdateAdapter convertUserupdateAdapter = new ConvertUserupdateAdapter(new UserUpdateAdaptee());

            User updateUser = convertUserupdateAdapter.getConvert(data);
            UpdateResult s;
            try
            {
                s = userAccess.Update(updateUser, UserId).Result;
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { code = 1, message = "Update Fail", fail = ex.Message });
            }

            return new ObjectResult(new { code = 0, message = "Update Success" });
        }
        [Route("account/changepass")]
        [HttpPut]
        public ActionResult<messResult> changPass(ChangePass data)
        {
            messResult mess = new messResult();
            if (!data.NewPassword.Equals(data.New2Password))
            {
                return new ObjectResult(new { code = 1, message = "New password not match" });
            }
            else
            {
                try
                {

                    var user = db.CheckUserChangePass(data).Result;
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(data.NewPassword);
                    User updateUser = new User();
                    updateUser.Username = user[0].Username;
                    updateUser.Email = user[0].Email;
                    updateUser.PhoneNumber = user[0].PhoneNumber;
                    updateUser.Address = user[0].Address;
                    updateUser.TypeUser = user[0].TypeUser;
                    updateUser.Name = user[0].Name;
                    updateUser.Password = passwordHash;
                    try
                    {
                        UpdateResult s = userAccess.Update(updateUser, data.UserId).Result;
                        mess.code = 0;
                        mess.message = "Change password success";

                    }
                    catch (Exception ex)
                    {
                        return new ObjectResult(new { code = 1, message = "Chang password fail", fail = ex.Message });
                    }

                }
                catch (Exception ex)
                {
                    return new ObjectResult(new { code = 1, message = "Invalid Password", fail = ex.Message });
                }
            }


            return new ObjectResult(new { code = mess.code, message = mess.message });
        }
    }
}

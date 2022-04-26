namespace web_shop.Models
{
    public class messResult
    {
        public int code;
        public string message, userId;
        public int typeUser;
        public User user;
        public Product product;
        public List<Product> listProducts;
        public List<User> listUsers;
        public List<productCart> listProductsCart;
        public List<Order> listOrder;
        public messResult() { }
        public messResult(int code, string mess)
        {
            this.code = code;
            this.message = mess;
        }
        public messResult(int code, string mess, int typeUser, string userId, User user)
        {
            this.code = code;
            this.message = mess;
            this.typeUser = typeUser;
            this.userId = userId;
            this.user = user;
        }
        public messResult(int code, string mess, Product product)
        {
            this.code = code;
            this.message = mess;
            this.product = product;
        }
        public messResult(int code, string mess, List<Product> listProducts)
        {
            this.code = code;
            this.message = mess;
            this.listProducts = listProducts;
        }
        public messResult(int code, string mess, List<User> listUsers)
        {
            this.code = code;
            this.message = mess;
            this.listUsers = listUsers;
        }
        public messResult(int code, string mess, List<productCart> listProductsCart)
        {
            this.code = code;
            this.message = mess;
            this.listProductsCart = listProductsCart;
        }
        public messResult(int code, string mess, List<Order> listOrder)
        {
            this.code = code;
            this.message = mess;
            this.listOrder = listOrder;
        }
    }
}

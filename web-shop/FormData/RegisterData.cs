﻿namespace web_shop.FormData
{
    public class RegisterData
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Email { get; set; }
        public int TypeUser { get; set; } = 0;
    }
}

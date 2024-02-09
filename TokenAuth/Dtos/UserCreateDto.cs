namespace TokenAuth.Dtos
{
    public class UserCreateDto
    {
        public string TcNo { get; set; } =default!;
        public string PhoneNumber { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string UserName { get; set; } = default!;
    }
}

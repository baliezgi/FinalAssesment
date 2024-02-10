namespace Management.Service.Dtos
{
    public class TokenCreateDto
    {
        public string TcNo { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
    }
}

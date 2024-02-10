namespace Management.Service.Dtos
{
    public class RoleCreateRequestDto
    {
        public string userId { get; set; } = default!;
        public string roleName { get; set; } = default!;
    }
}

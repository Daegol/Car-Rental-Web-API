namespace AutoDabiServiceAPI.DTOs
{
    public class UserChangePasswordDto
    {
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
namespace Template_Web.Accelerator.Models.Authentication
{
    public class UserAuthenticationResponse
    {
        public bool Success { get; set; }
        public object Token { get; set; }
        public string Error { get; set; }
    }
}

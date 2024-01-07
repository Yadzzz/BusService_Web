namespace Template_Web.Accelerator.Domain
{
    public class UserContext
    {
        //This class is used to store the user's information in the session or in a cookie if needed, adjust the properties as needed
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

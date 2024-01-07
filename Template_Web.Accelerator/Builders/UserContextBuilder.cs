using Template_Web.Accelerator.Domain;

namespace Template_Web.Accelerator.Builders
{
    public class UserContextBuilder
    {
        public UserContextBuilder()
        {
            
        }

        public UserContext Build(Guid userId)
        {
            var userContext = new UserContext();
            userContext.Id = userId;
            userContext.Name = "yad";

            return userContext;
        }
    }
}

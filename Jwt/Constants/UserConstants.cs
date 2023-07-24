using Jwt.Models;

namespace Jwt.Constants
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "pvbloantonio", Password = "admin1234", Rol = "admin", Email = "pablo.elguetav@gmail.com",
            Firstname = "Pablo", Lastname = "Elgueta"},

            new UserModel() { Username = "Magnolia", Password = "vendedora1234", Rol = "vendedor", Email = "magnolia.elgueta@gmail.com",
            Firstname = "Magnolia", Lastname = "Elgueta"}
        };
    }
}

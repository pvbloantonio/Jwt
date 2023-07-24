using Jwt.Models;

namespace Jwt.Constants
{
    public class CountryConstants
    {
        public static List<CountryModel> Coutries = new List<CountryModel>()
        {
            new CountryModel() {Name = "Chile"},
            new CountryModel() {Name = "Argentina"},
            new CountryModel() {Name = "Mexico"},
        };

    }
}

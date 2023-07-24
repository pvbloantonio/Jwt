using Jwt.Models;

namespace Jwt.Constants
{
    public class EmployeeConstants
    {
        public static List<EmployeeModel> Employees = new List<EmployeeModel>()
        {
           new EmployeeModel() {Firstname = "Valeska", Lastname = "Saavedra", Email =  "vale.saavedra@gmail.com"},
           new EmployeeModel() {Firstname= "Romina", Lastname= "Garcia", Email= "romi.garcia@gmail.com"},
        };
    }
}

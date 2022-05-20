using Practical_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_19.Repositiories
{
    public interface Iservice
    {
        Task<List<Employee>> GetEmployee();
        Task<Employee> PostEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
        Task<Employee> GetEmployeeByID(int id);
    }
}

using DBdesign.Shared;

namespace DBdesign.Client.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<Employees> Emps { get; set; }
        List<Punchs1> Ps1 { get; set; }
        List<Punchs2> Ps2 { get; set; }
        Task GetPunch1();
        Task GetPunch2();
        Task GetEmployees();
        Task<Employees> GetSingleEmployee(int id);
    }
}

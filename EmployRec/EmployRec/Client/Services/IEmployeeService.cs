

using EmployRec.Client.Pages;
using EmployRec.Shared;

namespace EmployRec.Client.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<Emplo> Emps { get; set; }
        List<Puns1> Ps1 { get; set; }
        List<Puns2> Ps2 { get; set; }
        Task GetPunch1();
        Task GetPunch2();
        Task GetEmployees();
        Task<Puns1> GetSingleEmpPun1(int id);
        Task<Puns2> GetSingleEmpPun2(int id);
        Task CreatePunIn1(Puns1 puns1);
        Task CreatePunIn2(Puns2 puns2);
        //Task CreatePunIn<T>(T puns);
        Task UpdatePunch1(Puns1 puns1);
        Task UpdatePunch2(Puns2 puns2);
        public string DateDiff(DateTime D1, DateTime D2);
    }
}

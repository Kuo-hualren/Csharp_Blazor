using DBdesign.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace DBdesign.Client.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public EmployeeService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Employees> Emps { get; set; } = new List<Employees>();
        public List<Punchs1> Ps1 { get; set; } = new List<Punchs1>();
        public List<Punchs2> Ps2 { get; set; } = new List<Punchs2>();
        

        public async Task GetEmployees()
        {
            var result = await _http.GetFromJsonAsync<List<Employees>>("/api/employ");
            if (result != null)
                Emps = result;
        }

        public async Task GetPunch1()
        {
            var result = await _http.GetFromJsonAsync<List<Punchs1>>("/api/employ/pr1");
            if (result != null)
                Ps1 = result;
        }

        public Task GetPunch2()
        {
            throw new NotImplementedException();
        }

        public Task<Employees> GetSingleEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}

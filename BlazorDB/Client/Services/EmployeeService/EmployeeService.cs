using BlazorDB.Client.Pages;
using BlazorDB.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorDB.Client.Services.EmployeeService
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

        public List<Employee> Employees { get; set; } = new List<Employee>();
        
        public List<Record> Records { get; set; } = new List<Record>();

        
        public async Task<Employee> GetSingleEmployee(int id)
        {
            var result = await _http.GetFromJsonAsync<Employee>($"api/employ/{id}");
            if (result != null)
                return result;
            throw new Exception("Employee not found!");

        }

        public async Task GetEmployees()
        {
            var result = await _http.GetFromJsonAsync<List<Employee>>("api/employ");
            if (result != null)
            {
                Employees = result;
            }

        }

        public async Task GetRecords()
        {
            var result = await _http.GetFromJsonAsync<List<Record>>("/api/employ/records");
            if (result != null)
                Records = result;
        }

        public async Task CreateEmployee(Employee employee)
        {
            var result = await _http.PostAsJsonAsync("api/employ", employee);
            await SetEmployees(result);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var result = await _http.PutAsJsonAsync($"api/employ/{employee.Id}", employee);
            await SetEmployees(result);
        }

        public async Task DeleteEmployee(int id)
        {
            var result = await _http.DeleteAsync($"api/employ/{id}");
            await SetEmployees(result);
        }


        private async Task SetEmployees(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Employee>>();
            Employees = response;
            _navigationManager.NavigateTo("employees");
        }







        //-------------------------------------------------------------------------------
        //public async Task CreateRecord(Record record)
        //{
        //    var result = await _http.PostAsJsonAsync("api/employ/records", record);
        //    await SetRecords(result);
        //}
        //private async Task SetRecords(HttpResponseMessage result)
        //{
        //    var response = await result.Content.ReadFromJsonAsync<List<Record>>();
        //    Records = response;
        //    _navigationManager.NavigateTo("record");
        //}




        //---------------------------------------Punch Test---------------------------------------
        public List<PunchRec> PunchRecs { get; set; } = new List<PunchRec>();
        public async Task GetPunchRec()
        {
            var result = await _http.GetFromJsonAsync<List<PunchRec>>("/api/employ/punchtime");
            if (result != null)
                PunchRecs = result;
        }

        public async Task CreatePunch(PunchRec punch)
        {
            var result = await _http.PostAsJsonAsync("api/employ/punchtime", punch);
            var response = await result.Content.ReadFromJsonAsync<List<PunchRec>>();
            PunchRecs = response;
            _navigationManager.NavigateTo("punch");
        }

        public async Task UpdatePunch(PunchRec punch)
        {
            var result = await _http.PutAsJsonAsync($"api/employ/punchtime/{punch.Id}", punch);
            var response = await result.Content.ReadFromJsonAsync<PunchRec>();
            PunchRecs[punch.Id-1] = response;
            _navigationManager.NavigateTo("punch");
        }

        public async Task<PunchRec> GetSinglePunch(int id)
        {
            var result = await _http.GetFromJsonAsync<PunchRec>($"api/employ/punchtime/{id}");
            if (result != null)
                return result;
            throw new Exception("Punch Record not found!");


        }

        public string DateDiff(DateTime D1, DateTime D2)
        {
            string? dateDif = " ";
            //TimeSpan ts1 = new TimeSpan(D1.Ticks);
            
            DateTime ts1 = Convert.ToDateTime(D1.ToString());
            DateTime ts2 = Convert.ToDateTime(D2.ToString());

            TimeSpan ts = ts2 - ts1;
            dateDif = ts.Hours.ToString() + "小時" + ts.Minutes.ToString() + "分鐘" + ts.Seconds.ToString() + "秒";
            
            Console.WriteLine(dateDif);
            return dateDif;
        }
    }

    
}

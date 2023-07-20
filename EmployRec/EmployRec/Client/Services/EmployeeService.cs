using System;
using System.Net.Http.Json;
using System.Reflection;
using EmployRec.Client.Pages;
using EmployRec.Shared;
using Microsoft.AspNetCore.Components;
using static System.Net.WebRequestMethods;

namespace EmployRec.Client.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        public List<Emplo> Emps { get; set; } = new List<Emplo>();
        public List<Puns1> Ps1 { get; set; } = new List<Puns1>();
        public List<Puns2> Ps2 { get; set; } = new List<Puns2>();

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public EmployeeService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }


        public async Task GetEmployees()
        {
            var result = await _http.GetFromJsonAsync<List<Emplo>>("/api/employs");
            if (result != null)
                Emps = result;
        }

        public async Task GetPunch1()
        {
            var result = await _http.GetFromJsonAsync<List<Puns1>>("/api/employs/ps1");
            if (result != null)
                Ps1 = result;
        }

        public async Task GetPunch2()
        {
            var result = await _http.GetFromJsonAsync<List<Puns2>>("/api/employs/ps2");
            if (result != null)
                Ps2 = result;
        }

        public async Task<Puns1> GetSingleEmpPun1(int id)
        {
            var result = await _http.GetFromJsonAsync<Puns1>($"api/employ/ps1/{id}");
            if (result != null)
                return result;
            throw new Exception("Employee not found!");
        }

        public async Task<Puns2> GetSingleEmpPun2(int id)
        {
            var result = await _http.GetFromJsonAsync<Puns2>($"api/employ/ps2/{id}");
            if (result != null)
                return result;
            throw new Exception("Employee not found!");
        }

        public async Task CreatePunIn1(Puns1 puns1)
        {
            var result = await _http.PostAsJsonAsync("api/employs/ps1", puns1);
            var response = await result.Content.ReadFromJsonAsync<List<Puns1>>();           
            Ps1 = response;
            _navigationManager.NavigateTo("punch1");
           
        }

        public async Task CreatePunIn2(Puns2 puns2)
        {
            var result = await _http.PostAsJsonAsync("api/employs/ps2", puns2);
            var response = await result.Content.ReadFromJsonAsync<List<Puns2>>();
            Console.WriteLine(response);
            Ps2 = response;
            _navigationManager.NavigateTo("punch2");

        }

        public async Task UpdatePunch1(Puns1 puns1)
        {
            var result = await _http.PutAsJsonAsync($"api/employs/ps1/{puns1.Id}", puns1);
            var response = await result.Content.ReadFromJsonAsync<List<Puns1>>();
            Ps1 = response;
            _navigationManager.NavigateTo("punch1");
        }

        public async Task UpdatePunch2(Puns2 puns2)
        {
            var result = await _http.PutAsJsonAsync($"api/employs/ps2/{puns2.Id}", puns2);
            var response = await result.Content.ReadFromJsonAsync<List<Puns2>>();
            Ps2 = response;
            _navigationManager.NavigateTo("punch2");
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

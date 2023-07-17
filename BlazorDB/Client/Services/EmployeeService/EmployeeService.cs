﻿using BlazorDB.Client.Pages;
using BlazorDB.Shared;
using Microsoft.AspNetCore.Components;
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
    }

    
}

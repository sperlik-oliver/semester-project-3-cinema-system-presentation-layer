﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ABDOTClient.Data;
using ABDOTClient.Factories;
using ABDOTClient.Model;

namespace ABDOTClient.Networking.Requests
{
    public class EmployeeRequest : IEmployeeRequest
    {
        public Task<bool> CreateEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EditEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> GetEmployee(int Employeeid)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            throw new System.NotImplementedException();
        }
    }
}
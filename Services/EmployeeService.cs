using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UsersApi.Models;

namespace UsersApi.Services
{
    public class EmployeeService
    {
        public Employee Add(Employee emp)
        {
            Employee empp = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59948/api/");
                var PostTask = client.PostAsJsonAsync<Employee>("Employee", emp);
                PostTask.Wait();
                var Result = PostTask.Result;
                if (Result.IsSuccessStatusCode)
                {
                    var data = Result.Content.ReadFromJsonAsync<Employee>();
                    data.Wait();
                    empp = data.Result;
                }
            }
            return empp;
        }
        public ICollection<Employee> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59948/api/");
                var Get = client.GetFromJsonAsync<ICollection<Employee>>("Employee");
                Get.Wait();
                if (Get != null)
                {
                    return Get.Result;
                }
            }
            return null;
        }
    }
}

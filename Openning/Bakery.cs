using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Employee employee)
        {
            if(data.Count < Capacity)
            {
                data.Add(employee);
            }

        }

        public bool Remove(string name)
        {
            Employee nameToRemove = data.FirstOrDefault(n => n.Name == name);

            if(nameToRemove == null)
            {
                return false;
            }

            data.Remove(nameToRemove);
            return true;
        }

        
        public Employee GetOldestEmployee()
        {
            //Employee lookFor = data.FirstOrDefault(n => n.Name == name);
            return data.OrderByDescending(n => n.Age).FirstOrDefault();

        }

        
        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(n => n.Name == name);

        }

        
        public string Report()
        {

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Employees working at Bakery: {Name}");

            foreach (var item in data)
            {
                result.AppendLine($"Employee: {item.Name}, {item.Age} ({item.Country})");
            }

            return result.ToString();
            
        }
        
        

    }
}

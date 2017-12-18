using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Strategy.Base
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Id={Id}, Name={Name}";
        }
    }

    public class EmployeeByIdComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }
    public class Client {

        public void SortLists()
        {
            List<Employee> list = new List<Employee>();

            //Используем "функтор"
            list.Sort(new EmployeeByIdComparer());

            //Используем делегат
            list.Sort((x,y)=>String.Compare(x.Name, y.Name, StringComparison.Ordinal));
        }
    }

}

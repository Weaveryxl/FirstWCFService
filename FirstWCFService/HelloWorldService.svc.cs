using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace FirstWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(Namespace = "http://antra.net")]
    public class HellowordlService : IHelloworldService
    {
        public string GetEmployeeName(int ID)
        {
            try
            {
                return "My name is John Doe";
            }
            catch (Exception)
            {
                var fault = new HelloFault
                {
                    ErrorCode = "99",
                    ErrorDescription = "Please check values"
                };
                throw new FaultException<HelloFault>(fault);
            }
        }

        public Employee GetEmployee(int ID)
        {
            try
            {
                var allEmps = GetAllEmployees();
                return allEmps.First(x => x.ID == ID);
            }
            catch (Exception ex)
            {
                var fault = new HelloFault
                {
                    ErrorCode = "100",
                    ErrorDescription = ex.Message
                };
                throw new FaultException<HelloFault>(fault);
            }
        }

        public int Divide(int a, int b)
        {
            try
            {
                return a/b;
            }
            catch (DivideByZeroException ex)
            {
                var fault = new HelloFault
                {
                    ErrorCode = "101",
                    ErrorDescription = "Divide by Zero"
                };
                throw new FaultException<HelloFault>(fault);
            }
        }

        public int Multiply(int a, int b)
        {
            return a*b;
        }

        private List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee {ID = 1, Name = "John", State = "VA"},
                new Employee {ID = 2, Name = "Tom", State = "CT"},
                new Employee {ID = 3, Name = "Kate", State = "OH"}
            };
            return employees;
        }
    }
}
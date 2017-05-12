using System.Runtime.Serialization;
using System.ServiceModel;

namespace FirstWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "http://antra.net")]
    public interface IHelloworldService
    {
        [OperationContract]
        [FaultContract(typeof(HelloFault))]
        string GetEmployeeName(int ID);

        [OperationContract]
        [FaultContract(typeof(HelloFault))]
        Employee GetEmployee(int ID);

        [OperationContract]
        [FaultContract(typeof(HelloFault))]
        int Divide(int a, int b);

        [OperationContract]
        [FaultContract(typeof(HelloFault))]
        int Multiply(int a, int b);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string State { get; set; }
         
        [IgnoreDataMember]
        public string SSN { get; set; }
        
    }

    [DataContract(Namespace = "http://antra.net")]
    public class HelloFault
    {
        [DataMember]
        public string ErrorCode { get; set; }

        [DataMember]
        public string ErrorDescription { get; set; }
    }
}
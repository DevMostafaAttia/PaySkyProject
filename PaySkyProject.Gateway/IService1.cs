using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PaySkyProject.Gateway
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "/Students", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Student> GetStudentDetails();

        [OperationContract]
        [WebInvoke(Method = "POST",UriTemplate = "/AddStudent", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string AddStudent(Student student);

        [OperationContract(Name = "GetSampleMethod")]
        [WebInvoke(Method = "POST",UriTemplate = "PostSampleMethod/New")]
        string PostSampleMethod(string data);
    }
  
    [DataContract]
    public class Student
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}

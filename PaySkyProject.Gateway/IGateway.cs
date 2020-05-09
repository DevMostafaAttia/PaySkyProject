using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PaySkyProject.Gateway
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGateway" in both code and config file together.
    [ServiceContract]
    public interface IGateway
    {

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/ProcessTransaction", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string ProcessTransaction(Transaction transaction);

    }



    [DataContract]
    public class Transaction
    {
        [DataMember]
        public string Value { get; set; }
    }
}

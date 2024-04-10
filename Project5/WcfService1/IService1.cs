using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string StepsToSavings(int steps, decimal gasPrice);

        [OperationContract]
        string GoogleSearch(string query);
    }
}

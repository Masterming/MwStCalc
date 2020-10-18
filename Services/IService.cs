using System;
using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        double GetMwStPerc(int id);
    }
}

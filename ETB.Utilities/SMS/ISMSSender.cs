using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ETB.Utilities.SMS
{
    public interface ISMSSender
    {
        Task SendSMSAV2sync(string toCommSepNumber, string message);
        Task SendSMSAV1sync(string toCommSepNumber, string message);
    }
}

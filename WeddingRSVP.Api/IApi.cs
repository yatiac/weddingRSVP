using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRSVP.Api
{
    public interface IApi
    {

        object GetSeat(string id);

        object ConfirmSeats(string id, int seats);

        object ResetAll(string pw);
    }
}

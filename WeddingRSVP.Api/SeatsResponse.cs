using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRSVP.Api
{
    public class SeatsResponse
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public Seats SeatInfo { get; set; }
    }
}

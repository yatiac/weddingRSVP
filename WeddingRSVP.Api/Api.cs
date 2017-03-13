using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingRSVP.Api
{
    public class Api : IApi
    {

        public object GetSeat(string id)
        {            
            using(var context = new context())
            {
                var response = GetSeatsInfo(id, context);
                return response;
            }          
        }

        private static SeatsResponse GetSeatsInfo(string id, context context)
        {
            var errorMessage = string.Empty;
            var error = false;
            var assignedSeats = 0;
            var familyName = string.Empty;
            var seatResponse = context.Seats.Where(x => x.Id.Equals(id)).FirstOrDefault();
            // Validate id exists and is not confirmed
            if (seatResponse == null)
            {
                error = true;
                errorMessage = "Código no encontrado";
            }
            else if (seatResponse.Confirmed)
            {
                error = true;
                errorMessage = "Reserva ya confirmada";
            }
            else
            {
                error = false;
                assignedSeats = seatResponse.AssignedSeats;
                familyName = seatResponse.FamilyName;
            }
            return new SeatsResponse
            {
                Error = error,
                Message = errorMessage,
                SeatInfo = seatResponse
            };
        }

        public object ConfirmSeats(string id, int confirmedSeats)
        {
            using (var context = new context())
            {
                var response = GetSeatsInfo(id, context);
                if(!response.Error)
                {
                    if (confirmedSeats > response.SeatInfo.AssignedSeats)
                    {
                        response.Error = true;
                        response.Message = "El numero de puestos a confirmar no puede ser mayor a los asignados.";
                        response.SeatInfo = null;
                    }
                    else
                    {
                        response.SeatInfo.Confirmed = true;
                        response.SeatInfo.ConfirmedSeats = confirmedSeats;                        
                        response.Message = "Se ha confirmado su RSVP exitosamente. Numero de puestos: " + confirmedSeats;
                        if(confirmedSeats > 0)
                        {
                            response.Message += ".\r\nTe esperamos en nuestra boda :).";
                        }
                        context.SaveChanges();
                    }
                }

            return response;
            }  
        }


        public object ResetAll(string pw)
        {
            if (!(pw == "Lt9suSzrVX9GMWF"))
            {
                return "";
            }
            else
            {
                using(var context = new context())
                {
                    context.Seats.ToList().ForEach(i => { i.Confirmed = false; i.ConfirmedSeats = 0; });
                    context.SaveChanges();
                }                
            }
            return "success";
        }
    }
}

namespace WeddingRSVP.Api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Seats
    {
        [StringLength(6)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FamilyName { get; set; }

        public int AssignedSeats { get; set; }

        public int ConfirmedSeats { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public bool Confirmed { get; set; }
    }
}

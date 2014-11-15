using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTS.MainWebUI.Models
{
    public partial class UrbanArea
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]      
        public decimal[] Location {
            get
            {
                return new decimal[] { this.Latitude, this.Longitude };
            }

            private set { }
        }
    }
}

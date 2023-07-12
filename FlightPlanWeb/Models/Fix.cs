using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightplanWeb.Models
{
    public class Fix
    {
		public string airway { get; set; } = string.Empty;
		public double lat { get; set; }
		public double lon { get; set; }
	}
}
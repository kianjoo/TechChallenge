using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightPlanAPI.Models
{
    public class ICAO
    {
		public string country { get; set; } = string.Empty;
		public string region { get; set; } = string.Empty;
		public string iata { get; set; } = string.Empty;
		[Key]
		public string icao { get; set; } = string.Empty;
		public string airport { get; set; } = string.Empty;
		public string lat { get; set; } = string.Empty;
		public string lon { get; set; } = string.Empty;
	}
}
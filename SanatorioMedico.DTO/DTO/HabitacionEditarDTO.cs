using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
	public class HabitacionEditarDTO
	{

		public int CodigoHabitacion { get; set; }
		public int CodigoSucursal { get; set; }
		public string NumeroHabitacion { get; set; } = string.Empty;
		public string CodigoCama { get; set; } = string.Empty;
		public string TipoHabitacion { get; set; } = string.Empty;
		public string Piso { get; set; } = string.Empty;
		public int Capacidad { get; set; }
		public decimal TarifaDiaria { get; set; }
		public string Descripcion { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;
	}
}

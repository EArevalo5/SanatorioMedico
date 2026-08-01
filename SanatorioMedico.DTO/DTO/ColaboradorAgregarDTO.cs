using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
	public class ColaboradorAgregarDTO
	{
		public int CodigoSucursal { get; set; }
		public int CodigoRol { get; set; }
		public string Nombres { get; set; } = string.Empty;
		public string Apellidos { get; set; } = string.Empty;
		public string DPI { get; set; } = string.Empty;
		public string NumeroColegiado { get; set; } = string.Empty;
		public string TipoColaborador { get; set; } = string.Empty;
		public string Telefono { get; set; } = string.Empty;
		public string CorreoElectronico { get; set; } = string.Empty;
		public string Direccion { get; set; } = string.Empty;
		public DateOnly FechaContratacion { get; set; }
		public string NombreUsuario { get; set; } = string.Empty;
		public string ClaveAcceso { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;



	}
}

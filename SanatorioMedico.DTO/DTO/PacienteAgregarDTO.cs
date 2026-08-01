using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
	public class PacienteAgregarDTO
	{
		public string NumeroExpediente { get; set; } = string.Empty;
		public string TipoDocumento { get; set; } = string.Empty;
		public string NumeroDocumento { get; set; } = string.Empty;
		public string Nombres { get; set; } = string.Empty;
		public string Apellidos { get; set; } = string.Empty;
		public DateOnly FechaNacimiento { get; set; }
		public string Genero { get; set; } = string.Empty;
		public string TipoSangre { get; set; } = string.Empty;
		public string Telefono { get; set; } = string.Empty;
		public string CorreoElectronico { get; set; } = string.Empty;
		public string Direccion { get; set; } = string.Empty;
		public string ContactoEmergencia { get; set; } = string.Empty;
		public string TelefonoEmergencia { get; set; } = string.Empty;
		public string Alergias { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;


	}
}

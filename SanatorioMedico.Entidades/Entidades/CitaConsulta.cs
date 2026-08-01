using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.Entidades.Entidades
{
	public class CitaConsulta
	{
		public int CodigoCitaConsulta { get; set; }
		public int CodigoPaciente { get; set; }
		public int CodigoColaborador { get; set; }
		public int CodigoSucursal { get; set; }
		public int CodigoEspecialidad { get; set; }
		public DateTime FechaHoraCita { get; set; }
		public string TipoAtencion { get; set; } = string.Empty;
		public string MotivoConsulta { get; set; } = string.Empty;
		public string Sintomas { get; set; } = string.Empty;
		public string ObservacionesMedicas { get; set; } = string.Empty;
		public string TratamientoGeneral { get; set; } = string.Empty;
		public string PresionArterial { get; set; } = string.Empty;
		public decimal Temperatura { get; set; }
		public decimal Peso { get; set; }
		public string Estado { get; set; } = string.Empty;

	}
}

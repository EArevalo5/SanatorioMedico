using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
	public class HospitalizacionConsultaDTO
	{
		public int CodigoHospitalizacion { get; set; }
		public int CodigoPaciente { get; set; }
		public int CodigoSucursal { get; set; }
		public int CodigoColaborador { get; set; }
		public int CodigoCitaConsulta { get; set; }
		public int CodigoHabitacion { get; set; }
		public string MotivoIngreso { get; set; } = string.Empty;
		public string DiagnosticoIngreso { get; set; } = string.Empty;
		public string DiagnosticoEgreso { get; set; } = string.Empty;
		public string RecomendacionesEgreso { get; set; } = string.Empty;
		public string Observaciones { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;




	}
}

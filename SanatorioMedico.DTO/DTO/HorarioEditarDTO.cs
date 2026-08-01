using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
	public class HorarioEditarDTO
	{
		public int CodigoHorario { get; set; }
		public int CodigoColaborador { get; set; }
		public int CodigoSucursal { get; set; }
		public int CodigoEspecialidad { get; set; }
		public string DiaSemana { get; set; } = string.Empty;
		public TimeOnly HoraInicio { get; set; }
		public TimeOnly HoraFin { get; set; }
		public int DuracionCitaMinutos { get; set; }
		public string Jornada { get; set; } = string.Empty;
		public string Observaciones { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;



	}
}

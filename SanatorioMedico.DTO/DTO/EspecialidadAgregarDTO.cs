using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
	public class EspecialidadAgregarDTO
	{

		public string NombreEspecialidad { get; set; } = string.Empty;
		public string Descripcion { get; set; } = string.Empty;
		public string AreaMedica { get; set; } = string.Empty;
		public int DuracionConsulta { get; set; }
		public decimal CostoConsulta { get; set; }
		public bool RequiereCita { get; set; }
		public string Observaciones { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
	public class ColaboradorEspecialidadAgregarDTO
	{
		public int CodigoColaborador { get; set; }
		public int CodigoEspecialidad { get; set; }
		public DateOnly FechaAsignacion { get; set; }
		public string NumeroAutorizacion { get; set; } = string.Empty;
		public string InstitucionAcreditadora { get; set; } = string.Empty;
		public DateOnly FechaVencimiento { get; set; }
		public string Observaciones { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;

	}
}

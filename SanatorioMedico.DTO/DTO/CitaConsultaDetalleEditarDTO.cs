using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
	public class CitaConsultaDetalleEditarDTO
	{
		public int CodigoDetalle { get; set; }
		public int CodigoCitaConsulta { get; set; }
		public int CodigoProducto { get; set; }
		public string TipoDetalle { get; set; } = string.Empty;
		public string SubtipoDetalle { get; set; } = string.Empty;
		public string DescripcionDetalle { get; set; } = string.Empty;
		public string Dosis { get; set; } = string.Empty;
		public string Frecuencia { get; set; } = string.Empty;
		public string Duracion { get; set; } = string.Empty;
		public string Indicaciones { get; set; } = string.Empty;
		public string Resultado { get; set; } = string.Empty;
		public decimal Cantidad { get; set; }
		public string Estado { get; set; } = string.Empty;


	}
}

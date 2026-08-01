using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
	public class FacturaConsultaDTO
	{
		public int CodigoFactura { get; set; }
		public int CodigoPaciente { get; set; }
		public int CodigoSucursal { get; set; }
		public int CodigoColaborador { get; set; }
		public string NumeroFactura { get; set; } = string.Empty;
		public string NombreFacturacion { get; set; } = string.Empty;
		public string NITFacturacion { get; set; } = string.Empty;
		public string DireccionFacturacion { get; set; } = string.Empty;
		public decimal Subtotal { get; set; }
		public decimal Descuento { get; set; }
		public decimal Impuesto { get; set; }
		public decimal Total { get; set; }
		public decimal SaldoPendiente { get; set; }
		public string Estado { get; set; } = string.Empty;


	}
}

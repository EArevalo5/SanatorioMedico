using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
public class FacturaDetalleConsultaDTO
	{
		public int CodigoFacturaDetalle { get; set; }
		public int CodigoFactura { get; set; }
		public string TipoMovimiento { get; set; } = string.Empty;
		public string TipoCargo { get; set; } = string.Empty;
		public string Concepto { get; set; } = string.Empty;
		public decimal Cantidad { get; set; }
		public decimal PrecioUnitario { get; set; }
		public decimal Subtotal { get; set; }
		public decimal MontoPago { get; set; }
		public string FormaPago { get; set; } = string.Empty;
		public string ReferenciaPago { get; set; } = string.Empty;
		public int CodigoReferenciaOrigen { get; set; }
		public string Observaciones { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;


	}
}

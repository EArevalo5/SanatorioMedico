using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
	public class MovimientoInventarioAgregarDTO
	{
		public int CodigoSucursal { get; set; }
		public int CodigoProducto { get; set; }
		public int CodigoProveedor { get; set; }
		public int CodigoColaborador { get; set; }
		public string TipoMovimiento { get; set; } = string.Empty;
		public string NumeroDocumento { get; set; } = string.Empty;
		public string Lote { get; set; } = string.Empty;
		public DateOnly FechaVencimiento { get; set; }
		public decimal CantidadEntrada { get; set; }
		public decimal CantidadSalida { get; set; }
		public decimal CostoUnitario { get; set; }
		public decimal ExistenciaResultante { get; set; }
		public string MotivoMovimiento { get; set; } = string.Empty;
		public string Observaciones { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;


	}
}

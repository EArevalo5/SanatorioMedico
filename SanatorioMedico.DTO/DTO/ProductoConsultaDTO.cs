using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.DTO.DTO
{
	public class ProductoConsultaDTO
	{
		public int CodigoProducto { get; set; }
		public string CodigoInterno { get; set; } = string.Empty;
		public string NombreProducto { get; set; } = string.Empty;
		public string TipoProducto { get; set; } = string.Empty;
		public string Categoria { get; set; } = string.Empty;
		public string Presentacion { get; set; } = string.Empty;
		public string UnidadMedida { get; set; } = string.Empty;
		public string PrincipioActivo { get; set; } = string.Empty;
		public string Concentracion { get; set; } = string.Empty;
		public decimal PrecioCompra { get; set; }
		public decimal PrecioVenta { get; set; }
		public bool RequiereReceta { get; set; }
		public string Estado { get; set; } = string.Empty;



	}
}

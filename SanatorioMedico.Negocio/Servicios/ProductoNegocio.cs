using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class ProductoNegocio
	{
		private readonly ProductoDatos productoDatos;

		public ProductoNegocio()
		{
			productoDatos = new ProductoDatos();
		}

		public List<Producto> ConsultarProductos()
		{
			return productoDatos.ConsultarProductos();
		}

		public bool AgregarProducto(Producto producto)
		{
			return productoDatos.AgregarProducto(producto);
		}

		public Producto? BuscarProducto(int codigoProducto)
		{
			return productoDatos.BuscarProducto(codigoProducto);
		}

		public bool EditarProducto(Producto producto)
		{
			return productoDatos.EditarProducto(producto);
		}

		public bool EliminarProducto(int codigoProducto)
		{
			return productoDatos.EliminarProducto(codigoProducto);
		}
	}
}
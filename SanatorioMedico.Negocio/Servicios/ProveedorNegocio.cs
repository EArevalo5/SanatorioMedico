using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class ProveedorNegocio
	{
		private readonly ProveedorDatos proveedorDatos;

		public ProveedorNegocio()
		{
			proveedorDatos = new ProveedorDatos();
		}

		public List<Proveedor> ConsultarProveedores()
		{
			return proveedorDatos.ConsultarProveedores();
		}

		public bool AgregarProveedor(Proveedor proveedor)
		{
			return proveedorDatos.AgregarProveedor(proveedor);
		}

		public Proveedor? BuscarProveedor(int codigoProveedor)
		{
			return proveedorDatos.BuscarProveedor(codigoProveedor);
		}

		public bool EditarProveedor(Proveedor proveedor)
		{
			return proveedorDatos.EditarProveedor(proveedor);
		}

		public bool EliminarProveedor(int codigoProveedor)
		{
			return proveedorDatos.EliminarProveedor(codigoProveedor);
		}
	}
}
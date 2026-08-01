
using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{

	// Método Consultar Sucursales
	public class SucursalNegocio
	{
		private readonly SucursalDatos sucursalDatos;

		public SucursalNegocio()
		{
			sucursalDatos = new SucursalDatos();
		}

		public List<Sucursal> ConsultarSucursales()
		{
			return sucursalDatos.ConsultarSucursales();
		}



		// Metodo Agregar Sucursales
		public bool AgregarSucursal(Sucursal sucursal)
		{
			return sucursalDatos.AgregarSucursal(sucursal);
		}
		// Método Buscar Sucursal
		public Sucursal? BuscarSucursal(int codigoSucursal)
		{
			return sucursalDatos.BuscarSucursal(codigoSucursal);
		}
		// Método Editar Sucursal
		public bool EditarSucursal(Sucursal sucursal)
		{
			return sucursalDatos.EditarSucursal(sucursal);
		}
		// Método Eliminar Sucursal
		public bool EliminarSucursal(int codigoSucursal)
		{
			return sucursalDatos.EliminarSucursal(codigoSucursal);
		}



	}
}

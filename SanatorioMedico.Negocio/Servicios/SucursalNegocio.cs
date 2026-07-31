
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
	}
}

using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class RolNegocio
	{
		private readonly RolDatos rolDatos;

		public RolNegocio()
		{
			rolDatos = new RolDatos();
		}

		public List<Rol> ConsultarRoles()
		{
			return rolDatos.ConsultarRoles();
		}

		public bool AgregarRol(Rol rol)
		{
			return rolDatos.AgregarRol(rol);
		}

		public Rol? BuscarRol(int codigoRol)
		{
			return rolDatos.BuscarRol(codigoRol);
		}

		public bool EditarRol(Rol rol)
		{
			return rolDatos.EditarRol(rol);
		}

		public bool EliminarRol(int codigoRol)
		{
			return rolDatos.EliminarRol(codigoRol);
		}
	}
}

using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class ColaboradorEspecialidadNegocio
	{
		private readonly ColaboradorEspecialidadDatos datos;

		public ColaboradorEspecialidadNegocio()
		{
			datos = new ColaboradorEspecialidadDatos();
		}

		public List<ColaboradorEspecialidad> ConsultarColaboradoresEspecialidades()
		{
			return datos.ConsultarColaboradoresEspecialidades();
		}

		public bool AgregarColaboradorEspecialidad(ColaboradorEspecialidad entidad)
		{
			return datos.AgregarColaboradorEspecialidad(entidad);
		}

		public ColaboradorEspecialidad? BuscarColaboradorEspecialidad(int codigo)
		{
			return datos.BuscarColaboradorEspecialidad(codigo);
		}

		public bool EditarColaboradorEspecialidad(ColaboradorEspecialidad entidad)
		{
			return datos.EditarColaboradorEspecialidad(entidad);
		}

		public bool EliminarColaboradorEspecialidad(int codigo)
		{
			return datos.EliminarColaboradorEspecialidad(codigo);
		}
	}
}
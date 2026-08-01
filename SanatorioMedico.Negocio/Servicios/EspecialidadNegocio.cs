using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class EspecialidadNegocio
	{
		private readonly EspecialidadDatos especialidadDatos;

		public EspecialidadNegocio()
		{
			especialidadDatos = new EspecialidadDatos();
		}

		public List<Especialidad> ConsultarEspecialidades()
		{
			return especialidadDatos.ConsultarEspecialidades();
		}

		public bool AgregarEspecialidad(Especialidad especialidad)
		{
			return especialidadDatos.AgregarEspecialidad(especialidad);
		}

		public Especialidad? BuscarEspecialidad(int codigoEspecialidad)
		{
			return especialidadDatos.BuscarEspecialidad(codigoEspecialidad);
		}

		public bool EditarEspecialidad(Especialidad especialidad)
		{
			return especialidadDatos.EditarEspecialidad(especialidad);
		}

		public bool EliminarEspecialidad(int codigoEspecialidad)
		{
			return especialidadDatos.EliminarEspecialidad(codigoEspecialidad);
		}
	}
}
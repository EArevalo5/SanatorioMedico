using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class HorarioNegocio
	{
		private readonly HorarioDatos horarioDatos;

		public HorarioNegocio()
		{
			horarioDatos = new HorarioDatos();
		}

		public List<Horario> ConsultarHorarios()
		{
			return horarioDatos.ConsultarHorarios();
		}

		public bool AgregarHorario(Horario horario)
		{
			return horarioDatos.AgregarHorario(horario);
		}

		public Horario? BuscarHorario(int codigoHorario)
		{
			return horarioDatos.BuscarHorario(codigoHorario);
		}

		public bool EditarHorario(Horario horario)
		{
			return horarioDatos.EditarHorario(horario);
		}

		public bool EliminarHorario(int codigoHorario)
		{
			return horarioDatos.EliminarHorario(codigoHorario);
		}
	}
}
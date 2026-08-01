using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class HabitacionNegocio
	{
		private readonly HabitacionDatos habitacionDatos;

		public HabitacionNegocio()
		{
			habitacionDatos = new HabitacionDatos();
		}

		public List<Habitacion> ConsultarHabitaciones()
		{
			return habitacionDatos.ConsultarHabitaciones();
		}

		public bool AgregarHabitacion(Habitacion habitacion)
		{
			return habitacionDatos.AgregarHabitacion(habitacion);
		}

		public Habitacion? BuscarHabitacion(int codigoHabitacion)
		{
			return habitacionDatos.BuscarHabitacion(codigoHabitacion);
		}

		public bool EditarHabitacion(Habitacion habitacion)
		{
			return habitacionDatos.EditarHabitacion(habitacion);
		}

		public bool EliminarHabitacion(int codigoHabitacion)
		{
			return habitacionDatos.EliminarHabitacion(codigoHabitacion);
		}
	}
}
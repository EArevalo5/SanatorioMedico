using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class CitaConsultaNegocio
	{
		private readonly CitaConsultaDatos citaConsultaDatos;

		public CitaConsultaNegocio()
		{
			citaConsultaDatos = new CitaConsultaDatos();
		}

		public List<CitaConsulta> ConsultarCitasConsultas()
		{
			return citaConsultaDatos.ConsultarCitasConsultas();
		}

		public bool AgregarCitaConsulta(CitaConsulta cita)
		{
			return citaConsultaDatos.AgregarCitaConsulta(cita);
		}

		public CitaConsulta? BuscarCitaConsulta(int codigoCitaConsulta)
		{
			return citaConsultaDatos.BuscarCitaConsulta(codigoCitaConsulta);
		}

		public bool EditarCitaConsulta(CitaConsulta cita)
		{
			return citaConsultaDatos.EditarCitaConsulta(cita);
		}

		public bool EliminarCitaConsulta(int codigoCitaConsulta)
		{
			return citaConsultaDatos.EliminarCitaConsulta(codigoCitaConsulta);
		}
	}
}
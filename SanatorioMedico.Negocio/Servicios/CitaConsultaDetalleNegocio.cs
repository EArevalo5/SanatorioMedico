using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class CitaConsultaDetalleNegocio
	{
		private readonly CitaConsultaDetalleDatos datos;

		public CitaConsultaDetalleNegocio()
		{
			datos = new CitaConsultaDetalleDatos();
		}

		public List<CitaConsultaDetalle> ConsultarCitasConsultasDetalle()
		{
			return datos.ConsultarCitasConsultasDetalle();
		}

		public bool AgregarCitaConsultaDetalle(CitaConsultaDetalle detalle)
		{
			return datos.AgregarCitaConsultaDetalle(detalle);
		}

		public CitaConsultaDetalle? BuscarCitaConsultaDetalle(int codigoDetalle)
		{
			return datos.BuscarCitaConsultaDetalle(codigoDetalle);
		}

		public bool EditarCitaConsultaDetalle(CitaConsultaDetalle detalle)
		{
			return datos.EditarCitaConsultaDetalle(detalle);
		}

		public bool EliminarCitaConsultaDetalle(int codigoDetalle)
		{
			return datos.EliminarCitaConsultaDetalle(codigoDetalle);
		}
	}
}
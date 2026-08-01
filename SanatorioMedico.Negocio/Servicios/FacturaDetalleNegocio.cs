using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class FacturaDetalleNegocio
	{
		private readonly FacturaDetalleDatos datos;

		public FacturaDetalleNegocio()
		{
			datos = new FacturaDetalleDatos();
		}

		public List<FacturaDetalle> ConsultarFacturasDetalle()
		{
			return datos.ConsultarFacturasDetalle();
		}

		public bool AgregarFacturaDetalle(FacturaDetalle detalle)
		{
			return datos.AgregarFacturaDetalle(detalle);
		}

		public FacturaDetalle? BuscarFacturaDetalle(int codigoFacturaDetalle)
		{
			return datos.BuscarFacturaDetalle(codigoFacturaDetalle);
		}

		public bool EditarFacturaDetalle(FacturaDetalle detalle)
		{
			return datos.EditarFacturaDetalle(detalle);
		}

		public bool EliminarFacturaDetalle(int codigoFacturaDetalle)
		{
			return datos.EliminarFacturaDetalle(codigoFacturaDetalle);
		}
	}
}
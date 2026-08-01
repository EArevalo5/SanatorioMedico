using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class FacturaNegocio
	{
		private readonly FacturaDatos facturaDatos;

		public FacturaNegocio()
		{
			facturaDatos = new FacturaDatos();
		}

		public List<Factura> ConsultarFacturas()
		{
			return facturaDatos.ConsultarFacturas();
		}

		public bool AgregarFactura(Factura factura)
		{
			return facturaDatos.AgregarFactura(factura);
		}

		public Factura? BuscarFactura(int codigoFactura)
		{
			return facturaDatos.BuscarFactura(codigoFactura);
		}

		public bool EditarFactura(Factura factura)
		{
			return facturaDatos.EditarFactura(factura);
		}

		public bool EliminarFactura(int codigoFactura)
		{
			return facturaDatos.EliminarFactura(codigoFactura);
		}
	}
}
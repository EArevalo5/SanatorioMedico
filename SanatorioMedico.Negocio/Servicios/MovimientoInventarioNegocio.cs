using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class MovimientoInventarioNegocio
	{
		private readonly MovimientoInventarioDatos movimientoDatos;

		public MovimientoInventarioNegocio()
		{
			movimientoDatos = new MovimientoInventarioDatos();
		}

		public List<MovimientoInventario> ConsultarMovimientosInventario()
		{
			return movimientoDatos.ConsultarMovimientosInventario();
		}

		public bool AgregarMovimientoInventario(MovimientoInventario movimiento)
		{
			return movimientoDatos.AgregarMovimientoInventario(movimiento);
		}

		public MovimientoInventario? BuscarMovimientoInventario(int codigoMovimientoInventario)
		{
			return movimientoDatos.BuscarMovimientoInventario(codigoMovimientoInventario);
		}

		public bool EditarMovimientoInventario(MovimientoInventario movimiento)
		{
			return movimientoDatos.EditarMovimientoInventario(movimiento);
		}

		public bool EliminarMovimientoInventario(int codigoMovimientoInventario)
		{
			return movimientoDatos.EliminarMovimientoInventario(codigoMovimientoInventario);
		}
	}
}
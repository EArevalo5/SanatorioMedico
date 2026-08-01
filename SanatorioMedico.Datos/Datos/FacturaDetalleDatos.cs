using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class FacturaDetalleDatos
	{
		public List<FacturaDetalle> ConsultarFacturasDetalle()
		{
			List<FacturaDetalle> lista = new List<FacturaDetalle>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_FacturasDetalle_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				lista.Add(new FacturaDetalle
				{
					CodigoFacturaDetalle = lector["CodigoFacturaDetalle"] != DBNull.Value
						? Convert.ToInt32(lector["CodigoFacturaDetalle"]) : 0,

					CodigoFactura = lector["CodigoFactura"] != DBNull.Value
						? Convert.ToInt32(lector["CodigoFactura"]) : 0,

					TipoMovimiento = lector["TipoMovimiento"]?.ToString() ?? string.Empty,
					TipoCargo = lector["TipoCargo"]?.ToString() ?? string.Empty,
					Concepto = lector["Concepto"]?.ToString() ?? string.Empty,

					Cantidad = lector["Cantidad"] != DBNull.Value
						? Convert.ToDecimal(lector["Cantidad"]) : 0m,

					PrecioUnitario = lector["PrecioUnitario"] != DBNull.Value
						? Convert.ToDecimal(lector["PrecioUnitario"]) : 0m,

					Subtotal = lector["Subtotal"] != DBNull.Value
						? Convert.ToDecimal(lector["Subtotal"]) : 0m,

					MontoPago = lector["MontoPago"] != DBNull.Value
						? Convert.ToDecimal(lector["MontoPago"]) : 0m,

					FormaPago = lector["FormaPago"]?.ToString() ?? string.Empty,
					ReferenciaPago = lector["ReferenciaPago"]?.ToString() ?? string.Empty,

					CodigoReferenciaOrigen = lector["CodigoReferenciaOrigen"] != DBNull.Value
						? Convert.ToInt32(lector["CodigoReferenciaOrigen"]) : 0,

					Observaciones = lector["Observaciones"]?.ToString() ?? string.Empty,
					Estado = lector["Estado"]?.ToString() ?? string.Empty
				});
			}

			return lista;
		}

		public bool AgregarFacturaDetalle(FacturaDetalle detalle)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_FacturasDetalle_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoFactura", SqlDbType.Int).Value = detalle.CodigoFactura;
			comando.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar, 30).Value = detalle.TipoMovimiento;
			comando.Parameters.Add("@TipoCargo", SqlDbType.VarChar, 50).Value = detalle.TipoCargo;
			comando.Parameters.Add("@Concepto", SqlDbType.VarChar, 250).Value = detalle.Concepto;

			SqlParameter pCantidad = comando.Parameters.Add("@Cantidad", SqlDbType.Decimal);
			pCantidad.Precision = 12; pCantidad.Scale = 2; pCantidad.Value = detalle.Cantidad;

			SqlParameter pPrecio = comando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal);
			pPrecio.Precision = 12; pPrecio.Scale = 2; pPrecio.Value = detalle.PrecioUnitario;

			SqlParameter pSubtotal = comando.Parameters.Add("@Subtotal", SqlDbType.Decimal);
			pSubtotal.Precision = 12; pSubtotal.Scale = 2; pSubtotal.Value = detalle.Subtotal;

			SqlParameter pMonto = comando.Parameters.Add("@MontoPago", SqlDbType.Decimal);
			pMonto.Precision = 12; pMonto.Scale = 2; pMonto.Value = detalle.MontoPago;

			comando.Parameters.Add("@FormaPago", SqlDbType.VarChar, 50).Value = detalle.FormaPago;
			comando.Parameters.Add("@ReferenciaPago", SqlDbType.VarChar, 100).Value = detalle.ReferenciaPago;
			comando.Parameters.Add("@CodigoReferenciaOrigen", SqlDbType.Int).Value = detalle.CodigoReferenciaOrigen;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 500).Value = detalle.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = detalle.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public FacturaDetalle? BuscarFacturaDetalle(int codigoFacturaDetalle)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_FacturasDetalle_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoFacturaDetalle", SqlDbType.Int).Value = codigoFacturaDetalle;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new FacturaDetalle
				{
					CodigoFacturaDetalle = lector["CodigoFacturaDetalle"] == DBNull.Value ? 0 : Convert.ToInt32(lector["CodigoFacturaDetalle"]),
					CodigoFactura = lector["CodigoFactura"] == DBNull.Value ? 0 : Convert.ToInt32(lector["CodigoFactura"]),

					TipoMovimiento = lector["TipoMovimiento"] == DBNull.Value ? "" : lector["TipoMovimiento"].ToString()!,
					TipoCargo = lector["TipoCargo"] == DBNull.Value ? "" : lector["TipoCargo"].ToString()!,
					Concepto = lector["Concepto"] == DBNull.Value ? "" : lector["Concepto"].ToString()!,

					Cantidad = lector["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(lector["Cantidad"]),
					PrecioUnitario = lector["PrecioUnitario"] == DBNull.Value ? 0 : Convert.ToDecimal(lector["PrecioUnitario"]),
					Subtotal = lector["Subtotal"] == DBNull.Value ? 0 : Convert.ToDecimal(lector["Subtotal"]),
					MontoPago = lector["MontoPago"] == DBNull.Value ? 0 : Convert.ToDecimal(lector["MontoPago"]),

					FormaPago = lector["FormaPago"] == DBNull.Value ? "" : lector["FormaPago"].ToString()!,
					ReferenciaPago = lector["ReferenciaPago"] == DBNull.Value ? "" : lector["ReferenciaPago"].ToString()!,

					CodigoReferenciaOrigen = lector["CodigoReferenciaOrigen"] == DBNull.Value
						? 0
						: Convert.ToInt32(lector["CodigoReferenciaOrigen"]),

					Observaciones = lector["Observaciones"] == DBNull.Value ? "" : lector["Observaciones"].ToString()!,
					Estado = lector["Estado"] == DBNull.Value ? "" : lector["Estado"].ToString()!
				};
			}

			return null;
		}
		public bool EditarFacturaDetalle(FacturaDetalle detalle)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_FacturasDetalle_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoFacturaDetalle", SqlDbType.Int).Value = detalle.CodigoFacturaDetalle;
			comando.Parameters.Add("@CodigoFactura", SqlDbType.Int).Value = detalle.CodigoFactura;
			comando.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar, 30).Value = detalle.TipoMovimiento;
			comando.Parameters.Add("@TipoCargo", SqlDbType.VarChar, 50).Value = detalle.TipoCargo;
			comando.Parameters.Add("@Concepto", SqlDbType.VarChar, 250).Value = detalle.Concepto;

			SqlParameter pCantidad = comando.Parameters.Add("@Cantidad", SqlDbType.Decimal);
			pCantidad.Precision = 12; pCantidad.Scale = 2; pCantidad.Value = detalle.Cantidad;

			SqlParameter pPrecio = comando.Parameters.Add("@PrecioUnitario", SqlDbType.Decimal);
			pPrecio.Precision = 12; pPrecio.Scale = 2; pPrecio.Value = detalle.PrecioUnitario;

			SqlParameter pSubtotal = comando.Parameters.Add("@Subtotal", SqlDbType.Decimal);
			pSubtotal.Precision = 12; pSubtotal.Scale = 2; pSubtotal.Value = detalle.Subtotal;

			SqlParameter pMonto = comando.Parameters.Add("@MontoPago", SqlDbType.Decimal);
			pMonto.Precision = 12; pMonto.Scale = 2; pMonto.Value = detalle.MontoPago;

			comando.Parameters.Add("@FormaPago", SqlDbType.VarChar, 50).Value = detalle.FormaPago;
			comando.Parameters.Add("@ReferenciaPago", SqlDbType.VarChar, 100).Value = detalle.ReferenciaPago;
			comando.Parameters.Add("@CodigoReferenciaOrigen", SqlDbType.Int).Value = detalle.CodigoReferenciaOrigen;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 500).Value = detalle.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = detalle.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarFacturaDetalle(int codigoFacturaDetalle)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_FacturasDetalle_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoFacturaDetalle", SqlDbType.Int).Value = codigoFacturaDetalle;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}
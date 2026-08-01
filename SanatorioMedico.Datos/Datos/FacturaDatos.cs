using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class FacturaDatos
	{
		public List<Factura> ConsultarFacturas()
		{
			List<Factura> lista = new List<Factura>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Facturas_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				lista.Add(new Factura
				{
					CodigoFactura = Convert.ToInt32(lector["CodigoFactura"]),
					CodigoPaciente = Convert.ToInt32(lector["CodigoPaciente"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					NumeroFactura = lector["NumeroFactura"].ToString() ?? string.Empty,
					NombreFacturacion = lector["NombreFacturacion"].ToString() ?? string.Empty,
					NITFacturacion = lector["NITFacturacion"].ToString() ?? string.Empty,
					DireccionFacturacion = lector["DireccionFacturacion"].ToString() ?? string.Empty,
					Subtotal = Convert.ToDecimal(lector["Subtotal"]),
					Descuento = Convert.ToDecimal(lector["Descuento"]),
					Impuesto = Convert.ToDecimal(lector["Impuesto"]),
					Total = Convert.ToDecimal(lector["Total"]),
					SaldoPendiente = Convert.ToDecimal(lector["SaldoPendiente"]),
					Estado = lector["Estado"].ToString() ?? string.Empty
				});
			}

			return lista;
		}

		public bool AgregarFactura(Factura factura)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Facturas_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = factura.CodigoPaciente;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = factura.CodigoSucursal;
			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = factura.CodigoColaborador;
			comando.Parameters.Add("@NumeroFactura", SqlDbType.VarChar, 50).Value = factura.NumeroFactura;
			comando.Parameters.Add("@NombreFacturacion", SqlDbType.VarChar, 150).Value = factura.NombreFacturacion;
			comando.Parameters.Add("@NITFacturacion", SqlDbType.VarChar, 20).Value = factura.NITFacturacion;
			comando.Parameters.Add("@DireccionFacturacion", SqlDbType.VarChar, 200).Value = factura.DireccionFacturacion;

			SqlParameter pSubtotal = comando.Parameters.Add("@Subtotal", SqlDbType.Decimal);
			pSubtotal.Precision = 12; pSubtotal.Scale = 2; pSubtotal.Value = factura.Subtotal;

			SqlParameter pDescuento = comando.Parameters.Add("@Descuento", SqlDbType.Decimal);
			pDescuento.Precision = 12; pDescuento.Scale = 2; pDescuento.Value = factura.Descuento;

			SqlParameter pImpuesto = comando.Parameters.Add("@Impuesto", SqlDbType.Decimal);
			pImpuesto.Precision = 12; pImpuesto.Scale = 2; pImpuesto.Value = factura.Impuesto;

			SqlParameter pTotal = comando.Parameters.Add("@Total", SqlDbType.Decimal);
			pTotal.Precision = 12; pTotal.Scale = 2; pTotal.Value = factura.Total;

			SqlParameter pSaldo = comando.Parameters.Add("@SaldoPendiente", SqlDbType.Decimal);
			pSaldo.Precision = 12; pSaldo.Scale = 2; pSaldo.Value = factura.SaldoPendiente;

			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = factura.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public Factura? BuscarFactura(int codigoFactura)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Facturas_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoFactura", SqlDbType.Int).Value = codigoFactura;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new Factura
				{
					CodigoFactura = Convert.ToInt32(lector["CodigoFactura"]),
					CodigoPaciente = Convert.ToInt32(lector["CodigoPaciente"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),
					NumeroFactura = lector["NumeroFactura"].ToString() ?? string.Empty,
					NombreFacturacion = lector["NombreFacturacion"].ToString() ?? string.Empty,
					NITFacturacion = lector["NITFacturacion"].ToString() ?? string.Empty,
					DireccionFacturacion = lector["DireccionFacturacion"].ToString() ?? string.Empty,
					Subtotal = Convert.ToDecimal(lector["Subtotal"]),
					Descuento = Convert.ToDecimal(lector["Descuento"]),
					Impuesto = Convert.ToDecimal(lector["Impuesto"]),
					Total = Convert.ToDecimal(lector["Total"]),
					SaldoPendiente = Convert.ToDecimal(lector["SaldoPendiente"]),
					Estado = lector["Estado"].ToString() ?? string.Empty
				};
			}

			return null;
		}

		public bool EditarFactura(Factura factura)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Facturas_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoFactura", SqlDbType.Int).Value = factura.CodigoFactura;
			comando.Parameters.Add("@CodigoPaciente", SqlDbType.Int).Value = factura.CodigoPaciente;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = factura.CodigoSucursal;
			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = factura.CodigoColaborador;
			comando.Parameters.Add("@NumeroFactura", SqlDbType.VarChar, 50).Value = factura.NumeroFactura;
			comando.Parameters.Add("@NombreFacturacion", SqlDbType.VarChar, 150).Value = factura.NombreFacturacion;
			comando.Parameters.Add("@NITFacturacion", SqlDbType.VarChar, 20).Value = factura.NITFacturacion;
			comando.Parameters.Add("@DireccionFacturacion", SqlDbType.VarChar, 200).Value = factura.DireccionFacturacion;

			SqlParameter pSubtotal = comando.Parameters.Add("@Subtotal", SqlDbType.Decimal);
			pSubtotal.Precision = 12; pSubtotal.Scale = 2; pSubtotal.Value = factura.Subtotal;

			SqlParameter pDescuento = comando.Parameters.Add("@Descuento", SqlDbType.Decimal);
			pDescuento.Precision = 12; pDescuento.Scale = 2; pDescuento.Value = factura.Descuento;

			SqlParameter pImpuesto = comando.Parameters.Add("@Impuesto", SqlDbType.Decimal);
			pImpuesto.Precision = 12; pImpuesto.Scale = 2; pImpuesto.Value = factura.Impuesto;

			SqlParameter pTotal = comando.Parameters.Add("@Total", SqlDbType.Decimal);
			pTotal.Precision = 12; pTotal.Scale = 2; pTotal.Value = factura.Total;

			SqlParameter pSaldo = comando.Parameters.Add("@SaldoPendiente", SqlDbType.Decimal);
			pSaldo.Precision = 12; pSaldo.Scale = 2; pSaldo.Value = factura.SaldoPendiente;

			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value = factura.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}

		public bool EliminarFactura(int codigoFactura)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_Facturas_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoFactura", SqlDbType.Int).Value = codigoFactura;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}
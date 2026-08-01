using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class MovimientoInventarioDatos
	{
		public List<MovimientoInventario> ConsultarMovimientosInventario()
		{
			List<MovimientoInventario> lista = new List<MovimientoInventario>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_MovimientosInventario_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				lista.Add(new MovimientoInventario
				{
					CodigoMovimientoInventario = lector["CodigoMovimientoInventario"] == DBNull.Value
	? 0
	: Convert.ToInt32(lector["CodigoMovimientoInventario"]),

					CodigoSucursal = lector["CodigoSucursal"] == DBNull.Value
	? 0
	: Convert.ToInt32(lector["CodigoSucursal"]),

					CodigoProducto = lector["CodigoProducto"] == DBNull.Value
	? 0
	: Convert.ToInt32(lector["CodigoProducto"]),

					CodigoProveedor = lector["CodigoProveedor"] == DBNull.Value
	? 0
	: Convert.ToInt32(lector["CodigoProveedor"]),

					CodigoColaborador = lector["CodigoColaborador"] == DBNull.Value
	? 0
	: Convert.ToInt32(lector["CodigoColaborador"]),

					TipoMovimiento = lector["TipoMovimiento"] == DBNull.Value ? "" : lector["TipoMovimiento"].ToString()!,
					NumeroDocumento = lector["NumeroDocumento"] == DBNull.Value ? "" : lector["NumeroDocumento"].ToString()!,
					Lote = lector["Lote"] == DBNull.Value ? "" : lector["Lote"].ToString()!,

					FechaVencimiento = lector["FechaVencimiento"] == DBNull.Value
						? DateOnly.MinValue
						: DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaVencimiento"])),

					CantidadEntrada = lector["CantidadEntrada"] == DBNull.Value
						? 0
						: Convert.ToDecimal(lector["CantidadEntrada"]),

					CantidadSalida = lector["CantidadSalida"] == DBNull.Value
						? 0
						: Convert.ToDecimal(lector["CantidadSalida"]),

					CostoUnitario = lector["CostoUnitario"] == DBNull.Value
						? 0
						: Convert.ToDecimal(lector["CostoUnitario"]),

					ExistenciaResultante = lector["ExistenciaResultante"] == DBNull.Value
						? 0
						: Convert.ToDecimal(lector["ExistenciaResultante"]),

					MotivoMovimiento = lector["MotivoMovimiento"] == DBNull.Value ? "" : lector["MotivoMovimiento"].ToString()!,
					Observaciones = lector["Observaciones"] == DBNull.Value ? "" : lector["Observaciones"].ToString()!,
					Estado = lector["Estado"] == DBNull.Value ? "" : lector["Estado"].ToString()!
				});
			}

			return lista;
		}


		public MovimientoInventario? BuscarMovimientoInventario(int codigoMovimientoInventario)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_MovimientosInventario_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoMovimientoInventario", SqlDbType.Int).Value = codigoMovimientoInventario;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new MovimientoInventario
				{
					CodigoMovimientoInventario = Convert.ToInt32(lector["CodigoMovimientoInventario"]),
					CodigoSucursal = Convert.ToInt32(lector["CodigoSucursal"]),
					CodigoProducto = Convert.ToInt32(lector["CodigoProducto"]),
					CodigoProveedor = Convert.ToInt32(lector["CodigoProveedor"]),
					CodigoColaborador = Convert.ToInt32(lector["CodigoColaborador"]),

					TipoMovimiento = lector["TipoMovimiento"] == DBNull.Value ? "" : lector["TipoMovimiento"].ToString()!,
					NumeroDocumento = lector["NumeroDocumento"] == DBNull.Value ? "" : lector["NumeroDocumento"].ToString()!,
					Lote = lector["Lote"] == DBNull.Value ? "" : lector["Lote"].ToString()!,

					FechaVencimiento = lector["FechaVencimiento"] == DBNull.Value
						? DateOnly.MinValue
						: DateOnly.FromDateTime(Convert.ToDateTime(lector["FechaVencimiento"])),

					CantidadEntrada = lector["CantidadEntrada"] == DBNull.Value
						? 0
						: Convert.ToDecimal(lector["CantidadEntrada"]),

					CantidadSalida = lector["CantidadSalida"] == DBNull.Value
						? 0
						: Convert.ToDecimal(lector["CantidadSalida"]),

					CostoUnitario = lector["CostoUnitario"] == DBNull.Value
						? 0
						: Convert.ToDecimal(lector["CostoUnitario"]),

					ExistenciaResultante = lector["ExistenciaResultante"] == DBNull.Value
						? 0
						: Convert.ToDecimal(lector["ExistenciaResultante"]),

					MotivoMovimiento = lector["MotivoMovimiento"] == DBNull.Value ? "" : lector["MotivoMovimiento"].ToString()!,
					Observaciones = lector["Observaciones"] == DBNull.Value ? "" : lector["Observaciones"].ToString()!,
					Estado = lector["Estado"] == DBNull.Value ? "" : lector["Estado"].ToString()!
				};
			}

			return null;
		}


		public bool AgregarMovimientoInventario(MovimientoInventario movimiento)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_MovimientosInventario_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = movimiento.CodigoSucursal;
			comando.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = movimiento.CodigoProducto;
			comando.Parameters.Add("@CodigoProveedor", SqlDbType.Int).Value = movimiento.CodigoProveedor;
			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = movimiento.CodigoColaborador;
			comando.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar, 40).Value = movimiento.TipoMovimiento;
			comando.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 50).Value = movimiento.NumeroDocumento;
			comando.Parameters.Add("@Lote", SqlDbType.VarChar, 50).Value = movimiento.Lote;
			comando.Parameters.Add("@FechaVencimiento", SqlDbType.Date).Value = movimiento.FechaVencimiento;

			SqlParameter pEntrada = comando.Parameters.Add("@CantidadEntrada", SqlDbType.Decimal);
			pEntrada.Precision = 12;
			pEntrada.Scale = 2;
			pEntrada.Value = movimiento.CantidadEntrada;

			SqlParameter pSalida = comando.Parameters.Add("@CantidadSalida", SqlDbType.Decimal);
			pSalida.Precision = 12;
			pSalida.Scale = 2;
			pSalida.Value = movimiento.CantidadSalida;

			SqlParameter pCosto = comando.Parameters.Add("@CostoUnitario", SqlDbType.Decimal);
			pCosto.Precision = 12;
			pCosto.Scale = 2;
			pCosto.Value = movimiento.CostoUnitario;

			SqlParameter pExistencia = comando.Parameters.Add("@ExistenciaResultante", SqlDbType.Decimal);
			pExistencia.Precision = 12;
			pExistencia.Scale = 2;
			pExistencia.Value = movimiento.ExistenciaResultante;

			comando.Parameters.Add("@MotivoMovimiento", SqlDbType.VarChar, 250).Value = movimiento.MotivoMovimiento;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 500).Value = movimiento.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = movimiento.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}


		public bool EditarMovimientoInventario(MovimientoInventario movimiento)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_MovimientosInventario_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoMovimientoInventario", SqlDbType.Int).Value = movimiento.CodigoMovimientoInventario;
			comando.Parameters.Add("@CodigoSucursal", SqlDbType.Int).Value = movimiento.CodigoSucursal;
			comando.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = movimiento.CodigoProducto;
			comando.Parameters.Add("@CodigoProveedor", SqlDbType.Int).Value = movimiento.CodigoProveedor;
			comando.Parameters.Add("@CodigoColaborador", SqlDbType.Int).Value = movimiento.CodigoColaborador;
			comando.Parameters.Add("@TipoMovimiento", SqlDbType.VarChar, 40).Value = movimiento.TipoMovimiento;
			comando.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 50).Value = movimiento.NumeroDocumento;
			comando.Parameters.Add("@Lote", SqlDbType.VarChar, 50).Value = movimiento.Lote;
			comando.Parameters.Add("@FechaVencimiento", SqlDbType.Date).Value = movimiento.FechaVencimiento;

			SqlParameter pEntrada = comando.Parameters.Add("@CantidadEntrada", SqlDbType.Decimal);
			pEntrada.Precision = 12;
			pEntrada.Scale = 2;
			pEntrada.Value = movimiento.CantidadEntrada;

			SqlParameter pSalida = comando.Parameters.Add("@CantidadSalida", SqlDbType.Decimal);
			pSalida.Precision = 12;
			pSalida.Scale = 2;
			pSalida.Value = movimiento.CantidadSalida;

			SqlParameter pCosto = comando.Parameters.Add("@CostoUnitario", SqlDbType.Decimal);
			pCosto.Precision = 12;
			pCosto.Scale = 2;
			pCosto.Value = movimiento.CostoUnitario;

			SqlParameter pExistencia = comando.Parameters.Add("@ExistenciaResultante", SqlDbType.Decimal);
			pExistencia.Precision = 12;
			pExistencia.Scale = 2;
			pExistencia.Value = movimiento.ExistenciaResultante;

			comando.Parameters.Add("@MotivoMovimiento", SqlDbType.VarChar, 250).Value = movimiento.MotivoMovimiento;
			comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 500).Value = movimiento.Observaciones;
			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = movimiento.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}


		public bool EliminarMovimientoInventario(int codigoMovimientoInventario)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_MovimientosInventario_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoMovimientoInventario", SqlDbType.Int).Value = codigoMovimientoInventario;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}
using Microsoft.Data.SqlClient;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Utilidades.Configuracion;
using System.Data;

namespace SanatorioMedico.Datos.Datos
{
	public class CitaConsultaDetalleDatos
	{
		public List<CitaConsultaDetalle> ConsultarCitasConsultasDetalle()
		{
			List<CitaConsultaDetalle> lista = new List<CitaConsultaDetalle>();

			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_CitasConsultasDetalle_Consultar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			while (lector.Read())
			{
				lista.Add(new CitaConsultaDetalle
				{
					CodigoDetalle = lector["CodigoDetalle"] == DBNull.Value ? 0 : Convert.ToInt32(lector["CodigoDetalle"]),
					CodigoCitaConsulta = lector["CodigoCitaConsulta"] == DBNull.Value ? 0 : Convert.ToInt32(lector["CodigoCitaConsulta"]),
					CodigoProducto = lector["CodigoProducto"] == DBNull.Value ? 0 : Convert.ToInt32(lector["CodigoProducto"]),

					TipoDetalle = lector["TipoDetalle"] == DBNull.Value ? string.Empty : lector["TipoDetalle"].ToString()!,
					SubtipoDetalle = lector["SubtipoDetalle"] == DBNull.Value ? string.Empty : lector["SubtipoDetalle"].ToString()!,
					DescripcionDetalle = lector["DescripcionDetalle"] == DBNull.Value ? string.Empty : lector["DescripcionDetalle"].ToString()!,
					Dosis = lector["Dosis"] == DBNull.Value ? string.Empty : lector["Dosis"].ToString()!,
					Frecuencia = lector["Frecuencia"] == DBNull.Value ? string.Empty : lector["Frecuencia"].ToString()!,
					Duracion = lector["Duracion"] == DBNull.Value ? string.Empty : lector["Duracion"].ToString()!,
					Indicaciones = lector["Indicaciones"] == DBNull.Value ? string.Empty : lector["Indicaciones"].ToString()!,
					Resultado = lector["Resultado"] == DBNull.Value ? string.Empty : lector["Resultado"].ToString()!,

					Cantidad = lector["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(lector["Cantidad"]),

					Estado = lector["Estado"] == DBNull.Value ? string.Empty : lector["Estado"].ToString()!
				});
			}

			return lista;
		}


		public bool AgregarCitaConsultaDetalle(CitaConsultaDetalle detalle)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_CitasConsultasDetalle_Agregar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoCitaConsulta", SqlDbType.Int).Value = detalle.CodigoCitaConsulta;
			comando.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = detalle.CodigoProducto;
			comando.Parameters.Add("@TipoDetalle", SqlDbType.VarChar, 40).Value = detalle.TipoDetalle;
			comando.Parameters.Add("@SubtipoDetalle", SqlDbType.VarChar, 100).Value = detalle.SubtipoDetalle;
			comando.Parameters.Add("@DescripcionDetalle", SqlDbType.VarChar, 1000).Value = detalle.DescripcionDetalle;
			comando.Parameters.Add("@Dosis", SqlDbType.VarChar, 100).Value = detalle.Dosis;
			comando.Parameters.Add("@Frecuencia", SqlDbType.VarChar, 100).Value = detalle.Frecuencia;
			comando.Parameters.Add("@Duracion", SqlDbType.VarChar, 100).Value = detalle.Duracion;
			comando.Parameters.Add("@Indicaciones", SqlDbType.VarChar, 500).Value = detalle.Indicaciones;
			comando.Parameters.Add("@Resultado", SqlDbType.VarChar, 1000).Value = detalle.Resultado;

			SqlParameter paramCantidad = comando.Parameters.Add("@Cantidad", SqlDbType.Decimal);
			paramCantidad.Precision = 12;
			paramCantidad.Scale = 2;
			paramCantidad.Value = detalle.Cantidad;

			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = detalle.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}


		public CitaConsultaDetalle? BuscarCitaConsultaDetalle(int codigoDetalle)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_CitasConsultasDetalle_Buscar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoDetalle", SqlDbType.Int).Value = codigoDetalle;

			conexion.Open();
			using SqlDataReader lector = comando.ExecuteReader();

			if (lector.Read())
			{
				return new CitaConsultaDetalle
				{
					CodigoDetalle = lector["CodigoDetalle"] == DBNull.Value ? 0 : Convert.ToInt32(lector["CodigoDetalle"]),
					CodigoCitaConsulta = lector["CodigoCitaConsulta"] == DBNull.Value ? 0 : Convert.ToInt32(lector["CodigoCitaConsulta"]),
					CodigoProducto = lector["CodigoProducto"] == DBNull.Value ? 0 : Convert.ToInt32(lector["CodigoProducto"]),

					TipoDetalle = lector["TipoDetalle"] == DBNull.Value ? string.Empty : lector["TipoDetalle"].ToString()!,
					SubtipoDetalle = lector["SubtipoDetalle"] == DBNull.Value ? string.Empty : lector["SubtipoDetalle"].ToString()!,
					DescripcionDetalle = lector["DescripcionDetalle"] == DBNull.Value ? string.Empty : lector["DescripcionDetalle"].ToString()!,
					Dosis = lector["Dosis"] == DBNull.Value ? string.Empty : lector["Dosis"].ToString()!,
					Frecuencia = lector["Frecuencia"] == DBNull.Value ? string.Empty : lector["Frecuencia"].ToString()!,
					Duracion = lector["Duracion"] == DBNull.Value ? string.Empty : lector["Duracion"].ToString()!,
					Indicaciones = lector["Indicaciones"] == DBNull.Value ? string.Empty : lector["Indicaciones"].ToString()!,
					Resultado = lector["Resultado"] == DBNull.Value ? string.Empty : lector["Resultado"].ToString()!,

					Cantidad = lector["Cantidad"] == DBNull.Value ? 0 : Convert.ToDecimal(lector["Cantidad"]),

					Estado = lector["Estado"] == DBNull.Value ? string.Empty : lector["Estado"].ToString()!
				};
			}

			return null;
		}


		public bool EditarCitaConsultaDetalle(CitaConsultaDetalle detalle)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_CitasConsultasDetalle_Editar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoDetalle", SqlDbType.Int).Value = detalle.CodigoDetalle;
			comando.Parameters.Add("@CodigoCitaConsulta", SqlDbType.Int).Value = detalle.CodigoCitaConsulta;
			comando.Parameters.Add("@CodigoProducto", SqlDbType.Int).Value = detalle.CodigoProducto;
			comando.Parameters.Add("@TipoDetalle", SqlDbType.VarChar, 40).Value = detalle.TipoDetalle;
			comando.Parameters.Add("@SubtipoDetalle", SqlDbType.VarChar, 100).Value = detalle.SubtipoDetalle;
			comando.Parameters.Add("@DescripcionDetalle", SqlDbType.VarChar, 1000).Value = detalle.DescripcionDetalle;
			comando.Parameters.Add("@Dosis", SqlDbType.VarChar, 100).Value = detalle.Dosis;
			comando.Parameters.Add("@Frecuencia", SqlDbType.VarChar, 100).Value = detalle.Frecuencia;
			comando.Parameters.Add("@Duracion", SqlDbType.VarChar, 100).Value = detalle.Duracion;
			comando.Parameters.Add("@Indicaciones", SqlDbType.VarChar, 500).Value = detalle.Indicaciones;
			comando.Parameters.Add("@Resultado", SqlDbType.VarChar, 1000).Value = detalle.Resultado;

			SqlParameter paramCantidad = comando.Parameters.Add("@Cantidad", SqlDbType.Decimal);
			paramCantidad.Precision = 12;
			paramCantidad.Scale = 2;
			paramCantidad.Value = detalle.Cantidad;

			comando.Parameters.Add("@Estado", SqlDbType.VarChar, 20).Value = detalle.Estado;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}


		public bool EliminarCitaConsultaDetalle(int codigoDetalle)
		{
			using SqlConnection conexion = new SqlConnection(ConexionSQL.CadenaConexion);
			using SqlCommand comando = new SqlCommand("Usp_CitasConsultasDetalle_Eliminar", conexion);
			comando.CommandType = CommandType.StoredProcedure;

			comando.Parameters.Add("@CodigoDetalle", SqlDbType.Int).Value = codigoDetalle;

			conexion.Open();
			comando.ExecuteNonQuery();

			return true;
		}
	}
}
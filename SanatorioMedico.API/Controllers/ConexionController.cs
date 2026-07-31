using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SanatorioMedico.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ConexionController : ControllerBase
	{
		private readonly IConfiguration configuracion;

		public ConexionController(IConfiguration configuracion)
		{
			this.configuracion = configuracion;
		}

		[HttpGet("probar")]
		public IActionResult ProbarConexion()
		{
			try
			{
				string cadenaConexion =
					configuracion.GetConnectionString("ConexionSQL")
					?? throw new Exception(
						"No se encontró la cadena de conexión."
					);

				using SqlConnection conexion =
					new SqlConnection(cadenaConexion);

				conexion.Open();

				using SqlCommand comando =
					new SqlCommand("SELECT DB_NAME()", conexion);

				string baseDatos =
					comando.ExecuteScalar()?.ToString()
					?? "No identificada";

				return Ok(new
				{
					exito = true,
					mensaje = "Conexión realizada correctamente.",
					baseDatos
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					exito = false,
					mensaje = "No fue posible conectar con SQL Server.",
					error = ex.Message
				});
			}
		}
	}
}


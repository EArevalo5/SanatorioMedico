using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColaboradoresController : ControllerBase
	{
		private readonly ColaboradorNegocio colaboradorNegocio;

		public ColaboradoresController()
		{
			colaboradorNegocio = new ColaboradorNegocio();
		}

		[HttpGet("ConsultarColaboradores")]
		public ActionResult<RespuestaApi<List<ColaboradorConsultaDTO>>> ConsultarColaboradores()
		{
			try
			{
				List<Colaborador> colaboradores = colaboradorNegocio.ConsultarColaboradores();

				List<ColaboradorConsultaDTO> colaboradoresConsulta = colaboradores.Select(c => new ColaboradorConsultaDTO
				{
					CodigoColaborador = c.CodigoColaborador,
					CodigoSucursal = c.CodigoSucursal,
					CodigoRol = c.CodigoRol,
					Nombres = c.Nombres,
					Apellidos = c.Apellidos,
					DPI = c.DPI,
					NumeroColegiado = c.NumeroColegiado,
					TipoColaborador = c.TipoColaborador,
					Telefono = c.Telefono,
					CorreoElectronico = c.CorreoElectronico,
					Direccion = c.Direccion,
					FechaContratacion = c.FechaContratacion,
					NombreUsuario = c.NombreUsuario,
					Estado = c.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<ColaboradorConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Colaboradores consultados correctamente.",
					Datos = colaboradoresConsulta,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<ColaboradorConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar los colaboradores.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarColaborador")]
		public ActionResult<RespuestaApi<bool>> AgregarColaborador([FromBody] ColaboradorAgregarDTO dto)
		{
			try
			{
				Colaborador colaborador = new Colaborador
				{
					CodigoSucursal = dto.CodigoSucursal,
					CodigoRol = dto.CodigoRol,
					Nombres = dto.Nombres,
					Apellidos = dto.Apellidos,
					DPI = dto.DPI,
					NumeroColegiado = dto.NumeroColegiado,
					TipoColaborador = dto.TipoColaborador,
					Telefono = dto.Telefono,
					CorreoElectronico = dto.CorreoElectronico,
					Direccion = dto.Direccion,
					FechaContratacion = dto.FechaContratacion,
					NombreUsuario = dto.NombreUsuario,
					ClaveAcceso = dto.ClaveAcceso,
					Estado = dto.Estado
				};

				bool resultado = colaboradorNegocio.AgregarColaborador(colaborador);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Colaborador agregado correctamente." : "No fue posible agregar el colaborador.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar el colaborador.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarColaborador/{codigoColaborador:int}")]
		public ActionResult<RespuestaApi<ColaboradorConsultaDTO>> BuscarColaborador(int codigoColaborador)
		{
			try
			{
				Colaborador? colaborador = colaboradorNegocio.BuscarColaborador(codigoColaborador);

				if (colaborador == null)
				{
					return NotFound(new RespuestaApi<ColaboradorConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró el colaborador solicitado.",
						Datos = null,
						Detalle = null
					});
				}

				ColaboradorConsultaDTO dto = new ColaboradorConsultaDTO
				{
					CodigoColaborador = colaborador.CodigoColaborador,
					CodigoSucursal = colaborador.CodigoSucursal,
					CodigoRol = colaborador.CodigoRol,
					Nombres = colaborador.Nombres,
					Apellidos = colaborador.Apellidos,
					DPI = colaborador.DPI,
					NumeroColegiado = colaborador.NumeroColegiado,
					TipoColaborador = colaborador.TipoColaborador,
					Telefono = colaborador.Telefono,
					CorreoElectronico = colaborador.CorreoElectronico,
					Direccion = colaborador.Direccion,
					FechaContratacion = colaborador.FechaContratacion,
					NombreUsuario = colaborador.NombreUsuario,
					Estado = colaborador.Estado
				};

				return Ok(new RespuestaApi<ColaboradorConsultaDTO>
				{
					Exito = true,
					Mensaje = "Colaborador encontrado correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<ColaboradorConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar el colaborador.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarColaborador")]
		public ActionResult<RespuestaApi<bool>> EditarColaborador([FromBody] ColaboradorEditarDTO dto)
		{
			try
			{
				Colaborador colaborador = new Colaborador
				{
					CodigoColaborador = dto.CodigoColaborador,
					CodigoSucursal = dto.CodigoSucursal,
					CodigoRol = dto.CodigoRol,
					Nombres = dto.Nombres,
					Apellidos = dto.Apellidos,
					DPI = dto.DPI,
					NumeroColegiado = dto.NumeroColegiado,
					TipoColaborador = dto.TipoColaborador,
					Telefono = dto.Telefono,
					CorreoElectronico = dto.CorreoElectronico,
					Direccion = dto.Direccion,
					FechaContratacion = dto.FechaContratacion,
					NombreUsuario = dto.NombreUsuario,
					ClaveAcceso = dto.ClaveAcceso,
					Estado = dto.Estado
				};

				bool resultado = colaboradorNegocio.EditarColaborador(colaborador);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Colaborador editado correctamente." : "No fue posible editar el colaborador.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar el colaborador.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarColaborador/{codigoColaborador:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarColaborador(int codigoColaborador)
		{
			try
			{
				bool resultado = colaboradorNegocio.EliminarColaborador(codigoColaborador);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Colaborador eliminado correctamente." : "No fue posible eliminar el colaborador.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar el colaborador.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}
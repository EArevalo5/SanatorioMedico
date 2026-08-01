using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColaboradoresEspecialidadesController : ControllerBase
	{
		private readonly ColaboradorEspecialidadNegocio negocio;

		public ColaboradoresEspecialidadesController()
		{
			negocio = new ColaboradorEspecialidadNegocio();
		}

		[HttpGet("ConsultarColaboradoresEspecialidades")]
		public ActionResult<RespuestaApi<List<ColaboradorEspecialidadConsultaDTO>>> ConsultarColaboradoresEspecialidades()
		{
			try
			{
				List<ColaboradorEspecialidad> lista = negocio.ConsultarColaboradoresEspecialidades();

				List<ColaboradorEspecialidadConsultaDTO> dtos = lista.Select(item => new ColaboradorEspecialidadConsultaDTO
				{
					CodigoColaboradorEspecialidad = item.CodigoColaboradorEspecialidad,
					CodigoColaborador = item.CodigoColaborador,
					CodigoEspecialidad = item.CodigoEspecialidad,
					FechaAsignacion = item.FechaAsignacion,
					NumeroAutorizacion = item.NumeroAutorizacion,
					InstitucionAcreditadora = item.InstitucionAcreditadora,
					FechaVencimiento = item.FechaVencimiento,
					Observaciones = item.Observaciones,
					Estado = item.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<ColaboradorEspecialidadConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Asignaciones de especialidades consultadas correctamente.",
					Datos = dtos,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<ColaboradorEspecialidadConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar las especialidades de colaboradores.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarColaboradorEspecialidad")]
		public ActionResult<RespuestaApi<bool>> AgregarColaboradorEspecialidad([FromBody] ColaboradorEspecialidadAgregarDTO dto)
		{
			try
			{
				ColaboradorEspecialidad entidad = new ColaboradorEspecialidad
				{
					CodigoColaborador = dto.CodigoColaborador,
					CodigoEspecialidad = dto.CodigoEspecialidad,
					FechaAsignacion = dto.FechaAsignacion,
					NumeroAutorizacion = dto.NumeroAutorizacion,
					InstitucionAcreditadora = dto.InstitucionAcreditadora,
					FechaVencimiento = dto.FechaVencimiento,
					Observaciones = dto.Observaciones,
					Estado = dto.Estado
				};

				bool resultado = negocio.AgregarColaboradorEspecialidad(entidad);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Asignación agregada correctamente." : "No fue posible agregar la asignación.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar la asignación de especialidad.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarColaboradorEspecialidad/{codigoColaboradorEspecialidad:int}")]
		public ActionResult<RespuestaApi<ColaboradorEspecialidadConsultaDTO>> BuscarColaboradorEspecialidad(int codigoColaboradorEspecialidad)
		{
			try
			{
				ColaboradorEspecialidad? entidad = negocio.BuscarColaboradorEspecialidad(codigoColaboradorEspecialidad);

				if (entidad == null)
				{
					return NotFound(new RespuestaApi<ColaboradorEspecialidadConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró la asignación solicitada.",
						Datos = null,
						Detalle = null
					});
				}

				ColaboradorEspecialidadConsultaDTO dto = new ColaboradorEspecialidadConsultaDTO
				{
					CodigoColaboradorEspecialidad = entidad.CodigoColaboradorEspecialidad,
					CodigoColaborador = entidad.CodigoColaborador,
					CodigoEspecialidad = entidad.CodigoEspecialidad,
					FechaAsignacion = entidad.FechaAsignacion,
					NumeroAutorizacion = entidad.NumeroAutorizacion,
					InstitucionAcreditadora = entidad.InstitucionAcreditadora,
					FechaVencimiento = entidad.FechaVencimiento,
					Observaciones = entidad.Observaciones,
					Estado = entidad.Estado
				};

				return Ok(new RespuestaApi<ColaboradorEspecialidadConsultaDTO>
				{
					Exito = true,
					Mensaje = "Asignación encontrada correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<ColaboradorEspecialidadConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar la asignación.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarColaboradorEspecialidad")]
		public ActionResult<RespuestaApi<bool>> EditarColaboradorEspecialidad([FromBody] ColaboradorEspecialidadEditarDTO dto)
		{
			try
			{
				ColaboradorEspecialidad entidad = new ColaboradorEspecialidad
				{
					CodigoColaboradorEspecialidad = dto.CodigoColaboradorEspecialidad,
					CodigoColaborador = dto.CodigoColaborador,
					CodigoEspecialidad = dto.CodigoEspecialidad,
					FechaAsignacion = dto.FechaAsignacion,
					NumeroAutorizacion = dto.NumeroAutorizacion,
					InstitucionAcreditadora = dto.InstitucionAcreditadora,
					FechaVencimiento = dto.FechaVencimiento,
					Observaciones = dto.Observaciones,
					Estado = dto.Estado
				};

				bool resultado = negocio.EditarColaboradorEspecialidad(entidad);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Asignación editada correctamente." : "No fue posible editar la asignación.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar la asignación de especialidad.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarColaboradorEspecialidad/{codigoColaboradorEspecialidad:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarColaboradorEspecialidad(int codigoColaboradorEspecialidad)
		{
			try
			{
				bool resultado = negocio.EliminarColaboradorEspecialidad(codigoColaboradorEspecialidad);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Asignación eliminada correctamente." : "No fue posible eliminar la asignación.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar la asignación de especialidad.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}
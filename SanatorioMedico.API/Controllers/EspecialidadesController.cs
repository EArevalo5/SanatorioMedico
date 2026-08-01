using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EspecialidadesController : ControllerBase
	{
		private readonly EspecialidadNegocio especialidadNegocio;

		public EspecialidadesController()
		{
			especialidadNegocio = new EspecialidadNegocio();
		}

		[HttpGet("ConsultarEspecialidades")]
		public ActionResult<RespuestaApi<List<EspecialidadConsultaDTO>>> ConsultarEspecialidades()
		{
			try
			{
				List<Especialidad> especialidades = especialidadNegocio.ConsultarEspecialidades();

				List<EspecialidadConsultaDTO> especialidadesConsulta = especialidades.Select(e => new EspecialidadConsultaDTO
				{
					CodigoEspecialidad = e.CodigoEspecialidad,
					NombreEspecialidad = e.NombreEspecialidad,
					Descripcion = e.Descripcion,
					AreaMedica = e.AreaMedica,
					DuracionConsulta = e.DuracionConsulta,
					CostoConsulta = e.CostoConsulta,
					RequiereCita = e.RequiereCita,
					Observaciones = e.Observaciones,
					Estado = e.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<EspecialidadConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Especialidades consultadas correctamente.",
					Datos = especialidadesConsulta,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<EspecialidadConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar las especialidades.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarEspecialidad")]
		public ActionResult<RespuestaApi<bool>> AgregarEspecialidad([FromBody] EspecialidadAgregarDTO dto)
		{
			try
			{
				Especialidad especialidad = new Especialidad
				{
					NombreEspecialidad = dto.NombreEspecialidad,
					Descripcion = dto.Descripcion,
					AreaMedica = dto.AreaMedica,
					DuracionConsulta = dto.DuracionConsulta,
					CostoConsulta = dto.CostoConsulta,
					RequiereCita = dto.RequiereCita,
					Observaciones = dto.Observaciones,
					Estado = dto.Estado
				};

				bool resultado = especialidadNegocio.AgregarEspecialidad(especialidad);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Especialidad agregada correctamente." : "No fue posible agregar la especialidad.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar la especialidad.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarEspecialidad/{codigoEspecialidad:int}")]
		public ActionResult<RespuestaApi<EspecialidadConsultaDTO>> BuscarEspecialidad(int codigoEspecialidad)
		{
			try
			{
				Especialidad? especialidad = especialidadNegocio.BuscarEspecialidad(codigoEspecialidad);

				if (especialidad == null)
				{
					return NotFound(new RespuestaApi<EspecialidadConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró la especialidad solicitada.",
						Datos = null,
						Detalle = null
					});
				}

				EspecialidadConsultaDTO dto = new EspecialidadConsultaDTO
				{
					CodigoEspecialidad = especialidad.CodigoEspecialidad,
					NombreEspecialidad = especialidad.NombreEspecialidad,
					Descripcion = especialidad.Descripcion,
					AreaMedica = especialidad.AreaMedica,
					DuracionConsulta = especialidad.DuracionConsulta,
					CostoConsulta = especialidad.CostoConsulta,
					RequiereCita = especialidad.RequiereCita,
					Observaciones = especialidad.Observaciones,
					Estado = especialidad.Estado
				};

				return Ok(new RespuestaApi<EspecialidadConsultaDTO>
				{
					Exito = true,
					Mensaje = "Especialidad encontrada correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<EspecialidadConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar la especialidad.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarEspecialidad")]
		public ActionResult<RespuestaApi<bool>> EditarEspecialidad([FromBody] EspecialidadEditarDTO dto)
		{
			try
			{
				Especialidad especialidad = new Especialidad
				{
					CodigoEspecialidad = dto.CodigoEspecialidad,
					NombreEspecialidad = dto.NombreEspecialidad,
					Descripcion = dto.Descripcion,
					AreaMedica = dto.AreaMedica,
					DuracionConsulta = dto.DuracionConsulta,
					CostoConsulta = dto.CostoConsulta,
					RequiereCita = dto.RequiereCita,
					Observaciones = dto.Observaciones,
					Estado = dto.Estado
				};

				bool resultado = especialidadNegocio.EditarEspecialidad(especialidad);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Especialidad editada correctamente." : "No fue posible editar la especialidad.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar la especialidad.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarEspecialidad/{codigoEspecialidad:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarEspecialidad(int codigoEspecialidad)
		{
			try
			{
				bool resultado = especialidadNegocio.EliminarEspecialidad(codigoEspecialidad);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Especialidad eliminada correctamente." : "No fue posible eliminar la especialidad.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar la especialidad.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}
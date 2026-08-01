using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HorariosController : ControllerBase
	{
		private readonly HorarioNegocio horarioNegocio;

		public HorariosController()
		{
			horarioNegocio = new HorarioNegocio();
		}

		[HttpGet("ConsultarHorarios")]
		public ActionResult<RespuestaApi<List<HorarioConsultaDTO>>> ConsultarHorarios()
		{
			try
			{
				List<Horario> horarios = horarioNegocio.ConsultarHorarios();

				List<HorarioConsultaDTO> horariosConsulta = horarios.Select(h => new HorarioConsultaDTO
				{
					CodigoHorario = h.CodigoHorario,
					CodigoColaborador = h.CodigoColaborador,
					CodigoSucursal = h.CodigoSucursal,
					CodigoEspecialidad = h.CodigoEspecialidad,
					DiaSemana = h.DiaSemana,
					HoraInicio = h.HoraInicio,
					HoraFin = h.HoraFin,
					DuracionCitaMinutos = h.DuracionCitaMinutos,
					Jornada = h.Jornada,
					Observaciones = h.Observaciones,
					Estado = h.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<HorarioConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Horarios consultados correctamente.",
					Datos = horariosConsulta,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<HorarioConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar los horarios.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarHorario")]
		public ActionResult<RespuestaApi<bool>> AgregarHorario([FromBody] HorarioAgregarDTO dto)
		{
			try
			{
				Horario horario = new Horario
				{
					CodigoColaborador = dto.CodigoColaborador,
					CodigoSucursal = dto.CodigoSucursal,
					CodigoEspecialidad = dto.CodigoEspecialidad,
					DiaSemana = dto.DiaSemana,
					HoraInicio = dto.HoraInicio,
					HoraFin = dto.HoraFin,
					DuracionCitaMinutos = dto.DuracionCitaMinutos,
					Jornada = dto.Jornada,
					Observaciones = dto.Observaciones,
					Estado = dto.Estado
				};

				bool resultado = horarioNegocio.AgregarHorario(horario);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Horario agregado correctamente." : "No fue posible agregar el horario.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar el horario.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarHorario/{codigoHorario:int}")]
		public ActionResult<RespuestaApi<HorarioConsultaDTO>> BuscarHorario(int codigoHorario)
		{
			try
			{
				Horario? horario = horarioNegocio.BuscarHorario(codigoHorario);

				if (horario == null)
				{
					return NotFound(new RespuestaApi<HorarioConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró el horario solicitado.",
						Datos = null,
						Detalle = null
					});
				}

				HorarioConsultaDTO dto = new HorarioConsultaDTO
				{
					CodigoHorario = horario.CodigoHorario,
					CodigoColaborador = horario.CodigoColaborador,
					CodigoSucursal = horario.CodigoSucursal,
					CodigoEspecialidad = horario.CodigoEspecialidad,
					DiaSemana = horario.DiaSemana,
					HoraInicio = horario.HoraInicio,
					HoraFin = horario.HoraFin,
					DuracionCitaMinutos = horario.DuracionCitaMinutos,
					Jornada = horario.Jornada,
					Observaciones = horario.Observaciones,
					Estado = horario.Estado
				};

				return Ok(new RespuestaApi<HorarioConsultaDTO>
				{
					Exito = true,
					Mensaje = "Horario encontrado correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<HorarioConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar el horario.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarHorario")]
		public ActionResult<RespuestaApi<bool>> EditarHorario([FromBody] HorarioEditarDTO dto)
		{
			try
			{
				Horario horario = new Horario
				{
					CodigoHorario = dto.CodigoHorario,
					CodigoColaborador = dto.CodigoColaborador,
					CodigoSucursal = dto.CodigoSucursal,
					CodigoEspecialidad = dto.CodigoEspecialidad,
					DiaSemana = dto.DiaSemana,
					HoraInicio = dto.HoraInicio,
					HoraFin = dto.HoraFin,
					DuracionCitaMinutos = dto.DuracionCitaMinutos,
					Jornada = dto.Jornada,
					Observaciones = dto.Observaciones,
					Estado = dto.Estado
				};

				bool resultado = horarioNegocio.EditarHorario(horario);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Horario editado correctamente." : "No fue posible editar el horario.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar el horario.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarHorario/{codigoHorario:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarHorario(int codigoHorario)
		{
			try
			{
				bool resultado = horarioNegocio.EliminarHorario(codigoHorario);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Horario eliminado correctamente." : "No fue posible eliminar el horario.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar el horario.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}
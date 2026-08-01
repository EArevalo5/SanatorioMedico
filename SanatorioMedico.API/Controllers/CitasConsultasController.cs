using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CitasConsultasController : ControllerBase
	{
		private readonly CitaConsultaNegocio citaConsultaNegocio;

		public CitasConsultasController()
		{
			citaConsultaNegocio = new CitaConsultaNegocio();
		}

		[HttpGet("ConsultarCitasConsultas")]
		public ActionResult<RespuestaApi<List<CitaConsultaConsultaDTO>>> ConsultarCitasConsultas()
		{
			try
			{
				List<CitaConsulta> lista = citaConsultaNegocio.ConsultarCitasConsultas();

				List<CitaConsultaConsultaDTO> dtos = lista.Select(c => new CitaConsultaConsultaDTO
				{
					CodigoCitaConsulta = c.CodigoCitaConsulta,
					CodigoPaciente = c.CodigoPaciente,
					CodigoColaborador = c.CodigoColaborador,
					CodigoSucursal = c.CodigoSucursal,
					CodigoEspecialidad = c.CodigoEspecialidad,
					FechaHoraCita = c.FechaHoraCita,
					TipoAtencion = c.TipoAtencion,
					MotivoConsulta = c.MotivoConsulta,
					Sintomas = c.Sintomas,
					ObservacionesMedicas = c.ObservacionesMedicas,
					TratamientoGeneral = c.TratamientoGeneral,
					PresionArterial = c.PresionArterial,
					Temperatura = c.Temperatura,
					Peso = c.Peso,
					Estado = c.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<CitaConsultaConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Citas/Consultas consultadas correctamente.",
					Datos = dtos,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<CitaConsultaConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar las citas/consultas.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}


		[HttpPost("AgregarCitaConsulta")]
		public ActionResult<RespuestaApi<bool>> AgregarCitaConsulta([FromBody] CitaConsultaAgregarDTO dto)
		{
			try
			{
				CitaConsulta cita = new CitaConsulta
				{
					CodigoPaciente = dto.CodigoPaciente,
					CodigoColaborador = dto.CodigoColaborador,
					CodigoSucursal = dto.CodigoSucursal,
					CodigoEspecialidad = dto.CodigoEspecialidad,
					FechaHoraCita = dto.FechaHoraCita,
					TipoAtencion = dto.TipoAtencion,
					MotivoConsulta = dto.MotivoConsulta,
					Sintomas = dto.Sintomas,
					ObservacionesMedicas = dto.ObservacionesMedicas,
					TratamientoGeneral = dto.TratamientoGeneral,
					PresionArterial = dto.PresionArterial,
					Temperatura = dto.Temperatura,
					Peso = dto.Peso,
					Estado = dto.Estado
				};

				bool resultado = citaConsultaNegocio.AgregarCitaConsulta(cita);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Cita/Consulta agregada correctamente." : "No fue posible agregar la cita/consulta.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar la cita/consulta.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}


		[HttpGet("BuscarCitaConsulta/{codigoCitaConsulta:int}")]
		public ActionResult<RespuestaApi<CitaConsultaConsultaDTO>> BuscarCitaConsulta(int codigoCitaConsulta)
		{
			try
			{
				CitaConsulta? cita = citaConsultaNegocio.BuscarCitaConsulta(codigoCitaConsulta);

				if (cita == null)
				{
					return NotFound(new RespuestaApi<CitaConsultaConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró la cita/consulta solicitada.",
						Datos = null,
						Detalle = null
					});
				}

				CitaConsultaConsultaDTO dto = new CitaConsultaConsultaDTO
				{
					CodigoCitaConsulta = cita.CodigoCitaConsulta,
					CodigoPaciente = cita.CodigoPaciente,
					CodigoColaborador = cita.CodigoColaborador,
					CodigoSucursal = cita.CodigoSucursal,
					CodigoEspecialidad = cita.CodigoEspecialidad,
					FechaHoraCita = cita.FechaHoraCita,
					TipoAtencion = cita.TipoAtencion,
					MotivoConsulta = cita.MotivoConsulta,
					Sintomas = cita.Sintomas,
					ObservacionesMedicas = cita.ObservacionesMedicas,
					TratamientoGeneral = cita.TratamientoGeneral,
					PresionArterial = cita.PresionArterial,
					Temperatura = cita.Temperatura,
					Peso = cita.Peso,
					Estado = cita.Estado
				};

				return Ok(new RespuestaApi<CitaConsultaConsultaDTO>
				{
					Exito = true,
					Mensaje = "Cita/Consulta encontrada correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<CitaConsultaConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar la cita/consulta.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}


		[HttpPut("EditarCitaConsulta")]
		public ActionResult<RespuestaApi<bool>> EditarCitaConsulta([FromBody] CitaConsultaEditarDTO dto)
		{
			try
			{
				CitaConsulta cita = new CitaConsulta
				{
					CodigoCitaConsulta = dto.CodigoCitaConsulta,
					CodigoPaciente = dto.CodigoPaciente,
					CodigoColaborador = dto.CodigoColaborador,
					CodigoSucursal = dto.CodigoSucursal,
					CodigoEspecialidad = dto.CodigoEspecialidad,
					FechaHoraCita = dto.FechaHoraCita,
					TipoAtencion = dto.TipoAtencion,
					MotivoConsulta = dto.MotivoConsulta,
					Sintomas = dto.Sintomas,
					ObservacionesMedicas = dto.ObservacionesMedicas,
					TratamientoGeneral = dto.TratamientoGeneral,
					PresionArterial = dto.PresionArterial,
					Temperatura = dto.Temperatura,
					Peso = dto.Peso,
					Estado = dto.Estado
				};

				bool resultado = citaConsultaNegocio.EditarCitaConsulta(cita);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Cita/Consulta editada correctamente." : "No fue posible editar la cita/consulta.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar la cita/consulta.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}


		[HttpDelete("EliminarCitaConsulta/{codigoCitaConsulta:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarCitaConsulta(int codigoCitaConsulta)
		{
			try
			{
				bool resultado = citaConsultaNegocio.EliminarCitaConsulta(codigoCitaConsulta);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Cita/Consulta eliminada correctamente." : "No fue posible eliminar la cita/consulta.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar la cita/consulta.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}
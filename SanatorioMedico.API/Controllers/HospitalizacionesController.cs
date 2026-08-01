using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HospitalizacionesController : ControllerBase
	{
		private readonly HospitalizacionNegocio hospitalizacionNegocio;

		public HospitalizacionesController()
		{
			hospitalizacionNegocio = new HospitalizacionNegocio();
		}

		[HttpGet("ConsultarHospitalizaciones")]
		public ActionResult<RespuestaApi<List<HospitalizacionConsultaDTO>>> ConsultarHospitalizaciones()
		{
			try
			{
				List<Hospitalizacion> lista = hospitalizacionNegocio.ConsultarHospitalizaciones();

				List<HospitalizacionConsultaDTO> dtos = lista.Select(h => new HospitalizacionConsultaDTO
				{
					CodigoHospitalizacion = h.CodigoHospitalizacion,
					CodigoPaciente = h.CodigoPaciente,
					CodigoSucursal = h.CodigoSucursal,
					CodigoColaborador = h.CodigoColaborador,
					CodigoCitaConsulta = h.CodigoCitaConsulta,
					CodigoHabitacion = h.CodigoHabitacion,
					MotivoIngreso = h.MotivoIngreso,
					DiagnosticoIngreso = h.DiagnosticoIngreso,
					DiagnosticoEgreso = h.DiagnosticoEgreso,
					RecomendacionesEgreso = h.RecomendacionesEgreso,
					Observaciones = h.Observaciones,
					Estado = h.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<HospitalizacionConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Hospitalizaciones consultadas correctamente.",
					Datos = dtos,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<HospitalizacionConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar las hospitalizaciones.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarHospitalizacion")]
		public ActionResult<RespuestaApi<bool>> AgregarHospitalizacion([FromBody] HospitalizacionAgregarDTO dto)
		{
			try
			{
				Hospitalizacion hospitalizacion = new Hospitalizacion
				{
					CodigoPaciente = dto.CodigoPaciente,
					CodigoSucursal = dto.CodigoSucursal,
					CodigoColaborador = dto.CodigoColaborador,
					CodigoCitaConsulta = dto.CodigoCitaConsulta,
					CodigoHabitacion = dto.CodigoHabitacion,
					MotivoIngreso = dto.MotivoIngreso,
					DiagnosticoIngreso = dto.DiagnosticoIngreso,
					DiagnosticoEgreso = dto.DiagnosticoEgreso,
					RecomendacionesEgreso = dto.RecomendacionesEgreso,
					Observaciones = dto.Observaciones,
					Estado = dto.Estado
				};

				bool resultado = hospitalizacionNegocio.AgregarHospitalizacion(hospitalizacion);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Hospitalización agregada correctamente." : "No fue posible agregar la hospitalización.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar la hospitalización.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarHospitalizacion/{codigoHospitalizacion:int}")]
		public ActionResult<RespuestaApi<HospitalizacionConsultaDTO>> BuscarHospitalizacion(int codigoHospitalizacion)
		{
			try
			{
				Hospitalizacion? hospitalizacion = hospitalizacionNegocio.BuscarHospitalizacion(codigoHospitalizacion);

				if (hospitalizacion == null)
				{
					return NotFound(new RespuestaApi<HospitalizacionConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró la hospitalización solicitada.",
						Datos = null,
						Detalle = null
					});
				}

				HospitalizacionConsultaDTO dto = new HospitalizacionConsultaDTO
				{
					CodigoHospitalizacion = hospitalizacion.CodigoHospitalizacion,
					CodigoPaciente = hospitalizacion.CodigoPaciente,
					CodigoSucursal = hospitalizacion.CodigoSucursal,
					CodigoColaborador = hospitalizacion.CodigoColaborador,
					CodigoCitaConsulta = hospitalizacion.CodigoCitaConsulta,
					CodigoHabitacion = hospitalizacion.CodigoHabitacion,
					MotivoIngreso = hospitalizacion.MotivoIngreso,
					DiagnosticoIngreso = hospitalizacion.DiagnosticoIngreso,
					DiagnosticoEgreso = hospitalizacion.DiagnosticoEgreso,
					RecomendacionesEgreso = hospitalizacion.RecomendacionesEgreso,
					Observaciones = hospitalizacion.Observaciones,
					Estado = hospitalizacion.Estado
				};

				return Ok(new RespuestaApi<HospitalizacionConsultaDTO>
				{
					Exito = true,
					Mensaje = "Hospitalización encontrada correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<HospitalizacionConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar la hospitalización.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarHospitalizacion")]
		public ActionResult<RespuestaApi<bool>> EditarHospitalizacion([FromBody] HospitalizacionEditarDTO dto)
		{
			try
			{
				Hospitalizacion hospitalizacion = new Hospitalizacion
				{
					CodigoHospitalizacion = dto.CodigoHospitalizacion,
					CodigoPaciente = dto.CodigoPaciente,
					CodigoSucursal = dto.CodigoSucursal,
					CodigoColaborador = dto.CodigoColaborador,
					CodigoCitaConsulta = dto.CodigoCitaConsulta,
					CodigoHabitacion = dto.CodigoHabitacion,
					MotivoIngreso = dto.MotivoIngreso,
					DiagnosticoIngreso = dto.DiagnosticoIngreso,
					DiagnosticoEgreso = dto.DiagnosticoEgreso,
					RecomendacionesEgreso = dto.RecomendacionesEgreso,
					Observaciones = dto.Observaciones,
					Estado = dto.Estado
				};

				bool resultado = hospitalizacionNegocio.EditarHospitalizacion(hospitalizacion);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Hospitalización editada correctamente." : "No fue posible editar la hospitalización.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar la hospitalización.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarHospitalizacion/{codigoHospitalizacion:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarHospitalizacion(int codigoHospitalizacion)
		{
			try
			{
				bool resultado = hospitalizacionNegocio.EliminarHospitalizacion(codigoHospitalizacion);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Hospitalización eliminada correctamente." : "No fue posible eliminar la hospitalización.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar la hospitalización.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}
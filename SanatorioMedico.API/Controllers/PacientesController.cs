using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PacientesController : ControllerBase
	{
		private readonly PacienteNegocio pacienteNegocio;

		public PacientesController()
		{
			pacienteNegocio = new PacienteNegocio();
		}

		[HttpGet("ConsultarPacientes")]
		public ActionResult<RespuestaApi<List<PacienteConsultaDTO>>> ConsultarPacientes()
		{
			try
			{
				List<Paciente> pacientes = pacienteNegocio.ConsultarPacientes();

				List<PacienteConsultaDTO> pacientesConsulta = pacientes.Select(p => new PacienteConsultaDTO
				{
					CodigoPaciente = p.CodigoPaciente,
					NumeroExpediente = p.NumeroExpediente,
					TipoDocumento = p.TipoDocumento,
					NumeroDocumento = p.NumeroDocumento,
					Nombres = p.Nombres,
					Apellidos = p.Apellidos,
					FechaNacimiento = p.FechaNacimiento,
					Genero = p.Genero,
					TipoSangre = p.TipoSangre,
					Telefono = p.Telefono,
					CorreoElectronico = p.CorreoElectronico,
					Direccion = p.Direccion,
					ContactoEmergencia = p.ContactoEmergencia,
					TelefonoEmergencia = p.TelefonoEmergencia,
					Alergias = p.Alergias,
					Estado = p.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<PacienteConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Pacientes consultados correctamente.",
					Datos = pacientesConsulta,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<PacienteConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar los pacientes.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarPaciente")]
		public ActionResult<RespuestaApi<bool>> AgregarPaciente([FromBody] PacienteAgregarDTO dto)
		{
			try
			{
				Paciente paciente = new Paciente
				{
					NumeroExpediente = dto.NumeroExpediente,
					TipoDocumento = dto.TipoDocumento,
					NumeroDocumento = dto.NumeroDocumento,
					Nombres = dto.Nombres,
					Apellidos = dto.Apellidos,
					FechaNacimiento = dto.FechaNacimiento,
					Genero = dto.Genero,
					TipoSangre = dto.TipoSangre,
					Telefono = dto.Telefono,
					CorreoElectronico = dto.CorreoElectronico,
					Direccion = dto.Direccion,
					ContactoEmergencia = dto.ContactoEmergencia,
					TelefonoEmergencia = dto.TelefonoEmergencia,
					Alergias = dto.Alergias,
					Estado = dto.Estado
				};

				bool resultado = pacienteNegocio.AgregarPaciente(paciente);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Paciente agregado correctamente." : "No fue posible agregar el paciente.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar el paciente.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarPaciente/{codigoPaciente:int}")]
		public ActionResult<RespuestaApi<PacienteConsultaDTO>> BuscarPaciente(int codigoPaciente)
		{
			try
			{
				Paciente? paciente = pacienteNegocio.BuscarPaciente(codigoPaciente);

				if (paciente == null)
				{
					return NotFound(new RespuestaApi<PacienteConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró el paciente solicitado.",
						Datos = null,
						Detalle = null
					});
				}

				PacienteConsultaDTO dto = new PacienteConsultaDTO
				{
					CodigoPaciente = paciente.CodigoPaciente,
					NumeroExpediente = paciente.NumeroExpediente,
					TipoDocumento = paciente.TipoDocumento,
					NumeroDocumento = paciente.NumeroDocumento,
					Nombres = paciente.Nombres,
					Apellidos = paciente.Apellidos,
					FechaNacimiento = paciente.FechaNacimiento,
					Genero = paciente.Genero,
					TipoSangre = paciente.TipoSangre,
					Telefono = paciente.Telefono,
					CorreoElectronico = paciente.CorreoElectronico,
					Direccion = paciente.Direccion,
					ContactoEmergencia = paciente.ContactoEmergencia,
					TelefonoEmergencia = paciente.TelefonoEmergencia,
					Alergias = paciente.Alergias,
					Estado = paciente.Estado
				};

				return Ok(new RespuestaApi<PacienteConsultaDTO>
				{
					Exito = true,
					Mensaje = "Paciente encontrado correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<PacienteConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar el paciente.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarPaciente")]
		public ActionResult<RespuestaApi<bool>> EditarPaciente([FromBody] PacienteEditarDTO dto)
		{
			try
			{
				Paciente paciente = new Paciente
				{
					CodigoPaciente = dto.CodigoPaciente,
					NumeroExpediente = dto.NumeroExpediente,
					TipoDocumento = dto.TipoDocumento,
					NumeroDocumento = dto.NumeroDocumento,
					Nombres = dto.Nombres,
					Apellidos = dto.Apellidos,
					FechaNacimiento = dto.FechaNacimiento,
					Genero = dto.Genero,
					TipoSangre = dto.TipoSangre,
					Telefono = dto.Telefono,
					CorreoElectronico = dto.CorreoElectronico,
					Direccion = dto.Direccion,
					ContactoEmergencia = dto.ContactoEmergencia,
					TelefonoEmergencia = dto.TelefonoEmergencia,
					Alergias = dto.Alergias,
					Estado = dto.Estado
				};

				bool resultado = pacienteNegocio.EditarPaciente(paciente);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Paciente editado correctamente." : "No fue posible editar el paciente.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar el paciente.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarPaciente/{codigoPaciente:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarPaciente(int codigoPaciente)
		{
			try
			{
				bool resultado = pacienteNegocio.EliminarPaciente(codigoPaciente);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Paciente eliminado correctamente." : "No fue posible eliminar el paciente.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar el paciente.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}
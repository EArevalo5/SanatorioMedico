using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RolesController : ControllerBase
	{
		private readonly RolNegocio rolNegocio;

		public RolesController()
		{
			rolNegocio = new RolNegocio();
		}

		[HttpGet("ConsultarRoles")]
		public ActionResult<RespuestaApi<List<RolConsultaDTO>>> ConsultarRoles()
		{
			try
			{
				List<Rol> roles = rolNegocio.ConsultarRoles();

				List<RolConsultaDTO> rolesConsulta = roles.Select(rol => new RolConsultaDTO
				{
					CodigoRol = rol.CodigoRol,
					NombreRol = rol.NombreRol,
					DescripcionRol = rol.DescripcionRol,
					ModuloPrincipal = rol.ModuloPrincipal,
					PermiteConsultar = rol.PermiteConsultar,
					PermiteAgregar = rol.PermiteAgregar,
					PermiteEditar = rol.PermiteEditar,
					PermiteAnular = rol.PermiteAnular,
					Estado = rol.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<RolConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Roles consultados correctamente.",
					Datos = rolesConsulta,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<RolConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar los roles.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarRol")]
		public ActionResult<RespuestaApi<bool>> AgregarRol([FromBody] RolAgregarDTO rolAgregarDTO)
		{
			try
			{
				Rol rol = new Rol
				{
					NombreRol = rolAgregarDTO.NombreRol,
					DescripcionRol = rolAgregarDTO.DescripcionRol,
					ModuloPrincipal = rolAgregarDTO.ModuloPrincipal,
					PermiteConsultar = rolAgregarDTO.PermiteConsultar,
					PermiteAgregar = rolAgregarDTO.PermiteAgregar,
					PermiteEditar = rolAgregarDTO.PermiteEditar,
					PermiteAnular = rolAgregarDTO.PermiteAnular,
					Estado = rolAgregarDTO.Estado
				};

				bool resultado = rolNegocio.AgregarRol(rol);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Rol agregado correctamente." : "No fue posible agregar el rol.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar el rol.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarRol/{codigoRol:int}")]
		public ActionResult<RespuestaApi<RolConsultaDTO>> BuscarRol(int codigoRol)
		{
			try
			{
				Rol? rol = rolNegocio.BuscarRol(codigoRol);

				if (rol == null)
				{
					return NotFound(new RespuestaApi<RolConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró el rol solicitado.",
						Datos = null,
						Detalle = null
					});
				}

				RolConsultaDTO rolConsultaDTO = new RolConsultaDTO
				{
					CodigoRol = rol.CodigoRol,
					NombreRol = rol.NombreRol,
					DescripcionRol = rol.DescripcionRol,
					ModuloPrincipal = rol.ModuloPrincipal,
					PermiteConsultar = rol.PermiteConsultar,
					PermiteAgregar = rol.PermiteAgregar,
					PermiteEditar = rol.PermiteEditar,
					PermiteAnular = rol.PermiteAnular,
					Estado = rol.Estado
				};

				return Ok(new RespuestaApi<RolConsultaDTO>
				{
					Exito = true,
					Mensaje = "Rol encontrado correctamente.",
					Datos = rolConsultaDTO,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<RolConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar el rol.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarRol")]
		public ActionResult<RespuestaApi<bool>> EditarRol([FromBody] RolEditarDTO rolEditarDTO)
		{
			try
			{
				Rol rol = new Rol
				{
					CodigoRol = rolEditarDTO.CodigoRol,
					NombreRol = rolEditarDTO.NombreRol,
					DescripcionRol = rolEditarDTO.DescripcionRol,
					ModuloPrincipal = rolEditarDTO.ModuloPrincipal,
					PermiteConsultar = rolEditarDTO.PermiteConsultar,
					PermiteAgregar = rolEditarDTO.PermiteAgregar,
					PermiteEditar = rolEditarDTO.PermiteEditar,
					PermiteAnular = rolEditarDTO.PermiteAnular,
					Estado = rolEditarDTO.Estado
				};

				bool resultado = rolNegocio.EditarRol(rol);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Rol editado correctamente." : "No fue posible editar el rol.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar el rol.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarRol/{codigoRol:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarRol(int codigoRol)
		{
			try
			{
				bool resultado = rolNegocio.EliminarRol(codigoRol);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Rol eliminado correctamente." : "No fue posible eliminar el rol.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar el rol.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}
using Microsoft.AspNetCore.Mvc;
using SanatorioMedico.DTO.DTO;
using SanatorioMedico.Entidades.Entidades;
using SanatorioMedico.Negocio.Servicios;

namespace SanatorioMedico.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProveedoresController : ControllerBase
	{
		private readonly ProveedorNegocio proveedorNegocio;

		public ProveedoresController()
		{
			proveedorNegocio = new ProveedorNegocio();
		}

		[HttpGet("ConsultarProveedores")]
		public ActionResult<RespuestaApi<List<ProveedorConsultaDTO>>> ConsultarProveedores()
		{
			try
			{
				List<Proveedor> lista = proveedorNegocio.ConsultarProveedores();

				List<ProveedorConsultaDTO> dtos = lista.Select(p => new ProveedorConsultaDTO
				{
					CodigoProveedor = p.CodigoProveedor,
					NIT = p.NIT,
					RazonSocial = p.RazonSocial,
					NombreComercial = p.NombreComercial,
					Direccion = p.Direccion,
					Municipio = p.Municipio,
					Departamento = p.Departamento,
					Telefono = p.Telefono,
					CorreoElectronico = p.CorreoElectronico,
					PersonaContacto = p.PersonaContacto,
					TelefonoContacto = p.TelefonoContacto,
					Estado = p.Estado
				}).ToList();

				return Ok(new RespuestaApi<List<ProveedorConsultaDTO>>
				{
					Exito = true,
					Mensaje = "Proveedores consultados correctamente.",
					Datos = dtos,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<List<ProveedorConsultaDTO>>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al consultar los proveedores.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPost("AgregarProveedor")]
		public ActionResult<RespuestaApi<bool>> AgregarProveedor([FromBody] ProveedorAgregarDTO dto)
		{
			try
			{
				Proveedor proveedor = new Proveedor
				{
					NIT = dto.NIT,
					RazonSocial = dto.RazonSocial,
					NombreComercial = dto.NombreComercial,
					Direccion = dto.Direccion,
					Municipio = dto.Municipio,
					Departamento = dto.Departamento,
					Telefono = dto.Telefono,
					CorreoElectronico = dto.CorreoElectronico,
					PersonaContacto = dto.PersonaContacto,
					TelefonoContacto = dto.TelefonoContacto,
					Estado = dto.Estado
				};

				bool resultado = proveedorNegocio.AgregarProveedor(proveedor);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Proveedor agregado correctamente." : "No fue posible agregar el proveedor.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al agregar el proveedor.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpGet("BuscarProveedor/{codigoProveedor:int}")]
		public ActionResult<RespuestaApi<ProveedorConsultaDTO>> BuscarProveedor(int codigoProveedor)
		{
			try
			{
				Proveedor? proveedor = proveedorNegocio.BuscarProveedor(codigoProveedor);

				if (proveedor == null)
				{
					return NotFound(new RespuestaApi<ProveedorConsultaDTO>
					{
						Exito = false,
						Mensaje = "No se encontró el proveedor solicitado.",
						Datos = null,
						Detalle = null
					});
				}

				ProveedorConsultaDTO dto = new ProveedorConsultaDTO
				{
					CodigoProveedor = proveedor.CodigoProveedor,
					NIT = proveedor.NIT,
					RazonSocial = proveedor.RazonSocial,
					NombreComercial = proveedor.NombreComercial,
					Direccion = proveedor.Direccion,
					Municipio = proveedor.Municipio,
					Departamento = proveedor.Departamento,
					Telefono = proveedor.Telefono,
					CorreoElectronico = proveedor.CorreoElectronico,
					PersonaContacto = proveedor.PersonaContacto,
					TelefonoContacto = proveedor.TelefonoContacto,
					Estado = proveedor.Estado
				};

				return Ok(new RespuestaApi<ProveedorConsultaDTO>
				{
					Exito = true,
					Mensaje = "Proveedor encontrado correctamente.",
					Datos = dto,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<ProveedorConsultaDTO>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al buscar el proveedor.",
					Datos = null,
					Detalle = ex.Message
				});
			}
		}

		[HttpPut("EditarProveedor")]
		public ActionResult<RespuestaApi<bool>> EditarProveedor([FromBody] ProveedorEditarDTO dto)
		{
			try
			{
				Proveedor proveedor = new Proveedor
				{
					CodigoProveedor = dto.CodigoProveedor,
					NIT = dto.NIT,
					RazonSocial = dto.RazonSocial,
					NombreComercial = dto.NombreComercial,
					Direccion = dto.Direccion,
					Municipio = dto.Municipio,
					Departamento = dto.Departamento,
					Telefono = dto.Telefono,
					CorreoElectronico = dto.CorreoElectronico,
					PersonaContacto = dto.PersonaContacto,
					TelefonoContacto = dto.TelefonoContacto,
					Estado = dto.Estado
				};

				bool resultado = proveedorNegocio.EditarProveedor(proveedor);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Proveedor editado correctamente." : "No fue posible editar el proveedor.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al editar el proveedor.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}

		[HttpDelete("EliminarProveedor/{codigoProveedor:int}")]
		public ActionResult<RespuestaApi<bool>> EliminarProveedor(int codigoProveedor)
		{
			try
			{
				bool resultado = proveedorNegocio.EliminarProveedor(codigoProveedor);

				return Ok(new RespuestaApi<bool>
				{
					Exito = resultado,
					Mensaje = resultado ? "Proveedor eliminado correctamente." : "No fue posible eliminar el proveedor.",
					Datos = resultado,
					Detalle = null
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new RespuestaApi<bool>
				{
					Exito = false,
					Mensaje = "Ocurrió un error al eliminar el proveedor.",
					Datos = false,
					Detalle = ex.Message
				});
			}
		}
	}
}
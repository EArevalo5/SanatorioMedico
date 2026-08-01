using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.Entidades.Entidades
{
	public class Proveedor
	{
		public int CodigoProveedor { get; set; }
		public string NIT { get; set; } = string.Empty;
		public string RazonSocial { get; set; } = string.Empty;
		public string NombreComercial { get; set; } = string.Empty;
		public string Direccion { get; set; } = string.Empty;
		public string Municipio { get; set; } = string.Empty;
		public string Departamento { get; set; } = string.Empty;
		public string Telefono { get; set; } = string.Empty;
		public string CorreoElectronico { get; set; } = string.Empty;
		public string PersonaContacto { get; set; } = string.Empty;
		public string TelefonoContacto { get; set; } = string.Empty;
		public string Estado { get; set; } = string.Empty;



	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatorioMedico.Entidades.Entidades
{
	public class Rol
	{
		public int CodigoRol { get; set; }
		public string NombreRol { get; set; } = string.Empty;
		public string DescripcionRol { get; set; } = string.Empty;
		public string ModuloPrincipal { get; set; } = string.Empty;
		public bool PermiteConsultar { get; set; }
		public bool PermiteAgregar { get; set; }
		public bool PermiteEditar { get; set; }
		public bool PermiteAnular { get; set; }
		public string Estado { get; set; } = string.Empty;





	}
}

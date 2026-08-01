using System;
using System.Collections.Generic;
using System.Text;

namespace SanatorioMedico.DTO.DTO
{
	public class SucursalEditarDTO
	{
		public int CodigoSucursal { get; set; }

		public string NombreSucursal { get; set; } = string.Empty;

		public string Direccion { get; set; } = string.Empty;

		public decimal PresupuestoMensual { get; set; }

		public bool Estado { get; set; }
	}
}


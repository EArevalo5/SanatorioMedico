using System;
using System.Collections.Generic;
using System.Text;

namespace SanatorioMedico.DTO.DTO
{
	public class SucursalConsultaDTO
	{
		public int CodigoSucursal { get; set; }

		public string NombreSucursal { get; set; } = string.Empty;

		public string Direccion { get; set; } = string.Empty;

		public DateOnly FechaApertura { get; set; }

		public TimeOnly HoraApertura { get; set; }

		public decimal PresupuestoMensual { get; set; }

		public bool Estado { get; set; }
	}
}

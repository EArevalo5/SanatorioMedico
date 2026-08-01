using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class PacienteNegocio
	{
		private readonly PacienteDatos pacienteDatos;

		public PacienteNegocio()
		{
			pacienteDatos = new PacienteDatos();
		}

		public List<Paciente> ConsultarPacientes()
		{
			return pacienteDatos.ConsultarPacientes();
		}

		public bool AgregarPaciente(Paciente paciente)
		{
			return pacienteDatos.AgregarPaciente(paciente);
		}

		public Paciente? BuscarPaciente(int codigoPaciente)
		{
			return pacienteDatos.BuscarPaciente(codigoPaciente);
		}

		public bool EditarPaciente(Paciente paciente)
		{
			return pacienteDatos.EditarPaciente(paciente);
		}

		public bool EliminarPaciente(int codigoPaciente)
		{
			return pacienteDatos.EliminarPaciente(codigoPaciente);
		}
	}
}
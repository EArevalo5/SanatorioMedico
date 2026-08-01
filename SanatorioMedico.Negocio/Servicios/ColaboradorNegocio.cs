using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class ColaboradorNegocio
	{
		private readonly ColaboradorDatos colaboradorDatos;

		public ColaboradorNegocio()
		{
			colaboradorDatos = new ColaboradorDatos();
		}

		public List<Colaborador> ConsultarColaboradores()
		{
			return colaboradorDatos.ConsultarColaboradores();
		}

		public bool AgregarColaborador(Colaborador colaborador)
		{
			return colaboradorDatos.AgregarColaborador(colaborador);
		}

		public Colaborador? BuscarColaborador(int codigoColaborador)
		{
			return colaboradorDatos.BuscarColaborador(codigoColaborador);
		}

		public bool EditarColaborador(Colaborador colaborador)
		{
			return colaboradorDatos.EditarColaborador(colaborador);
		}

		public bool EliminarColaborador(int codigoColaborador)
		{
			return colaboradorDatos.EliminarColaborador(codigoColaborador);
		}
	}
}
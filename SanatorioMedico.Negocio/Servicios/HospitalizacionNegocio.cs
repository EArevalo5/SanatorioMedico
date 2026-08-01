using SanatorioMedico.Datos.Datos;
using SanatorioMedico.Entidades.Entidades;

namespace SanatorioMedico.Negocio.Servicios
{
	public class HospitalizacionNegocio
	{
		private readonly HospitalizacionDatos hospitalizacionDatos;

		public HospitalizacionNegocio()
		{
			hospitalizacionDatos = new HospitalizacionDatos();
		}

		public List<Hospitalizacion> ConsultarHospitalizaciones()
		{
			return hospitalizacionDatos.ConsultarHospitalizaciones();
		}

		public bool AgregarHospitalizacion(Hospitalizacion hospitalizacion)
		{
			return hospitalizacionDatos.AgregarHospitalizacion(hospitalizacion);
		}

		public Hospitalizacion? BuscarHospitalizacion(int codigoHospitalizacion)
		{
			return hospitalizacionDatos.BuscarHospitalizacion(codigoHospitalizacion);
		}

		public bool EditarHospitalizacion(Hospitalizacion hospitalizacion)
		{
			return hospitalizacionDatos.EditarHospitalizacion(hospitalizacion);
		}

		public bool EliminarHospitalizacion(int codigoHospitalizacion)
		{
			return hospitalizacionDatos.EliminarHospitalizacion(codigoHospitalizacion);
		}
	}
}

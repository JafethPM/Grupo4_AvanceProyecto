using WebApplicationAPP.Models;
using WebApplicationAPP.Repositories;
using WebApplicationAPP.Services;

namespace WebApplicationAPP.Business
{
    public class ServicioBusiness
    {
        private readonly IServicioRepository _repo; 
        private readonly IBitacoraService _bitacora;

        public ServicioBusiness(IServicioRepository repo, IBitacoraService bitacora )
        {
            _repo = repo;
            _bitacora = bitacora;
        }


        public List<Servicio> Listar()
        {
            try
            {
                return _repo.Listar();
            }
            catch (Exception)
            {
                return new List<Servicio>();
            }
        }


        public Servicio Obtener(int id)
        {
            try
            {
                return _repo.Obtener(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string Crear(Servicio s)
        {
            try
            {
                if (s == null)
                    return "Datos inválidos";

                if (string.IsNullOrEmpty(s.Nombre))
                    return "El nombre es requerido";

                if (s.Monto <= 0)
                    return "El monto debe ser mayor a 0";

                s.FechaDeRegistro = DateTime.Now;
                s.Estado = true;

                _repo.Insertar(s);
                _bitacora.RegistrarEvento
                    (
                   "Cajas_G4",
                   "INSERT",
                   "Se creó una nueva caja",
                   null,
                   s
                );

                return "OK";
            }
            catch (Exception)
            {
                return "Error al crear el servicio";
            }

        }

        public string Editar(Servicio s)
        {
            try
            {
                var existente = _repo.Obtener(s.Id);

                if (existente == null)
                    return "Servicio no existe";

                if (string.IsNullOrEmpty(s.Nombre))
                    return "El nombre es requerido";

                if (s.Monto <= 0)
                    return "El monto debe ser mayor a 0";

                existente.Nombre = s.Nombre;
                existente.Descripcion = s.Descripcion;
                existente.Monto = s.Monto;
                existente.IVA = s.IVA;
                existente.Especialidad = s.Especialidad;
                existente.Especialista = s.Especialista;
                existente.Clinica = s.Clinica;
                existente.FechaDeModificacion = DateTime.Now;
                existente.Estado = s.Estado;

                _repo.Actualizar(existente);
                _bitacora.RegistrarEvento
                        (
                            "Servicio_G4",
                            "UPDATE",
                            "Se editó un servicio",
                            null,
                            existente
                        );

                return "OK";
            }
            catch (Exception)
            {
                return "Error al editar el servicio";
            }
        }
    }
}

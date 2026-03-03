using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Bussines
{
    public class SinpeBussines
    {
        private readonly ISinpeRepository _repository;

        public SinpeBussines(ISinpeRepository repository)
        {
            _repository = repository;
        }

        public void Registrar(Sinpe sinpe)
        {
            sinpe.FechaDeRegistro = DateTime.Now;
            sinpe.Estado = false;

            _repository.Registrar(sinpe);
        }
    }
}

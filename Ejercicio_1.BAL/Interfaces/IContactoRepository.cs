using Ejercicio_1.DAL.Models;

namespace Ejercicio_1.BAL.Interfaces
{
    public interface IContactoRepository
    {
        public List<Contacto> GetAll();
        public Contacto GetById(int id);
        public void Add(Contacto contacto);
        public void Update(Contacto contacto);
        public void Delete(int id);
    }
}

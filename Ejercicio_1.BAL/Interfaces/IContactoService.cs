using Ejercicio_1.DAL.Models;

namespace Ejercicio_1.BAL.Interfaces
{
    public interface IContactoService
    {
        public List<Contacto> GetAllContactos();
        public Contacto GetContactoById(int id);
        public void AddContacto(Contacto contacto);
        public void UpdateContacto(Contacto contacto);
        public void DeleteContacto(int id);
    }
}

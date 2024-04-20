using Ejercicio_1.BAL.Interfaces;
using Ejercicio_1.DAL.Models;

namespace Ejercicio_1.BAL.Services
{
    public class ContactoService(IContactoRepository repo) : IContactoService
    {
        public List<Contacto> GetAllContactos()
        {
            return repo.GetAll();
        }

        public Contacto GetContactoById(int id)
        {
            return repo.GetById(id);
        }
        public void AddContacto(Contacto contacto)
        {
            repo.Add(contacto);
        }

        public void UpdateContacto(Contacto contacto)
        {
            repo.Update(contacto);
        }

        public void DeleteContacto(int id)
        {
            repo.Delete(id);
        }
    }
}

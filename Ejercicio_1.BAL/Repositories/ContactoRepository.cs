using Ejercicio_1.BAL.Interfaces;
using Ejercicio_1.DAL;
using Ejercicio_1.DAL.Models;

namespace Ejercicio_1.BAL.Repositories
{
    public class ContactoRepository(Guia3Periodo3Context context) : IContactoRepository
    {
        public void Add(Contacto contacto)
        {
            context.Add(contacto);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var contacto = context.Contactos.FirstOrDefault(c => c.IdContacto == id);
            context.Contactos.Remove(contacto);
            SaveChanges();
        }

        public List<Contacto> GetAll()
        {
            return context.Contactos.ToList();
        }

        public Contacto GetById(int id)
        {
            return context.Contactos.FirstOrDefault(c => c.IdContacto == id);
        }

        public void Update(Contacto contacto)
        {
            var existingContact = context.Contactos.FirstOrDefault(c => c.IdContacto == contacto.IdContacto);
            existingContact.Nombres = contacto.Nombres;
            existingContact.Apellidos = contacto.Apellidos;
            existingContact.Telefono = contacto.Telefono;
            existingContact.Correo = contacto.Correo;
            SaveChanges();
        }

        private void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

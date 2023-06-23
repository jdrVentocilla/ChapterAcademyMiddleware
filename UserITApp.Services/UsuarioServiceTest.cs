using Core.GestionDeExcepciones;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserITApp.Entities;
using UserITApp.Persistence;
using System.Collections;

namespace UserITApp.Services
{
    internal class UsuarioServiceTest : IServicioGenerico<Usuario>
    {
        private readonly UserITAppContext _context;
        public UsuarioServiceTest(UserITAppContext context)
        {
            this._context = context;
        }
        public StateExecution Upsert(Usuario entidad)
        {
            Usuario entiodadEncontrada = this._context.Usuario.Find(entidad.Id);

            if (entiodadEncontrada == null)
            {
                this._context.Add(entidad);
            }
            else
            {
                this._context.Update(entidad);

            }
            this._context.SaveChanges();

            return (new StateExecution()
            {

                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = entiodadEncontrada == null ? "Registro guardado con éxito." : "Registro modificado con éxito." },


            });



        }

        public StateExecution Delete(string id)
        {
            Usuario entidad = this._context.Usuario.Find(id);

            if (entidad == null)
            {
                return new StateExecution()
                {

                    Status = false,
                    StateType = State.ErrorNotContent,
                    MessageState = new Message() { Description = "Registro no encontrado." },

                };
            }

            this._context.Usuario.Remove(entidad);
            this._context.SaveChanges();

            return new StateExecution()
            {

                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Registro eliminado con éxito." },

            };



        }

        public StateExecution Upsert(Aplicacion entidad)

        {
            Aplicacion entiodadEncontrada = this._context.Aplicacion.Find(entidad.Id);

            if (entiodadEncontrada == null)
            {
                this._context.Add(entidad);
            }
            else
            {
                this._context.Update(entidad);

            }
            this._context.SaveChanges();

            return (new StateExecution()
            {

                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = entiodadEncontrada == null ? "Registro guardado con éxito." : "Registro modificado con éxito." },


            });



        }

        public StateExecution<Usuario> Find(string id)
        {
            Usuario entidadEncontrada = this._context.Usuario.Find(id);


            return (new StateExecution<Usuario>()
            {

                Status = entidadEncontrada != null,
                StateType = entidadEncontrada != null ? State.Ok : State.ErrorNotContent,
                Data = entidadEncontrada,
                MessageState = new Message() { Description = entidadEncontrada == null ? "Registro no encontrado." : "Registro encontrado." },


            });



        }

        public StateExecution<IEnumerable<Usuario>> Get()
        {

            IEnumerable<Usuario> lista = new List<Usuario>();

            return  new StateExecution<IEnumerable<Usuario>>() {  Status =  true , Data = lista };
             
        }
    }
}

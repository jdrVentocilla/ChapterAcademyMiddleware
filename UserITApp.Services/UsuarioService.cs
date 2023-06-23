using Core.GestionDeExcepciones;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserITApp.Entities;
using UserITApp.Persistence;

namespace UserITApp.Services
{
    public class UsuarioService
    {
        private  UserITAppContext _context;
        public UsuarioService() {


        }
        public StateExecution Upsert(Usuario entidad)
        {
            using (_context = new UserITAppContext())

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
          
        }

        public StateExecution Delete(string id)
        {
            using (_context = new UserITAppContext())
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
           
        }

        public StateExecution Upsert(Aplicacion entidad)

        {
            using (_context = new UserITAppContext()) {

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
            
            
          
        }

        public StateExecution<Aplicacion> Find(Aplicacion entidad)
        {
            using (_context = new UserITAppContext())
            {
                Aplicacion entidadEncontrada = this._context.Aplicacion.Find(entidad.Id);


                return (new StateExecution<Aplicacion>()
                {

                    Status = entidadEncontrada != null,
                    StateType = entidadEncontrada != null ? State.Ok : State.ErrorNotContent,
                    Data = entidadEncontrada,
                    MessageState = new Message() { Description = entidadEncontrada == null ? "Registro encontrado." : "Registro no encontrado." },


                });
            }
            

        }

        public StateExecution<IEnumerable<Aplicacion>> Get()
        {
            using (_context = new UserITAppContext())
            {
                IEnumerable<Aplicacion> listaEntidad = this._context.Aplicacion.AsEnumerable<Aplicacion>();


                return (new StateExecution<IEnumerable<Aplicacion>>()
                {

                    Status = true,
                    StateType = State.Ok,
                    Data = listaEntidad,
                    MessageState = new Message() { Description = "Registro encontrado." },


                });



            }


        }


    }
}

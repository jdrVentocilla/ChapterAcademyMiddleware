using Core.GestionDeExcepciones;
using Core;
using UserITApp.Entities;
using UserITApp.Persistence;


namespace UserITApp.Services
{
    public class AplicacionService : IServicioGenerico<Aplicacion>
    {

        private readonly UserITAppContext _context;
        public AplicacionService(UserITAppContext userITAppContext)
        {
            _context = userITAppContext;
        }



        public StateExecution Delete(string id)
        {
            Aplicacion entidad = this._context.Aplicacion.Find(id);

            if (entidad == null)
            {
                return new StateExecution()
                {

                    Status = false,
                    StateType = State.ErrorNotContent,
                    MessageState = new Message() { Description = "Registro no encontrado." },

                };
            }

            this._context.Aplicacion.Remove(entidad);
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

      

        public StateExecution<IEnumerable<Aplicacion>> Get()
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

        public StateExecution<Aplicacion> Find(string id)
        {

            Aplicacion entidadEncontrada = this._context.Aplicacion.Find(id);


            return (new StateExecution<Aplicacion>()
            {

                Status = entidadEncontrada != null,
                StateType = entidadEncontrada != null ? State.Ok : State.ErrorNotContent,
                Data = entidadEncontrada,
                MessageState = new Message() { Description = entidadEncontrada == null ? "Registro no encontrado." : "Registro encontrado." },


            });

        }
    }
}

using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserITApp.Entities;

namespace UserITApp.Services
{
    public interface IServicioGenerico<T> where T : class
    {
        StateExecution Delete(string id);
        StateExecution<T> Find(string id);
        StateExecution<IEnumerable<T>> Get();
        StateExecution Upsert(T entidad);
    }
}

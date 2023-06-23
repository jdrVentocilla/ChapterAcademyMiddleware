using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserITApp.Entities;


namespace UserITApp.Persistence
{
    public class UserITAppContext : DbContext
    {

        public DbSet<Usuario> Usuario => Set<Usuario>();
        public DbSet<Aplicacion> Aplicacion => Set<Aplicacion>();
        public DbSet<AplicacionUsuario> AplicacionUsuario => Set<AplicacionUsuario>();


        public UserITAppContext(DbContextOptions options) : base (options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

           
        }

    }
}

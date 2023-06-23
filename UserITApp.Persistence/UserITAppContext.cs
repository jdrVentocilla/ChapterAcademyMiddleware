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


        public UserITAppContext() : base ()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
                     options.UseMySql("Server=64.227.8.152; Database=useritapp; Uid=useritapp; Pwd=#gD09IO1F; CharSet=utf8; Port=3306;",
                     ServerVersion.AutoDetect("Server=64.227.8.152; Database=useritapp; Uid=useritapp; Pwd=#gD09IO1F; CharSet=utf8; Port=3306;  pooling=true;"));
            
            base.OnConfiguring(options);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            
        }

    }
}

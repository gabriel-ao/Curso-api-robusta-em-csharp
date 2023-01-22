using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence.Repositories
{
    public class XGameContext : DbContext
    {

        //public XGameContext() : base("Server=localhost;Database=XGame-DB;Port=5432;User Id=postgres;Password=gabriel; Persist Security Info=False; Connect Timeout=300")
        public XGameContext() : base("XGameConnectionStrings")
        //public XGameContext() : base("")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }




        public IDbSet<Jogador> Jogadores { get; set; }
        public IDbSet<Plataforma> Plataformas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // retirar o plural automático
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Setar para usar varchar ao invés de nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            // Caso eu esqueça de informar o tamanho do campo ele irá colocar varchar de 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            // Mapeia as entidades
            //modelBuilder.Configurations.Add(new JogadorMap());
            //modelBuilder.Configurations.Add(new PlataformaMap());

            #region Adicionar entidade mapeadas - automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(XGameContext).Assembly);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}


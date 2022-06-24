namespace DevIO.Infra.Migrations
{
    using DevIO.Infra.Data.Context;   
    using System.Data.Entity.Migrations;
  

    internal sealed class Configuration : DbMigrationsConfiguration<MeuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        
    }
}

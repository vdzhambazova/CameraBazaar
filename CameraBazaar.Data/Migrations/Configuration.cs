namespace CameraBazaar.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CameraBazaar.Data.CameraBazaarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CameraBazaarContext context)
        {
           
        }
    }
}

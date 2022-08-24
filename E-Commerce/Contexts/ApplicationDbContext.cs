namespace ECommerce
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
		//private readonly string connectionString;
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
				options) : base(options)
        {
        }
		//public ApplicationDbContext(string connectionString){
            //this.connectionString = connectionString;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
			//optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString))
			//.EnableDetailedErrors() .EnableSensitiveDataLogging()
			//.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                    typeof(ApplicationDbContext).Assembly);
        }
    }
}

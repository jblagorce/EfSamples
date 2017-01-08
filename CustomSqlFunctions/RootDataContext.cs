namespace CustomSqlFunctions
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using System.Linq;
    using System.Data.Entity.Core.Objects;
    using CodeFirstStoreFunctions;

    public class BaseDataContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Add(new FunctionsConvention<RootDataContext>("dbo"));
        }
    }

    public class RootDataContext : DbContext
    {
        public RootDataContext(string setElementsTableId)
              : base(System.Configuration.ConfigurationManager.ConnectionStrings["RepositoryConnectionString"].ConnectionString)
        {
            Database.SetInitializer(new NullDatabaseInitializer<RootDataContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Add<CustomFunctionConvention>();
        }

        public DbSet<RootEntity> Roots { get; set; }

        public DbSet<Customer> Customers { get; set; }

        [DbFunction("RootDataContext", "CustomersByZipCode")]
        public IQueryable<Customer> CustomersByZipCode(string zipCode)
        {
            var zipCodeParameter = zipCode != null ?
                new ObjectParameter("ZipCode", zipCode) :
                new ObjectParameter("ZipCode", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext
                .CreateQuery<Customer>(
                    string.Format("[{0}].{1}", GetType().Name,
                        "[CustomersByZipCode](@ZipCode)"), zipCodeParameter);
        }

    }
}

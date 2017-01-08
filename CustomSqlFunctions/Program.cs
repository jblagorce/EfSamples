namespace CustomSqlFunctions
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new RootDataContext(new Random().Next().ToString());
                            var query = ctx.Roots.Where(r => DataBase.SqlFunctions.ParseInt(r.Title) == 1 && r.ct2.DigitalSourceId.StartsWith("face")).Take(1);
            Console.WriteLine(((System.Data.Entity.Infrastructure.DbQuery<RootEntity>)query).ToString());
            var result = query.ToList();

            Console.ReadLine();
        }
    }
}

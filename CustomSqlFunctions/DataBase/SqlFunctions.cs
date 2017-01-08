namespace CustomSqlFunctions.DataBase
{
    using System;
    using System.Data.Entity;

    public class SqlFunctions
    {
        // The namespace has to exactly match the namespace of the Context
        [DbFunction("CustomSqlFunctions", "ParseInt")]
        public static int ParseInt(string value)
        {
            throw new NotImplementedException();
        }
    }
}

namespace CustomSqlFunctions
{
    using System;

    public class RootEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public ComplexType1 ct1 { get; set; }
        public ComplexType2 ct2 { get; set; }
    }

    public class ComplexType1
    {
        public String Url { get; set; }
        public String UrlTitle { get; set; }
    }

    public class ComplexType2
    {
        public string DigitalSourceId { get; set; }
        public string SocialId { get; set; }
    }
}

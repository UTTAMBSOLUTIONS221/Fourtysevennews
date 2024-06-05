namespace Fourtysevennews.Models.Blogs
{
    public class Fortysevennewsblogs
    {
        public long Systemblogid { get; set; }
        public string? Systemblogtitle { get; set; }
        public string? Systemblogdescription { get; set; }
        public long Systemblogcategoryid { get; set; }
        public string? Extra { get; set; }
        public string? Extra1 { get; set; }
        public string? Extra2 { get; set; }
        public string? Extra3 { get; set; }
        public string? Extra4 { get; set; }
        public string? Extra5 { get; set; }
        public string? Extra6 { get; set; }
        public string? Extra7 { get; set; }
        public string? Extra8 { get; set; }
        public string? Extra9 { get; set; }
        public long Createdby { get; set; }
        public long Modifiedby { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
        public List<Fortysevennewsblogparagraphs>? Blogparagraphs { get; set; }
        public List<Fortysevennewsblogtags>? Blogtags { get; set; }
        public List<Fortysevennewsblogimages>? Blogimages { get; set; }
    }
}

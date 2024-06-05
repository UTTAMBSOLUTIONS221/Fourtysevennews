using Newtonsoft.Json;

namespace Fourtysevennews.Models.Blogs
{
    public class SystemblognewsDetail
    {
        public long RespStatus { get; set; }
        public string? RespMessage { get; set; }
        public int TotalResults { get; set; }
        public List<Systemblognews>? Systemblognews { get; set; }
    }
    public class Systemblognews
    {
        public long Systemblogid { get; set; }
        public string? Systemblogtitle { get; set; }
        public string? Systemblogdescription { get; set; }
        public string? Systemblogimageurl { get; set; }
        public long Systemblogcategoryid { get; set; }
        public string? BlogCategoryName { get; set; }
        public string? Createdby { get; set; }
        public string? Createdbyname { get; set; }
        public string? Modifiedby { get; set; }
        public string? Modifiedbyname { get; set; }
        public DateTime Datemodified { get; set; }
        public DateTime Datecreated { get; set; }
        public long Systemblogstatus { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
    }
}

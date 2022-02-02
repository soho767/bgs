using System.Web;

namespace BGS.Data;

public partial class Part
{
    public int PartId { get; set; }

    public long ModifiedTicks { get; set; }

    public string Category { get; set; }

    public string SubCategory { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }

    public int Stock { get; set; }

    public long PriceCents { get; set; }

    public string Url => $"https://letmebingthatforyou.com/?q={HttpUtility.UrlEncode(Name)}";
}

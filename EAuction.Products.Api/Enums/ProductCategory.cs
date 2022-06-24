using System.ComponentModel;

namespace EAuction.Products.Api.Enums
{
    public enum ProductCategory
    {
        [Description("Painting")]
        Painting = 0,

        [Description("Sculptord")]
        Sculptord = 1,

        [Description("Ornament")]
        Ornament = 2
    }
}

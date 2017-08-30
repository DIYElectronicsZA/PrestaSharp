using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class product_attribute : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_product { get; set; }
        public string reference { get; set; }
        public string supplier_reference { get; set; }
        public string location { get; set; }
        public string ean13 { get; set; }
        public string upc { get; set; }
        public decimal wholesale_price { get; set; }
        public decimal price { get; set; }
        public decimal ecotax { get; set; }
        public long quantity { get; set; }
        public decimal weight { get; set; }
        public decimal unit_price_impact { get; set; }
        public int default_on { get; set; }
        public long minimal_quantity { get; set; }
        public string available_date { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ProductAttributeFactory : RestSharpFactory
    {
        public ProductAttributeFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.product_attribute Get(long ProductAttributeId)
        {
            RestRequest request = this.RequestForGet("product_attributes", ProductAttributeId, "product_Attribute");
            return this.Execute<Entities.product_attribute>(request);
        }

        public Entities.product_attribute Add(Entities.product_attribute ProductAttribute)
        {
            long? idAux = ProductAttribute.id;
            ProductAttribute.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(ProductAttribute);
            RestRequest request = this.RequestForAdd("product_attributes", Entities);
            Entities.product_attribute aux = this.Execute<Entities.product_attribute>(request);
            ProductAttribute.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.product_attribute ProductAttribute)
        {
            RestRequest request = this.RequestForUpdate("product_attributes", ProductAttribute.id, ProductAttribute);
            this.Execute<Entities.product_attribute>(request);
        }

        public void Delete(long ProductAttributeId)
        {
            RestRequest request = this.RequestForDelete("product_attributes", ProductAttributeId);
            this.Execute<Entities.product_attribute>(request);
        }

        public void Delete(Entities.product_attribute ProductAttribute)
        {
            this.Delete((long)ProductAttribute.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("product_attributes", null, "product_attributes");
            return this.ExecuteForGetIds<List<long>>(request, "product_attribute");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.product_attribute> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("product_attributes", "full", Filter, Sort, Limit, "product_attributes");
            return this.ExecuteForFilter<List<Entities.product_attribute>>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<long> GetIdsByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("product_attributes", "[id]", Filter, Sort, Limit, "product_attributes");
            List<PrestaSharp.Entities.FilterEntities.product_attribute> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.product_attribute>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all product attributes.
        /// </summary>
        /// <returns>A list of product attributes</returns>
        public List<Entities.product_attribute> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        public List<Entities.product_attribute> AddList(List<Entities.product_attribute> ProductAttributes)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.product_attribute ProductAttribute in ProductAttributes)
            {
                ProductAttribute.id = null;
                Entities.Add(ProductAttribute);
            }
            RestRequest request = this.RequestForAdd("product_attributes", Entities);
            return this.Execute<List<Entities.product_attribute>>(request);
        }
    }
}

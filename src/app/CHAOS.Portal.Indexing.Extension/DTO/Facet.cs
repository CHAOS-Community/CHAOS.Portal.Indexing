using CHAOS.Index;
using CHAOS.Portal.DTO.Standard;
using CHAOS.Serialization;
using CHAOS.Serialization.XML;

namespace CHAOS.Portal.Indexing.Extension.DTO
{
    public class Facet : Result, IFacet
    {
        public string DataType { get; set; }
        [Serialize]
        public string Value { get; set; }
        [Serialize]
        [SerializeXML(true)]
        public uint Count { get; set; }

        public Facet(IFacet facet)
        {
            DataType = facet.DataType;
            Value    = facet.Value;
            Count    = facet.Count;
        }       
    }
}

using System.Collections.Generic;
using System.Linq;
using CHAOS.Index;
using CHAOS.Portal.DTO.Standard;
using CHAOS.Serialization;
using CHAOS.Serialization.XML;

namespace CHAOS.Portal.Indexing.Extension.DTO
{
    public class FacetsResult : Result, IFacetsResult
    {
        [Serialize]
        [SerializeXML( true )]
        public string Value { get; set; }
        [Serialize]
        public IEnumerable<IFacet> Facets { get; set; }

        public FacetsResult( IFacetsResult result )
        {
            Value  = result.Value;
            Facets = result.Facets.Select( facet => new Facet( facet ) );
        }
    }
}

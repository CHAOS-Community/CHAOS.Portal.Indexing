using System.Collections.Generic;
using System.Linq;
using CHAOS.Index;
using CHAOS.Portal.DTO.Standard;
using CHAOS.Serialization;

namespace CHAOS.Portal.Indexing.Extension.DTO
{
    public class IndexResponse : Result
    {
        #region Properties

        [Serialize("FacetQueriesResult")]
        public IEnumerable<FacetsResult> FacetQueriesResult { get; set; }
        [Serialize("FacetFieldsResult")]
        public IEnumerable<FacetsResult> FacetFieldsResult { get; set; }

        #endregion
        #region Constructors

        public IndexResponse( IIndexResponse<UUIDResult> response )
        {
            FacetQueriesResult = response.FacetResult.FacetQueriesResult.Select( result => new FacetsResult( result ) );
            FacetFieldsResult  = response.FacetResult.FacetFieldsResult.Select( result => new FacetsResult( result ) );
        }

        #endregion
    }
}

using System.Linq;
using CHAOS.Index;
using CHAOS.Portal.Core;
using CHAOS.Portal.Core.Extension;
using CHAOS.Portal.DTO.Standard;

namespace CHAOS.Portal.Indexing.Extension
{
    public class Index : AExtension
    {
        #region Search

        public void Search( ICallContext callContext, IQuery query )
        {
            callContext.PortalResponse.PortalResult.GetModule( "Portal" ).AddResult( new ScalarResult( callContext.IndexManager.GetIndex( "CHAOS.MCM.Module.AMCMModule" ).Get<UUIDResult>( query ).FacetResult.FacetFieldsResult.First().Facets.Count() ) );
        }

        #endregion
    }
}

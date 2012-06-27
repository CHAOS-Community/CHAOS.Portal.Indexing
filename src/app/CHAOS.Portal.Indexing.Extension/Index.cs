using System.Linq;
using CHAOS.Index;
using CHAOS.Portal.Core;
using CHAOS.Portal.Core.Extension;
using CHAOS.Portal.DTO.Standard;
using CHAOS.Portal.Indexing.Extension.DTO;

namespace CHAOS.Portal.Indexing.Extension
{
    public class Index : AExtension
    {
        #region Search

        public void Search( ICallContext callContext, IQuery query )
        {
            var response = callContext.IndexManager.GetIndex( "CHAOS.MCM.Module.AMCMModule" ).Get<UUIDResult>( query );

            callContext.PortalResponse.PortalResult.GetModule( "Portal" ).AddResult( new IndexResponse( response ) );
        }

        #endregion
    }
}

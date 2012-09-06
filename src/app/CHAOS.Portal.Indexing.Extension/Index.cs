using System.Linq;
using CHAOS.Index;
using CHAOS.MCM.Module.Rights;
using CHAOS.Portal.Core;
using CHAOS.Portal.Core.Extension;
using CHAOS.Portal.DTO.Standard;
using CHAOS.Portal.Indexing.Extension.DTO;

namespace CHAOS.Portal.Indexing.Extension
{
	/// <summary>
	/// This module depends on CHAOS.MCM.Module.FolderModule
	/// </summary>
    public class Index : AExtension
    {
        #region Search

		/// <summary>
		/// Will search the index using the specified query.
		/// </summary>
		/// <param name="callContext"></param>
		/// <param name="query"></param>
        public IndexResponse Search( ICallContext callContext, IQuery query, UUID accessPointGUID )
        {
			if( accessPointGUID != null )
                query.Query = string.Format( "({0})+AND+(PubStart:[*+TO+NOW]+AND+PubEnd:[NOW+TO+*])", query.Query );
            else
            {
				var folders = callContext.PortalApplication.GetModule<MCM.Module.FolderModule>().Get( callContext, null, null, null, (uint) FolderPermissions.Read );

                query.Query = string.Format( "({0})+AND+({1})", query.Query, string.Join( "+OR+", folders.Select( folder => string.Format( "FolderTree:{0}", folder.ID ) ) ) );
            }

            var response = callContext.IndexManager.GetIndex( "CHAOS.MCM.Module.AMCMModule" ).Get<UUIDResult>( query );

            return new IndexResponse( response );
        }

        #endregion
    }
}

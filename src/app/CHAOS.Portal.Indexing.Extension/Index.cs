﻿using System.Linq;
using CHAOS.Index;
using CHAOS.MCM.Permission;
using CHAOS.Portal.Core;
using CHAOS.Portal.Core.Extension;
using CHAOS.Portal.DTO.Standard;
using CHAOS.Portal.Indexing.Extension.DTO;

namespace CHAOS.Portal.Indexing.Extension
{
	/// <summary>
	/// This module depends on CHAOS.MCM.Module.FolderModule
	/// </summary>
	[Extension("Index")]
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
                query.Query = string.Format("({0})+AND+(ap{1}_PubStart:[*+TO+NOW]+AND+ap{1}_PubEnd:[NOW+TO+*])", query.Query, accessPointGUID);
            else
            {
				var folders = callContext.PortalApplication.GetModule<MCM.Module.FolderModule>().Get( callContext, null, null, null, (uint) FolderPermission.Read );

                query.Query = string.Format( "({0})+AND+({1})", query.Query, string.Join( "+OR+", folders.Select( folder => string.Format( "FolderTree:{0}", folder.ID ) ) ) );
            }

            var response = callContext.IndexManager.GetIndex( "CHAOS.MCM.Module.AMCMModule" ).Get<UUIDResult>( query );

            return new IndexResponse( response );
        }

        #endregion
    }
}

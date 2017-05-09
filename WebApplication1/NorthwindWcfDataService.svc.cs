//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace WebApplication1
{
    public class NorthwindWcfDataService : DataService< NorthwindEntities >
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            //config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);

            config.UseVerboseErrors = true;

            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;

            // Grant only the rights needed to support the client application.
            config.SetEntitySetAccessRule("Orders", EntitySetRights.AllRead
                 | EntitySetRights.WriteMerge
                 | EntitySetRights.WriteReplace);
            config.SetEntitySetAccessRule("Order_Details", EntitySetRights.AllRead
                | EntitySetRights.AllWrite);
            config.SetEntitySetAccessRule("Customers", EntitySetRights.AllRead);

        }
    }
}

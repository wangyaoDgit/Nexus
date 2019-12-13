﻿namespace Aiursoft.Pylon.Models.API.UserAddressModels
{
    public class ViewAuditLogAddressModel : UserOperationAddressModel
    {
        /// <summary>
        /// Default is 10
        /// </summary>
        public int PageSize { get; set; } = 10;
        /// <summary>
        /// Starts from 0.
        /// </summary>
        public int PageNumber { get; set; } = 0;
    }
}

﻿using Aiursoft.Handler.Exceptions;
using Aiursoft.Handler.Models;
using Aiursoft.Scanner.Interfaces;
using Aiursoft.SDK.Models.Status;
using Aiursoft.SDK.Models.Status.EventAddressModels;
using Aiursoft.SDK.Models.Status.EventViewModels;
using Aiursoft.XelNaga.Models;
using Aiursoft.XelNaga.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Aiursoft.SDK.Services.ToStatusServer
{
    public class EventService : IScopedDependency
    {
        private readonly HTTPService _http;
        private readonly ServiceLocation _serviceLocation;

        public EventService(
            HTTPService http,
            ServiceLocation serviceLocation)
        {
            _http = http;
            _serviceLocation = serviceLocation;
        }

        public async Task<AiurProtocol> LogAsync(string accessToken, string message, string stackTrace, EventLevel eventLevel, string path)
        {
            var url = new AiurUrl(_serviceLocation.Status, "Event", "Log", new { });
            var form = new AiurUrl(string.Empty, new LogAddressModel
            {
                AccessToken = accessToken,
                Message = message,
                StackTrace = stackTrace,
                EventLevel = eventLevel,
                Path = path
            });
            var result = await _http.Post(url, form, true);
            var jResult = JsonConvert.DeserializeObject<AiurProtocol>(result);
            if (jResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(jResult);
            return jResult;
        }

        public async Task<ViewLogViewModel> ViewAsync(string accessToken)
        {
            var url = new AiurUrl(_serviceLocation.Status, "Event", "View", new ViewAddressModel
            {
                AccessToken = accessToken
            });
            var result = await _http.Get(url, true);
            var jResult = JsonConvert.DeserializeObject<ViewLogViewModel>(result);
            if (jResult.Code != ErrorType.Success)
                throw new AiurUnexceptedResponse(jResult);
            return jResult;
        }
    }
}

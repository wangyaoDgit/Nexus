using Aiursoft.Gateway.Data;
using Aiursoft.Gateway.Models;
using Aiursoft.SDK.Models.Developer;
using Aiursoft.SDK.Services.ToDeveloperServer;
using Aiursoft.XelNaga.Exceptions;
using Aiursoft.XelNaga.Interfaces;
using Aiursoft.XelNaga.Models;
using Aiursoft.XelNaga.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aiursoft.Gateway.Services
{

    public class GrantChecker : IScopedDependency
    {
        private readonly GatewayDbContext _dbContext;
        private readonly DeveloperApiService _developerApiService;
        private readonly ACTokenManager _tokenManager;

        public GrantChecker(
            GatewayDbContext context,
            DeveloperApiService developerApiService,
            ACTokenManager tokenManager)
        {
            _dbContext = context;
            _developerApiService = developerApiService;
            _tokenManager = tokenManager;
        }

        public async Task<GatewayUser> EnsureGranted(string accessToken, string userId, Func<App, bool> prefix)
        {
            var appid = _tokenManager.ValidateAccessToken(accessToken);
            var targetUser = await _dbContext.Users.Include(t => t.Emails).SingleOrDefaultAsync(t => t.Id == userId);
            var app = await _developerApiService.AppInfoAsync(appid);
            if (!_dbContext.LocalAppGrant.Any(t => t.AppID == appid && t.GatewayUserId == targetUser.Id))
            {
                throw new AiurAPIModelException(ErrorType.Unauthorized, "This user did not grant your app!");
            }
            if (prefix != null && !prefix(app.App))
            {
                throw new AiurAPIModelException(ErrorType.Unauthorized, "You app is not allowed to do that!");
            }
            return targetUser;
        }
    }
}
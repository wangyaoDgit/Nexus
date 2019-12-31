﻿using Aiursoft.XelNaga.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Aiursoft.Account.Services
{
    public class AccountSmsSender : ITransientDependency
    {
        private readonly string _smsAccountIdentification;
        private readonly string _smsAccountPassword;
        private readonly string _smsAccountFrom;
        private readonly ILogger _logger;

        public AccountSmsSender(
            IConfiguration configuration,
            ILogger<AccountSmsSender> logger)
        {
            _smsAccountFrom = configuration["SMSAccountFrom"];
            _smsAccountIdentification = configuration["SMSAccountIdentification"];
            _smsAccountPassword = configuration["SMSAccountPassword"];
            _logger = logger;
        }

        public Task SendAsync(string number, string message)
        {
            if (string.IsNullOrWhiteSpace(_smsAccountFrom))
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrWhiteSpace(_smsAccountIdentification))
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrWhiteSpace(_smsAccountPassword))
            {
                throw new ArgumentNullException();
            }
            try
            {
                TwilioClient.Init(_smsAccountIdentification, _smsAccountPassword);
                return MessageResource.CreateAsync(
                  to: new PhoneNumber(number),
                  from: new PhoneNumber(_smsAccountFrom),
                  body: message);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);
                return Task.CompletedTask;
            }
        }
    }
}

﻿using Core.Sms;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services.Sms
{
    public class SmsSender : ISmsSender
    {
        private readonly ILogger<SmsSender> _logger;
        private readonly SmsConfiguration _smsConfig;
        public SmsSender(SmsConfiguration smsConfig, ILogger<SmsSender> logger)
        {
            _smsConfig = smsConfig;
            _logger = logger;
        }

        public Task SendSmsAsync(string number, string message)
        {
            // https://www.smscountry.com/Developers.aspx?code=httpjava&sft=1
            //Console.WriteLine("Sending SMS...");

            SMSCAPI obj = new SMSCAPI();
            string strPostResponse;
            strPostResponse = obj.SendSMS(_smsConfig.Username, _smsConfig.Password, number, message);
            //Console.WriteLine("Server Response " + strPostResponse);

            _logger.LogInformation($"SMS sent to {number}...");
            return Task.CompletedTask;
        }
    }
}

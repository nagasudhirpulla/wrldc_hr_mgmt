﻿using System.Threading.Tasks;

namespace Core.Sms
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}

﻿using Template_Web.Accelerator.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Web.Accelerator.Services.Email
{
    public interface IEmailService
    {

        public Task<bool> SendEmailAsync(EmailDataModel emailData);
    }
}

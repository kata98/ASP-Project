using ASPBlog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPBlog.Application.Emails
{
    public interface IEmailSender
    {
        void Send(MessageDto message);
    }
}

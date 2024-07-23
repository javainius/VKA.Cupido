using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKA.Cupido.Entities;
using VKA.Cupido.Models;

namespace VKA.Cupido.Application.Mappers
{
    public static class EmailMapper
    {
        public static EmailModel EmailEntityToEmailModel(this EmailEntity entity)
        {
            return new EmailModel
            {
                SenderEmail = entity.SenderEmail,
                SenderName = entity.SenderName,
                RecipientEmail = entity.RecipientEmail,
                RecipientName = entity.RecipientName,
                Subject = entity.Subject,
                HtmlContent = entity.HtmlContent,
                PlainTextContent = entity.PlainTextContent,
            };
        }

        public static EmailEntity EmailModelToEmailEntity(this EmailModel model)
        {
            return new EmailEntity
            {
                SenderEmail = model.SenderEmail,
                SenderName = model.SenderName,
                RecipientEmail = model.RecipientEmail,
                RecipientName = model.RecipientName,
                Subject = model.Subject,
                HtmlContent = model.HtmlContent,
                PlainTextContent = model.PlainTextContent,
            };
        }
    }
}

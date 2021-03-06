﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialHeroes.Domain.Core.Commands;
using SocialHeroes.Domain.Core.Interfaces;
using SocialHeroes.Domain.Core.Notifications;
using System.Linq;

namespace SocialHeroes.WebApi.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        protected ApiController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected bool IsValidOperation() => (!_notifications.HasNotifications());

        protected new IActionResult Response(object result)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = (result as ICommandResult)?.Data ?? result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }
    }
}

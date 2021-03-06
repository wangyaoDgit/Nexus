﻿using Aiursoft.Pylon.Services;
using Aiursoft.XelNaga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Aiursoft.Pylon.Attributes
{
    /// <summary>
    /// Request the signed in token or throw a NotAiurSignedInException
    /// </summary>
    public class AiurForceAuth : ActionFilterAttribute
    {
        private string _preferController { get; }
        private string _preferAction { get; }
        private bool? _justTry { get; } = false;
        private bool _preferPageSet { get; }
        private bool _register { get; }
        private bool _directlyReject { get; }

        private bool _hasAPreferPage => (!string.IsNullOrEmpty(_preferController)
            && !string.IsNullOrEmpty(_preferAction))
            || _preferPageSet;

        private string _preferPage
        {
            get
            {
                if (string.IsNullOrEmpty(_preferController) && string.IsNullOrEmpty(_preferAction))
                {
                    return "/";
                }
                return new AiurUrl(string.Empty, _preferController, _preferAction, new { }).ToString();
            }
        }

        public AiurForceAuth(bool directlyReject = false)
        {
            _directlyReject = directlyReject;
        }

        public AiurForceAuth(string preferController, string preferAction, bool justTry, bool register = false)
        {
            _preferController = preferController;
            _preferAction = preferAction;
            _justTry = justTry ? true : (bool?)null;
            _preferPageSet = true;
            _register = register;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (!(context.Controller is Controller controller))
            {
                // If goes here, it seems we are not using it on a controller.
                throw new InvalidOperationException();
            }
            var show = context.HttpContext.Request.Query[Values.DirectShowString.Key];
            //Not signed in
            if (!controller.User.Identity.IsAuthenticated)
            {
                if (_hasAPreferPage)
                {
                    // Just redirected back, leave him here.
                    if (show == Values.DirectShowString.Value && _justTry == true)
                    {
                        return;
                    }
                    // Try him.
                    context.Result = Redirect(context, _preferPage, _justTry, _register);
                }
                // Directly response a 403
                else if (_directlyReject)
                {
                    context.Result = new UnauthorizedResult();
                }
                // Don't have a prefer page, force him to sign in.
                else
                {
                    context.Result = Redirect(context, controller.Request.Path.Value, justTry: null, register: _register);
                }
            }
            //Signed in, let him go to preferred page directly.
            else if (_hasAPreferPage && !controller.Request.Path.Value.ToLower().StartsWith(_preferPage.ToLower()))
            {
                context.HttpContext.Response.Redirect(_preferPage);
            }
            //Signed in and no preferred page, Display current page.
            else
            {
            }
        }

        private RedirectResult Redirect(ActionExecutingContext context, string page, bool? justTry, bool register)
        {
            var urlConverter = context.HttpContext.RequestServices.GetService<UrlConverter>();
            string serverPosition = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}";
            string url = urlConverter.UrlWithAuth(serverPosition, page, justTry, register);
            return new RedirectResult(url);
        }
    }
}

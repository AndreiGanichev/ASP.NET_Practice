using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;

namespace ASP.NET_Practice.Auth
{
    /// <summary>
    /// Реализует функционал авторизации
    /// </summary>
    public class CustomAuthentication : IAuthentication
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private const string _cookieName = "__AUTH_COOKIE";
        private IUserRepository _repository;
        private IPrincipal _currentUser;

        public CustomAuthentication(IUserRepository repository)
        {
            _repository = repository;
        }

        #region IAuthentication 
        public IPrincipal CurrentUser
        {
            get
            {
                if (_currentUser != null)
                {
                    return _currentUser;
                }

                try
                {
                    var authCookie = HttpContext.Request.Cookies[_cookieName];

                    if (authCookie != null && !string.IsNullOrWhiteSpace(authCookie.Value))
                    {
                        var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                        _currentUser = new UserPrincipal(ticket.Name, _repository);
                    }
                    else
                    {
                        _currentUser = new UserPrincipal(null, null);
                    }
                }
                catch (Exception e)
                {
                    _logger.Error($"Failed authentication: {e.Message}");
                    _currentUser = new UserPrincipal(null, null);
                }

                return _currentUser;
            }
        }

        public HttpContext HttpContext { get; set; }

        public User Login(string login, string password, bool isPersistent)
        {
            var user = _repository.Login(login, password);

            if (user != null)
            {
                var authCookie = CreateCookie(login, password, isPersistent);
                HttpContext.Response.SetCookie(authCookie);
            }

            return user;
        }

        public void LogOut()
        {
            var authCookie = HttpContext.Response.Cookies[_cookieName];

            if(authCookie != null)
            {
                authCookie.Value = string.Empty;
            }
        }
        #endregion

        private HttpCookie CreateCookie(string login, string password, bool isPersistent)
        {
            var ticket = new FormsAuthenticationTicket(
                1,
                login,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                isPersistent,
                FormsAuthentication.FormsCookiePath);

            var encTicket = FormsAuthentication.Encrypt(ticket);
            var authCookie = new HttpCookie(_cookieName, encTicket)
            {
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            return authCookie;
        }
    }
}
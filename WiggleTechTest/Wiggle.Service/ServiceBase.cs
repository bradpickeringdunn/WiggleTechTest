using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.ErrorHandling;
using Backbone.Logging;
using Backbone.Repository;
using Backbone.Services.Requests;
using Backbone.Services.Results;

namespace Wiggle.Service
{
    public class ServiceBase
    {
        public NotificationCollection Notifications { get; set; }
        private ILogger Logger { get; set; }

        public ServiceBase(ILogger logger)
        {
            Logger = logger;
        }

        public T Execute<T>(Func<T> request) where T : class, new()
        {
            var action = new T();

            try
            {
                return request.Invoke();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                Notifications.Add("Generic service exception");
            }

            return action;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Logging;
using Backbone.Services.Results;

namespace Wiggle.Service.Adapter
{
    public class BaseServiceCall
    {
        private ILogger Logger { get; set; }

        public BaseServiceCall(ILogger logger)
        {
            Logger = logger;
        }

        //public T TryExecute<T>(Action<T> action) where T : GenericServiceResult, new()
        //{
        //    var stopwatch = new Stopwatch();
        //    var result = new T();

        //    try
        //    {
        //        stopwatch.Start();

        //        result = action();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex);
        //        result.Notifications.Add("A generic service error occurred.");
        //        stopwatch.Start();
        //    }

        //    return result;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Wiggle.Localization
{
    /// <summary>
    /// Provedes access to recources
    /// </summary>
    public class ContentString
    {        
        /// <summary>
        /// Get resource errors.
        /// </summary>
        public string GetError(string error)
        {
            return Errors.ResourceManager.GetString(error);
        }

    }
}

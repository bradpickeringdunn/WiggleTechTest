using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Wiggle.Localization
{
    public class ContentString
    {
        const char keySplit = '_';

        public static ContentString Initialize
        {
            get
            {
                return new ContentString();
            }
        }
        static Dictionary<string,Assembly> ResourceFiles;

        private string DefaultLanguage = "en";

        public ContentString()
        {
            ResourceFiles = new Dictionary<string, Assembly>();
            ResourceFiles.Add("Errors", Assembly.GetExecutingAssembly());
            
        }

        public string GetError(string error)
        {
            return Errors.ResourceManager.GetString(error);
            //return ResolveResource(error);
        }

        private string ResolveResource(string keyValue){

            var keyPair = keyValue.Split(keySplit);
            string resourceName = keyPair.First();
            var rm = GetResourceManager(resourceName);
            return rm.GetString(keyValue);
        
        }

        private ResourceManager GetResourceManager(string key)
        {            
            Assembly resourcePath = null;
            ResourceFiles.TryGetValue(key, out resourcePath);

            var rm = new ResourceManager(key, resourcePath);

            return rm;
        }
    }
}

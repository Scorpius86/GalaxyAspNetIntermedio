using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.Session.Utility
{
    public class ApplicationData
    {
        private readonly IDictionary<string, string> _applicationData;
        public ApplicationData()
        {
            _applicationData = new Dictionary<string, string>();
        }

        public void Set<T>(string key, T value)
        {
            if (_applicationData.Keys.Contains(key))
            {
                _applicationData[key] = JsonConvert.SerializeObject(value);
            }
            else
            {
                _applicationData.Add(key, JsonConvert.SerializeObject(value));
            }
        }

        public T Get<T>(string key)
        {
            string value = _applicationData[key];

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
        public ICollection<string> Keys
        {
            get { return _applicationData.Keys; }
        }

    }
}

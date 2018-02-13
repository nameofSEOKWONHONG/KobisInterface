using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieInfoGather
{
    /// <summary>
    /// 사용시 assemblyinfo 에 다음 구문을 추가 [assembly: InternalsVisibleTo("MovieYes24Library")]
    /// dynamic 형을 전달 하기위한 설정임.
    /// </summary>
    public class ParameterHelper
    {
        private Dictionary<string, object> _map = new Dictionary<string, object>();

        public ParameterHelper() { }

        public ParameterHelper(params dynamic[] kvps)
        {
            foreach (var item in kvps)
            {
                _map.Add(item.Key, item.Value);
            }
        }

        public ParameterHelper(params KeyValuePair<string, object>[] kvps)
        {
            foreach (var item in kvps)
            {
                _map.Add(item.Key, item.Value);
            }
        }

        public ParameterHelper(Dictionary<string, object> kvps)
        {
            _map = kvps;
        }

        public ParameterHelper Add(string key, object value)
        {
            _map.Add(key, value);

            return this;
        }

        public NameValueCollection ToNameValueCollection()
        {
            var nvc = new NameValueCollection();

            foreach (var kvp in _map)
            {
                string value = null;
                if (kvp.Value != null)
                {
                    value = kvp.Value.ToString();
                }

                nvc.Add(kvp.Key.ToString(), value);
            }

            return nvc;
        }

        public JObject ToJObject()
        {
            return JObject.FromObject(_map);
        }

        public string ToGetParam()
        {
            string ret = "";
            int idx = 0;
            foreach (dynamic kvp in _map)
            {
                if (idx == 0)
                    ret += kvp.Key + "=" + kvp.Value;
                else
                    ret += "&" + kvp.Key + "=" + kvp.Value;

                idx++;
            }

            return ret;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(_map);
        }

        public string ToJson<TEntity>(TEntity entity)
        {
            return JsonConvert.SerializeObject(entity);
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MovieInfoGather
{
    public class RequestHelper
    {
        public RequestHelper()
        {
            
        }

        public async Task<TEntity> GetRequestAsync<TEntity>(string url, string param)
        {
            TEntity entity = default(TEntity);

            using(var client = new HttpClient())
            {
                try
                {
                    var resultUrl = url + "?" + param;
                    var response = await client.GetAsync(resultUrl);

                    response.EnsureSuccessStatusCode();

                    if(response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        entity = JsonConvert.DeserializeObject<TEntity>(result);
                    }
                }
                catch(Exception e)
                {
                    
                }
                finally
                {

                }
            }

            return entity;
        }
    }
}

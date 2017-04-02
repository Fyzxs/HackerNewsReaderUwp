using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    public class ItemJson
    {
        [JsonProperty("id")]
        public long Id;
    }
}

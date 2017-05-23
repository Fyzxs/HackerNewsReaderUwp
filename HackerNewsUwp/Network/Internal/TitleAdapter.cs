using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    public class TitleAdapter : INetworkAdapter<Title>
    {
        public Title FromRawContent(string rawContent)
        {
            return new Title(JsonConvert.DeserializeObject<TitleJson>(rawContent).Title);
        }
    }
}
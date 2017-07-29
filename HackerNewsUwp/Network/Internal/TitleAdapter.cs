using Newtonsoft.Json;

namespace HackerNewsUwp.Network.Internal
{
    public class TitleAdapter : INetworkAdapter<Title>
    {
        public Title FromRawContent(string rawContent)
        {
            string rawString = JsonConvert.DeserializeObject<TitleJson>(rawContent).Title;
            return rawString == null
                ? Title.NullTitle
                : new Title(rawString);
        }
    }
}
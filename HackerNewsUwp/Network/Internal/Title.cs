using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Network.Internal
{
    public class Title
    {
        private readonly string _title;

        public Title(string title)
        {
            _title = title;
        }

        public void TitleInto(ISetText item)
        {
            item.Text = _title;
        }
    }
}

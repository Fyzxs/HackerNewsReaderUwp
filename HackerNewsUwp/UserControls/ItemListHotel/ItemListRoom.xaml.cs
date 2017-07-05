using HackerNewsUwp.Network;
using HackerNewsUwp.UserControls.ItemHotel;
using System;
using Windows.ApplicationModel;
using Windows.UI.Core;

namespace HackerNewsUwp.UserControls.ItemListHotel
{
    public sealed partial class ItemListRoom
    {
        public ItemListRoom()
        {
            InitializeComponent();
        }

        private async void Grid_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (DesignMode.DesignModeEnabled) return;

            HackerNewsAccess hackerNewsAccess = new HackerNewsAccess();
            Items items = (await hackerNewsAccess.TopStories()).Body();

            for (int i = 0; i < items.Count(); i++)
            {
                int index = i;
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    ItemRoom itemRoom = new ItemRoom();
                    items.ProvideId(index, itemRoom);
                    MyItemList.Items?.Insert(index, itemRoom);
                });
            }
        }

    }
}

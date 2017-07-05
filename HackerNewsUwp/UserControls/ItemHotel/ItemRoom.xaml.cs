using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using System;

namespace HackerNewsUwp.UserControls.ItemHotel
{
    public sealed partial class ItemRoom : ItemElevator.IRoom, Items.IItemIdConsumer
    {
        private ItemId _itemId;

        public ItemRoom()
        {
            InitializeComponent();
        }

        public ISetText Title() => TxtTitle;

        public ISetText Author() => TxtAuthor;

        private void Grid_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (_itemId == null) { throw new InvalidOperationException("ItemId must be set before grid load"); };
            ItemElevator elevator = new ItemElevator(_itemId, new ItemConcierge(), new HackerNewsAccess());
            elevator.Load(this);
        }

        public void ConsumeItemId(ItemId itemId)
        {
            if (_itemId != null) { throw new InvalidOperationException("ItemId is Immutable"); }
            _itemId = itemId;
        }
    }
}

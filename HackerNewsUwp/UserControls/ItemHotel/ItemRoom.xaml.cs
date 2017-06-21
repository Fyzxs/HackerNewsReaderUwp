// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;

namespace HackerNewsUwp.UserControls.ItemHotel
{
    public sealed partial class ItemRoom : ItemElevator.IRoom
    {
        public ItemRoom()
        {
            InitializeComponent();
        }


        public ISetText Title()
        {
            return TxtTitle;
        }

        public ISetText Author()
        {
            return TxtAuthor;
        }

        private void Grid_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ItemElevator elevator = new ItemElevator(new ItemId(8863), new ItemConcierge(), new HackerNewsAccess());
            elevator.Load(this);
        }
    }
}

using System;
using HackerNewsUwp.Network;
using HackerNewsUwp.Network.Internal;
using HackerNewsUwp.UserControls;

namespace HackerNewsUwp.Screens.MainPageHotel
{
    public class MainPageElevator :  MainPageConcierge.IElevator
    {
        private readonly IMainPageView _mainPageView;
        private readonly MainPageConcierge _mainPageConcierge;

        public interface IMainPageView
        {
            ISetText Title();
        }
        
        public MainPageElevator(IMainPageView mainPageView, MainPageConcierge mainPageConcierge = null)
        {
            _mainPageView = mainPageView;
            _mainPageConcierge = mainPageConcierge ?? new MainPageConcierge(this, new HackerNewsAccess());
        }
        public void DisplayTitle(string title) => _mainPageView.Title().Text = title;


        public void DisplayItem(Item item)
        {
            item.TitleInto(_mainPageView.Title());
        }
        public void DisplayItems(Items items)
        {
            throw new NotImplementedException("Where's the Kaboom? I wanted a big kaboom");
        }

        public async void ViewLoaded()
        {
            await _mainPageConcierge.LoadItem(new ItemId(14_448_404));
        }
    }
}

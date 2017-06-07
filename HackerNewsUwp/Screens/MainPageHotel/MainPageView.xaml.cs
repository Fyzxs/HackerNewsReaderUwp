﻿using System.Threading.Tasks;
using HackerNewsUwp.UserControls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HackerNewsUwp.Screens.MainPageHotel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPageView : MainPageElevator.IMainPageView
    {
        private readonly MainPageElevator _mainPageElevator;

        public MainPageView()
        {
            this.InitializeComponent();
            _mainPageElevator = new MainPageElevator(this);
        }
        
        ISetText MainPageElevator.IMainPageView.Title() => TxtTitle;

        public ItemHotel.ILoadItem ItemControl => IvItem;

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _mainPageElevator.ViewLoaded();
        }
    }
}

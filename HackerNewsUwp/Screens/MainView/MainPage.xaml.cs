using Windows.UI.Xaml.Controls;
using HackerNewsUwp.UserControls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HackerNewsUwp.Screens.MainView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPageView : MainPageBridge.IMainPageView
    {
        public MainPageView()
        {
            this.InitializeComponent();
        }

        IText MainPageBridge.IMainPageView.Title()
        {
            return TxtTitle;
        }

        public IText Count()
        {
            throw new System.NotImplementedException();
        }
    }
}

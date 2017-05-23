using HackerNewsUwp.UserControls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HackerNewsUwp.Screens.MainView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPageView : MainPageElevator.IMainPageView
    {
        public MainPageView()
        {
            this.InitializeComponent();
        }

        ISetText MainPageElevator.IMainPageView.Title()
        {
            return TxtTitle;
        }

        public ISetText Count()
        {
            throw new System.NotImplementedException();
        }
    }
}

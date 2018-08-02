using Xamarin.Forms;

namespace XamFormsTalk.Page
{
    public class MainTabPage : TabbedPage
    {
        public MainTabPage()
        {
            Children.Add(new MainPage());
            Children.Add(new CameraPage());
        }
    }
}


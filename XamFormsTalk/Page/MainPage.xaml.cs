using Xamarin.Forms;

namespace XamFormsTalk.Page
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnItalicButtonToggled(object sender, ToggledEventArgs args)
        {
            if (args.Value)
            {
                WelcomeLabel.FontAttributes |= FontAttributes.Italic;
            }
            else
            {
                WelcomeLabel.FontAttributes &= ~FontAttributes.Italic;
            }
        }
    }
}

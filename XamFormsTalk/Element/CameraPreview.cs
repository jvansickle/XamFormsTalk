using Xamarin.Forms;
using XamFormsTalk.Contracts;

namespace XamFormsTalk.Element
{
    public class CameraPreview : View
    {
        public static readonly BindableProperty CameraProperty =
            BindableProperty.Create(nameof(Camera),
                                    typeof(CameraOptions),
                                    typeof(CameraPreview),
                                    CameraOptions.Rear);

        public CameraOptions Camera
        {
            get { return (CameraOptions)GetValue(CameraProperty); }
            set { SetValue(CameraProperty, value); }
        }
    }
}

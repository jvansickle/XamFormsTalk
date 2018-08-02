using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using XamFormsTalk.Element;
using XamFormsTalk.macOS.Control;
using XamFormsTalk.macOS.Renderer;

[assembly: ExportRenderer(typeof(CameraPreview), typeof(CameraPreviewRenderer))]
namespace XamFormsTalk.macOS.Renderer
{
    public class CameraPreviewRenderer : ViewRenderer<CameraPreview, NSCameraPreview>
    {
        NSCameraPreview nsCameraPreview;

        protected override void OnElementChanged(ElementChangedEventArgs<CameraPreview> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                nsCameraPreview = new NSCameraPreview();
                SetNativeControl(nsCameraPreview);
            }
            if (e.OldElement != null)
            {
                // Unsubscribe
                nsCameraPreview.Tapped -= OnCameraPreviewTapped;
            }
            if (e.NewElement != null)
            {
                // Subscribe
                nsCameraPreview.Tapped += OnCameraPreviewTapped;
            }
        }

        void OnCameraPreviewTapped(object sender, EventArgs e)
        {
            if (nsCameraPreview.IsPreviewing)
            {
                nsCameraPreview.CaptureSession.StopRunning();
                nsCameraPreview.IsPreviewing = false;
            }
            else
            {
                nsCameraPreview.CaptureSession.StartRunning();
                nsCameraPreview.IsPreviewing = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.CaptureSession.Dispose();
                Control.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

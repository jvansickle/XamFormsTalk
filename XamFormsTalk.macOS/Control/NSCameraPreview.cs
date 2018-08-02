using System;
using System.Linq;
using AppKit;
using AVFoundation;
using CoreGraphics;
using Foundation;
using XamFormsTalk.Contracts;

namespace XamFormsTalk.macOS.Control
{
    public class NSCameraPreview : NSView
    {
        AVCaptureVideoPreviewLayer previewLayer;

        public event EventHandler<EventArgs> Tapped;

        public AVCaptureSession CaptureSession { get; private set; }

        public bool IsPreviewing { get; set; }

        public NSCameraPreview()
        {
            IsPreviewing = false;
            Initialize();
        }

        public override void DrawRect(CGRect dirtyRect)
        {
            base.DrawRect(dirtyRect);
            previewLayer.Frame = dirtyRect;
        }

        public override void MouseDown(NSEvent theEvent)
        {
            base.MouseDown(theEvent);
            OnTapped();
        }

        protected virtual void OnTapped()
        {
            Tapped?.Invoke(this, new EventArgs());
        }

        void Initialize()
        {
            CaptureSession = new AVCaptureSession();
            previewLayer = new AVCaptureVideoPreviewLayer(CaptureSession)
            {
                Frame = Bounds,
                VideoGravity = AVLayerVideoGravity.ResizeAspectFill
            };

            var videoDevices = AVCaptureDevice.DevicesWithMediaType(AVMediaType.Video);
            var device = videoDevices.FirstOrDefault();

            if (device == null)
            {
                return;
            }

            var input = new AVCaptureDeviceInput(device, out NSError error);
            CaptureSession.AddInput(input);
            WantsLayer = true;
            Layer.AddSublayer(previewLayer);
            CaptureSession.StartRunning();
            IsPreviewing = true;
        }
    }
}

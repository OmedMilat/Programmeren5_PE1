using System;
using Xamarin.Forms;

namespace B4.PE1.OmedMilat
{//Meeste van dit gedeelte is van internet gehaald.
    public class PinchToZoomContainer : ContentView
    {
        double currentScale = 1;
        double startScale = 1;
        double xOffset = 0;
        double yOffset = 0;
        double x, y;

        public PinchToZoomContainer()
        {
            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += OnPinchUpdated;
            GestureRecognizers.Add(pinchGesture);

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += TapGesture_Tapped;
            tapGesture.NumberOfTapsRequired = 2;
            GestureRecognizers.Add(tapGesture);

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {

            if (e.StatusType == GestureStatus.Running && Content.Scale != 1)
            {
                // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                Content.TranslationX = Math.Max(Math.Min(0, x + e.TotalX), -Math.Abs(Content.Width - App.ScreenWidth));
                Content.TranslationY = Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(Content.Height - App.ScreenHeight));
            }

            if (e.StatusType == GestureStatus.Completed)
            {
                // Store the translation applied during the pan
                x = Content.TranslationX;
                y = Content.TranslationY;
            }


        }

        void TapGesture_Tapped(object sender, EventArgs e)
        {
            if (Content.Scale == 1)
            {
                Content.Scale = 1.5;
            }
            else
            {
                Content.TranslationX=0;
                Content.TranslationY=0;
                Content.Scale = 1.0;
            }
        }

        void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Status == GestureStatus.Started)
            {
                // Store the current scale factor applied to the wrapped user interface element,
                // and zero the components for the center point of the translate transform.
                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }
            if (e.Status == GestureStatus.Running)
            {
                // Calculate the scale factor to be applied.
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the X pixel coordinate.
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the Y pixel coordinate.
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                // Calculate the transformed element pixel coordinates.
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);

                // Apply translation based on the change in origin.
                Content.TranslationX = targetX.Clamp(-Content.Width * (currentScale - 1), 0);
                Content.TranslationY = targetY.Clamp(-Content.Height * (currentScale - 1), 0);

                // Apply scale factor
                Content.Scale = currentScale;
            }
            if (e.Status == GestureStatus.Completed)
            {
                // Store the translation delta's of the wrapped user interface element.
                xOffset = Content.TranslationX;
                yOffset = Content.TranslationY;
            }
        }
    }
}
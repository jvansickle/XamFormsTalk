using System;
using Xamarin.Forms;

namespace XamFormsTalk.Element
{
    public class ToggleButton : Button
    {
        public event EventHandler<ToggledEventArgs> Toggled;

        public static readonly BindableProperty IsToggledProperty =
            BindableProperty.Create(nameof(IsToggled),
                                    typeof(bool),
                                    typeof(ToggleButton),
                                    false,
                                    BindingMode.TwoWay,
                                    propertyChanged: OnIsToggledChanged);

        public bool IsToggled
        {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }

        public ToggleButton()
        {
            Clicked += OnClicked;
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            VisualStateManager.GoToState(this, "ToggledOff");
        }

        void OnClicked(object sender, EventArgs args)
        {
            IsToggled ^= true;
        }

        static void OnIsToggledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ToggleButton toggleButton = (ToggleButton)bindable;
            bool isToggled = (bool)newValue;

            toggleButton.Toggled?.Invoke(toggleButton, new ToggledEventArgs(isToggled));

            VisualStateManager.GoToState(toggleButton, isToggled ? "ToggledOn" : "ToggledOff");
        }
    }
}

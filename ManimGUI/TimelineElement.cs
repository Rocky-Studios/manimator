using Microsoft.Maui.Controls;
using System.Globalization;

namespace ManimGUI
{
    public class TimelineElement : ContentView
    {
        // Example custom properties
        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(string), typeof(TimelineElement), "Manim Type");

        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly BindableProperty LengthSecondsProperty =
            BindableProperty.Create(nameof(LengthSeconds), typeof(float), typeof(TimelineElement), 1f, propertyChanged: OnLengthSecondsChanged);

        public float LengthSeconds
        {
            get { return (float)GetValue(LengthSecondsProperty); }
            set { SetValue(LengthSecondsProperty, value); }
        }

        public TimelineElement()
        {
            var mainLayout = new ContentView
            {
                BackgroundColor = Color.FromRgb(0, 200, 80),
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Start,
                HeightRequest = 50 // Example height
            };

            // Bind width of mainLayout to LengthSeconds property
            mainLayout.SetBinding(WidthRequestProperty, new Binding(nameof(LengthSeconds), source: this, converter: new MultiplyConverter()));

            Content = mainLayout;
        }
        // Property changed callback for LengthSeconds
        private static void OnLengthSecondsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // Ensure mainLayout is updated when LengthSeconds changes
            var element = bindable as TimelineElement;
            if (element != null)
            {
                var mainLayout = element.Content as ContentView;
                if (mainLayout != null)
                {
                    mainLayout.WidthRequest = element.LengthSeconds * 100;
                }
            }
        }

        // Converter class to multiply value by 100
        public class MultiplyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is float lengthSeconds)
                {
                    return lengthSeconds * 100;
                }
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}

using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace floatingbutton
{
    public class demopage : ContentPage
    {
        public demopage()
        {
            var imgAdd = new Image
            {
                MinimumWidthRequest = 50,
                MinimumHeightRequest = 50,
                Source = ImageSource.FromFile("addon.png"),
                HorizontalOptions = LayoutOptions.End
            };

            var dataList = new List<string>
            {
                "Ding dong, the witch is dead",
                "When you walk through a storm",
                "I love rock and roll",
                "D'oh!",
                "People say on the day of victory, no fatigue is felt\n" +
                "Garbo, it's you that has the power that makes ev'ry man's heart melt\n" +
                "They say that, when the heart is a fire sparks fly out of the cage\n" +
                "But beauty is like a good wine, the taste is sweeter with age",
                "No man can guess in cold blood what he might do in passion\n" +
                "But the things that he deplores today are tomorrow's latest fashion\n" +
                "Serving one's own passion is the greatest slavery\n" +
                "But if in wanting you I become your slave, I intend no bravery",
                "Remember you're a womble"
            };

            if (Device.OS == TargetPlatform.iOS)
                this.Padding = new Thickness(0, 20, 0, 0);
            if (Device.OS != TargetPlatform.iOS)
                this.BackgroundColor = Color.White;

            var listView = new ListView()
            {
                HasUnevenRows = true,
                ItemsSource = dataList, 
                ItemTemplate = new DataTemplate(typeof(LyricViewCell))
            };

            var layOut = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    listView
                }
            };

            Content = layOut;

            AbsoluteLayout.SetLayoutFlags(imgAdd, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(imgAdd, new Rectangle(0, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            layOut.Children.Add(imgAdd);
        }
    }

    public class LyricViewCell : ViewCell
    {
        public LyricViewCell()
        {
            var label = new Label()
            {
                Text = "lyric",
                Font = Font.SystemFontOfSize(NamedSize.Default),
                TextColor = Color.Blue
            };
            label.SetBinding(Label.TextProperty, new Binding("."));

            View = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(12, 8),
                Children = { label }
            };
        }
    }
}



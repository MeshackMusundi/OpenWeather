using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace OpenWeatherCS.Utils
{
    class SelectAllTextBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewKeyUp += AssociatedObject_PreviewKeyUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewKeyUp -= AssociatedObject_PreviewKeyUp;
        }

        private void AssociatedObject_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AssociatedObject.SelectAll();
            }
        }
    }
}

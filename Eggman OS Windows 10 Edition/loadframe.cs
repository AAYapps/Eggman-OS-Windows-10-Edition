using Windows.UI.Xaml.Controls;

namespace Eggman_OS_Windows_10_Edition
{
    class loadframe
    {
        public void load(Page currentpage ,Page frame)
        {
            currentpage.Frame.Navigate(frame.GetType());
        }
    }
}

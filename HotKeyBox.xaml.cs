using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace FastHotKeyForWPF
{
    [HotKeyComponent]
    public partial class HotKeyBox : UserControl
    {
        public HotKeyBox()
        {
            InitializeComponent();
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("MyProperty", typeof(CornerRadius), typeof(HotKeyBox), new PropertyMetadata(default(CornerRadius)));

        private void TextBox_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is TextBox box)
            {
                box.Focusable = true;
                box.Focus();
            }
        }

        private void TextBox_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is TextBox box)
            {
                box.Focusable = false;
                System.Windows.Input.Keyboard.ClearFocus();
            }
        }
    }
}

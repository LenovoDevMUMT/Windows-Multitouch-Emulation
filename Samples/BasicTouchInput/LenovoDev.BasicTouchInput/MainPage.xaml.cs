
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace LenovoDev.BasicTouchInput
{
    public sealed partial class MainPage : Page
    {
        private readonly Color _colorLenovoRed = Color.FromArgb(0xff, 0xee, 0x31, 0x24);
        private readonly Color _colorGrey = Color.FromArgb(0xff, 0xcc, 0xcc, 0xcc);

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ONLY TRIGGERED ONCE WHEN CLICKING OR TOUCHING THE BORDER AREA
        /// Mouse: Occurs on mouse hover or pressed!
        /// Touch: Occurs only when touching the canvas.
        /// Digitizer: Hover or writing with the pen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderPressed_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            BorderPressed.Background = new SolidColorBrush(_colorLenovoRed);
            TextBlockPressed.Text = "Pressed";
        }

        /// <summary>
        ///  ONLY TRIGGERED ONCE WHEN RELEASING LEFT MOUSE BUTTON OR REMOVING FINGERS WHILE IN THE BORDER AREA
        /// Mouse: Occurs on mouse hover or pressed!
        /// Touch: Occurs only when touching the canvas.
        /// Digitizer: Hover or writing with the pen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderPressed_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            BorderPressed.Background = new SolidColorBrush(_colorGrey);
            TextBlockPressed.Text = "Released";
        }

        /// <summary>
        /// Mouse: Occurs on mouse hover or pressed!
        /// Touch: Occurs only when touching the canvas.
        /// Digitizer: Hover or writing with the pen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderEntered_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            BorderEntered.Background = new SolidColorBrush(_colorLenovoRed);
            TextBlockEntered.Text = "Entered";
        }

        /// <summary>
        /// Mouse: Occurs on mouse hover or pressed!
        /// Touch: Occurs only when touching the canvas.
        /// Digitizer: Hover or writing with the pen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderEntered_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            BorderEntered.Background = new SolidColorBrush(_colorGrey);
            TextBlockEntered.Text = "Exited";
        }

        /// <summary>
        /// MULTIPLE TIMES, VERY SENSITIVE!
        /// Mouse: Occurs on mouse moved when hovering above the canvas or while the left mouse button is pressed.
        /// Touch: When moving the finger over the canvas while your finger is pressing.
        /// Digitizer: Moving while hovering with the pen above the canvas or while writing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasMoved_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            // get the current point
            var ptr = e.GetCurrentPoint((Canvas)sender);

            // add the point to draw the line
            // to use with multi-touch, get the pointer id and create a different polyline for every pointer id.
            PolylineMoved.Points.Add(ptr.Position);
        }
    }
}

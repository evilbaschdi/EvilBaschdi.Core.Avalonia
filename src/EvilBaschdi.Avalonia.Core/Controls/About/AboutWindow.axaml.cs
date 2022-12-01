using Avalonia.Controls;

namespace EvilBaschdi.Avalonia.Core.Controls.About
{
    /// <inheritdoc />
    public partial class AboutWindow : Window
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public AboutWindow()
        {
            InitializeComponent();

            IHandleOsDependentTitleBar handleOsDependentTitleBar = new HandleOsDependentTitleBar();
            handleOsDependentTitleBar.RunFor((this, HeaderPanel, MainPanel));
        }
    }
}
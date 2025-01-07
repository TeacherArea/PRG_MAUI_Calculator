namespace PRG1_MAUI_Calculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell())
            {
                Width = 390,
                Height = 844,
            };

            return window;
        }
    }
}
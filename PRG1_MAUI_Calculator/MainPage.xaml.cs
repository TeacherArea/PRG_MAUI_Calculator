namespace PRG1_MAUI_Calculator
{
    public partial class MainPage : ContentPage
    {
        private double accumulator = 0;
        private double operand = 0;
        private string operation = "";
        private string currentInput = "";   // Ny variabel. Hur används den, och vad är skillnaden mot tidigare?
        private bool isCalculated = false;  // Ny (oanvänd) variabel. Vad kan denna tänkas hålla koll på, och var använda den?
        public MainPage()
        {
            InitializeComponent();
        }

        // TODO Fortfarande fungerar inte fortsatta uträkningar, efter att Calculate() anropats (om man inte trycker på "C" först, då fungerar det). 
        private void NumberButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            currentInput += button.Text;

            if (double.TryParse(currentInput, out double value))
            {
                // operand = (operand * 10) + Convert.ToDouble(button.Text); ... Varför fungerade inte den tidigare lösningen?
                operand = value;
                EntryResult.Text = currentInput;
                EntryCalculations.Text += button.Text;
            }
        }


        private void OperatorButton(object sender, EventArgs e)
        {
            if (operation != "")
            {
                Calculate();
            }
            else
            {
                accumulator = operand;
            }

            operand = 0;

            Button button = (Button)sender;
            operation = button.Text;

            EntryCalculations.Text += $" {operation} ";

            currentInput = "";  // glöm inte strategiskt nollställa, annars följer saker med till nästa "omgång"!
            operand = 0;
        }

        // För att hantera kommatecknet måste det ges en egen metod. Varför? Vad gör denna metod, och vad är svagheten med denna lösning?
        private void DecimalButton(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentInput))
            {
                currentInput = "0,";
            }
            else if (!currentInput.Contains(","))
            {
                currentInput += ",";
            }

            EntryResult.Text = currentInput;
            EntryCalculations.Text += ",";
        }


        private void EqualButton(object sender, EventArgs e)
        {
            Calculate();

            EntryResult.Text = accumulator.ToString();
            EntryCalculations.Text = accumulator.ToString();

            operation = "";
            operand = 0;
            currentInput = accumulator.ToString();
        }


        private void Calculate()
        {
            switch (operation)
            {
                case "+":
                    accumulator += operand;
                    break;
                case "-":
                    accumulator -= operand;
                    break;
                case "*":
                    accumulator *= operand;
                    break;
                case "/":
                    if (operand == 0)
                    {
                        DisplayAlert("Fel!", "Division med noll är ej tillåtet.", "OK");
                        Clear();
                        return;
                    }
                    accumulator /= operand;
                    break;
            }

            operand = 0;
        }

        private void ClearButton(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            accumulator = 0;
            operand = 0;
            operation = "";
            currentInput = "";

            EntryCalculations.Text = "";
            EntryResult.Text = "0";
        }


        // TODO Minnesknappen fungerar inte ännu
        private void StoreInMemoryButton(object sender, EventArgs e)
        {
            EntryCalculations.Text = "Kommande funktion";
        }

        // TODO Hämta från minnet fungerar inte ännu
        private void CatchFromMemoryButton(object sender, EventArgs e)
        {
            EntryCalculations.Text = "Kommande funktion";
        }

    }

}

using System;
using System.Windows;

namespace Id4Countdown
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Mostra la finestra di input come dialog
            var input = new InputWindow();
            bool? result = input.ShowDialog();

            if (result == true)
            {
                // Crea la finestra principale con il TimeSpan scelto
                var main = new MainWindow(input.SelectedTime);

                // Imposta la MainWindow dell'app
                MainWindow = main;

                // Quando la MainWindow si chiude, spegni l'app esplicitamente
                main.Closed += (_, __) => Shutdown();

                main.Show();
            }
            else
            {
                // L'utente ha annullato → chiudi subito l'app
                Shutdown();
            }
        }
    }
}

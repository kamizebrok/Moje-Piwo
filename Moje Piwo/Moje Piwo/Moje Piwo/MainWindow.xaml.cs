using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Moje_Piwo.Model;
using MySql.Data.MySqlClient;

namespace Moje_Piwo
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        int counter = 0;
        private List<Button> przyciski = new List<Button>();
        private List<Piwo> piwa = new List<Piwo>();
        private Button zaznaczonyPrzycisk;
        string id_button;


        private void UsunZaznaczonyPrzycisk_Click(object sender, RoutedEventArgs e)
        {
            // Upewnij się, że jest zaznaczony przycisk
            if (zaznaczonyPrzycisk != null)
            {
                ListBoxElementy.Items.Remove(zaznaczonyPrzycisk);
                przyciski.Remove(zaznaczonyPrzycisk);
                zaznaczonyPrzycisk = null;
                counter--;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //button "dodaj piwo"
            counter += 1;
            Button nowyButton = new Button();
            nowyButton.Content = "Piwo " + Convert.ToString(counter);
            NazwaPiwa.Text = nowyButton.Content.ToString();
            nowyButton.Width = 145;
            nowyButton.Height = 25;
            nowyButton.Click += Element_Click;
            nowyButton.Tag = Guid.NewGuid().ToString();

            przyciski.Add(nowyButton);
            ListBoxElementy.Items.Add(nowyButton);

            if (zaznaczonyPrzycisk != null)
            {
                zaznaczonyPrzycisk.Background = Brushes.LightGray;
                zaznaczonyPrzycisk = null;
            }
            nowyButton.Background = Brushes.LightBlue;
            zaznaczonyPrzycisk = nowyButton;
            id_button = nowyButton.Tag.ToString();

            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            TextBox4.Text = string.Empty;
            TextBox5.Text = string.Empty;
            TextBox6.Text = string.Empty;
            TextBox7.Text = string.Empty;
            TextBox8.Text = string.Empty;
            CheckBox1.IsChecked = false;
            RadioButton1.IsChecked = false;
            RadioButton2.IsChecked = false;
            RadioButton3.IsChecked = false;
            RadioButton4.IsChecked = false;
            RadioButton5.IsChecked = false;
            Zapisano.Content = "";
            Piwo newPiwo = new Piwo(id_button, TextBox1.Text);
            piwa.Add(newPiwo);
        }


        private void Element_Click(object sender, RoutedEventArgs e)
        {
            //metoda dodawana do nowych buttonow
            Button kliknietyButton = (Button)sender;
            id_button = kliknietyButton.Tag.ToString();

            if (zaznaczonyPrzycisk != null)
            {
                zaznaczonyPrzycisk.Background = Brushes.LightGray;
                zaznaczonyPrzycisk = null;
            }
            kliknietyButton.Background = Brushes.LightBlue;
            zaznaczonyPrzycisk = kliknietyButton;
            NazwaPiwa.Text = kliknietyButton.Content.ToString();
            Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
            CheckBox1.IsChecked = false;

            if (current_piwo != null)
            {
                TextBox1.Text = current_piwo.Opis;
                TextBox2.Text = current_piwo.Rodzaj;
                TextBox3.Text = current_piwo.Ekstrakt;
                TextBox4.Text = current_piwo.Cena;
                TextBox5.Text = current_piwo.Procent;
                TextBox6.Text = current_piwo.Browar;
                TextBox7.Text = current_piwo.Kraj;
                TextBox8.Text = current_piwo.Koncern;

                
                if (current_piwo.Ocena == 1.0) { RadioButton1.IsChecked = true; }
                else if (current_piwo.Ocena == 2.0) { RadioButton2.IsChecked = true; }
                else if (current_piwo.Ocena == 3.0) { RadioButton3.IsChecked = true; }
                else if (current_piwo.Ocena == 4.0) { RadioButton4.IsChecked = true; }
                else if (current_piwo.Ocena == 5.0) { RadioButton5.IsChecked = true; }
                
                if(current_piwo.Ulubione)
                {
                    zaznaczonyPrzycisk.Background = Brushes.LightYellow;
                    CheckBox1.IsChecked = true;
                }
            }
            else
            {
                TextBox1.Text = "nie znaleziono";
            }

            Zapisano.Content = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //zapisywanie
            Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
            if (current_piwo != null)
            {
                current_piwo.Opis = TextBox1.Text;
                Zapisano.Content = "Pomyślnie zapisano piwo!";
                current_piwo.Rodzaj = TextBox2.Text;
                current_piwo.Ekstrakt = TextBox3.Text;
                current_piwo.Cena = TextBox4.Text;
                current_piwo.Procent = TextBox5.Text;
                current_piwo.Browar = TextBox6.Text;
                current_piwo.Kraj = TextBox7.Text;
                current_piwo.Koncern = TextBox8.Text;
                zaznaczonyPrzycisk.Content = NazwaPiwa.Text;
            }
            else
            {
                TextBox1.Text = "Nie zapisano, być może zapomniałeś najpierw zaznaczyć swoje piwo :)";
                Zapisano.Content = "Nie zapisano piwa :(";
            }
            


        }


        private void ListBoxElementy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            if (zaznaczonyPrzycisk != null)
            {
                Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
                if (current_piwo != null)
                {
                    current_piwo.Ocena = 1.0;
                }
            }
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            if (zaznaczonyPrzycisk != null)
            {
                Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
                if (current_piwo != null)
                {
                    current_piwo.Ocena = 2.0;
                }
            }
        }

        private void RadioButton3_Checked(object sender, RoutedEventArgs e)
        {
            if (zaznaczonyPrzycisk != null)
            {
                Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
                if (current_piwo != null)
                {
                    current_piwo.Ocena = 3.0;
                }
            }
        }

        private void RadioButton4_Checked(object sender, RoutedEventArgs e)
        {
            if (zaznaczonyPrzycisk != null)
            {
                Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
                if (current_piwo != null)
                {
                    current_piwo.Ocena = 4.0;
                }
            }
        }

        private void RadioButton5_Checked(object sender, RoutedEventArgs e)
        {
            if (zaznaczonyPrzycisk != null)
            {
                Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
                if (current_piwo != null)
                {
                    current_piwo.Ocena = 5.0;
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (zaznaczonyPrzycisk != null)
            {
                Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
                if (current_piwo != null)
                {
                    current_piwo.Ulubione = true;
                    zaznaczonyPrzycisk.Background = Brushes.LightYellow;
                }
            }
        }

        private void ZapiszDoBazy_Click(object sender, RoutedEventArgs e)
        {
            Piwo wczytane_piwo = new Piwo();
            DataAccess.ReadData();
            TextBox1.Text = "siema";
        }
    }
}

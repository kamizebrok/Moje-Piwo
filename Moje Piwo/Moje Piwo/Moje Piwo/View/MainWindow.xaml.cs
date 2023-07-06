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
using Microsoft.Data.Sqlite;
using Moje_Piwo.Model;
using System.Data.SQLite;


namespace Moje_Piwo.View
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        string connectionString = "Data Source=D:\\Moje-Piwo\\Moje Piwo\\Moje Piwo\\Moje Piwo\\piwo.db;Version=3;";

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

                if (current_piwo.Ulubione)
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

        private void WczytajZBazy_Click(object sender, RoutedEventArgs e)
        {
            List<Piwo> piwka = new List<Piwo>();

            SQLiteConnection connection = new SQLiteConnection(connectionString);
            try
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Beer";
                using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id_beer"]);
                            string nazwa = reader["Name"].ToString();
                            string typ = reader["Type"].ToString();
                            string woltaz = reader["Voltage"].ToString();
                            string ekstrakt = reader["Extract"].ToString();
                            string opis = reader["Description"].ToString();
                            string cena = reader["Price"].ToString();
                            string browar = reader["Brewery"].ToString();
                            string kraj = reader["Country"].ToString();
                            string koncern = reader["Concern"].ToString();
                            bool fav = Convert.ToBoolean(reader["Favorite"]);
                            string csid = reader["CsID"].ToString();
                            double ocena = Convert.ToDouble(reader["Rating"]);

                            Piwo piwunio = new Piwo(csid, nazwa, opis, typ, ekstrakt, cena, woltaz, browar, kraj, koncern, ocena, fav, id);
                            piwka.Add(piwunio);
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {

            }

        }

        private void ZapiszDoBazy_Click(object sender, RoutedEventArgs e)
        {
            if (zaznaczonyPrzycisk != null)
            {
                Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
                if (current_piwo != null)
                {
                    int idpiwo = current_piwo.intid;
                    string nazwa = current_piwo.Nazwa;
                    string opis = current_piwo.Opis;
                    string rodzaj = current_piwo.Rodzaj;
                    string ekstrakt = current_piwo.Ekstrakt;
                    string cena = current_piwo.Cena;
                    string procent = current_piwo.Procent;
                    string browar = current_piwo.Browar;
                    string kraj = current_piwo.Kraj;
                    string koncern = current_piwo.Koncern;
                    double ocena = current_piwo.Ocena;
                    bool fav = current_piwo.Ulubione;
                    string csid = current_piwo.PiwoID;

                    SQLiteConnection connection = new SQLiteConnection(connectionString);
                    try
                    {
                        connection.Open();
                        string insertQuery = "INSERT INTO Beer (id_beer, Name, Type, Voltage, Extract, Description, Price, Brewery, Country, Concern, Favorite, CsID, Rating) VALUES (@idpiwo, @nazwa, @rodzaj, @procent, @ekstrakt, @opis, @cena, @browar, @kraj, @koncern, @fav, @csid, @ocena)";
                        using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@idpiwo", idpiwo);
                            command.Parameters.AddWithValue("@opis", opis);
                            command.Parameters.AddWithValue("@cena", cena);
                            command.Parameters.AddWithValue("@nazwa", nazwa);
                            command.Parameters.AddWithValue("@rodzaj", rodzaj);
                            command.Parameters.AddWithValue("@procent", procent);
                            command.Parameters.AddWithValue("@ekstrakt", ekstrakt);
                            command.Parameters.AddWithValue("@browar", browar);
                            command.Parameters.AddWithValue("@kraj", kraj);
                            command.Parameters.AddWithValue("@koncern", koncern);
                            command.Parameters.AddWithValue("@fav", fav);
                            command.Parameters.AddWithValue("@csid", csid);
                            command.Parameters.AddWithValue("@ocena", ocena);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (SQLiteException ex)
                    {
                        // Handle the exception
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            MessageBox.Show("Osoba została zapisana do bazy danych.");
        }
    }
}
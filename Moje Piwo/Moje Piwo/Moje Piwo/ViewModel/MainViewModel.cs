using Moje_Piwo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.SQLite;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Collections.ObjectModel;

namespace Moje_Piwo.ViewModel
{
    public class MainViewModel : Base
    {
        string connectionString = "Data Source=D:\\Moje-Piwo\\Moje Piwo\\Moje Piwo\\Moje Piwo\\piwo.db;Version=3;";
        public ICommand ZapiszDoBazyCommand { get; }
        public ICommand WczytajZBazyCommand { get; }
        public ICommand UsunZaznaczonyPrzycisk { get; }
        public ICommand ButtonClick { get; }
        public ICommand DodajPiwoCommand { get; }
        public ICommand ZapiszPiwoCommand { get; }
        public ICommand ElClick { get; }
        private bool zapisEnabled;
        public bool ZapisEnabled
        {
            get { return zapisEnabled; }
            set
            {
                if (zapisEnabled != value)
                {
                    zapisEnabled = value;
                    onPropertyChange(nameof(ZapisEnabled));
                }
            }
        }
        private bool usunEnabled;
        public bool UsunEnabled
        {
            get { return usunEnabled; }
            set
            {
                if (usunEnabled != value)
                {
                    usunEnabled = value;
                    onPropertyChange(nameof(UsunEnabled));
                }
            }
        }
        private string isOverlayVisible;
        public string IsOverlayVisible
        {
            get { return isOverlayVisible; }
            set
            {
                if (isOverlayVisible != value)
                {
                    isOverlayVisible = value;
                    onPropertyChange(nameof(IsOverlayVisible));
                }
            }
        }

        private string nazwaPiwa;
        public string NazwaPiwa
        {
            get { return nazwaPiwa; }
            set
            {
                if (nazwaPiwa != value)
                {
                    nazwaPiwa = value;
                    onPropertyChange();
                }
            }
        }

        private string textBox1Text;
        public string TextBox1Text
        {
            get { return textBox1Text; }
            set
            {
                if (textBox1Text != value)
                {
                    textBox1Text = value;
                    onPropertyChange();
                }
            }
        }

        private string textBox2Text;
        public string TextBox2Text
        {
            get { return textBox2Text; }
            set
            {
                if (textBox2Text != value)
                {
                    textBox2Text = value;
                    onPropertyChange();
                }
            }
        }

        private string textBox3Text;
        public string TextBox3Text
        {
            get { return textBox3Text; }
            set
            {
                if (textBox3Text != value)
                {
                    textBox3Text = value;
                    onPropertyChange();
                }
            }
        }

        private string textBox4Text;
        public string TextBox4Text
        {
            get { return textBox4Text; }
            set
            {
                if (textBox4Text != value)
                {
                    textBox4Text = value;
                    onPropertyChange();
                }
            }
        }

        private string textBox5Text;
        public string TextBox5Text
        {
            get { return textBox5Text; }
            set
            {
                if (textBox5Text != value)
                {
                    textBox5Text = value;
                    onPropertyChange();
                }
            }
        }

        private string textBox6Text;
        public string TextBox6Text
        {
            get { return textBox6Text; }
            set
            {
                if (textBox6Text != value)
                {
                    textBox6Text = value;
                    onPropertyChange();
                }
            }
        }

        private string textBox7Text;
        public string TextBox7Text
        {
            get { return textBox7Text; }
            set
            {
                if (textBox7Text != value)
                {
                    textBox7Text = value;
                    onPropertyChange();
                }
            }
        }

        private string textBox8Text;
        public string TextBox8Text
        {
            get { return textBox8Text; }
            set
            {
                if (textBox8Text != value)
                {
                    textBox8Text = value;
                    onPropertyChange();
                }
            }
        }

        private bool checkBox1Checked;
        public bool CheckBox1Checked
        {
            get { return checkBox1Checked; }
            set
            {
                if (checkBox1Checked != value)
                {
                    checkBox1Checked = value;
                    onPropertyChange();
                }
            }
        }

        private bool radioButton1Checked;
        public bool RadioButton1Checked
        {
            get { return radioButton1Checked; }
            set
            {
                if (radioButton1Checked != value)
                {
                    radioButton1Checked = value;
                    onPropertyChange();
                }
            }
        }

        private bool radioButton2Checked;
        public bool RadioButton2Checked
        {
            get { return radioButton2Checked; }
            set
            {
                if (radioButton2Checked != value)
                {
                    radioButton2Checked = value;
                    onPropertyChange();
                }
            }
        }

        private bool radioButton3Checked;
        public bool RadioButton3Checked
        {
            get { return radioButton3Checked; }
            set
            {
                if (radioButton3Checked != value)
                {
                    radioButton3Checked = value;
                    onPropertyChange();
                }
            }
        }

        private bool radioButton4Checked;
        public bool RadioButton4Checked
        {
            get { return radioButton4Checked; }
            set
            {
                if (radioButton4Checked != value)
                {
                    radioButton4Checked = value;
                    onPropertyChange();
                }
            }
        }

        private bool radioButton5Checked;
        public bool RadioButton5Checked
        {
            get { return radioButton5Checked; }
            set
            {
                if (radioButton5Checked != value)
                {
                    radioButton5Checked = value;
                    onPropertyChange();
                }
            }
        }

        private string zapisanoContent;
        public string ZapisanoContent
        {
            get { return zapisanoContent; }
            set
            {
                if (zapisanoContent != value)
                {
                    zapisanoContent = value;
                    onPropertyChange();
                }
            }
        }


        public MainViewModel()
        {
            ZapiszDoBazyCommand = new RelayCommand(ZapiszDoBazy);
            WczytajZBazyCommand = new RelayCommand(WczytajZBazy);
            UsunZaznaczonyPrzycisk = new RelayCommand(UsunZaznaczonyPrzycisk_Click);
            ButtonClick = new RelayCommand(Button_Click);
            DodajPiwoCommand = new RelayCommand(Button_Click_1);
            ZapiszPiwoCommand = new RelayCommand(Button_Click_2);
            ListBoxItems = new ObservableCollection<Button>();
            ZapisEnabled = false;
            UsunEnabled = false;
            IsOverlayVisible = "Visible";
            WczytajZBazy();
        }

        int counter = 0;
        private List<Button> przyciski = new List<Button>();
        private List<Piwo> piwa = new List<Piwo>();
        private Button zaznaczonyPrzycisk;
        string id_button;


        private void UsunZaznaczonyPrzycisk_Click()
        {
            if (zaznaczonyPrzycisk != null)
            {
                Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
                ListBoxItems.Remove(zaznaczonyPrzycisk);
                przyciski.Remove(zaznaczonyPrzycisk);
                zaznaczonyPrzycisk = null;
                counter--;
                if (current_piwo != null)
                {
                    SQLiteConnection connection = new SQLiteConnection(connectionString);
                    try
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM Beer WHERE CsID = @Id";
                        using (SQLiteCommand command = new SQLiteCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Id", current_piwo.PiwoID);
                            command.ExecuteNonQuery();
                        }

                    }
                    finally
                    {
                        connection.Close();
                    }
                    MessageBox.Show("Piwo zostalo usunięte z bazy danych.");
                }

                else
                {
                    MessageBox.Show("Wybierz piwo do usunięcia.");
                }
                if (ListBoxItems.Count == 0)
                {
                    IsOverlayVisible = "Visible";
                    UsunEnabled = false;
                    ZapisEnabled = false;
                }
            }
        }

        private void Button_Click()
        {

        }

        private ObservableCollection<Button> listBoxItems;
        public ObservableCollection<Button> ListBoxItems
        {
            get { return listBoxItems; }
            set
            {
                if (listBoxItems != value)
                {
                    listBoxItems = value;
                    onPropertyChange();
                }
            }
        }

        private void Button_Click_1()
        {
            //button "dodaj piwo"
            counter += 1;
            Button nowyButton = new Button();
            nowyButton.Content = "Piwo " + Convert.ToString(counter);
            NazwaPiwa = nowyButton.Content.ToString();
            nowyButton.Width = 145;
            nowyButton.Height = 25;
            nowyButton.Click += Element_Click;
            nowyButton.Tag = Guid.NewGuid().ToString();

            przyciski.Add(nowyButton);
            ListBoxItems.Add(nowyButton);

            if (zaznaczonyPrzycisk != null)
            {
                zaznaczonyPrzycisk.Background = Brushes.LightGray;
                zaznaczonyPrzycisk = null;
            }
            nowyButton.Background = Brushes.LightBlue;
            zaznaczonyPrzycisk = nowyButton;
            id_button = nowyButton.Tag.ToString();

            TextBox1Text = string.Empty;
            TextBox2Text = string.Empty;
            TextBox3Text = string.Empty;
            TextBox4Text = string.Empty;
            TextBox5Text = string.Empty;
            TextBox6Text = string.Empty;
            TextBox7Text = string.Empty;
            TextBox8Text = string.Empty;
            CheckBox1Checked = false;
            RadioButton1Checked = false;
            RadioButton2Checked = false;
            RadioButton3Checked = false;
            RadioButton4Checked = false;
            RadioButton5Checked = false;
            ZapisanoContent = "";
            Piwo newPiwo = new Piwo(id_button, TextBox1Text);
            piwa.Add(newPiwo);
            ZapisEnabled = true;
            UsunEnabled = true;
            IsOverlayVisible = "Hidden";
            UpdateAll();
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
            NazwaPiwa = kliknietyButton.Content.ToString();
            Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
            CheckBox1Checked = false;

            if (current_piwo != null)
            {
                TextBox1Text = current_piwo.Opis;
                TextBox2Text = current_piwo.Rodzaj;
                TextBox3Text = current_piwo.Ekstrakt;
                TextBox4Text = current_piwo.Cena;
                TextBox5Text = current_piwo.Procent;
                TextBox6Text = current_piwo.Browar;
                TextBox7Text = current_piwo.Kraj;
                TextBox8Text = current_piwo.Koncern;


                if (current_piwo.Ocena == 1.0) { RadioButton1Checked = true; onPropertyChange(nameof(RadioButton1Checked)); }
                else if (current_piwo.Ocena == 2.0) { RadioButton2Checked = true; onPropertyChange(nameof(RadioButton2Checked)); }
                else if (current_piwo.Ocena == 3.0) { RadioButton3Checked = true; onPropertyChange(nameof(RadioButton3Checked)); }
                else if (current_piwo.Ocena == 4.0) { RadioButton4Checked = true; onPropertyChange(nameof(RadioButton4Checked)); }
                else if (current_piwo.Ocena == 5.0) { RadioButton5Checked = true; onPropertyChange(nameof(RadioButton5Checked)); }

                if (current_piwo.Ulubione)
                {
                    zaznaczonyPrzycisk.Background = Brushes.LightYellow;
                    CheckBox1Checked = true;
                }
            }
            else
            {
                TextBox1Text = "nie znaleziono";
            }

            ZapisanoContent = "";
            UsunEnabled = true;
            ZapisEnabled = true;
            IsOverlayVisible = "Hidden";
            UpdateAll();
        }

        private void UpdateAll()
        {
            onPropertyChange(nameof(NazwaPiwa));
            onPropertyChange(nameof(TextBox1Text));
            onPropertyChange(nameof(TextBox2Text));
            onPropertyChange(nameof(TextBox3Text));
            onPropertyChange(nameof(TextBox4Text));
            onPropertyChange(nameof(TextBox5Text));
            onPropertyChange(nameof(TextBox6Text));
            onPropertyChange(nameof(TextBox7Text));
            onPropertyChange(nameof(TextBox8Text));
            onPropertyChange(nameof(RadioButton1Checked));
            onPropertyChange(nameof(RadioButton1Checked));
            onPropertyChange(nameof(RadioButton3Checked));
            onPropertyChange(nameof(RadioButton4Checked));
            onPropertyChange(nameof(RadioButton5Checked));
            onPropertyChange(nameof(CheckBox1Checked));
        }
        private void Button_Click_2()
        {
            //zapisywanie
            Piwo current_piwo = piwa.Find(piwo => piwo.PiwoID == id_button);
            if (current_piwo != null)
            {
                current_piwo.Nazwa = NazwaPiwa;
                current_piwo.Opis = TextBox1Text;
                ZapisanoContent = "Pomyślnie zapisano piwo!";
                current_piwo.Rodzaj = TextBox2Text;
                current_piwo.Ekstrakt = TextBox3Text;
                current_piwo.Cena = TextBox4Text;
                current_piwo.Procent = TextBox5Text;
                current_piwo.Browar = TextBox6Text;
                current_piwo.Kraj = TextBox7Text;
                current_piwo.Koncern = TextBox8Text;
                zaznaczonyPrzycisk.Content = NazwaPiwa;
            }
            else
            {
                TextBox1Text = "Nie zapisano, być może zapomniałeś najpierw zaznaczyć swoje piwo :)";
                ZapisanoContent = "Nie zapisano piwa :(";
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

        private void WczytajZBazy()
        {
            int counter = 0;
            List<Piwo> piwka = new List<Piwo>();
            ListBoxItems.Clear();
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

            foreach (Piwo piwo in piwka)
            {
                counter += 1;
                Button nowyButton = new Button();
                nowyButton.Content = piwo.Nazwa;
                NazwaPiwa = nowyButton.Content.ToString();
                nowyButton.Width = 145;
                nowyButton.Height = 25;
                nowyButton.Click += Element_Click;
                nowyButton.Tag = piwo.PiwoID;

                przyciski.Add(nowyButton);
                ListBoxItems.Add(nowyButton);

                if (zaznaczonyPrzycisk != null)
                {
                    zaznaczonyPrzycisk.Background = Brushes.LightGray;
                    zaznaczonyPrzycisk = null;
                }
                nowyButton.Background = Brushes.LightBlue;
                zaznaczonyPrzycisk = nowyButton;
                id_button = nowyButton.Tag.ToString();

                TextBox1Text = piwo.Opis;
                TextBox2Text = piwo.Rodzaj;
                TextBox3Text = piwo.Ekstrakt;
                TextBox4Text = piwo.Cena;
                TextBox5Text = piwo.Procent;
                TextBox6Text = piwo.Browar;
                TextBox7Text = piwo.Kraj;
                TextBox8Text = piwo.Koncern;
                CheckBox1Checked = false;
                if (piwo.Ulubione) { CheckBox1Checked = true; }
                RadioButton1Checked = false;
                RadioButton2Checked = false;
                RadioButton3Checked = false;
                RadioButton4Checked = false;
                RadioButton5Checked = false;
                ZapisanoContent = "";
                piwa.Add(piwo);
            }
        }

        private void ZapiszDoBazy()
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
                        string selectMaxIdQuery = "SELECT MAX(id_beer) FROM Beer";
                        using (SQLiteCommand maxIdCommand = new SQLiteCommand(selectMaxIdQuery, connection))
                        {
                            object result = maxIdCommand.ExecuteScalar();
                            int maxId = Convert.ToInt32(result);
                            int newId = maxId + 1;

                            string insertQuery = "INSERT INTO Beer (id_beer, Name, Type, Voltage, Extract, Description, Price, Brewery, Country, Concern, Favorite, CsID, Rating) VALUES (@idpiwo, @nazwa, @rodzaj, @procent, @ekstrakt, @opis, @cena, @browar, @kraj, @koncern, @fav, @csid, @ocena)";
                            using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                            {
                                command.Parameters.AddWithValue("@idpiwo", newId);
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
                    }
                    finally
                    {
                        connection.Close();
                    }
                    if (ListBoxItems.Count == 0)
                    {
                        IsOverlayVisible = "Visible";
                    }
                    else
                    {
                        IsOverlayVisible = "Hidden";
                    }  
                }
            }
        }

    }
}

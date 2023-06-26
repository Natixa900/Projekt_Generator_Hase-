using System;
using System.Collections.Generic;
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

using PasswordGenerator.Data;
using System.Data.SqlClient;



namespace PasswordGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            His.ItemsSource = GetPAss();
            znaki2.IsChecked = true;
        }

        #region operacje CRUD(Dodawanie,usuwanie,wczytanie, update)

        //wczytanie bazy danych do listy 
        private List<Data.PasswordContainer> GetPAss()
        {
            using (var password = new Data.PasswordGenEntities())
            {
                return password.PasswordContainer.ToList();
            }
        }
        //dodanie nowego hasła do bazy danych 
        public void AddNewPassword(Data.PasswordContainer newPass)
        {
            using (var PasswordList = new Data.PasswordGenEntities())
            {

                PasswordList.PasswordContainer.Add(newPass);
                PasswordList.SaveChanges();
            }
        }

        //usuwanie hasła z bazy
        public void DeletePassword(Data.PasswordContainer DELPass)
        {
            using (var PasswordList = new Data.PasswordGenEntities())
            {
                var passwordToDelete = PasswordList.PasswordContainer.Find(DELPass.Nazwa);
                PasswordList.PasswordContainer.Remove(passwordToDelete);
                PasswordList.SaveChanges();
            }
            His.ItemsSource = GetPAss();
        }
        //Update Hasła
        private void UpdatePS(Data.PasswordContainer updatePS)
        {
            using (var PasswordList = new Data.PasswordGenEntities())
            {
                var PasswordToUpdate = PasswordList.PasswordContainer.Find(updatePS.Nazwa);
                if (PasswordToUpdate != null )
                {
                    DeletePassword(PasswordToUpdate);
                    AddNewPassword(updatePS);
                    His.ItemsSource = GetPAss();
                }
                else
                {
                    AddNewPassword(updatePS);
                    His.ItemsSource = GetPAss();
                }
            }

        }

        #endregion

        #region panelGłówny

        //generowanie hasła
        int repeat ;
        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            oldPS.Text = ShowPSD.Text;
            ShowPSD.Text=string.Empty;
            Random random = new Random();
            string Password=string.Empty;
            int r=0;
           
            char w;
            
             
                while(r<repeat)
                {
                w = Convert.ToChar(random.Next(33,127));
                Password += w;
                  
                    r++;
                    
                    
                }
              
               
                


            
            ShowPSD.Text = Password;
            CHZapisz.IsEnabled = true;

        }
        //przenosi wygenerowane hasło do okienka służącego do zapisu
        private void Save_PS(object sender, RoutedEventArgs e)
        {
            Saved.Text = ShowPSD.Text;

        }
        //funcja zapisująca haslo
       
        private void FinalSave(object sender, RoutedEventArgs e)
        {
            
            try
            {

                if (Gdzie.Text != string.Empty && Saved.Text != null)
                {
                    Data.PasswordContainer passwordContainer = new Data.PasswordContainer();
                    passwordContainer.Nazwa = Gdzie.Text;
                    passwordContainer.Haslo = Saved.Text;
                    
                    
                    //UpdatePS(passwordContainer);
                    UpdatePS(passwordContainer);
                    
                    MessageBox.Show("Haslo zostalo dodane do bazy");
                    Gdzie.Text = string.Empty;
                    Saved.Text = string.Empty;

                }
                
                else
                {

                    MessageBox.Show($"Pole nie moze byc puste ");

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        #endregion








        #region Opcje
        //tryb ciemny
        private void NightTR(object sender, RoutedEventArgs e)
        {
            //Grid and Tabs
           GridHome.Background = Brushes.Black;
            Histo.Background = Brushes.Black;
            Home.Background = Brushes.Black;
            Home.Foreground = Brushes.Green;
            HS.Background = Brushes.Black;
            HS.Foreground = Brushes.Green;
            UST.Background = Brushes.Black;
            UST.Foreground = Brushes.Green;
            GridUSt.Background = Brushes.Black;
            //Labels
            Label1.Foreground = Brushes.Green;
            Tryb.Foreground = Brushes.Green;
            PSLEN.Foreground = Brushes.Green;
            POpr.Foreground = Brushes.Green;

            NM.Foreground = Brushes.Green;

            PASE.Foreground = Brushes.Green;

            //textBox, Textblocks
            ShowPSD.Background = Brushes.Black;
            ShowPSD.Foreground = Brushes.Green;

            oldPS.Background = Brushes.Black;
            oldPS.Foreground = Brushes.Green;

            Gdzie.Background = Brushes.Black;
            Saved.Background = Brushes.Black;

            Gdzie.Foreground = Brushes.Green;
            Saved.Foreground = Brushes.Green;

            //Buttons

            Generuj.Background = Brushes.Black;
            Generuj.Foreground = Brushes.Green;

            CHZapisz.Background = Brushes.Black;
            CHZapisz.Foreground = Brushes.Green;

           FSave.Background = Brushes.Black;
            FSave.Foreground = Brushes.Green;

            Night.Foreground = Brushes.Green;
            Light.Foreground = Brushes.Green;

            znaki1.Foreground = Brushes.Green;
            znaki2.Foreground = Brushes.Green;
        }
        //tryb jasny 
        private void LightTR(object sender, RoutedEventArgs e)
        {
            //Grid and Tabs
            GridHome.Background = Brushes.AliceBlue;
            Histo.Background = Brushes.AliceBlue;
            Histo.Background = Brushes.AliceBlue;
            Home.Background = Brushes.AliceBlue;
            Home.Foreground = Brushes.Black;
            HS.Background = Brushes.AliceBlue;
            HS.Foreground = Brushes.Black;
            UST.Background = Brushes.AliceBlue;
            UST.Foreground = Brushes.Black;
            GridUSt.Background = Brushes.AliceBlue;
            //Labels
            Label1.Foreground = Brushes.Black;

            POpr.Foreground = Brushes.Black;

            NM.Foreground = Brushes.Black;

            PASE.Foreground = Brushes.Black;

            Tryb.Foreground = Brushes.Black;
            PSLEN.Foreground = Brushes.Black;
            //textBox, Textblocks
            ShowPSD.Background = Brushes.White;
            ShowPSD.Foreground = Brushes.Black;

            oldPS.Background = Brushes.White;
            oldPS.Foreground = Brushes.Black;

            Gdzie.Background = Brushes.White;
            Saved.Background = Brushes.White;

            Gdzie.Foreground = Brushes.Black;
            Saved.Foreground = Brushes.Black;

            //Buttons

            Generuj.Background = Brushes.White;
            Generuj.Foreground = Brushes.Black;

            CHZapisz.Background = Brushes.White;
            CHZapisz.Foreground = Brushes.Black;

            FSave.Background = Brushes.White;
            FSave.Foreground = Brushes.Black;

            Night.Foreground = Brushes.Black;
            Light.Foreground = Brushes.Black;

            znaki1.Foreground = Brushes.Black;
            znaki2.Foreground = Brushes.Black;
            
        }


        //wybór ilości znaków
        private void znaki_Checked(object sender, RoutedEventArgs e)
        {
            if (znaki2.IsChecked==true)
            {
                repeat = 10;
            }
            else
            {
                repeat = 8;
            }


        }



        #endregion

        #region Historia

        //refresh button data
        private void History_Loaded(object sender, RoutedEventArgs e)
        {

            His.ItemsSource = GetPAss();

        }
       //wyszukiwanie haseł wybranych 
        private void SearchButton(object sender, RoutedEventArgs e)
        {
            var Pass = GetPAss();
            string searchItem = SearchBox.Text;

            if (searchItem != string.Empty)
            {
                var item = Pass.Where(x => x.Nazwa == searchItem).ToList();

                His.ItemsSource = item;
            }
            else
            {
                His.ItemsSource = Pass;
            }


            
        }
        //przycisk usuwa hasło 
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PasswordContainer DeletePass = new PasswordContainer();
                var index = His.SelectedIndex;
                DeletePass.Nazwa = GetPAss()[index].Nazwa;
                DeletePass.Haslo = GetPAss()[index].Haslo;

                DeletePassword(DeletePass);
            }
            catch (Exception)
            {

                MessageBox.Show("Cos nie tak");
            }
          
        }

        
        #endregion


    }
}

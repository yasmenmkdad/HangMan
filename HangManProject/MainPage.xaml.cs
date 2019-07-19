using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HangManProject
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
       public string Player;
        public MainPage()
        {
            InitializeComponent();
            DependencyService.Get<Isqlite>().GetConnection();
            DependencyService.Get<SqliteForPlayer>().GetConnection();
            insertPlayerName();
            Hangimg.Source = ImageSource.FromFile("hangimage.png");
        }
        private void MainGame(object sender, EventArgs e)
        {
            //to store Data into table of words
            word d = new word();
            d.Name = "hh";
            bool r = DependencyService.Get<Isqlite>().SaveData(d);
            if(PlayerName.Text==null)
            {
                DisplayAlert(null,"Please enter your name please","ok");
            }
            else
            {
                //to move to game page
                Navigation.PushAsync(new MainGame());
            }
        }
        public void insertPlayerName()
        {
            Player player = new Player();
            player.PlayerName = PlayerName.Text;
            bool r = DependencyService.Get<SqliteForPlayer>().SaveData(player);
            if(r==true)
            {
                DisplayAlert(null, "Enter successufully", "ok");
            }
            else
            {
                DisplayAlert(null, "Failed to enter your name", "ok");
            }
        }
    }
}

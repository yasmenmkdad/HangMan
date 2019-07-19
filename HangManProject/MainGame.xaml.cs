using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using SQLite;

namespace HangManProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainGame : ContentPage
    {
        private int count = 0;
        private int Score = 0;
        private string TheCurrentWord;
        private string ThecopyWord;
        private SQLiteConnection database;
        private List<word> words;
        private string TheNameOfBtn;
        private string[] images = { "web.png", "Web1.png", "Web2.png", "Web3.png", "Web4.jpg" };
        public MainGame()
        {
            InitializeComponent();
            database = DependencyService.Get<Isqlite>().GetConnection();
            words = DependencyService.Get<Isqlite>().GetWords();
            hangimgs.Source = ImageSource.FromFile(images.ElementAt(count));
            GetWotd();
            //clear();
        }
        //choice random word from list
        public void GetWotd()
        {
            count = 0;
            hangimgs.Source = ImageSource.FromFile(images.ElementAt(count));
            int index = (new Random()).Next(words.Count);
            TheCurrentWord = words[index].Name;
            CreateLine();
            DispalyChars();
        }
        public void WinOrNot()
        {
            if(count>=5)
            {
                DisplayAlert(null, "YOU Lost" +" "+ Score.ToString(), "ok");
            }
            else
            {
                hangimgs.Source = ImageSource.FromFile(images.ElementAt(count));
            }
            //if(ThecopyWord.Equals(TheCurrentWord))
            //    DisplayAlert(null, "YOU win"+" "+ Score.ToString(), "ok"); ;
        }
        public void CreateLine()
        {
            ThecopyWord = "";
            for (int i = 0; i < TheCurrentWord.Length; i++)
            {
                ThecopyWord += "_";
            }
        }
        public void DispalyChars()
        {
            MissingWord.Text ="";
            for (int i = 0; i < ThecopyWord.Length; i++)
            {
                MissingWord.Text += ThecopyWord.Substring(i,1);
                MissingWord.Text += " ";
            }
        }
        public void compare(string NameBtn)
        {
            char[] CurrWord = TheCurrentWord.ToCharArray();
            char[] CopWord = ThecopyWord.ToCharArray();
            char ch = char.Parse(NameBtn);
            for(int i=0;i<TheCurrentWord.Length;i++)
            {
                if(CurrWord[i]==ch)
                {
                    Score+=10;
                    CopWord[i] = ch;
                }
            }
            ThecopyWord = new string(CopWord);
            DispalyChars();
        }
        public void alph_btn(object sender, EventArgs e)
        {
            Button btn =sender as Button;
            btn.BackgroundColor = Color.Red;
            TheNameOfBtn =btn.Text;
          if(TheCurrentWord.Contains(TheNameOfBtn))
            {
                compare(TheNameOfBtn);
            }
          else
            {
                count++;
                WinOrNot();
            }
        }
        //public void clear()
        //{
        //    count = 0;
        //    Score = 0;
        //    hangimgs.Source = ImageSource.FromFile(images.ElementAt(count));
        //    ThecopyWord = "";
        //    TheCurrentWord = "";
        //}
        //public void Draw_Word(char[] myword)
        //{
        //   for(int i=0;i<myword.Length;i++)
        //    {
        //        MissingWord.Text += " - ";
        //    }
        //}
        //public void update(int index,char ch,char[] MyWord)
        //{
        //    for(int i=0;i<MyWord.Length;i++)
        //    {
        //       if(i==index)
        //        {
        //            (MissingWord.Text.ToCharArray())[i] = ch;
        //        }

        //    }
        //}
        //public char[] GetSingleWord()
        //{
        //    //List<word> words = DependencyService.Get<Isqlite>().GetWords();kda fen el words ely 3ndk
        //    //int index=0;
        //    //index++;
        //    //return words[index].Name;
        //    count = 0;
        //    MissingWord.Text = " ";
        //    hangimgs.Source = ImageSource.FromFile(images.ElementAt(count));
        //    int index = (new Random()).Next(words.Count);
        //    name = (words[index].Name).ToCharArray();
        //    //Draw_Word(name);
        //    return name;
        //}
        //public bool get()
        //{
        //    char[] MyWord = GetSingleWord();
        //    Draw_Word(MyWord);
        //    for(int i=0;i<MyWord.Length;i++)
        //    {
        //        if(TheNameOfBtn.Equals(MyWord[i]))
        //        {
        //            update(i, MyWord[i], MyWord);
        //            IsFound = true;
        //            Score += 10;
        //            break;
        //        }
        //        else
        //        {
        //            IsFound = false;
        //        }
        //    }
        //    return IsFound;
        //}

        //public void loseGame()
        //{
        //    count++;
        //    if (count<=5)
        //    {
        //        hangimgs.Source = ImageSource.FromFile(images.ElementAt(count));
        //    }
        //    else
        //    {
        //        DisplayAlert(null, "YOU Lost"+Score.ToString(), "ok");
        //    }
        //}
        //private void check_Btn(object sender, EventArgs e)
        //{
        //    //int increment = 0;
        //    //do
        //    //{
        //    //    if(get()==true)
        //    //    {
        //    //        alph_btn(sender,e);
        //    //    }
        //    //    else
        //    //    {
        //    //        loseGame();
        //    //    }
        //    //    increment++;
        //    //}
        //    //while (increment<=GetSingleWord().Length);

        //}
    }
}
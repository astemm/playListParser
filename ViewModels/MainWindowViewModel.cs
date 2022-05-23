using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using plParser.Commands;
using plParser.Models;

namespace plParser.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int num;
        private string  input;
        private string message;
        private PlayList playList;
        private string name;
        private ObservableCollection<Song> songs;

        public MainWindowViewModel()
        {
            OnClickMe = new RelayCommand(OnExecuteButtonClickEvent, o => true);
            message = "You displayed playlist";
        }

        public ICommand OnClickMe { get; set; }

        public string Input { 
            get {return  input; }
            set {this.RaiseAndSetIfChanged(ref input, value);}
        }

        public string Message { 
            get {return  message; }
            set {this.RaiseAndSetIfChanged(ref message, value);}
        }

        public PlayList PlayList { 
            get {return  playList; }
            set {this.RaiseAndSetIfChanged(ref playList, value);}
        }

        public ObservableCollection<Song> Songs { 
            get {return  songs; }
            set {this.RaiseAndSetIfChanged(ref songs, value);}
        }

        private void OnExecuteButtonClickEvent(object parameter)
        {
            Console.WriteLine(Input);
            HtmlParser parser=new HtmlParser("https://www.boomplay.com/playlists/35900409");
            Songs=new ObservableCollection<Song>(parser.ParseSongs());
            PlayList=parser.ParsePlayList();
            //PlayList.Avatara.Save(@"C:\img2.png");
            num++;
            Message=Message+num;
        }

    }
}

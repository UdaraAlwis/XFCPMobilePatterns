using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XFMyNotesAppDI
{
    public class MyNote : INotifyPropertyChanged
    {
        private DateTime _timestamp;
        private string _noteText;
        private string _noteTitle;

        public DateTime TimeStamp
        {
            get { return _timestamp; }
            set { SetPropertyValue(ref _timestamp, value); }
        }

        public string NoteText
        {
            get { return _noteText; }
            set { SetPropertyValue(ref _noteText, value); }
        }

        public string NoteTitle
        {
            get { return _noteTitle; }
            set { SetPropertyValue(ref _noteTitle, value); }
        }

        public MyNote() : this("Just a random thought.", "Nothing to Say", DateTime.Now)
        {

        }

        public MyNote(MyNote copy)
        {
            this.NoteTitle = copy.NoteTitle;
            this.NoteText = copy.NoteText;
            this.TimeStamp = copy.TimeStamp;
        }

        public MyNote(string noteTitle,string noteText, DateTime timestamp)
        {
            NoteTitle = noteTitle;
            NoteText = noteText;
            TimeStamp = timestamp;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        bool SetPropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value) == false)
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }
}

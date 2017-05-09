using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFMyNotesAppFP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewNotePage : ContentPage
    {
        private readonly int _noteIndex;
        public ViewNotePage(int noteIndex)
        {
            InitializeComponent();
            _noteIndex = noteIndex;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var note = ServiceLoaderManager.Instance.MyNotes[_noteIndex];
            BindingContext = note;

            ServiceLoaderManager.Instance.NoteReader.Speak(
                $"{note.NoteTitle} {note.NoteText}, " +
                $"posted on {note.TimeStamp:D}, {note.TimeStamp:t}");
        }

        private void EditNoteButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditNotePage(_noteIndex));
        }
    }
}

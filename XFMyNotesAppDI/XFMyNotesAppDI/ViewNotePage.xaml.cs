using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFMyNotesAppDI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewNotePage : ContentPage
    {
        private NoteManager _noteManager;
        private readonly int _noteIndex;
        public ViewNotePage(int noteIndex)
        {
            InitializeComponent();
            _noteIndex = noteIndex;

            _noteManager = App.Container.Resolve<NoteManager>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            var note = _noteManager.MyNotes[_noteIndex];
            BindingContext = note;

            var notereader = App.Container.Resolve<INoteReader>();

            notereader.Speak(
                $"{note.NoteTitle}, {note.NoteText}, " +
                $"posted on {note.TimeStamp:D}, {note.TimeStamp:t}");
        }

        private void EditNoteButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditNotePage(_noteIndex));
        }
    }
}

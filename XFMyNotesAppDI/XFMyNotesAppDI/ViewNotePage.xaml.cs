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
        private readonly int _noteIndex;
        public ViewNotePage(int noteIndex)
        {
            InitializeComponent();
            _noteIndex = noteIndex;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            NoteManager viewModel = App.Container.Resolve(typeof(NoteManager), nameof(NoteManager)) as NoteManager;
            
            var note = viewModel.MyNotes[_noteIndex];
            BindingContext = note;

            var notereader = App.Container.Resolve(typeof(INoteReader), nameof(INoteReader)) as INoteReader;

            notereader.Speak(
                $"{note.NoteTitle} {note.NoteText}, " +
                $"posted on {note.TimeStamp:D}, {note.TimeStamp:t}");
        }

        private void EditNoteButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditNotePage(_noteIndex));
        }
    }
}

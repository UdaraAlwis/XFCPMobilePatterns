using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFMyNotesAppDI
{
    public partial class NoteListPage : ContentPage
    {
        public NoteListPage()
        {
            InitializeComponent();
            NoteListView.ItemSelected += NoteListViewOnItemSelected;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //NoteListView.ItemsSource = NoteManager.Instance.MyNotes;
        }

        private void NoteListViewOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            //int index = NoteManager.Instance.MyNotes.IndexOf((MyNote)selectedItemChangedEventArgs.SelectedItem);
            //Navigation.PushAsync(new ViewNotePage(index));
        }

        private void AddNewNoteButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditNotePage());
        }

        private void OnEdit(object sender, EventArgs e)
        {
            //var note = (MyNote)((MenuItem)sender).CommandParameter;
            //int index = NoteManager.Instance.MyNotes.IndexOf(note);

            //Navigation.PushAsync(new EditNotePage(index));
        }

        private void OnDelete(object sender, EventArgs e)
        {
            //var note = (MyNote)((MenuItem)sender).CommandParameter;
            //NoteManager.Instance.MyNotes.Remove(note);
        }
    }
}

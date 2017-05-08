using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFMyNotesAppFP
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

            NoteListView.ItemsSource = ServiceLoaderManager.Instance.MyNotes;
        }

        private void NoteListViewOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            int index = ServiceLoaderManager.Instance.MyNotes.IndexOf((MyNote)selectedItemChangedEventArgs.SelectedItem);
            Navigation.PushAsync(new ViewNotePage(index));
        }
    }
}

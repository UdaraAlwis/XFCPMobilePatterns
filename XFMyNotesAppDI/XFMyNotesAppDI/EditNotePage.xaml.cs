using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFMyNotesAppDI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNotePage : ContentPage
    {
        private readonly int _noteIndex = -1;
        public EditNotePage(int? noteIndex = null)
        {
            InitializeComponent();

            //if (noteIndex != null)
            //{
            //    _noteIndex = noteIndex.Value;
            //    SaveButton.Text = "Update";
            //}
            //else
            //{
            //    SaveButton.Text = "Add";
            //}
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (_noteIndex != -1)
            //{
            //    BindingContext = NoteManager.Instance.MyNotes[_noteIndex];
            //}
            //else
            //{
            //    BindingContext = new MyNote();
            //}
        }

        private void SaveButton_OnClicked(object sender, EventArgs e)
        {
            //if (_noteIndex != -1)
            //{
            //    Navigation.PopAsync();
            //}
            //else
            //{
            //    ((MyNote)this.BindingContext).TimeStamp = DateTime.Now;
            //    NoteManager.Instance.MyNotes.Insert(0, (MyNote)this.BindingContext);
            //    Navigation.PopAsync();
            //}
        }
    }
}

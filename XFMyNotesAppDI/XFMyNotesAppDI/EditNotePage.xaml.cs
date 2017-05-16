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
    public partial class EditNotePage : ContentPage
    {
        private NoteManager _noteManager;
        private readonly int _noteIndex = -1;
        public EditNotePage(int? noteIndex = null)
        {
            _noteManager = App.Container.Resolve<NoteManager>();

            InitializeComponent();

            if (noteIndex != null)
            {
                _noteIndex = noteIndex.Value;
                SaveButton.Text = "Update";
            }
            else
            {
                SaveButton.Text = "Add";
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_noteIndex != -1)
            {
                BindingContext = _noteManager.MyNotes[_noteIndex];
            }
            else
            {
                BindingContext = new MyNote();
            }
        }

        private void SaveButton_OnClicked(object sender, EventArgs e)
        {
            if (_noteIndex != -1)
            {
                Navigation.PopAsync();
            }
            else
            {
                ((MyNote)this.BindingContext).TimeStamp = DateTime.Now;
                _noteManager.MyNotes.Insert(0, (MyNote)this.BindingContext);
                Navigation.PopAsync();
            }
        }
    }
}

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
    public partial class EditNotePage : ContentPage
    {
        private readonly int _noteIndex;
        public EditNotePage(int noteIndex)
        {
            InitializeComponent();
            _noteIndex = noteIndex;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = ServiceLoaderManager.Instance.MyNotes[_noteIndex];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFMyNotesAppFP
{
    public class NoteManager
    {
        private static readonly NoteManager _instance = new NoteManager();
        public static NoteManager Instance { get { return _instance; } }


        public IList<MyNote> MyNotes { get; private set; }


        public INoteLoader NoteLoader { get; private set; }
        
        public INoteReader NoteReader { get; private set; }

        private NoteManager()
        {
            NoteLoader = ServiceLoaderFactory.CreateNoteLoader();
            NoteReader = ServiceLoaderFactory.CreateNoteReader();

            MyNotes = new ObservableCollection<MyNote>(NoteLoader.Load());
        }

        public void Save()
        {
            NoteLoader.Save(MyNotes);
        }
    }
}

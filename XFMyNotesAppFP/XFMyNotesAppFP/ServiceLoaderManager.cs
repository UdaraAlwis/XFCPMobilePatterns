using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFMyNotesAppFP
{
    public class ServiceLoaderManager
    {
        private static readonly ServiceLoaderManager _instance = new ServiceLoaderManager();
        public static ServiceLoaderManager Instance { get { return _instance; } }


        public IList<MyNote> MyNotes { get; private set; }


        public INoteLoader NoteLoader { get; private set; }
        
        public INoteReader NoteReader { get; private set; }

        private ServiceLoaderManager()
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

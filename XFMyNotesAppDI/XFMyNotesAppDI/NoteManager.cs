using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFMyNotesAppDI
{
    public class NoteManager
    {
        private readonly INoteReader _noteReader;
        private readonly INoteLoader _noteLoader;

        public IList<MyNote> MyNotes { get; private set; }
        
        public NoteManager(INoteLoader noteLoader, INoteReader noteReader)
        {
            _noteReader = noteReader;
            _noteLoader = noteLoader;
            
            MyNotes = new ObservableCollection<MyNote>(_noteLoader.Load());
        }

        public void Save()
        {
            _noteLoader.Save(MyNotes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFMyNotesAppSL
{
    public class NoteManager
    {
        private static readonly NoteManager _instance = new NoteManager();
        public static NoteManager Instance { get { return _instance; } }


        public IList<MyNote> MyNotes { get; private set; }
        
        private NoteManager()
        {
            var noteLoader = ServiceLocator.Instance.Resolve<INoteLoader>();
            MyNotes = new ObservableCollection<MyNote>(noteLoader.Load());
        }

        public void Save()
        {
            var noteLoader = ServiceLocator.Instance.Resolve<INoteLoader>();
            noteLoader.Save(MyNotes);
        }
    }
}

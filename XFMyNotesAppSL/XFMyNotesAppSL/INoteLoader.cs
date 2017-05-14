using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFMyNotesAppSL
{
    public interface INoteLoader
    {
        IEnumerable<MyNote> Load();

        void Save(IEnumerable<MyNote> notes);
    }
}

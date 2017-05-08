using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFMyNotesAppFP
{
    public static class ServiceLoaderFactory
    {
        public static Func<INoteLoader> CreateNoteLoader { get; set; }
        
        public static Func<INoteReader> CreateNoteReader { get; set; }
    }
}

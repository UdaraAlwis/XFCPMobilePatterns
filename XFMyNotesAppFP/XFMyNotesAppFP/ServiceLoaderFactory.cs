using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFMyNotesAppFP
{
    public static class ServiceLoaderFactory<T>
    {
        public static Func<T> CreateService { get; set; }
    }
}

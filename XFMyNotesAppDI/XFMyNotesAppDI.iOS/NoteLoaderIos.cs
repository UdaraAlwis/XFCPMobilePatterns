using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace XFMyNotesAppDI.iOS
{
    public class NoteLoaderIos : INoteLoader
    {
        const string FileName = "notes.xml";

        public IEnumerable<MyNote> Load()
        {
            XDocument doc = null;

            string filename = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "..", "Library", FileName);

            if (File.Exists(filename))
            {
                try
                {
                    doc = XDocument.Load(filename);
                }
                catch
                {
                }
            }

            if (doc == null)
                doc = XDocument.Parse(DefaultData);

            if (doc?.Root != null)
            {
                foreach (var entry in doc.Root.Elements("note"))
                {
                    yield return new MyNote(
                        entry.Attribute("title")?.Value,
                        entry.Value,
                        DateTime.Parse(entry.Attribute("timestamp")?.Value));
                }
            }
        }

        public void Save(IEnumerable<MyNote> notes)
        {
            string filename = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "..", "Library", FileName);

            if (File.Exists(filename))
                File.Delete(filename);

            XDocument doc = new XDocument(
                new XElement("notes",
                    notes.Select(q =>
                        new XElement("note",
                            new XAttribute("title", q.NoteTitle),
                            new XAttribute("timestamp", q.TimeStamp))
                        {
                            Value = q.NoteText
                        })));

            doc.Save(filename);
        }

        #region Internal Data
        static string DefaultData =
            @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <notes>
	            <note title=""Flying Monkeys"" timestamp=""5/8/2017 10:31:13 AM"">What if Monkeys could fly? that would be the most awesome thing ever!</note>
	            <note title=""Banana Forest"" timestamp=""3/8/2017 10:31:13 AM"">I like bananas. They're the best! Ok I need some babana right now.</note>
            </notes>";
        #endregion
    }
}
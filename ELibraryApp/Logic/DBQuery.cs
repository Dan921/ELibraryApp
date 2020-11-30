using ELibraryApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibraryApp.Logic
{
    public class DBQuery
    {
        ELibraryDBEntities eLibraryDBEntities = new ELibraryDBEntities();

        public void AddUserWithReader(Reader _reader, User _user)
        {
            eLibraryDBEntities.Users.Add(_user);
            eLibraryDBEntities.SaveChanges();
            _reader.UserId = eLibraryDBEntities.Users.FirstOrDefault(u => u.Login == _user.Login).UserId;
            eLibraryDBEntities.Readers.Add(_reader);
            eLibraryDBEntities.SaveChanges();
        }

        public void AddJournalRecord(BookReservationJournal _bookReservationJournal)
        {
            eLibraryDBEntities.BookReservationJournals.Add(_bookReservationJournal);
            eLibraryDBEntities.SaveChanges();
        }

        public void AddBook(Book _book)
        {
            eLibraryDBEntities.Books.Add(_book);
            eLibraryDBEntities.SaveChanges();
        }

        public void DeleteJournalRecord(BookReservationJournal _bookReservationJournal)
        {
            eLibraryDBEntities.BookReservationJournals.Remove(_bookReservationJournal);
            eLibraryDBEntities.SaveChanges();
        }

        public void DeleteReaderWithUser(Reader _reader)
        {
            eLibraryDBEntities.Readers.Remove(_reader);
            eLibraryDBEntities.Users.Remove(eLibraryDBEntities.Users.FirstOrDefault(u => u.UserId == _reader.UserId));
            eLibraryDBEntities.SaveChanges();
        }
    }
}

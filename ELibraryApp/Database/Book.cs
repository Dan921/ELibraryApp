//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ELibraryApp.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.BookReservationJournals = new HashSet<BookReservationJournal>();
        }
    
        public int BookId { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Nullable<int> PublishingYear { get; set; }
        public string Description { get; set; }
        public byte[] CoverImage { get; set; }
        public string Genre { get; set; }
        public Nullable<int> NumberOfCopies { get; set; }
        public Nullable<bool> IsPublished { get; set; }
        public Nullable<int> PenaltyPoint { get; set; }
        public string Tags { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual Author Author { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookReservationJournal> BookReservationJournals { get; set; }
    }
}

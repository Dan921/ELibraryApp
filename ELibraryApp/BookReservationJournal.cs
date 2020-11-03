//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ELibraryApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookReservationJournal
    {
        public int RecordId { get; set; }
        public System.DateTime BookingStartDate { get; set; }
        public System.DateTime BookingEndDate { get; set; }
        public Nullable<int> ReservationCode { get; set; }
        public int BookingStatusId { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
    
        public virtual BookingStatus BookingStatus { get; set; }
        public virtual Book Book { get; set; }
        public virtual Reader Reader { get; set; }
    }
}

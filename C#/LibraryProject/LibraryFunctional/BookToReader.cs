using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFunctional
{
    public class BookToReader
    {
        [Key]
        [ForeignKey("Book")]
        [Column(Order = 1)]
        public int BookId { get; set; }
        public Book Book { get; set; }

        [Key]
        [ForeignKey("Reader")]
        [Column(Order = 2)]
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }

        public DateTime? DateOfIssue { get; set; }
        public DateTime? ReturnDate { get; set; }


    }
}

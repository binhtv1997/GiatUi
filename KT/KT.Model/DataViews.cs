using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KT.Model
{
    public class DataViews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Problem { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateCreate { get; set; }
    }
}

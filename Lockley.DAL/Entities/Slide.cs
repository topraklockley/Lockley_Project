using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockley.DAL.Entities
{
    public class Slide
    {
        public int ID { get; set; }

        [Column(TypeName = "Varchar(50)"), StringLength(50), Display(Name ="Slide Slogan")]

        public string Slogan { get; set; }

        [Column(TypeName = "Varchar(50)"), StringLength(50), Display(Name = "Slide Title"), Required(ErrorMessage ="This field cannot be empty.")]

        public string Title { get; set; }

        [Column(TypeName = "Varchar(250)"), StringLength(250), Display(Name = "Slide Description"), Required(ErrorMessage = "This field cannot be empty.")]

        public string Description { get; set; }

        [Column(TypeName = "Varchar(150)"), StringLength(150), Display(Name = "Slide Picture")]

        public string FilePath { get; set; }

        [Column(TypeName = "decimal(18,2)"), Display(Name = "Price Information"), Required(ErrorMessage = "This field cannot be empty.")]

        public decimal Price { get; set; }

        [Column(TypeName = "Varchar(150)"), StringLength(150), Display(Name = "Link")]

        public string Link { get; set; }

        [Display(Name = "Display Index"), Required(ErrorMessage = "This field cannot be empty.")]

        public int DisplayIndex { get; set; }
    }
}

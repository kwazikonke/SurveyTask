using SurveyTask.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyTask.Models
{
    public class Customer
    {
        //PERSONAL DETAILS
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [DataType(dataType: DataType.PhoneNumber)]
        [RegularExpression(pattern: @"^\(?([0]{1})\)?[-. ]?([1-9]{1})[-. ]?([0-9]{8})$", ErrorMessage = "Entered number format is not valid.")]
        [StringLength(maximumLength: 10, ErrorMessage = "SA Contact Number must be exactly 10 digits long", MinimumLength = 10)]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "Age")]
        [Range(6, 119)]
        public int Age { get; set; }

        //CHECKBOXES
        [Display(Name = "Pizza")]
        [Required]
        public bool Pizza { get; set; }

        [Display(Name = "Pasta")]
        [Required]
        public bool Pasta { get; set; }

        [Display(Name = "Pap and Wors")]
        [Required]
        public bool PapandWors { get; set; }

        [Display(Name = "Chicken Stir fry")]
        [Required]
        public bool ChickenStirfry { get; set; }

        [Display(Name = "Beef Stir Fry")]
        [Required]
        public bool BeefStirFry { get; set; }

        [Display(Name = "Other")]
        [Required]
        public bool Other { get; set; }

        //RADIO BUTTONS
        [Display(Name = "I like to eat out")]
        [Required]
        public string firstQ { get; set; }
        
        [Display(Name = "I like to watch movies")]
        [Required]
        public string SecQ { get; set; }
       
        [Display(Name = "I like to watch TV")]
        [Required]
        public string thirdQ { get; set; }
       
        [Display(Name = "I like to listen to the radio")]
        [Required]
        public string forthQ { get; set; }

        public string Answer { get; set; }
     

        /////CALCULATIONS/////

        ApplicationDbContext db = new ApplicationDbContext();
        //CALC AGE
        public int Young()
        {
            int minAge = db.Customers.Min(p => p.Age);

            return minAge;
        }
        public int Old()
        {
            int maxAge = db.Customers.Max(p => p.Age);

            return maxAge;
        }
        public int Avarage()
        {
            int avarag = (int)db.Customers.Average(p => p.Age);
            return avarag;
        }
        public int TotalNum()
        {
            int count = db.Customers.Count();
            return count;
        }
        //CALC PERCENTAGE
        public decimal Calc()
        {
            decimal Percentage = 0;
            if (Pizza == true)
            {
                int numof_pizza = 0;
                Percentage = numof_pizza / TotalNum() * 100;
            }
            if (Pasta == true)
            {
                int numof_pasta = 0;
                Percentage = numof_pasta / TotalNum() * 100;
            }
            if (PapandWors == true)
            {
                int numof_pap = 0;
                Percentage = numof_pap / TotalNum() * 100;
            }
            return (Percentage);
        }

        //AVERAGE RATING



     }
}
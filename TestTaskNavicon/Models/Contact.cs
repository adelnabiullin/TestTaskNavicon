using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskNavicon.Models
{
    public enum Sex
    {
        [Display(Name = "Не указан")]
        U,

        [Display(Name = "Мужской")]
        M,

        [Display(Name = "Женский")]
        F
    }

    public class Contact
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} не должно быть пустым")]
        [DisplayName("Имя")]
        [StringLength(100, ErrorMessage = "{0} должно быть не длиннее 100 символов")]
        public string name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} не должна быть пустой")]
        [DisplayName("Фамилия")]
        [StringLength(100, ErrorMessage = "{0} должна быть не длиннее 100 символов")]
        public string surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} не должно быть пустым")]
        [DisplayName("Отчество")]
        [StringLength(100, ErrorMessage = "{0} должно быть не длиннее 100 символов")]
        public string patronymic { get; set; }

        [Required(ErrorMessage = "{0} не должна быть пустой")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Дата рождения")]
        public DateTime birthday { get; set; }

        [Required(ErrorMessage = "{0} не должен быть пустым")]
        [DisplayName("Пол")]
        public Sex sex { get; set; }

        [NotMapped]
        public int age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - birthday.Year;
                if (birthday > today.AddYears(-age)) age--;
                return age;
            }
        }
    }
}

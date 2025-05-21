using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    internal class Person
    {
        [DisplayName("ФИО сотрудника")]
        public string FullName { get; set; }
        [DisplayName("Дата рождения")]
        public DateTime BirthDate { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [DisplayName("Должность")]
        public string JobTitle { get; set; }
        [DisplayName("Номер Т/Д")]
        public string LaborContractNumber { get; set; }
        [DisplayName("График работы")]
        public string Schedule { get; set; }
        [DisplayName("ЗП")]
        public decimal Salary { get; set; }

        public Person(
            string fullName,
            DateTime birthDate,
            string email,
            string jobTitle,
            string laborContractNumber,
            string schedule,
            decimal salary
        )
        {
            FullName = fullName;
            BirthDate = birthDate;
            Email = email;
            JobTitle = jobTitle;
            LaborContractNumber = laborContractNumber;
            Schedule = schedule;
            Salary = salary;
        }
    }
}

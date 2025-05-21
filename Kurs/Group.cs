using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    internal class Group
    {
        [DisplayName("Название отдела")]
        public string GName { get; set; }

        [DisplayName("ФИО руководителя")]
        public string Head { get; set; }

        public Group(
            string gname,
            string email
        )
        {
            GName = gname;
            Head = email;
        }
    }
}

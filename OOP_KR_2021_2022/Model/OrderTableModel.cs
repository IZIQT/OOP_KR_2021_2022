using OOP_KR_2021_2022.Common.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KR_2021_2022.Model
{
    class OrderTableModel : ViewModelBase
    {
        private int id;
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int book_name;
        public int Book_name
        {
            get => Book_name;
            set
            {
                Book_name = value;
                OnPropertyChanged(nameof(book_name));
            }
        }

        /// <summary>
        /// дата выдачи
        /// </summary>
        private int date_issue;
        public int Date_issue
        {
            get => date_issue;
            set
            {
                date_issue = value;
                OnPropertyChanged(nameof(Date_issue));
            }
        }

        /// <summary>
        /// дата сдачи
        /// </summary>
        private int date_delivery;
        public int Date_delivery
        {
            get => date_delivery;
            set
            {
                date_delivery = value;
                OnPropertyChanged(nameof(Date_delivery));
            }
        }
    }
}

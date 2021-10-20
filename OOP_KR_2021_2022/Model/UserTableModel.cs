using OOP_KR_2021_2022.Common.MVVM;

namespace OOP_KR_2021_2022.Model
{
    class UserTableModel : ViewModelBase
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

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        private string surname;
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        private string patronymic;
        public string Patronymic
        {
            get => patronymic;
            set
            {
                patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        private string adress;
        public string Adress
        {
            get => adress;
            set
            {
                adress = value;
                OnPropertyChanged(nameof(Adress));
            }
        }

        private string phone;
        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
    }
}

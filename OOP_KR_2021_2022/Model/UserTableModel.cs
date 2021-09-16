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

        private int name;
        public int Name
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
        private int surname;
        public int Surname
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
        private int patronymic;
        public int Patronymic
        {
            get => patronymic;
            set
            {
                patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        private int adress;
        public int Adress
        {
            get => adress;
            set
            {
                adress = value;
                OnPropertyChanged(nameof(Adress));
            }
        }

        private int phone;
        public int Phone
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

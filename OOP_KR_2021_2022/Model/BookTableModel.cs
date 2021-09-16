using OOP_KR_2021_2022.Common.MVVM;

namespace OOP_KR_2021_2022.Model
{
    class BookTableModel : ViewModelBase
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
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string author;
        /// <summary>
        /// Автор
        /// </summary>
        public string Author
        {
            get => author;
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        private string publishing_house;
        /// <summary>
        /// Издание
        /// </summary>
        public string Publishing_house
        {
            get => publishing_house;
            set
            {
                publishing_house = value;
                OnPropertyChanged(nameof(Publishing_house));
            }
        }
        
        private int year_publishing;
        /// <summary>
        /// Год издания
        /// </summary>
        public int Year_publishing
        {
            get => year_publishing;
            set
            {
                year_publishing = value;
                OnPropertyChanged(nameof(Year_publishing));
            }
        }

        private int countPage;
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int CountPage
        {
            get => countPage;
            set
            {
                countPage = value;
                OnPropertyChanged(nameof(CountPage));
            }
        }
    }
}

using OOP_KR_2021_2022.Common.MVVM;
using OOP_KR_2021_2022.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace OOP_KR_2021_2022.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<BookTableModel> bookTable;
        public ObservableCollection<BookTableModel> BookTable
        {
            get => bookTable;
            set
            {
                bookTable = value;
                OnPropertyChanged(nameof(BookTable));
            }
        }

        private ObservableCollection<FilterModel> filter_model;
        public ObservableCollection<FilterModel> Filter_model
        {
            get => filter_model;
            set
            {
                filter_model = value;
                OnPropertyChanged(nameof(Filter_model));
            }
        }

        private FilterModel selectedContact;
        public FilterModel SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        private string textSearch;
        public string TextSearch
        {
            get => textSearch;
            set
            {
                textSearch = value;
                Predicate<object> Filter;
                switch (selectedContact.Id)
                {
                    case 1:
                        Filter = delegate (object ul) {
                            foreach (BookTableModel item in bookTable)
                            {
                                return item.Author == ul.ToString() && item.Name == ul.ToString();
                            }
                            return false;
                        };
                        CollectionViewSource.GetDefaultView(BookTable).Filter = Filter;
                        break;
                    case 2:
                        Filter = delegate (object ul) {
                            foreach (BookTableModel item in bookTable)
                            {
                                return item.Author == ul.ToString();
                            }
                            return false;
                        };
                        CollectionViewSource.GetDefaultView(BookTable).Filter = Filter;
                        break;
                    case 3:
                        Filter = delegate (object ul) {
                            foreach (BookTableModel item in bookTable)
                            {
                                return item.Name.StartsWith(ul.ToString());
                            }
                            return false;
                        };
                        CollectionViewSource.GetDefaultView(BookTable).Filter = Filter;
                        break;
                }
                OnPropertyChanged(nameof(TextSearch));
            }
        }

        private bool StartFilterModel()
        {
            try
            {
                Filter_model = new ObservableCollection<FilterModel>();
                Filter_model.Add(new FilterModel() { Id = 1, Name = "Умный поиск" });
                filter_model.Add(new FilterModel() { Id = 2, Name = "Автор" });
                filter_model.Add(new FilterModel() { Id = 3, Name = "Название книги" });
                return true;
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
                return false;
            }
        }

        private bool StartBookTableModel()
        {
            try
            {
                BookTable = new ObservableCollection<BookTableModel>();
                BookTable.Add(new BookTableModel() { Id = 1, Author = "Анджей Сапковский", CountPage = 2800, Name = "Ведьмак", Publishing_house = "АТС", Year_publishing = 2020 });
                BookTable.Add(new BookTableModel() { Id = 2, Author = "Рэй Брэдбери", CountPage = 320, Name = "Вино из одуванчиков", Publishing_house = "Эксмо-Пресс", Year_publishing = 2021 });
                BookTable.Add(new BookTableModel() { Id = 3, Author = "Данте Алигьери", CountPage = 352, Name = "Божественная комедия", Publishing_house = "Речь", Year_publishing = 2018 });
                BookTable.Add(new BookTableModel() { Id = 4, Author = "Джек Лондон", CountPage = 256, Name = "Алая чума", Publishing_house = "АТС", Year_publishing = 2016 });
                BookTable.Add(new BookTableModel() { Id = 5, Author = "Джек Лондон", CountPage = 2800, Name = "Мартин Иден", Publishing_house = " Издательский дом Мещерякова", Year_publishing = 2018 });
                BookTable.Add(new BookTableModel() { Id = 6, Author = "Джеффри Николас", CountPage = 352, Name = "Дюна", Publishing_house = "АТС", Year_publishing = 2021 });
                BookTable.Add(new BookTableModel() { Id = 7, Author = "Эрик Берн", CountPage = 256, Name = "Игры, в которые играют люди", Publishing_house = "Бомбора", Year_publishing = 2017 });
                BookTable.Add(new BookTableModel() { Id = 8, Author = "Антуан Сент-Экзюпери", CountPage = 160, Name = "Маленький принц", Publishing_house = "Эксмо", Year_publishing = 2011 });
                BookTable.Add(new BookTableModel() { Id = 9, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 1", Publishing_house = "Речь", Year_publishing = 2017 });
                BookTable.Add(new BookTableModel() { Id = 10, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 2", Publishing_house = "Речь", Year_publishing = 2017 });
                BookTable.Add(new BookTableModel() { Id = 11, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 3", Publishing_house = "Речь", Year_publishing = 2017 });
                BookTable.Add(new BookTableModel() { Id = 12, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 4", Publishing_house = "Речь", Year_publishing = 2017 });
                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return false;
            }
        }

        public MainWindowViewModel()
        {
            if (StartFilterModel() && StartBookTableModel())
            {

            }
        }


    }
}

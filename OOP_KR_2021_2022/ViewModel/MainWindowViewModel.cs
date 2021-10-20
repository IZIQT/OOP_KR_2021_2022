using OOP_KR_2021_2022.Common.MVVM;
using OOP_KR_2021_2022.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace OOP_KR_2021_2022.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<UserTableModel> userTable;
        public ObservableCollection<UserTableModel> UserTable
        {
            get => userTable;
            set
            {
                userTable = value;
                OnPropertyChanged(nameof(UserTable));
            }
        }

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
                if (TextSearch != null) TextSearch = textSearch;
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
                        Filter = delegate (object ul)
                        {
                            return ((BookTableModel)(ul)).Author.ToUpper().Contains(textSearch.ToUpper()) || ((BookTableModel)(ul)).Name.ToUpper().Contains(textSearch.ToUpper());
                        };
                        CollectionViewSource.GetDefaultView(BookTable).Filter = Filter;
                        break;
                    case 2:
                        Filter = delegate (object ul) {
                            return ((BookTableModel)(ul)).Author.ToUpper().Contains(textSearch.ToUpper());
                        };
                        CollectionViewSource.GetDefaultView(BookTable).Filter = Filter;
                        break;
                    case 3:
                        Filter = delegate (object ul) {
                            return ((BookTableModel)(ul)).Name.ToUpper().Contains(textSearch.ToUpper());
                        };
                        CollectionViewSource.GetDefaultView(BookTable).Filter = Filter;
                        break;
                }
                OnPropertyChanged(nameof(TextSearch));
            }
        }

        private BookTableModel selectedBook;
        public BookTableModel SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }
        
        private string tBAuthor;
        public string TBAuthor
        {
            get => tBAuthor;
            set
            {
                ErrorText = "";
                tBAuthor = value;
                OnPropertyChanged(nameof(TBAuthor));
            }
        }

        private string tBName;
        public string TBName
        {
            get => tBName;
            set
            {
                ErrorText = "";
                tBName = value;
                OnPropertyChanged(nameof(TBName));
            }
        }

        private string tBPublishing_house;
        public string TBPublishing_house
        {
            get => tBPublishing_house;
            set
            {
                ErrorText = "";
                tBPublishing_house = value;
                OnPropertyChanged(nameof(TBPublishing_house));
            }
        }

        private string tBYear_publishing;
        public string TBYear_publishing
        {
            get => tBYear_publishing;
            set
            {
                ErrorText = "";
                tBYear_publishing = value;
                OnPropertyChanged(nameof(TBYear_publishing));
            }
        }

        private string tBCountPage;
        public string TBCountPage
        {
            get => tBCountPage;
            set
            {
                ErrorText = "";
                tBCountPage = value;
                OnPropertyChanged(nameof(TBCountPage));
            }
        }

        private bool gridAddBook;
        public bool GridAddBook
        {
            get => gridAddBook;
            set
            {
                gridAddBook = value;
                OnPropertyChanged(nameof(GridAddBook));
            }
        }

        private bool bookTableVisibility;
        public bool BookTableVisibility
        {
            get => bookTableVisibility;
            set
            {
                bookTableVisibility = value;
                OnPropertyChanged(nameof(BookTableVisibility));
            }
        }

        private bool userTableVisibility;
        public bool UserTableVisibility
        {
            get => userTableVisibility;
            set
            {
                userTableVisibility = value;
                OnPropertyChanged(nameof(UserTableVisibility));
            }
        }

        private string errorText;
        public string ErrorText
        {
            get => errorText;
            set
            {
                errorText = value;
                OnPropertyChanged(nameof(ErrorText));
            }
        }
        
        public ICommand OrderBookCommand { get; set; }
        public ICommand BookDepositoryCommand { get; set; }
        public ICommand AccountingClientsCommand { get; set; }
        public ICommand AddBook { get; set; }
        public ICommand CreateBookReportCommand { get; set; }
        public ICommand CreateBooksReportCommand { get; set; }
        public MainWindowViewModel()
        {
            if (StartFilter() && StartBookTable() && StartUserTable())
            {
                UserTableVisibility = false;
                BookTableVisibility = false;
                GridAddBook = true;
                //UserTableVisibility = false;
                //BookTableVisibility = true;
                OrderBookCommand = new RelayCommand(OrderBookCommandExecute);
                BookDepositoryCommand = new RelayCommand(BookDepositoryCommandExecute);
                AccountingClientsCommand = new RelayCommand(AccountingClientsCommandExecute);
                AddBook = new RelayCommand(AddBookExecute);
                CreateBookReportCommand = new RelayCommand(CreateBookReportCommandExecute);
                CreateBooksReportCommand = new RelayCommand(CreateBooksReportCommandExecute);
            }
            else
            {
                Application.Current.MainWindow.Close();
            }
        }

        private void CreateBookReportCommandExecute(object obj)
        {
            ReportClass asd = new ReportClass();
            asd.CreateBookReport(obj as BookTableModel);
        }

        private void CreateBooksReportCommandExecute(object obj)
        {
            ReportClass asd = new ReportClass();
            asd.CreateBooksReport(BookTable);
        }

        private bool BookTableContains(BookTableModel ContainsItem)
        {
            foreach (BookTableModel item in BookTable)
            {
                if (ContainsItem.Id == item.Id && ContainsItem.Name == item.Name && ContainsItem.Publishing_house == item.Publishing_house && ContainsItem.Year_publishing == item.Year_publishing && ContainsItem.Author == item.Author) return true;
            }
            return false;
        }

        private void AddBookExecute(object obj)
        {
            if(BookTable != null)
            {
                int temp1, temp2;
                if(int.TryParse(tBCountPage, out temp1) && int.TryParse(tBYear_publishing, out temp2) && tBAuthor != "" && tBName != "" && tBPublishing_house != "" && tBCountPage != null && tBYear_publishing != null && tBAuthor != null && tBName != null && tBPublishing_house != null)
                {
                    int maxId = 0;
                    foreach (BookTableModel item in BookTable)
                    {
                        if (item.Id > maxId) maxId = item.Id+1;
                    }
                    BookTableModel temp = new BookTableModel() {Id = maxId, Author = tBAuthor, Name = tBName, CountPage = temp1, Publishing_house = tBPublishing_house, Year_publishing = temp2 };
                    if (BookTableContains(temp))
                    {
                        ErrorText = "Данный элемент находиться в таблице";
                        startTimer();
                    }
                    else
                    {
                        bookTable.Add(temp);
                        ErrorText = "Запись добавленна!";
                        startTimer();
                    }
                    
                }
                else
                {
                    ErrorText = "Корректно заполните поля!";
                }
                
            }
        }
        System.Timers.Timer timer = new System.Timers.Timer();

        void startTimer()
        {
            z = 0;
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000;
            timer.Start();
        }

        private int z;
        void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            z++;
            if (z == 5)
            {
                ErrorText = "";
                timer.Stop();
            }
        }

        private void AccountingClientsCommandExecute(object obj)
        {
            UserTableVisibility = true;
            BookTableVisibility = false;
            GridAddBook = false;
        }

        private void BookDepositoryCommandExecute(object obj)
        {
            UserTableVisibility = false;
            GridAddBook = false;
            BookTableVisibility = true;
        }

        private void OrderBookCommandExecute(object obj)
        {
            UserTableVisibility = false;
            BookTableVisibility = false;
            GridAddBook = true;
        }

        private bool StartFilter()
        {
            try
            {
                Filter_model = new ObservableCollection<FilterModel>();
                Filter_model.Add(new FilterModel() { Id = 1, Name = "Умный поиск" });
                filter_model.Add(new FilterModel() { Id = 2, Name = "Автор" });
                filter_model.Add(new FilterModel() { Id = 3, Name = "Название книги" });
                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return false;
            }
        }
        private bool StartBookTable()
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

        private bool StartUserTable()
        {
            try
            {
                UserTable = new ObservableCollection<UserTableModel>();
                UserTable.Add(new UserTableModel() { Id = 1, Name = "Василий", Surname = "Пупкин", Patronymic = "Валерьевич", Adress = "Г.Санкт-Петербург ул. Мира д.6 кв.23", Phone = "89535338532" });
                UserTable.Add(new UserTableModel() { Id = 1, Name = "Сергей", Surname = "Инанопуло", Patronymic = "Сергеевич", Adress = "Г.Санкт-Петербург ул. Советская д.26 кв.213", Phone = "89535368332" });
                UserTable.Add(new UserTableModel() { Id = 1, Name = "Мурат", Surname = "Акрапетян", Patronymic = "Абдулович", Adress = "Г.Самара ул. Советская д.16 кв.123", Phone = "89742588532" });
                UserTable.Add(new UserTableModel() { Id = 1, Name = "Мария", Surname = "Смоленко", Patronymic = "Васильевна", Adress = "Г.Судак ул. Строителей д.12 кв.57", Phone = "89536538431" });
                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return false;
            }
        }
    }
}

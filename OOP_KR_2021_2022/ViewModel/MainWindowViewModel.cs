using Microsoft.Win32;
using OOP_KR_2021_2022.Common.MVVM;
using OOP_KR_2021_2022.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataAdapter adapter;

        private string FilePath { get; set; }
        private DataTable userTable;
        public DataTable UserTable
        {
            get => userTable;
            set
            {
                userTable = value;
                OnPropertyChanged(nameof(UserTable));
            }
        }

        private DataTable bookTable;
        public DataTable BookTable
        {
            get => bookTable;
            set
            {
                bookTable = value;
                OnPropertyChanged(nameof(BookTable));
            }
        }

        private DataTable bookTableDits;
        public DataTable BookTableDits
        {
            get => bookTableDits;
            set
            {
                bookTableDits = value;
                OnPropertyChanged(nameof(BookTableDits));
            }
        }


        //private ObservableCollection<BookTableModel> bookTable;
        //public ObservableCollection<BookTableModel> BookTable
        //{
        //    get => bookTable;
        //    set
        //    {
        //        bookTable = value;
        //        OnPropertyChanged(nameof(BookTable));
        //    }
        //}

        //private ObservableCollection<BookTableModel> bookTableDits;
        //public ObservableCollection<BookTableModel> BookTableDits
        //{
        //    get => bookTableDits;
        //    set
        //    {
        //        bookTableDits = value;
        //        OnPropertyChanged(nameof(BookTableDits));
        //    }
        //}

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

        private object selectedUserCombobox;
        public object SelectedUserCombobox
        {
            get => selectedUserCombobox;
            set
            {
                selectedUserCombobox = value;
                OnPropertyChanged(nameof(SelectedUserCombobox));
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
                        BookTable.DefaultView.RowFilter = string.Format("Author LIKE '%{0}%' or Name LIKE '%{0}%'", textSearch.ToUpper());
                        //Filter = delegate (object ul)
                        //{
                        //    return ((DataRow)(ul)).ItemArray[3].ToString().Contains(textSearch.ToUpper()) ;
                        //};
                        //CollectionViewSource.GetDefaultView(BookTable.Rows).Filter = Filter;
                        break;
                    case 2:
                        BookTable.DefaultView.RowFilter = string.Format("Author LIKE '%{0}%'", textSearch.ToUpper());
                        //Filter = delegate (object ul) {
                        //    return ((BookTableModel)(ul)).Author.ToUpper().Contains(textSearch.ToUpper());
                        //};
                        //CollectionViewSource.GetDefaultView(BookTable).Filter = Filter;
                        break;
                    case 3:
                        BookTable.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", textSearch.ToUpper());
                        //Filter = delegate (object ul) {
                        //    return ((BookTableModel)(ul)).Name.ToUpper().Contains(textSearch.ToUpper());
                        //};
                        //CollectionViewSource.GetDefaultView(BookTable).Filter = Filter;
                        break;
                }
                OnPropertyChanged(nameof(TextSearch));
            }
        }

        //private BookTableModel selectedBook;
        //public BookTableModel SelectedBook
        //{
        //    get => selectedBook;
        //    set
        //    {
        //        selectedBook = value;
        //        OnPropertyChanged(nameof(SelectedBook));
        //    }
        //}

        //private BookTableModel selectedBookDist;
        //public BookTableModel SelectedBookDist
        //{
        //    get => selectedBookDist;
        //    set
        //    {
        //        selectedBookDist = value;
        //        OnPropertyChanged(nameof(SelectedBookDist));
        //    }
        //}

        private DataRowView selectedBook;
        public DataRowView SelectedBook
        {
            get => selectedBook;
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        private DataRowView selectedBookDist;
        public DataRowView SelectedBookDist
        {
            get => selectedBookDist;
            set
            {
                selectedBookDist = value;
                OnPropertyChanged(nameof(SelectedBookDist));
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

        private string tBCountBook;
        public string TBCountBook
        {
            get => tBCountPage;
            set
            {
                ErrorText = "";
                tBCountBook = value;
                OnPropertyChanged(nameof(TBCountBook));
            }
        }

        private string tBUSurname;
        public string TBUSurname
        {
            get => tBUSurname;
            set
            {
                ErrorText = "";
                tBUSurname = value;
                OnPropertyChanged(nameof(TBUSurname));
            }
        }

        private string tBUName;
        public string TBUName
        {
            get => tBUName;
            set
            {
                ErrorText = "";
                tBUName = value;
                OnPropertyChanged(nameof(TBUName));
            }
        }

        private string tBUPatronymic;
        public string TBUPatronymic
        {
            get => tBUPatronymic;
            set
            {
                ErrorText = "";
                tBUPatronymic = value;
                OnPropertyChanged(nameof(TBUPatronymic));
            }
        }

        private string tBUAdress;
        public string TBUAdress
        {
            get => tBUAdress;
            set
            {
                ErrorText = "";
                tBUAdress = value;
                OnPropertyChanged(nameof(TBUAdress));
            }
        }

        private string tBUPhone;
        public string TBUPhone
        {
            get => tBUPhone;
            set
            {
                ErrorText = "";
                tBUPhone = value;
                OnPropertyChanged(nameof(TBUPhone));
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

        private bool gridAddUser;
        public bool GridAddUser
        {
            get => gridAddUser;
            set
            {
                gridAddUser = value;
                OnPropertyChanged(nameof(GridAddUser));
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

        private bool bookTableDustVisibility;
        public bool BookTableDustVisibility
        {
            get => bookTableDustVisibility;
            set
            {
                bookTableDustVisibility = value;
                OnPropertyChanged(nameof(BookTableDustVisibility));
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
        public ICommand IssueOfABookCommand { get; set; }
        public ICommand OrderUserCommand { get; set; }
        public ICommand BookDepositoryCommand { get; set; }
        public ICommand BookDepositoryDistCommand { get; set; }
        public ICommand AccountingClientsCommand { get; set; }
        public ICommand AddBook { get; set; }
        public ICommand AddUser { get; set; }
        public ICommand CreateBookReportCommand { get; set; }
        public ICommand CreateBooksReportCommand { get; set; }
        public ICommand LoadingBookFromFileCommand { get; set; }
        public ICommand CMCBSelectedCommand { get; set; }
        public ICommand ReturnOfTheBookCommand { get; set; }
        public ICommand BookSelectedItemCommand { get; set; }
        public MainWindowViewModel()
        {

            if (StartFilter() && StartBookTable() && StartUserTable())
            {
                UserTableVisibility = false;
                BookTableVisibility = true;
                GridAddBook = false;
                gridAddUser = false;

                OrderBookCommand = new RelayCommand(OrderBookCommandExecute);
                //IssueOfABookCommand = new RelayCommand(IssueOfABookCommandExecute);
                OrderUserCommand = new RelayCommand(OrderUserCommandExecute);
                BookDepositoryCommand = new RelayCommand(BookDepositoryCommandExecute);
                BookDepositoryDistCommand = new RelayCommand(BookDepositoryDistCommandExecute);
                AccountingClientsCommand = new RelayCommand(AccountingClientsCommandExecute);
                AddBook = new RelayCommand(AddBookExecute);
                AddUser = new RelayCommand(AddUserExecute);
                CreateBookReportCommand = new RelayCommand(CreateBookReportCommandExecute);
                CreateBooksReportCommand = new RelayCommand(CreateBooksReportCommandExecute);
                LoadingBookFromFileCommand = new RelayCommand(LoadingBookFromFileCommandExecute);
                CMCBSelectedCommand = new RelayCommand(CMCBSelectedCommandExecute);
                ReturnOfTheBookCommand = new RelayCommand(ReturnOfTheBookCommandExecute);
                //BookSelectedItemCommand = new RelayCommand(BookSelectedItemCommandExecute);
            }
            else
            {
                Application.Current.MainWindow.Close();
            }
        }

        private void ReturnOfTheBookCommandExecute(object obj)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "update BookTable set dateofissue = NULL, dateofdelivery = NULL, userid = NULL where id = '" + (obj as DataRowView).Row.ItemArray[0].ToString() + "'";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                connection.Close();
                StartBookTable();
            }
        }

        //private BookTableModel selectItem;
        //private void BookSelectedItemCommandExecute(object obj)
        //{
        //    selectItem = obj as BookTableModel;
        //    //throw new NotImplementedException();
        //}

        private void CMCBSelectedCommandExecute(object obj)
        {
            if(SelectedUserCombobox != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlExpression = "update BookTable set dateofissue = @dateofissue, dateofdelivery = @dateofdelivery, userid = @userid where id = '" + (obj as DataRowView).Row.ItemArray[0].ToString() + "'";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@dateofissue", "" + DateTime.Now.Month + '.' + DateTime.Now.Day + '.' + DateTime.Now.Year);
                    if (DateTime.Now.Month + 3 < 12)
                    {
                        command.Parameters.AddWithValue("@dateofdelivery", "" + (DateTime.Now.Month + 3) + '.' + DateTime.Now.Day + '.' + DateTime.Now.Year);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@dateofdelivery", "" + (DateTime.Now.Month + 3) % 12 + '.' + DateTime.Now.Day + '.' + (DateTime.Now.Year + 1));
                    }
                    command.Parameters.AddWithValue("@userid", (SelectedUserCombobox as DataRowView).Row.ItemArray[0].ToString());
                    command.ExecuteNonQuery();
                    connection.Close();
                    SelectedUserCombobox = null;
                    StartBookTable();
                }
            }

            //(obj as DataRowView).Row.ItemArray[6] = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //if (DateTime.Now.Month + 3 < 12)
            //{
            //    (obj as DataRowView).Row.ItemArray[7] = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 3, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //}
            //else
            //{
            //    (obj as DataRowView).Row.ItemArray[7] = new DateTime(DateTime.Now.Year + 1, (DateTime.Now.Month + 3) % 12, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //}

            //throw new NotImplementedException();
        }

        private int UserTableCountID()
        {
            int maxId = 0;
            foreach (DataRow item in UserTable.Rows)
            {
                if ((int)item.ItemArray[0] >= maxId) maxId = (int)item.ItemArray[0] + 1;
            }
            return maxId;
        }

        /// <summary>
        /// Поиск пользователя
        /// </summary>
        /// <param name="ContainsItem">искомый элемент</param>
        /// <param name="FindBook">найденный пользователь</param>
        /// <returns></returns>
        private bool UserTableContains(UserTableModel ContainsItem)
        {
            foreach (DataRow item in UserTable.Rows)
            {
                if (ContainsItem.Surname == item.ItemArray[2].ToString() && ContainsItem.Name == item.ItemArray[1].ToString() && ContainsItem.Patronymic == item.ItemArray[3].ToString() && ContainsItem.Adress == item.ItemArray[4].ToString() && ContainsItem.Phone == item.ItemArray[5].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private void AddUserExecute(object obj)
        {
            if (UserTable != null)
            {
                if (TBUSurname != "" && TBUName != "" && TBUPatronymic != "" && TBUAdress != "" && TBUPhone != "" && TBUSurname != null && TBUName != null && TBUPatronymic != null && TBUAdress != null && TBUPhone != null)
                {

                    UserTableModel temp = new UserTableModel() { Id = UserTableCountID(), Surname = TBUSurname, Name = TBUName, Patronymic = TBUPatronymic, Phone = TBUPhone, Adress = TBUAdress };
                    if (UserTableContains(temp))
                    {
                        ErrorText = "Данный пользователь уже существует в базе!";
                        startTimer();
                    }
                    else
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string sqlExpression = "INSERT INTO UserTable (Name, Surname, Patronymic, Phone, Adress) VALUES (@Name, @Surname, @Patronymic, @Phone, @Adress)";
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            command.Parameters.AddWithValue("@Name", TBUName);
                            command.Parameters.AddWithValue("@Surname", TBUSurname);
                            command.Parameters.AddWithValue("@Patronymic", TBUPatronymic);
                            command.Parameters.AddWithValue("@Phone", TBUPhone);
                            command.Parameters.AddWithValue("@Adress", TBUAdress);
                            command.ExecuteNonQuery();
                        }
                    }
                    //UserTable.Rows.Add(temp);
                    connection.Close();
                    StartUserTable();
                    ErrorText = "Запись добавленна!";
                    startTimer();
                }
            }
            else
            {
                ErrorText = "Корректно заполните поля!";
            }

        }

        private bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = Environment.SystemDirectory;
            openFileDialog.Filter = "Text documents (.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        private void LoadingBookFromFileCommandExecute(object obj)
        {
            FileOperations LBF = new FileOperations(BookTableCountID());
            if (OpenFileDialog())
            {
                ObservableCollection<BookTableModel> temp = LBF.LoadingBookFromFile(FilePath);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (BookTableModel item in temp)
                    {
                        //BookTableModel findName;
                        //BookTableContains(item, out findName);
                        if (BookTableContains(item))
                        {
                            //bookTable.Rows.Add(item);

                            string sqlExpression = "INSERT INTO BookTable (Author, Name, CountPage, Publishing_house, Year_publishing) VALUES (@Author, @Name, @CountPage, @Publishing_house, @Year_publishing)";
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            command.Parameters.AddWithValue("@Name", item.Name);
                            command.Parameters.AddWithValue("@Author", item.Author);
                            command.Parameters.AddWithValue("@CountPage", item.CountPage);
                            command.Parameters.AddWithValue("@Publishing_house", item.Publishing_house);
                            command.Parameters.AddWithValue("@Year_publishing", item.Year_publishing);
                            command.ExecuteNonQuery();

                        }
                    }
                    connection.Close();
                    StartBookTable();
                }
            }

        }

        public void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (BookTableModel item in e.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= EntityViewModelPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (BookTableModel item in e.NewItems)
                {
                    //Added items
                    if(item != null) item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
        }

        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var row = sender as BookTableModel;
            SaveData(row);
        }

        private void SaveData(BookTableModel row)
        {
            //BookTable.Add(row);
        }

        private void CreateBookReportCommandExecute(object obj)
        {
            ReportClass asd = new ReportClass();
            asd.CreateBookReport(obj as DataRowView);
        }

        private void CreateBooksReportCommandExecute(object obj)
        {
            ReportClass asd = new ReportClass();
            asd.CreateBooksReport(BookTable.Rows);
        }

        /// <summary>
        /// Поиск книги
        /// </summary>
        /// <param name="ContainsItem">искомый элемент</param>
        /// <param name="FindBook">Найденая книга</param>
        /// <returns></returns>
        private bool BookTableContains(BookTableModel ContainsItem)
        {
            foreach (DataRow item in BookTable.Rows)
            {
                if (ContainsItem.Name == item.ItemArray[2].ToString() && ContainsItem.Publishing_house == item.ItemArray[3].ToString() && ContainsItem.Year_publishing == (int)item.ItemArray[4] && ContainsItem.Author == item.ItemArray[1].ToString() && ContainsItem.CountPage == (int)item.ItemArray[5])
                {
                    //FindBook = item;
                    return false;
                }
            }
            //FindBook = null;
            return true;
        }

        public int BookTableCountID()
        {
            int maxId = 0;
            foreach (DataRow item in BookTable.Rows)
            {
                if ((int)item.ItemArray[0] >= maxId) maxId = (int)item.ItemArray[0] + 1;
            }
            return maxId;
        }

        private void AddBookExecute(object obj)
        {
            if(BookTable != null)
            {
                int _countPage, _tBYear_publishing, _countBook;
                if(int.TryParse(tBCountPage, out _countPage) && int.TryParse(tBYear_publishing, out _tBYear_publishing) && tBAuthor != "" && tBName != "" && tBPublishing_house != "" && tBCountPage != null && tBYear_publishing != null && tBAuthor != null && tBName != null && tBPublishing_house != null && int.TryParse(tBCountBook, out _countBook))
                {
                    int _localId = BookTableCountID();
                    int j = _localId;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        for (; _localId < j + _countBook; _localId++)
                        {
                            //BookTable.Rows.Add(new BookTableModel() { Id = _localId, Author = tBAuthor, Name = tBName, CountPage = _countPage, Publishing_house = tBPublishing_house, Year_publishing = _tBYear_publishing});
                            string sqlExpression = "INSERT INTO BookTable (Author, Name, CountPage, Publishing_house, Year_publishing) VALUES (@Author, @Name, @CountPage, @Publishing_house, @Year_publishing)";
                            //string sqlExpression = "INSERT INTO BookTable (Author, Name, CountPage, Publishing_house, Year_publishing) VALUES ('" + tBAuthor + "', '" + tBName + "', '" + _countPage + "', '" + tBPublishing_house + "', '" + _tBYear_publishing + "')";
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            command.Parameters.AddWithValue("@Name", tBName);
                            command.Parameters.AddWithValue("@Author", tBAuthor);
                            command.Parameters.AddWithValue("@CountPage", _countPage);
                            command.Parameters.AddWithValue("@Publishing_house", tBPublishing_house);
                            command.Parameters.AddWithValue("@Year_publishing", _tBYear_publishing);
                            command.ExecuteNonQuery();

                            //DataRow carRow = BookTable.NewRow();
                            //carRow["id"] = j;
                            //carRow["Author"] = tBAuthor;
                            //carRow["Name"] = tBName;
                            //carRow["CountPage"] = _countPage;
                            //carRow["Publishing_house"] = tBPublishing_house;
                            //carRow["Year_publishing"] = _tBYear_publishing;
                            //BookTable.Rows.Add(carRow);
                        }

                    }
                    if (connection != null)
                        connection.Close();
                    StartBookTable();
                    ErrorText = "Запись(и) добавленна(ы)!";
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
            BookTableDustVisibility = false;
            UserTableVisibility = true;
            BookTableVisibility = false;
            GridAddBook = false;
            GridAddUser = false;
        }

        private void BookDepositoryCommandExecute(object obj)
        {
            BookTableDustVisibility = false;
            UserTableVisibility = false;
            GridAddBook = false;
            BookTableVisibility = true;
            GridAddUser = false;
        }

        private void BookDepositoryDistCommandExecute(object obj)
        {
            BookTableDustVisibility = true;
            UserTableVisibility = false;
            GridAddBook = false;
            BookTableVisibility = false;
            GridAddUser = false;
        }

        private void OrderBookCommandExecute(object obj)
        {
            BookTableDustVisibility = false;
            UserTableVisibility = false;
            BookTableVisibility = false;
            GridAddBook = true;
            GridAddUser = false;
        }

        private void OrderUserCommandExecute(object obj)
        {
            UserTableVisibility = false;
            BookTableVisibility = false;
            GridAddBook = false;
            GridAddUser = true;
        }

        //private void IssueOfABookCommandExecute(object obj)
        //{
        //    //IssuingBooks.Add();
        //}

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
                //EnableButtonExportCSV = false;
                //Task.Run(() =>
                //{
                //string sql = "SELECT * FROM BOOKTABLE";
                //string sql = "(SELECT b.*, (SUBSTRING(u.name,1,1)+'.'+SUBSTRING(u.Patronymic,1,1)+'. '+u.surname) as FIO FROM BOOKTABLE b, usertable u where b.Userid = u.id)";
                string sql = "(SELECT b.*, (SUBSTRING(u.name,1,1)+'.'+SUBSTRING(u.Patronymic,1,1)+'. '+u.surname) as FIO FROM BOOKTABLE b, usertable u where b.Userid = u.id) union all (SELECT b.*, '' as FIO FROM BOOKTABLE b where b.Userid is null)";
                BookTable = new DataTable();

                    SqlCommand command = new SqlCommand(sql, connection);
                    adapter = new SqlDataAdapter(command);

                    connection.Open();
                    adapter.Fill(BookTable);

                //sql = "SELECT DISTINCT Author, name, Publishing_house, Year_publishing, CountPage FROM BOOKTABLE";
                sql = "SELECT Author, name, Publishing_house, Year_publishing, CountPage, COUNT(*) as count FROM BOOKTABLE bt GROUP BY Author, name, Publishing_house, Year_publishing, CountPage";
                BookTableDits = new DataTable();

                command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                //connection.Open();
                adapter.Fill(BookTableDits);


                //DataView view = new DataView(BookTable);

                ////BookTableDits = BookTable.AsEnumerable().Distinct().CopyToDataTable<DataRow>();
                //BookTableDits = BookTable.DefaultView.ToTable(true, "Author", "name", "Publishing_house", "Year_publishing", "CountPage");
                //BookTableDits = BookTable;
                //BookTableDits = view.ToTable(true, "Author", "name", "Publishing_house", "Year_publishing", "CountPage");
                //OnPropertyChanged(nameof(BookTable));
                //OnPropertyChanged(nameof(BookTableDits));



                //});
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка! \n\n" + exp, "Ошибка!");
                return false;
            }
            finally
            {
                //EnableButtonExportCSV = true;
                if (connection != null)
                    connection.Close();
                
            }
            return true;
            //try
            //{
            //    BookTable = new ObservableCollection<BookTableModel>();
            //    BookTable.CollectionChanged += ContentCollectionChanged;
            //    int i = 1;
            //    int j = i;

            //    //new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
            //    BookTable.Add(new BookTableModel() { Id = i, Author = "Анджей Сапковский", CountPage = 2800, Name = "Ведьмак", Publishing_house = "АТС", Year_publishing = 2020, DateOfIssue = new DateTime(2021, 12, 1, 11, 11, 11), DateOfDelivery = new DateTime(2022, 3, 1, 11, 11, 11) });
            //    BookTable.Add(new BookTableModel() { Id = i, Author = "Анджей Сапковский", CountPage = 2800, Name = "Ведьмак", Publishing_house = "АТС", Year_publishing = 2020, DateOfIssue = new DateTime(2021, 11, 14, 11, 11, 11), DateOfDelivery = new DateTime(2022, 2, 14, 11, 11, 11) });
            //    for (; i < j+14; i++)
            //    {
            //        BookTable.Add(new BookTableModel() { Id = i, Author = "Анджей Сапковский", CountPage = 2800, Name = "Ведьмак", Publishing_house = "АТС", Year_publishing = 2020});
            //    }
            //    j = i;
            //    for (; i < j + 30; i++)
            //    {
            //        BookTable.Add(new BookTableModel() { Id = i, Author = "Анджей Сапковский", CountPage = 2800, Name = "Ведьмак", Publishing_house = "АТС", Year_publishing = 2020});
            //    }
            //    j = i;
            //    BookTable.Add(new BookTableModel() { Id = i, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 1", Publishing_house = "Речь", Year_publishing = 2017, DateOfIssue = new DateTime(2021, 11, 14, 11, 11, 11), DateOfDelivery = new DateTime(2022, 2, 14, 11, 11, 11) });
            //    BookTable.Add(new BookTableModel() { Id = i, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 1", Publishing_house = "Речь", Year_publishing = 2017, DateOfIssue = new DateTime(2021, 11, 14, 11, 11, 11), DateOfDelivery = new DateTime(2022, 2, 14, 11, 11, 11) });
            //    BookTable.Add(new BookTableModel() { Id = i, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 1", Publishing_house = "Речь", Year_publishing = 2017, DateOfIssue = new DateTime(2021, 9, 15, 11, 11, 11), DateOfDelivery = new DateTime(2021, 12, 15, 11, 11, 11) });
            //    BookTable.Add(new BookTableModel() { Id = i, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 1", Publishing_house = "Речь", Year_publishing = 2017, DateOfIssue = new DateTime(2021, 9, 28, 11, 11, 11), DateOfDelivery = new DateTime(2021, 12, 28, 11, 11, 11) });
            //    for (; i < j + 24; i++)
            //    {
            //        BookTable.Add(new BookTableModel() { Id = i, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 1", Publishing_house = "Речь", Year_publishing = 2017});
            //    }
            //    j = i;
            //    for (; i < j + 20; i++)
            //    {
            //        BookTable.Add(new BookTableModel() { Id = i, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 2", Publishing_house = "Речь", Year_publishing = 2017});
            //    }
            //    j = i;
            //    for (; i < j + 20; i++)
            //    {
            //        BookTable.Add(new BookTableModel() { Id = i, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 3", Publishing_house = "Речь", Year_publishing = 2017});
            //    }
            //    j = i;
            //    for (; i < j + 20; i++)
            //    {
            //        BookTable.Add(new BookTableModel() { Id = i, Author = "Лев Толстой", CountPage = 368, Name = "Война и мир, том 4", Publishing_house = "Речь", Year_publishing = 2017});
            //    }

            //    //BookTable.Add(new BookTableModel() { Id = 2, Author = "Рэй Брэдбери", CountPage = 320, Name = "Вино из одуванчиков", Publishing_house = "Эксмо-Пресс", Year_publishing = 2021, CountBook = 21 });
            //    //BookTable.Add(new BookTableModel() { Id = 3, Author = "Данте Алигьери", CountPage = 352, Name = "Божественная комедия", Publishing_house = "Речь", Year_publishing = 2018, CountBook = 15 });
            //    //BookTable.Add(new BookTableModel() { Id = 4, Author = "Джек Лондон", CountPage = 256, Name = "Алая чума", Publishing_house = "АТС", Year_publishing = 2016, CountBook = 27 });
            //    //BookTable.Add(new BookTableModel() { Id = 5, Author = "Джек Лондон", CountPage = 2800, Name = "Мартин Иден", Publishing_house = "Издательский дом Мещерякова", Year_publishing = 2018, CountBook = 41 });
            //    //BookTable.Add(new BookTableModel() { Id = 6, Author = "Джеффри Николас", CountPage = 352, Name = "Дюна", Publishing_house = "АТС", Year_publishing = 2021, CountBook = 4 });
            //    //BookTable.Add(new BookTableModel() { Id = 7, Author = "Эрик Берн", CountPage = 256, Name = "Игры, в которые играют люди", Publishing_house = "Бомбора", Year_publishing = 2017, CountBook = 13 });
            //    //BookTable.Add(new BookTableModel() { Id = 8, Author = "Антуан Сент-Экзюпери", CountPage = 160, Name = "Маленький принц", Publishing_house = "Эксмо", Year_publishing = 2011, CountBook = 24 });
            //    return true;
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.Message);
            //    return false;
            //}
        }

        private bool StartUserTable()
        {
            //try
            //{
            //    UserTable = new ObservableCollection<UserTableModel>();


            //    //UserTable.Add(new UserTableModel() { Id = 1, Name = "Василий", Surname = "Пупкин", Patronymic = "Валерьевич", Adress = "Г.Санкт-Петербург ул. Мира д.6 кв.23", Phone = "89535338532" });
            //    //UserTable.Add(new UserTableModel() { Id = 2, Name = "Сергей", Surname = "Инанопуло", Patronymic = "Сергеевич", Adress = "Г.Санкт-Петербург ул. Советская д.26 кв.213", Phone = "89535368332" });
            //    //UserTable.Add(new UserTableModel() { Id = 3, Name = "Мурат", Surname = "Акрапетян", Patronymic = "Абдулович", Adress = "Г.Самара ул. Советская д.16 кв.123", Phone = "89742588532" });
            //    //UserTable.Add(new UserTableModel() { Id = 4, Name = "Мария", Surname = "Смоленко", Patronymic = "Васильевна", Adress = "Г.Судак ул. Строителей д.12 кв.57", Phone = "89536538431" });
            //    return true;
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.Message);
            //    return false;
            //}

            try
            {
                string sql = "SELECT * FROM UserTable";
                UserTable = new DataTable();

                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(UserTable);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка! \n\n" + exp, "Ошибка!");
                return false;
            }
            finally
            {
                //EnableButtonExportCSV = true;
                if (connection != null)
                    connection.Close();
                
            }
            return true;

        }
    }
}

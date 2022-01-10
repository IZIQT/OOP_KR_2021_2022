using OOP_KR_2021_2022.Common.MVVM;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace OOP_KR_2021_2022.Model
{
    class FileOperations : ViewModelBase
    {
        private int _booktableMaxId;
        public FileOperations(int BooktableMaxId)
        {
            _booktableMaxId = BooktableMaxId;
        }

        public ObservableCollection<BookTableModel> LoadingBookFromFile(string filePath)
        {
            ObservableCollection<BookTableModel> currentCollection = new ObservableCollection<BookTableModel>();
            using (StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    currentCollection.Add(FileProcessing(line));
                }
            }
            return currentCollection;
        }

        public BookTableModel FileProcessing(string _text)
        {
            //Author = Сунь - цзы,CountPage = 192,Name = Искусствовойны,Publishing_house = АТС,Year_publishing = 2012,CountBook = 20;
            string[] temp = _text.Split(';');
            int temp1, temp2, temp3;
            int.TryParse(temp[1], out temp1);
            int.TryParse(temp[4], out temp2);
            //int.TryParse(temp[5], out temp3);
            BookTableModel currentItem = new BookTableModel()
            {
                Id = _booktableMaxId+1,
                Author = temp[0],
                CountPage = temp1,
                Name = temp[2],
                Publishing_house = temp[3],
                Year_publishing = temp2,
                //CountBook = temp3
            };
            _booktableMaxId++;
            return currentItem;
        }
    }
}

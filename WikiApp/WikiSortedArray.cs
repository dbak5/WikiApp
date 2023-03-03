using System;
using System.IO;
using System.Text;

namespace WikiApp
{
    internal class WikiSortedArray
    {
        #region Variables
        private const int Row = 12;
        private const int Col = 4;
        // 9.1 Create a global 2D string array, use static variables for the dimensions (row = 4, column = 12),
        public string[,] Array = new string[Row, Col];
        public bool Empty { get; private set; }
        #endregion

        public void SaveFile(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Append))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {

                    for (var i = 0; i < Row; i++)
                    {
                        for (var j = 0; j < Col; j++)
                        {
                            writer.Write(Array[i, j]);
                        }
                    }
                }
            }
        }

        // CHECK THIS NEEDS TO BE UPDATED TO LOAD BINARY FILE
        public void LoadData(string fileName)
        {
            //try
            //{
            //    using (var stream = File.Open(fileName, FileMode.Create))
            //    {
            //        using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
            //        {
            //            for (var k = 0; k < Row; k++)
            //            {
            //                for (var j = 0; j < Col; j++)
            //                {
            //                    Array[k, j] = reader.ReadString();
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            var fileText = File.ReadAllLines(fileName);
            var i = 0;

            foreach (var line in fileText)
            {
                var parts = line.Split('|');
                for (var x = 0; x < parts.Length; x++)
                {
                    Array[i, x] = parts[x];

                }
                i++;
            }

            //for (var i = 0; i < Row; i++)
            //{
            //    for (var j = 0; j < Col; j++)
            //    {
            //        Array[i, j] = reader.ReadString();

            //    }
            //}

            Empty = false;
        }

        // CHECK HAVEN'T STARTED
        public void AddItem()
        {
            // BINARY FILE WRITER - WRITE BINARY FILE 
            // MUST HAVE ALL TEXTBOXES FILLED TO ADD
            //Pointer TO SEE IF ARRAY IS FULL
            // FOCUS BACK TO THE SEARCH TEXT BOX
            SortArray();
        }
        
        #region WORKING
        // 9.7 Write the code for a Binary Search for the Name in the 2D array and display the information in the other textboxes when found, add suitable feedback if the search in not successful and clear the search textbox (do not use any built-in array methods)
        // -1 = no data
        // -2 = search item not found 
        // any other number = index number of search item
        public int BinarySearch(string searchTextBoxItem)
        {
            var searchResult = -1;
            var min = 0;
            var max = Row-1;

            while (min <= max)
            {
                var mid = ((min + max) / 2);
                var searchArrayItem = Array[mid, 0];

                if (searchArrayItem == null) continue;
                searchResult = -2;
                if (string.Compare(searchTextBoxItem.ToUpper(), searchArrayItem.ToUpper(), StringComparison.Ordinal) == 0)
                {
                    searchResult = mid;
                    break;
                }
                if (string.Compare(searchTextBoxItem.ToUpper(), searchArrayItem.ToUpper(), StringComparison.Ordinal) < 0)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return searchResult;
        }

        // 9.6 Write the code for a Bubble Sort method to sort the 2D array by Name ascending, ensure you use a separate swap method that passes the array element to be swapped (do not use any built-in array methods)
        private void BubbleSort(int index)
        {
            for (var z = 0; z < Col; z++)
            {
                var temp = Array[index, z];
                Array[index, z] = Array[index + 1, z];
                Array[index + 1, z] = temp;
            }
        }

        public void SortArray()
        {
            for (var x = 0; x < Row; x++)
            {
                for (var i = 0; i < Row - 1; i++)
                {
                    if (string.Compare(Array[i, 0], Array[i + 1, 0], StringComparison.OrdinalIgnoreCase ) > 0)
                    {
                        BubbleSort(i);
                    }
                }
            }
        }

        public void DeleteItem(int index)
        {
            for (var i = 0; i < Col; i++)
            {
                Array[index, i] = "";
            }
        }

        public void EditItem(int row, int col, string changedText)
        {
            Array[row, col] = changedText;
        }

        public void ClearArray()
        {

            for (var i = 0; i < Row; i++)
            {
                for (var j = 0; j < Col; j++)
                {
                    Array[i, j] = null;
                }
            }
            Empty = true;
        }
        #endregion
    } //class
} //namespace

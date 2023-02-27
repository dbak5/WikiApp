using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WikiApp
{
    internal class WikiSortedArray
    {
        #region Variables
        private const int Row = 12;
        private const int Col = 4;
        // 9.1 Create a global 2D string array, use static variables for the dimensions (row = 4, column = 12),
        public string[,] Array = new string[Row, Col];
        #endregion

        // CHECK THIS NEEDS TO BE UPDATED TO LOAD BINARY FILE
        public void LoadData(string fileName)
        {
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
        }

        // CHECK HAVENT STARTED
        public void AddItem()
        {
            //add
            SortArray();
        }

        // CHECK WHY NOT EDITING CORRECTLY (ON CHANGE KEYPRESS)
        public void EditItem(int row, int col, string changedText)
        {
            Array[row, col] = changedText;
        }


        #region WORKING
        // 9.7 Write the code for a Binary Search for the Name in the 2D array and display the information in the other textboxes when found, add suitable feedback if the search in not successful and clear the search textbox (do not use any built-in array methods)
        // -1 = no data
        // 0 = search item not found 
        // any other number = index number of search item
        public int BinarySearch(string searchItem)
        {
            var searchResult = -1;
            var min = 0;
            var max = Row - 1;

            while (min <= max)
            {
                var mid = ((min + max) / 2);
                var search = Array[mid, 0];

                if (search != null)
                {
                    searchResult = 0;
                    if (searchItem.CompareTo(search) == 0)
                    {
                        searchResult = mid;
                        break;
                    }
                    if (searchItem.CompareTo(search) < 0)
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        min = mid + 1;
                    }
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
                    if (string.Compare(Array[i, 0], Array[i + 1, 0]) == 1)
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

        #endregion

        //private void ClearArray()
        //{
        //    UpdateStatusStrip("Data cleared");
        //    ListViewDataStructure.Items.Clear();
        //    Array.Clear(_wikiArray.Array, 0, _wikiArray.Array.GetLength(0) * _wikiArray.Array.GetLength(1));
        //}

    } //class
} //namespace

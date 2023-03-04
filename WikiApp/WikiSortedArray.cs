using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace WikiApp
{
    // Class for the wiki array. All methods and variables for the ARRAY kept here.
    internal class WikiSortedArray
    {
        #region Variables
        // 9.1 Create a global 2D string array
        public string[,] Array = new string[Row, Col];

        // 9.1 Static variables for the dimensions (row = 12, column = 4)
        public const int Row = 12;
        public const int Col = 4;

        // "Empty" denotes whether array contains no values. Can be set privately, but can be accessed publicly.
        public bool Empty { get; private set; }

        #endregion

        /// <summary>
        /// 9.7 Write the code for a Binary Search for the Name in the 2D array and display the information in the other textboxes when found, add suitable feedback if the search in not successful and clear the search textbox (do not use any built-in array methods)
        /// </summary>
        /// <param name="searchTextBoxItem"></param>
        /// <returns> -1 = search item not found, other INT = index number of search item</returns>
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

        /// <summary>
        /// Takes values from the array and saves to a binary file
        /// </summary>
        /// <param name="fileName"></param>
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

        /// <summary>
        /// Reads a binary file and adds them to the wiki array
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadData(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open))
            {
                using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                {
                    for (var k = 0; k < Row; k++)
                    {
                        Array[k, 0] = reader.ReadString();
                        Array[k, 1] = reader.ReadString();
                        Array[k, 2] = reader.ReadString();
                        Array[k, 3] = reader.ReadString();
                    }
                }
            }
            // CHECK OLD CODE FOR READING TXT FILE - KEEP UNTIL FINISHED
            //var fileText = File.ReadAllLines(fileName);
            //var i = 0;

            //foreach (var line in fileText)
            //{
            //    var parts = line.Split('|');
            //    for (var x = 0; x < parts.Length; x++)
            //    {
            //        Array[i, x] = parts[x];

            //    }
            //    i++;
            //}
            Empty = false;
        }

        /// <summary>
        /// Method to sort array using the bubble sort, comparing ordinals
        /// </summary>
        public void SortArray()
        {
            for (var x = 0; x < Row; x++)
            {
                for (var i = 0; i < Row - 1; i++)
                {
                    if (string.Compare(Array[i, 0], Array[i + 1, 0], StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        BubbleSort(i);
                    }
                }
            }
        }

        /// <summary>
        /// Method to "delete" item from array (replaces a value with empty string "")
        /// </summary>
        /// <param name="index"></param>
        public void DeleteItem(int index)
        {
            for (var i = 0; i < Col; i++)
            {
                Array[index, i] = "";
            }
        }

        /// <summary>
        /// Edits an item from the array (replaces an existing value with a new value)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="changedText"></param>
        public void EditItem(int row, int col, string changedText)
        {
            Array[row, col] = changedText;
        }

        /// <summary>
        /// Clears the array after the user is done
        /// </summary>
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

        /// <summary>
        /// 9.6 Write the code for a Bubble Sort method to sort the 2D array by Name ascending, ensure you use a separate swap method that passes the array element to be swapped (do not use any built-in array methods)
        /// </summary>
        /// <param name="index"></param>
        private void BubbleSort(int index)
        {
            for (var z = 0; z < Col; z++)
            {
                string temp = Array[index, z];
                Array[index, z] = Array[index + 1, z];
                Array[index + 1, z] = temp;
            }
        }

    } //class
} //namespace

using System;

namespace WikiApp
{
    internal class WikiSortedArray
    {
        private const int Row = 12;
        private const int Col = 4;
        // 9.1 Create a global 2D string array, use static variables for the dimensions (row = 4, column = 12),
        public string[,] Array = new string[Row, Col];
        
        // CHECK THIS NEEDS TO BE UPDATED TO LOAD BINARY FILE
        public void LoadData()
        {
            var random = new Random();
            for (var x = 0; x < Row; x++)
            {
                for (var y = 0; y < Col; y++)
                {
                    Array[x, y] = random.Next(10, 99).ToString();
                }
            }
            SortArray();
        }

        public void AddItem()
        {
            //add
            SortArray();
        }

        public void EditItem(int index1, int index2, string newText)
        {
            Array[index1, index2] = newText;
            SortArray();
        }

        public void DeleteItem(int index)
        {
            for (var i = 0; i < Col; i++)
            {
                Array[index, i] = "~";
            }
            SortArray();
        }

        public void UpdateArray(int row, int col, string changedText)
        {
            EditItem(row, col, changedText);
        }

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

        private void SortArray()
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

    } //class

} //namespace

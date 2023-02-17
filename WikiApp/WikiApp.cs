﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// Author: DaHye Baker
// Student ID: 30063368
// Organisation: South Metropolitan TAFE
// Description: Wiki Application on Data Structures
// A program that presents information and definition on data structures

namespace WikiApp
{
    public partial class WikiApp : Form
    {
        public WikiApp()
        {
            InitializeComponent();
        }

        #region Variables
        // 9.1 Create a global 2D string array, use static variables for the dimensions (row = 4, column = 12),
        private const int Row = 12;
        private const int Col = 4;
        string[,] WikiArray = new string[Row, Col];
        bool sorted = false;
        bool filled = false;

        #endregion

        #region Events & Buttons
        // 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D array
        private void ButtonAdd_MouseClick(object sender, MouseEventArgs e)
        {
            // ADD CODE
        }

        // 9.3 Create and EDIT button that will allow the user to modify any information from the 4 text boxes into the 2D array
        private void ButtonEdit_MouseClick(object sender, MouseEventArgs e)
        {
            // ADD CODE
        }

        // 9.4 Create a DELETE button that removes all the information from a single entry of the array; the user must be prompted before the final deletion occurs
        private void ButtonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            // ADD CODE
        }

        // 9.5 Create a CLEAR method to clear the four text boxes so a new definition can be added
        private void ButtonClear_MouseClick(object sender, MouseEventArgs e)
        {
            // ADD CODE
        }

        // 9.10 Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat which is sorted by Name, ensure the user has the option to select an alternative file. Use a file stream and BinaryWriter to create the file
        private void ButtonSave_MouseClick(object sender, MouseEventArgs e)
        {
            // ADD CODE
        }

        // 9.11 Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array, ensure the user has the option to select an alternative file. Use a file stream and BinaryReader to complete this task
        private void ButtonLoad_MouseClick(object sender, MouseEventArgs e)
        {
            LoadData();
        }

        private void ButtonBinarySearch_MouseClick(object sender, MouseEventArgs e)
        {
            BinarySearch();
            // ADD CODE
        }
        
        private void ButtonSort_MouseClick(object sender, MouseEventArgs e)
        {
            SortTable();
        }
        #endregion

        #region Functions
        // 9.6 Write the code for a Bubble Sort method to sort the 2D array by Name ascending, ensure you use a separate swap method that passes the array element to be swapped (do not use any built-in array methods)
        /// <summary>
        /// Bubble sort function
        /// </summary>
        private void BubbleSort(int indx)
        {
            string temp;
            for (int z = 0; z < Col; z++)
            {
                temp = WikiArray[indx, z];
                WikiArray[indx, z] = WikiArray[indx + 1, z];
                WikiArray[indx + 1, z] = temp;
            }
        }

        /// <summary>
        /// Sort table
        /// </summary>
        private void SortTable()
        {
            for (int x = 0; x < Row; x++)
            {
                for (int i = 0; i < Row - 1; i++)
                {
                    if (string.Compare(WikiArray[i, 0], WikiArray[i + 1, 0]) == 1)
                    {
                        BubbleSort(i);
                    }
                }
            }
            DisplayData();
            sorted = true;
        }

        // 9.7 Write the code for a Binary Search for the Name in the 2D array and display the information in the other textboxes when found, add suitable feedback if the search in not successful and clear the search textbox (do not use any built-in array methods)
        /// <summary>
        /// Binary search function that would return a index
        /// </summary>
        /// <returns></returns>
        private int BinarySearch(int searchValue)
        {
     
            int lastIndex = Row - 1;
            int firstIndex = 0;
            int searchIndex;

            while (firstIndex <= lastIndex)
            {
                searchIndex = (firstIndex + lastIndex) / 2;

                // if searched value equals to the search index, then its a matched and its index will return
                if (WikiArray[searchIndex, 0] == searchValue.ToString())
                {
                    return searchIndex;
                }
                // if the searched value bigger than then current search index, then it will continue its search on the right hand of the array 
                else if (WikiArray[searchIndex, 0] < searchValue.ToInt())
                {
                    firstIndex = searchIndex + 1;
                }
                // if the searched value is smaller than the current search index, then it will continue its search on the left hand of the array
                else
                {
                    lastIndex = searchIndex - 1;
                }

            }
            return -1;

        }

        // 9.8 Create a display method that will show the following information in a ListView: Name and Category
        /// <summary>
        /// Display function
        /// </summary>
        private void DisplayData()
        {
            ListViewDataStructure.Items.Clear();
            for (int x = 0; x < Row; x++)
            {
                ListViewItem item = new ListViewItem(WikiArray[x, 0]);
                item.SubItems.Add(WikiArray[x, 1]);
                item.SubItems.Add(WikiArray[x, 2]);
                item.SubItems.Add(WikiArray[x, 3]);
                // item.SubItems.Add(WikiArray[x, 4]);
                ListViewDataStructure.Items.Add(item);
            }
        }

        // 9.9 Create a method so the user can select a definition (Name) from the ListView and all the information is displayed in the appropriate Textboxes
        /// <summary>
        /// Select function
        /// </summary>
        private void SelectItem(int index)
        {
            //ListViewDataStructure.SelectedItems();
                //(index, true);
            TextboxSearch.Clear();
            TextboxSearch.Text = ListViewDataStructure.SelectedItems.ToString();
        }

        /// <summary>
        /// Update list box function
        /// </summary>
        private void LoadData()
        {
            Random random = new Random();
            for (int x = 0; x < Row; x++)
            {
                for (int y = 0; y < Col; y++)
                {
                    WikiArray[x, y] = random.Next(10, 99).ToString();
                }
            }
            DisplayData();
        }

        /// <summary>
        /// Save file function
        /// </summary>
        /// 
        private void SaveFile()
        {
            // ADD CODE
        }

        /// <summary>
        /// Clear method
        /// </summary>
        private void ClearData()
        {
            // ADD CODE
        }

        /// <summary>
        /// Update status strip
        /// </summary>
        private void UpdateStatusStrip(string message, string status, MessageBoxIcon icon)
        {
            MessageBox.Show(message, status, MessageBoxButtons.OK, icon);
            StatusLabel.Text = message;
            TextboxSearch.Focus();
        }

        private void UpdateProgressBar(int value)
        {
            StatusProgressBar.Value = value;
        }

        private bool DeleteConfirmationMessage(object selectedItem)
        {
            var message = $"Are you sure you want to delete {selectedItem}?";
            var caption = $"Delete {selectedItem}?";
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    == DialogResult.Yes;
        }

        #endregion
    }
}
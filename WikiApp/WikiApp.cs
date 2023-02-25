﻿using System;
using System.Security.Cryptography;
using System.Windows.Forms;

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
        private string[,] _wikiArray = new string[Row, Col];

        private int _selectedIndex = -1;
        private bool _sorted = false;
        //bool filled = false;
        private bool _found = false;
        private bool _dataLoaded = false;

        #endregion

        #region Events & Buttons

        // 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D array
        private void ButtonAdd_MouseClick(object sender, MouseEventArgs e)
        {
            CheckTextBox();
            CheckArrayData(AddItem, "No data");
        }

        // 9.3 Create and EDIT button that will allow the user to modify any information from the 4 text boxes into the 2D array
        private void ButtonEdit_MouseClick(object sender, MouseEventArgs e)
        {
            CheckTextBox();
            CheckArrayData(EditItem, "No data to edit");
        }

        // 9.4 Create a DELETE button that removes all the information from a single entry of the array; the user must be prompted before the final deletion occurs
        private void ButtonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            CheckArrayData(DeleteItem, "No data to delete");
        }

        // 9.5 Create a CLEAR method to clear the four text boxes so a new definition can be added
        private void ButtonClear_MouseClick(object sender, MouseEventArgs e)
        {
            CheckArrayData(ClearData, "No data to clear");
        }

        // 9.10 Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat which is _sorted by Name, ensure the user has the option to select an alternative file. Use a file stream and BinaryWriter to create the file
        private void ButtonSave_MouseClick(object sender, MouseEventArgs e)
        {
            CheckArrayData(SaveFile, "No data to save");
        }

        // 9.11 Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array, ensure the user has the option to select an alternative file. Use a file stream and BinaryReader to complete this task
        // CHECK NEED TO LOAD BINARY FILE USING BINARY READER
        private void ButtonLoad_MouseClick(object sender, MouseEventArgs e)
        {
            LoadData();
            //CheckArrayData(LoadData, "Data loaded");
        }

        private void ButtonBinarySearch_MouseClick(object sender, MouseEventArgs e)
        {
            CheckTextBox();

            if (!_sorted)
            {
                SortTable();
                BinarySearch();
            }
            else
            {
                BinarySearch();
            }
        }

        private void ButtonSort_MouseClick(object sender, MouseEventArgs e)
        {
            CheckArrayData(SortTable, "No data to sort");
        }

        private void ListViewDataStructure_MouseClick(object sender, System.EventArgs e)
        {
            if (ListViewDataStructure.SelectedItems.Count > 0)
            {
                _selectedIndex = ListViewDataStructure.SelectedIndices[0];
                SelectItem(_selectedIndex);
            }
        }

        #endregion

        #region Functions
        // 9.6 Write the code for a Bubble Sort method to sort the 2D array by Name ascending, ensure you use a separate swap method that passes the array element to be swapped (do not use any built-in array methods)
        /// <summary>
        /// Bubble sort function
        /// </summary>
        private void BubbleSort(int index)
        {
            for (var z = 0; z < Col; z++)
            {
                var temp = _wikiArray[index, z];
                _wikiArray[index, z] = _wikiArray[index + 1, z];
                _wikiArray[index + 1, z] = temp;
            }
        }

        /// <summary>
        /// Sort table
        /// </summary>
        private void SortTable()
        {
            for (var x = 0; x < Row; x++)
            {
                for (var i = 0; i < Row - 1; i++)
                {
                    if (string.Compare(_wikiArray[i, 0], _wikiArray[i + 1, 0]) == 1)
                    {
                        BubbleSort(i);
                    }
                }
            }
            DisplayData();
            _sorted = true;
        }

        // 9.7 Write the code for a Binary Search for the Name in the 2D array and display the information in the other textboxes when found, add suitable feedback if the search in not successful and clear the search textbox (do not use any built-in array methods)
        /// <summary>
        /// Binary search function
        /// </summary>
        /// <returns> Returns -1 if the array contains null values, returns 0 if if the item cannot be found in the array </returns>
        private int BinarySearch()
        {

            var returnValue = -1;
            var searchItem = TextBoxSearch.Text;
            //_selectedIndex = -1;

            if (!string.IsNullOrEmpty(searchItem))
            {
                var min = 0;
                var max = Row - 1; // max is one less than size

                while (min <= max)
                {

                    var mid = ((min + max) / 2); // uses integer division
                    var search = _wikiArray[mid, 0];

                    if (search != null)
                    {

                        if (searchItem.CompareTo(search) == 0)
                        {
                            _found = true;
                            //_selectedIndex = mid;
                            _dataLoaded = true;
                            UpdateStatusStrip("Item found");
                            SelectItem(mid);
                            FocusTextBox();
                            break;
                        }
                        else if (searchItem.CompareTo(search) < 0)
                        {
                            max = mid - 1;
                        }
                        else
                        {
                            min = mid + 1;
                        }
                    }
                }

                if (!_found)
                {
                    UpdateStatusStrip("Item not found");

                }
            }

            return returnValue;

        }

        // 9.8 Create a display method that will show the following information in a ListView: Name and Category
        /// <summary>
        /// Display function
        /// </summary>
        private void DisplayData()
        {
            ListViewDataStructure.Items.Clear();
            for (var x = 0; x < Row; x++)
            {
                var item = new ListViewItem(_wikiArray[x, 0]);
                item.SubItems.Add(_wikiArray[x, 1]);
                item.SubItems.Add(_wikiArray[x, 2]);
                item.SubItems.Add(_wikiArray[x, 3]);
                // item.SubItems.Add(_wikiArray[x, 4]);
                ListViewDataStructure.Items.Add(item);
            }
        }

        // 9.9 Create a method so the user can select a definition (Name) from the ListView and all the information is displayed in the appropriate Textboxes
        /// <summary>
        /// Select function
        /// </summary>
        private void SelectItem(int index)
        {
            ListViewDataStructure.HideSelection = false;
            ListViewDataStructure.FullRowSelect = true;
            ListViewDataStructure.Items[index].Selected = true;
        }

        /// <summary>
        /// Update list box function
        /// </summary>
        private void LoadData()
        {
            // CHECK THIS NEEDS TO BE UPDATED TO LOAD BINARY FILE
            var random = new Random();
            for (var x = 0; x < Row; x++)
            {
                for (var y = 0; y < Col; y++)
                {
                    _wikiArray[x, y] = random.Next(10, 99).ToString();
                }
            }
            UpdateStatusStrip("Data successfully loaded");
            DisplayData();
            _dataLoaded = true;
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
            ListViewDataStructure.Items.Clear();
            Array.Clear(_wikiArray, 0, _wikiArray.GetLength(0) * _wikiArray.GetLength(1));
            UpdateStatusStrip("Data cleared");
        }

        /// <summary>
        /// Update status strip
        /// </summary>
        private void UpdateStatusStrip(string message)
        {
            StatusLabel.Text = message;
        }

        private void AddItem()
        {
            const string action = "add";
            const string actioned = "added";

            if (_selectedIndex == -1)
            {
                UpdateStatusStrip($"Nothing selected to {action}");
            }

            else
            {
                if (ConfirmationMessage(action))
                {
                    for (var i = 0; i < Col; i++)
                    {
                       // _wikiArray[index, i] = "~";
                        DisplayData();
                    }

                    UpdateStatusStrip($"Item {actioned}");
                    FocusTextBox();
                }
                else
                {
                    UpdateStatusStrip($"Item not {actioned}");
                }
            }
        }

        private void EditItem()
        {
            const string action = "edit";
            const string actioned = "edited";

            if (_selectedIndex == -1)
            {
                UpdateStatusStrip($"Nothing selected to {action}");
            }
            else
            {
                if (ConfirmationMessage(action))
                {
                    for (var i = 0; i < Col; i++)
                    {
                        //_wikiArray[index, i] = "~";
                        DisplayData();
                    }

                    UpdateStatusStrip($"Item {actioned}");
                    FocusTextBox();
                }
                else
                {
                    UpdateStatusStrip($"Item not {actioned}");
                }
            }
        }

        private void DeleteItem()
        {
            const string action = "delete";
            const string actioned = "deleted";

            if (_selectedIndex == -1)
            {
                UpdateStatusStrip("Nothing selected to delete");
  
            }
            else
            {
                if (ConfirmationMessage(action))
                {
                    var index = _selectedIndex;
                    for (var i = 0; i < Col; i++)
                    {
                        _wikiArray[index, i] = "~";
                        DisplayData();
                    }

                    UpdateStatusStrip($"Item {actioned}");
                    FocusTextBox();
                }
                else
                {
                    UpdateStatusStrip($"Item not {actioned}");
 
                }
            }
        }

        private static bool ConfirmationMessage(string action)
        {
            var message = $"Are you sure you want to {action} this item?";
            var caption = $"Please confirm {action}";
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    == DialogResult.Yes;
        }

        private void DisplayTextBox(string item)
        {
            TextBoxAdd.Text = item;
            TextBoxDelete.Text = item;
            TextBoxEdit.Text = item;
            TextBoxSearch.Text = item;
        }

        private void ClearTextBox()
        {
            TextBoxAdd.Clear();
            TextBoxDelete.Clear();
            TextBoxEdit.Clear();
            TextBoxSearch.Clear();
        }

        private void CheckArrayData(Action action, string message)
        {
            if (!_dataLoaded)
            {
                UpdateStatusStrip(message);
                ButtonAdd.Enabled = false;
                ButtonDelete.Enabled = false;
                ButtonSort.Enabled = false;
                ButtonSearch.Enabled = false;
                ButtonEdit.Enabled = false;
                ButtonClear.Enabled = false;
            }
            else
            {
                action();
                ButtonAdd.Enabled = true;
                ButtonDelete.Enabled = true;
                ButtonSort.Enabled = true;
                ButtonSearch.Enabled = true;
                ButtonEdit.Enabled = true;
                ButtonClear.Enabled = true;
            }
        }

        private void FocusTextBox()
        {
            TextBoxSearch.Focus();
        }

        //CHECK MIGHT BE ABLE TO PASS THE SPECIFIC TEXT BOX THROUGH
        private void CheckTextBox()
        {
            if (TextBoxSearch.Text == "")
            {
                UpdateStatusStrip("No text in search box");
            }
        }
        #endregion
    }
}
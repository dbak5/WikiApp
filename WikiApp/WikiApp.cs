using System;
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
using System.Reflection;
using ListView = System.Windows.Forms.ListView;

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
            ListViewDataStructure.SelectedIndexChanged += ListViewDataStructure_MouseClick;
            
        }

        #region Variables
        // 9.1 Create a global 2D string array, use static variables for the dimensions (row = 4, column = 12),
        private const int Row = 12;
        private const int Col = 4;
        string[,] WikiArray = new string[Row, Col];

        private int selectedIndex = -1;
        bool sorted = false;
        //bool filled = false;
        //bool found = false;

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
            CheckArrayData(EditItem, "No data");
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

        // 9.10 Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat which is sorted by Name, ensure the user has the option to select an alternative file. Use a file stream and BinaryWriter to create the file
        private void ButtonSave_MouseClick(object sender, MouseEventArgs e)
        {
            //CheckArrayData(EditItem, "No data to edit");
            // ADD CODE
        }

        // 9.11 Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array, ensure the user has the option to select an alternative file. Use a file stream and BinaryReader to complete this task
        // CHECK NEED TO LOAD BINARY FILE USING BINARY READER
        private void ButtonLoad_MouseClick(object sender, MouseEventArgs e)
        {
            LoadData();
            CheckArrayData(LoadData, "Data loaded");
        }

        private void ButtonBinarySearch_MouseClick(object sender, MouseEventArgs e)
        {
            CheckTextBox();

            if (int.TryParse(TextBoxSearch.Text, out var searchNumber))
            {
                var result = BinarySearch(searchNumber);
                if (result == -1)
                {
                    UpdateStatusStrip("No data to search");
                }
                else if (result == 0)
                {
                    UpdateStatusStrip("Item not found");
                    ClearTextBox();
                }
                else
                {
                    UpdateStatusStrip("Item found");
                    SelectItem(result);
                    DisplayTextBox(searchNumber.ToString());
                    ClearTextBox();
                }
            }
            FocusTextBox();
        }

        private void ButtonSort_MouseClick(object sender, MouseEventArgs e)
        {
            CheckArrayData(SortTable, "No data to sort");
            UpdateStatusStrip("Data sorted");
        }

        private void ListViewDataStructure_MouseClick(object sender, System.EventArgs e)
        {
            if (ListViewDataStructure.SelectedItems.Count > 0)
            {
                selectedIndex = ListViewDataStructure.SelectedIndices[0];
                SelectItem(selectedIndex);
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
                var temp = WikiArray[index, z];
                WikiArray[index, z] = WikiArray[index + 1, z];
                WikiArray[index + 1, z] = temp;
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
        /// Binary search function
        /// </summary>
        /// <returns> Returns -1 if the array contains null values, returns 0 if if the item cannot be found in the array </returns>
        private int BinarySearch(int searchValue)
        {
            var lastIndex = Row - 1;
            var firstIndex = 0;
            int searchIndex = selectedIndex;
            int returnValue = -1;

            while (firstIndex <= lastIndex)
            {
                searchIndex = (firstIndex + lastIndex) / 2;
                var search = WikiArray[searchIndex, 0];

                if (search != null)
                {
                    int.TryParse(search, out var arrayValue);
                    
                    returnValue = 0;

                    // if searched value equals to the search index, then its a matched and its index will return
                    if (arrayValue == searchValue)
                    {
                        return searchIndex;
                    }
                    // if the searched value bigger than then current search index, then it will continue its search on the right hand of the array 
                    else if (arrayValue < searchValue)
                    {
                        firstIndex = searchIndex + 1;
                    }
                    // if the searched value is smaller than the current search index, then it will continue its search on the left hand of the array
                    else
                    {
                        lastIndex = searchIndex - 1;
                    }
                }
                else
                {
                    lastIndex = searchIndex - 1;
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
                var item = new ListViewItem(WikiArray[x, 0]);
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
            ListViewDataStructure.Items.Clear();
            Array.Clear(WikiArray, 0, WikiArray.GetLength(0) * WikiArray.GetLength(1));
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
            var action = "add";
            var actioned = "added";

            if (selectedIndex == -1)
            {
                UpdateStatusStrip($"Nothing selected to {action}");
                return;
            }

            else
            {
                if (ConfirmationMessage(selectedIndex, action))
                {
                    int index = selectedIndex;
                    for (int i = 0; i < Col; i++)
                    {
                       // WikiArray[index, i] = "~";
                        DisplayData();
                    }

                    UpdateStatusStrip($"Item {actioned}");
                    FocusTextBox();
                }
                else
                {
                    UpdateStatusStrip($"Item not {actioned}");
                    return;
                }
            }
        }

        private void EditItem()
        {
            var action = "edit";
            var actioned = "edited";

            if (selectedIndex == -1)
            {
                UpdateStatusStrip($"Nothing selected to {action}");
                return;
            }
            else
            {
                if (ConfirmationMessage(selectedIndex, action))
                {
                    int index = selectedIndex;
                    for (int i = 0; i < Col; i++)
                    {
                        //WikiArray[index, i] = "~";
                        DisplayData();
                    }

                    UpdateStatusStrip($"Item {actioned}");
                    FocusTextBox();
                }
                else
                {
                    UpdateStatusStrip($"Item not {actioned}");
                    return;
                }
            }
        }

        private void DeleteItem()
        {
            var action = "delete";
            var actioned = "deleted";

            if (selectedIndex == -1)
            {
                UpdateStatusStrip("Nothing selected to delete");
                return;
            }
            else
            {
                if (ConfirmationMessage(selectedIndex, action))
                {
                    int index = selectedIndex;
                    for (int i = 0; i < Col; i++)
                    {
                        WikiArray[index, i] = "~";
                        DisplayData();
                    }

                    UpdateStatusStrip($"Item {actioned}");
                    FocusTextBox();
                }
                else
                {
                    UpdateStatusStrip($"Item not {actioned}");
                    return;
                }
            }
        }

        private bool ConfirmationMessage(object selectedItem, string action)
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
            var searchNumber = -1;
            var result = BinarySearch(searchNumber);
     
            if (result == -1)
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
                return;
            }
        }
        #endregion
    }
}
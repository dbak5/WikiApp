using System;
using System.IO;
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

        private WikiSortedArray _wikiArray;
        private int _selectedIndexRow = -1;

        #region Events
        //CHECK NEED FEEDBACK ON GREY OUT BUTTONS
        private void ButtonClearAll_MouseClick(object sender, MouseEventArgs e)
        {
            if (!GreyBoxArrayNull()) return;
            _wikiArray.ClearArray();
            DisplayListView();
            UpdateStatusStrip("Data cleared");
            GreyBoxArrayNull();
        }

        // 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D array
        private void ButtonAdd_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "add";
            const string actioned = "added";

            //if (!GreyBoxArrayNull()) return;
            //if (!CheckOutOfBound()) return;
            if (CheckArrayNull())
            {
                _wikiArray = new WikiSortedArray();
                TextBoxNam.Focus();
            }

            if (_wikiArray.Array[0, 0] == null)
            {
                if (!CheckIfTextBoxEmpty())
                   
                {
                    if (CheckIfExists())
                    {
                        UpdateItems(action, actioned);
                        TextBoxSearch.Focus();
                    }
                    else
                    {
                        UpdateStatusStrip($"Duplicate entry, cannot {action}");
                        TextBoxNam.Focus();
                    }
                }
                else
                {
                    UpdateStatusStrip("Please input data to add and ensure all fields are full");
                    TextBoxNam.Focus();
                }
            }
            else
            {
                UpdateStatusStrip($"Array is full, not {actioned}");
                ButtonAdd.Enabled = false;
                TextBoxSearch.Focus();
            }
        }

        // 9.3 Create and EDIT button that will allow the user to modify any information from the 4 text boxes into the 2D array
        private void ButtonEdit_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "edit";
            const string actioned = "edited";
            if (!GreyBoxArrayNull()) return;
            if (!CheckOutOfBound()) return;
            if (CheckIfSelected() && !CheckIfTextBoxEmpty())
            {
                if (CheckIfTextBoxChanged())
                {
                    if (CheckIfExists())
                    {
                        UpdateItems(action, actioned);
                        TextBoxSearch.Focus();
                    }
                    else
                    {
                        UpdateStatusStrip($"Duplicate entry, cannot {action}");
                        TextBoxNam.Focus();
                    }
                }
                else
                {
                    UpdateStatusStrip($"No changes made, item not {actioned}");
                    TextBoxNam.Focus();
                }
            }
            else
            {
                UpdateStatusStrip($"Nothing selected to {action}");
                TextBoxSearch.Focus();
            }
        }

        // 9.4 Create a DELETE button that removes all the information from a single entry of the array; the user must be prompted before the final deletion occurs
        private void ButtonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "delete";
            const string actioned = "deleted";

            //  UpdateStatusStrip("");
            if (!GreyBoxArrayNull()) return;
            if (!CheckOutOfBound()) return;
            if (CheckIfSelected() && !CheckIfTextBoxEmpty())
            {
                var selectedItem = _wikiArray.Array[_selectedIndexRow, 0];
                if (selectedItem != "")
                {
                    if (ConfirmationUserRequest(action))
                    {
                        _wikiArray.DeleteItem(_selectedIndexRow);
                        _wikiArray.BubbleSort();
                        DisplayListView();
                        ClearTextBoxes();
                        UpdateStatusStrip($"Item {actioned}");
                        ButtonAdd.Enabled = true;
                        TextBoxSearch.Focus();
                    }
                    else
                    {
                        UpdateStatusStrip($"Item not {actioned}");
                        TextBoxSearch.Focus();
                    }
                }
                else
                {
                    UpdateStatusStrip($"Nothing selected to {action}");
                    TextBoxSearch.Focus();
                }
            }
            else
            {
                UpdateStatusStrip($"Nothing selected to {action}");
                TextBoxSearch.Focus();
            }
        }

        // 9.10 Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat which is _sorted by Name, ensure the user has the option to select an alternative file. Use a file stream and BinaryWriter to create the file
        private void ButtonSave_MouseClick(object sender, MouseEventArgs e)
        {
            // CHECK IF WE SHOULD HAVE SOMETHING AUTOMATICALLY OR CHANGE IT
            string fileName = "definitions2.bin";

            const string filterLimits = "bin files (*.*)|*.bin|All files (*.*)|*.*";
            var saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = filterLimits,
                FilterIndex = 2,
                RestoreDirectory = true
            };
            var result = saveFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;

            // CHECK UNCOMMENT THESE WHEN WORKING
            //if (!GreyBoxArrayNull()) return;

            _wikiArray.SaveFile(fileName);
            _wikiArray.ClearArray();
            TextBoxSearch.Focus();
            DisplayListView();
            UpdateStatusStrip("File successfully saved");
        }

        // 9.11 Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array, ensure the user has the option to select an alternative file. Use a file stream and BinaryReader to complete this task
        private void ButtonLoad_MouseClick(object sender, MouseEventArgs e)
        {
            // CHECK UNCOMMENT BELOW ONCE EVERYTHING IS WORKING
            //const string filterLimits = "bin files (*.*)|*.bin|All files (*.*)|*.*";
            //    var openFileDialog1 = new OpenFileDialog
            //    {
            //        InitialDirectory = Directory.GetCurrentDirectory(),
            //        Filter = filterLimits,
            //        FilterIndex = 2,
            //        RestoreDirectory = true
            //    };
            //    var result = openFileDialog1.ShowDialog();
            //if (result.result != DialogResult.OK) return;

            // CHECK UNCOMMENT THESE WHEN WORKING
            //if (!GreyBoxArrayNull()) return;

            // CHECK REMOVE THIS AFTER EVERYTHING IS WORKING
            var fileName = "C:\\Users\\Bananus\\Downloads\\definitions.bin";
            if (CheckArrayNull())
            {
                _wikiArray = new WikiSortedArray();
                _wikiArray.LoadData(fileName);
                _wikiArray.BubbleSort();
                TextBoxSearch.Focus();
                DisplayListView();
                UpdateStatusStrip("Data successfully loaded");
                GreyBoxArrayNull();
            }
        }

        private void ButtonSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (!GreyBoxArrayNull()) return;

            // integer variable which is a row index number, or -1 if not found
            var searchResult = _wikiArray.BinarySearch(TextBoxSearch.Text);

            if (!string.IsNullOrEmpty(TextBoxSearch.Text))
            {
                    if (searchResult == -1)
                    {
                        UpdateStatusStrip("Item not found");
                        DeselectItem(_selectedIndexRow);
                        ClearTextBoxes();
                        TextBoxSearch.Focus();
                    return;
                    }
                    UpdateStatusStrip("Item found");
                    DeselectItem(_selectedIndexRow);
                    TextBoxSearch.Clear();
                    TextBoxNam.Focus();
                    SelectItem(searchResult);
            }
            else
            {
                UpdateStatusStrip("Please enter search");
                TextBoxSearch.Focus();
            }
        }

        private void ButtonClear_MouseClick(object sender, MouseEventArgs e)
        {
            ClearTextBoxes();
            TextBoxSearch.Clear();
            DeselectItem(_selectedIndexRow);
            TextBoxSearch.Focus();
        }

        private void ListViewSelect_MouseClick(object sender, EventArgs e)
        {

            if (!GreyBoxArrayNull()) return;
            if (ListViewDataStructure.SelectedItems.Count <= 0) return;
            _selectedIndexRow = ListViewDataStructure.SelectedIndices[0];
            SelectItem(_selectedIndexRow);
        }
        #endregion

        #region Methods
        // CHECK DOUBLE CLICK TEXTBOX TO CLEAR??
        /// <summary>
        /// 9.5 Create a CLEAR method to clear the four text boxes so a new definition can be added
        /// </summary>
        private void ClearTextBoxes()
        {
            if (CheckIfTextBoxEmpty())
            {
                ButtonClearTextBoxes.Enabled = false;
            }
            else
            {
                TextBoxNam.Clear();
                TextBoxDef.Clear();
                TextBoxStr.Clear();
                TextBoxCat.Clear();
                DeselectItem(_selectedIndexRow);
            }

          
        }

        /// <summary>
        /// 9.8 Create a display method that will show the following information in a ListView: Name and Category.
        /// </summary>
        private void DisplayListView()
        {
            ListViewDataStructure.Items.Clear();
            for (var x = 0; x < _wikiArray.Array.GetLength(0); x++)
            {
                var item = new ListViewItem(_wikiArray.Array[x, 0]);
                item.SubItems.Add(_wikiArray.Array[x, 1]);
                item.SubItems.Add(_wikiArray.Array[x, 2]);
                item.SubItems.Add(_wikiArray.Array[x, 3]);
                ListViewDataStructure.Items.Add(item);
                ListViewDataStructure.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                ListViewDataStructure.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        /// <summary>
        /// 9.9 Create a method so the user can select a definition (Name) from the ListView
        /// Uses an integer "index" to find value to select
        /// </summary>
        /// <param name="index"></param>
        private void SelectItem(int index)
        {
            ListViewDataStructure.HideSelection = false;
            ListViewDataStructure.FullRowSelect = true;
            ListViewDataStructure.Items[index].Selected = true;
            DisplayTextBoxes(index);
            ButtonEdit.Enabled = true;
            ButtonDelete.Enabled = true;
            ButtonClearTextBoxes.Enabled = true;
            TextBoxCat.Enabled = true;
            TextBoxNam.Enabled = true;
            TextBoxStr.Enabled = true;
            TextBoxDef.Enabled = true;
        }

        /// <summary>
        /// 9.9 All  information is displayed in the appropriate Textboxes
        /// </summary>
        /// <param name="index"></param>
        private void DisplayTextBoxes(int index)
        {
            TextBoxDef.Text = _wikiArray.Array[index, 3];
            TextBoxStr.Text = _wikiArray.Array[index, 2];
            TextBoxCat.Text = _wikiArray.Array[index, 1];
            TextBoxNam.Text = _wikiArray.Array[index, 0];
        }

        /// <summary>
        /// Method to deselect item if something else is searched for
        /// </summary>
        /// <param name="index"></param>
        private void DeselectItem(int index)
        {
            if (_selectedIndexRow == -1) return;
            ListViewDataStructure.HideSelection = false;
            ListViewDataStructure.FullRowSelect = false;
            ListViewDataStructure.Items[index].Selected = false;
            _selectedIndexRow = -1;
        }

        /// <summary>
        /// Update the status strip
        /// </summary>
        /// <param name="message"></param>
        private void UpdateStatusStrip(string message)
        {
            StatusLabel.Text = message;
        }

        /// <summary>
        /// Request confirmation from user for action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private static bool ConfirmationUserRequest(string action)
        {
            var message = $"Are you sure you want to {action} this item?";
            var caption = $"Please confirm {action}";
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                   == DialogResult.Yes;
        }

        /// <summary>
        /// Update items in the array for edit or add
        /// </summary>
        /// <param name="action"></param>
        /// <param name="actioned"></param>
        private void UpdateItems(string action, string actioned)
        {
            var newName = TextBoxNam.Text;
            var newCat = TextBoxCat.Text;
            var newStr = TextBoxStr.Text;
            var newDef = TextBoxDef.Text;
            if (ConfirmationUserRequest(action))
            {
                if (action == "add")
                {
                    _wikiArray.EditItem(0, 0, newName);
                    _wikiArray.EditItem(0, 1, newCat);
                    _wikiArray.EditItem(0, 2, newStr);
                    _wikiArray.EditItem(0, 3, newDef);
                   ClearTextBoxes();
                   TextBoxSearch.Enabled = true;
                   ButtonSearch.Enabled = true;
                }
                else
                {
                    _wikiArray.EditItem(_selectedIndexRow, 0, newName);
                    _wikiArray.EditItem(_selectedIndexRow, 1, newCat);
                    _wikiArray.EditItem(_selectedIndexRow, 2, newStr);
                    _wikiArray.EditItem(_selectedIndexRow, 3, newDef);
                    ClearTextBoxes();
                }
                _wikiArray.BubbleSort();
                DisplayListView();
                ListViewDataStructure.Enabled = true;
                UpdateStatusStrip($"Item {actioned}");
            }
            else
            {
                UpdateStatusStrip($"Item not {actioned}");
            }
        }

        #region Error trapping
        /// <summary>
        /// Check if the index is out of bounds of the array
        /// </summary>
        /// <returns></returns>
        private bool CheckOutOfBound()
        {
            if (_selectedIndexRow <= _wikiArray.Array.Length) return true;
            UpdateStatusStrip("outside");
            return false;
        }

        /// <summary>
        /// Check if the array is empty or null
        /// </summary>
        /// <returns></returns>
        private bool CheckArrayNull()
        {
            return _wikiArray == null || _wikiArray.Empty;
        }

        /// <summary>
        /// Check if the array contains values
        /// If no values in the array, return false and disable buttons
        /// If values in the array, return true and enable buttons
        /// </summary>
        /// <returns></returns>
        private bool GreyBoxArrayNull()
        {
            if (CheckArrayNull())
            {
                UpdateStatusStrip("No data in the array");
                ClearTextBoxes();
                TextBoxSearch.Clear();
                TextBoxSearch.Enabled = false;
                ButtonClearTextBoxes.Enabled = false;
                ButtonSearch.Enabled = false;
                ButtonEdit.Enabled = false;
                ButtonDelete.Enabled = false;
                ListViewDataStructure.Enabled = false;
                TextBoxNam.Focus();
                return false;
            }
       
            TextBoxSearch.Enabled = true;
            ListViewDataStructure.Enabled = true;
            ButtonSearch.Enabled = true;
            return true;
        }

        /// <summary>
        /// Check if something has been selected before carrying out an action.
        /// If something selected, return true, enable buttons
        /// If nothing selected, return false, disable buttons
        /// </summary>
        /// <returns></returns>
        private bool CheckIfSelected()
        {
            if (_selectedIndexRow != -1)
            {
                ButtonEdit.Enabled = true;
                ButtonDelete.Enabled = true;
                TextBoxCat.Enabled = true;
                TextBoxNam.Enabled = true;
                TextBoxStr.Enabled = true;
                TextBoxDef.Enabled = true;
                return true;
            }
            ButtonEdit.Enabled = false;
            ButtonDelete.Enabled = false;
            return false;
        }

        /// <summary>
        /// Check if an item already exists within the array
        /// If doesn't exist, returns -1
        /// </summary>
        /// <returns></returns>
        private bool CheckIfExists()
        {
            var searchResult = _wikiArray.BinarySearch(TextBoxNam.Text);
            return searchResult == -1;
        }
       
        /// <summary>
        /// Parameters for checking if textbox has changed by checking textboxes against wiki array
        /// </summary>
        /// <returns></returns>
        private bool CheckIfTextBoxChanged()
        {
            return _wikiArray.Array[_selectedIndexRow, 0] != TextBoxNam.Text ||
                   _wikiArray.Array[_selectedIndexRow, 1] != TextBoxCat.Text ||
                   _wikiArray.Array[_selectedIndexRow, 2] != TextBoxStr.Text ||
                   _wikiArray.Array[_selectedIndexRow, 3] != TextBoxDef.Text;
        }

        /// <summary>
        /// Checking to see if textboxes contain empty or null string
        /// </summary>
        /// <returns></returns>
        private bool CheckIfTextBoxEmpty()
        {
            return string.IsNullOrEmpty(TextBoxNam.Text) || string.IsNullOrEmpty(TextBoxCat.Text) ||
                   string.IsNullOrEmpty(TextBoxStr.Text) || string.IsNullOrEmpty(TextBoxDef.Text);
        }

        #endregion

        #endregion
    } //class
} //namespace
using System;
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

        private WikiSortedArray _wikiArray;
        private int _selectedIndex = -1;
        private string _nameChangedText;
        private string _categoryChangedText;
        private string _structureChangedText;
        private string _definitionChangedText;

        #endregion

        #region Events & Buttons

        // 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D array
        private void ButtonAdd_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "add";
            const string actioned = "added";

            if (!CheckArray()) return;
            if (!CheckSelected(action)) return;
            if (!CheckOutOfBound()) return;
            if (ConfirmationMessage(action))
            {
                //add
            }
            else
            {
                UpdateStatusStrip($"Item not {actioned}");
            }
        }

        // 9.3 Create and EDIT button that will allow the user to modify any information from the 4 text boxes into the 2D array
        private void ButtonEdit_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "edit";
            const string actioned = "edited";

            if (!CheckArray()) return;
            if (!CheckSelected(action)) return;
            if (!CheckOutOfBound()) return;
            if (ConfirmationMessage(action))
            {
                UpdateArray(_selectedIndex, 0, _nameChangedText);
                UpdateArray(_selectedIndex, 1, _categoryChangedText);
                UpdateArray(_selectedIndex, 2, _structureChangedText);
                UpdateArray(_selectedIndex, 3, _definitionChangedText);
                UpdateStatusStrip("Item edited");
                DisplayListView();
            }

            else
            {
                UpdateStatusStrip($"Item not {actioned}");
            }
        }

        // 9.4 Create a DELETE button that removes all the information from a single entry of the array; the user must be prompted before the final deletion occurs
        private void ButtonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "delete";
            const string actioned = "deleted";

            if (!CheckArray()) return;
            if (!CheckSelected(action)) return;
            if (!CheckOutOfBound()) return;
            if (ConfirmationMessage(action))
            {
                _wikiArray.DeleteItem(_selectedIndex);
                UpdateStatusStrip($"Item {actioned}");
                ClearTextBoxes();
                DisplayListView();
            }

            else
            {
                UpdateStatusStrip($"Item not {actioned}");
            }
        }

        // 9.5 Create a CLEAR method to clear the four text boxes so a new definition can be added
        private void ButtonClear_MouseClick(object sender, MouseEventArgs e)
        {
            ClearTextBoxes();
            UnselectItem();
        }

        // 9.10 Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat which is _sorted by Name, ensure the user has the option to select an alternative file. Use a file stream and BinaryWriter to create the file
        private void ButtonSave_MouseClick(object sender, MouseEventArgs e)
        {
          // add
        }

        // 9.11 Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array, ensure the user has the option to select an alternative file. Use a file stream and BinaryReader to complete this task
        // CHECK NEED TO LOAD BINARY FILE USING BINARY READER
        private void ButtonLoad_MouseClick(object sender, MouseEventArgs e)
        {
            _wikiArray = new WikiSortedArray();
            _wikiArray.LoadData();
            UpdateStatusStrip("Data successfully loaded");
            DisplayListView();
            CheckArray();
        }

        private void ButtonBinarySearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (!CheckArray()) return;
            if (!CheckTextBox()) return;
            var searchResult = _wikiArray.BinarySearch(TextBoxSearch.Text);
            switch (searchResult)
            {
                case -1:
                    UpdateStatusStrip("No data in the array");
                    return;
                case 0:
                    UpdateStatusStrip("Item not found");
                    TextBoxSearch.Focus();
                    break;
                default:
                    SelectItem(searchResult);
                    UpdateStatusStrip("Item found");
                    TextBoxSearch.Focus();
                    TextBoxSearch.Clear();
                    break;
            }
        }

        private void ListViewDataStructure_MouseClick(object sender, System.EventArgs e)
        {
            if (ListViewDataStructure.SelectedItems.Count <= 0) return;
            _selectedIndex = ListViewDataStructure.SelectedIndices[0];
            SelectItem(_selectedIndex);
        }

        private void TextBoxNam_TextChanged(object sender, System.EventArgs e)
        {
            _nameChangedText = TextBoxNam.Text;
        }

        private void TextBoxStr_TextChanged(object sender, System.EventArgs e)
        {
            _structureChangedText = TextBoxStr.Text;
     
        }

        private void TextBoxDef_TextChanged(object sender, System.EventArgs e)
        {
            _definitionChangedText = TextBoxDef.Text;
        }

        private void TextBoxCat_TextChanged(object sender, System.EventArgs e)
        {
            _categoryChangedText = TextBoxCat.Text;
          
        }

        #endregion

        #region Functions

        #region NOT WORKING

        private void SaveFile()
        {
            // ADD CODE
        }

        private void UpdateArray(int row, int col, string changedText)
        {
            _wikiArray.EditItem(row, col, changedText);
        }
        #endregion

        #region WORKING

        // 9.9 Create a method so the user can select a definition (Name) from the ListView and all the information is displayed in the appropriate Textboxes
        private void SelectItem(int index)
        {
            ListViewDataStructure.HideSelection = false;
            ListViewDataStructure.FullRowSelect = true;
            ListViewDataStructure.Items[index].Selected = true;
            DisplayTextBoxes(index);
        }

        // 9.8 Create a display method that will show the following information in a ListView: Name and Category
        private void DisplayListView()
        {
            ListViewDataStructure.Items.Clear();
            for (var x = 0; x < _wikiArray.Array.GetLength(0); x++)
            {
                var item = new ListViewItem(_wikiArray.Array[x, 0]);
                item.SubItems.Add(_wikiArray.Array[x, 1]);
                item.SubItems.Add(_wikiArray.Array[x, 2]);
                item.SubItems.Add(_wikiArray.Array[x, 3]);
                // item.SubItems.Add(Array[x, 4]);
                ListViewDataStructure.Items.Add(item);
            }
        }

        private void DisplayTextBoxes(int index)
        {
            TextBoxDef.Text = _wikiArray.Array[index, 3]; 
            TextBoxStr.Text = _wikiArray.Array[index, 2]; 
            TextBoxCat.Text = _wikiArray.Array[index, 1];
            TextBoxNam.Text = _wikiArray.Array[index, 0];
        }

        private void UpdateStatusStrip(string message)
        {
            StatusLabel.Text = message;
        }

        private void ClearTextBoxes()
        {
            TextBoxNam.Clear();
            TextBoxDef.Clear();
            TextBoxStr.Clear();
            TextBoxCat.Clear();
            TextBoxSearch.Clear();
            UnselectItem();
        }

        private static bool ConfirmationMessage(string action)
        {
            var message = $"Are you sure you want to {action} this item?";
            var caption = $"Please confirm {action}";
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                   == DialogResult.Yes;
        }

        private bool CheckTextBox()
        {
            if (string.IsNullOrEmpty(TextBoxSearch.Text))
            {
                UpdateStatusStrip("Search box is empty");
                return false;
            }
            return true;
        }

        private bool CheckSelected(string action)
        {
            if (_selectedIndex != -1) return true;
            UpdateStatusStrip($"Nothing selected to {action}");
            return false;
        }

        private bool CheckOutOfBound()
        {
            if (_selectedIndex <= _wikiArray.Array.Length) return true;
            UpdateStatusStrip("outside");
            return false;
        }

        private bool CheckArray()
        {
            if (_wikiArray == null)
            {
                UpdateStatusStrip("No data in the array");
                ClearTextBoxes();
                ButtonAdd.Enabled = false;
                ButtonDelete.Enabled = false;
                ButtonSearch.Enabled = false;
                ButtonEdit.Enabled = false;
                ButtonClear.Enabled = false;
                return false;
            }
            else
            {
                ButtonAdd.Enabled = true;
                ButtonDelete.Enabled = true;
                ButtonSearch.Enabled = true;
                ButtonEdit.Enabled = true;
                ButtonClear.Enabled = true;
                return true;
            }
        }

        private void UnselectItem()
        {
            _selectedIndex = -1;
        }
        #endregion

        #region REDUNDANT?
        private void ClearArray()
        {
            UpdateStatusStrip("Data cleared");
            ListViewDataStructure.Items.Clear();
            Array.Clear(_wikiArray.Array, 0, _wikiArray.Array.GetLength(0) * _wikiArray.Array.GetLength(1));
        }
        #endregion

        #endregion

    } //class
} //namespace
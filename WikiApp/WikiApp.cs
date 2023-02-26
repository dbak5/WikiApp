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
        private bool _textChanged;
        private string _nameChangedText;
        private string _categoryChangedText;
        private string _structureChangedText;
        private string _definitionChangedText;

        #endregion

        #region Events & Buttons

        #region Working
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
                TextBoxSearch.Clear();
                DisplayListView();
            }

            else
            {
                UpdateStatusStrip($"Item not {actioned}");
            }
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
                    ClearTextBoxes();
                    DeselectItem(_selectedIndex);
                    break;
                default:
                    SelectItem(searchResult);
                    UpdateStatusStrip("Item found");
                    TextBoxSearch.Focus();
                    TextBoxSearch.Clear();
                    break;
            }
        }

        // 9.5 Create a CLEAR method to clear the four text boxes so a new definition can be added
        private void ButtonClear_MouseClick(object sender, MouseEventArgs e)
        {
            ClearTextBoxes();
            TextBoxSearch.Clear();
            DeselectItem(_selectedIndex);
        }

        private void ListViewSelect_MouseClick(object sender, EventArgs e)
        {
            if (ListViewDataStructure.SelectedItems.Count <= 0) return;
            _selectedIndex = ListViewDataStructure.SelectedIndices[0];
            SelectItem(_selectedIndex);
        }

        #endregion


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
        // CHECK WHY IT ISN'T SORTING
        private void ButtonEdit_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "edit";
            const string actioned = "edited";

            if (!CheckArray()) return;
            if (!CheckSelected(action)) return;
            if (!CheckOutOfBound()) return;
            if (_textChanged)
            {
                if (ConfirmationMessage(action))
                {
                    _wikiArray.EditItem(_selectedIndex, 0, _nameChangedText);
                    _wikiArray.EditItem(_selectedIndex, 1, _categoryChangedText);
                    _wikiArray.EditItem(_selectedIndex, 2, _structureChangedText);
                    _wikiArray.EditItem(_selectedIndex, 3, _definitionChangedText);
                    UpdateStatusStrip("Item edited");
                    DisplayListView();
                    _textChanged = false;
                }

                else
                {
                    UpdateStatusStrip($"Item not {actioned}");
    
                }
            }
            else
            {
                UpdateStatusStrip("No changes made in text box");
            }
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

        #region TEXTBOX CHANGE HAS ISSUES NEED TO FIX
        private void TextBoxNam_KeyPress(object sender, KeyPressEventArgs e)
        {
           _nameChangedText = TextBoxNam.Text;
            _textChanged = true;
        }

        private void TextBoxCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            _categoryChangedText = TextBoxCat.Text;
            _textChanged = true;
        }

        private void TextBoxStr_KeyPress(object sender, KeyPressEventArgs e)
        {
            _structureChangedText = TextBoxStr.Text;
            _textChanged = true;
        }

        private void TextBoxDef_KeyPress(object sender, KeyPressEventArgs e)
        {
            _definitionChangedText = TextBoxDef.Text;
            _textChanged = true;
        }

    #endregion

        #endregion

        #region Functions
        private void SaveFile()
        {
            // ADD CODE
        }

        #region Working

        #region Select and deselect items in the list view
        // 9.9 Create a method so the user can select a definition (Name) from the ListView and all the information is displayed in the appropriate Textboxes
        private void SelectItem(int index)
        {
            ListViewDataStructure.HideSelection = false;
            ListViewDataStructure.FullRowSelect = true;
            ListViewDataStructure.Items[index].Selected = true;
            DisplayTextBoxes(index);
        }

        private void DeselectItem(int index)
        {
            if (_selectedIndex == -1) return;
            ListViewDataStructure.HideSelection = false;
            ListViewDataStructure.FullRowSelect = false;
            ListViewDataStructure.Items[index].Selected = false;
            _selectedIndex = -1;
        }
        #endregion

        #region Display and clear items - listview and textboxes
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

        private void ClearTextBoxes()
        {
            TextBoxNam.Clear();
            TextBoxDef.Clear();
            TextBoxStr.Clear();
            TextBoxCat.Clear();
            DeselectItem(_selectedIndex);
        }

        #endregion

        #region User feedback and confirmations
        private void UpdateStatusStrip(string message)
        {
            StatusLabel.Text = message;
        }

        private static bool ConfirmationMessage(string action)
        {
            var message = $"Are you sure you want to {action} this item?";
            var caption = $"Please confirm {action}";
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                   == DialogResult.Yes;
        }
        #endregion

        #region Error trapping
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
                TextBoxSearch.Clear();
                TextBoxCat.Enabled = false;
                TextBoxNam.Enabled = false;
                TextBoxStr.Enabled = false;
                TextBoxDef.Enabled = false;
                TextBoxSearch.Enabled = false;
                ButtonAdd.Enabled = false;
                ButtonDelete.Enabled = false;
                ButtonSearch.Enabled = false;
                ButtonEdit.Enabled = false;
                ButtonClear.Enabled = false;
                return false;
            }
            else
            {
                TextBoxCat.Enabled = true;
                TextBoxNam.Enabled = true;
                TextBoxStr.Enabled = true;
                TextBoxDef.Enabled = true;
                TextBoxSearch.Enabled = true;
                ButtonAdd.Enabled = true;
                ButtonDelete.Enabled = true;
                ButtonSearch.Enabled = true;
                ButtonEdit.Enabled = true;
                ButtonClear.Enabled = true;
                return true;
            }
        }

        #endregion

        #endregion

        #endregion

        
    } //class
} //namespace
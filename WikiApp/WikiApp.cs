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

        #region Variables

        private WikiSortedArray _wikiArray;
        private int _selectedIndex = -1;
        private bool _textChangedSearch;
        private bool _textChanged;
        private string _nameChangedText;
        private string _categoryChangedText;
        private string _structureChangedText;
        private string _definitionChangedText;
        private string _searchChangedText;

        #endregion

        #region Events & Buttons

        #region Working

        // 9.3 Create and EDIT button that will allow the user to modify any information from the 4 text boxes into the 2D array
        private void ButtonEdit_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "edit";
            const string actioned = "edited";
            //var array = _wikiArray.Array;

            // if (CheckArrayFull(array)) return;
            if (!CheckArrayNull()) return;
            if (!CheckOutOfBound()) return;
            if (CheckSelectedEdits())
            {
                if (CheckTextChangedEdits())
                {
                    if (ConfirmationMessage(action))
                    {
                        if (_nameChangedText != null)
                        {
                            _wikiArray.EditItem(_selectedIndex, 0, _nameChangedText);
                        }

                        if (_categoryChangedText != null)
                        {
                            _wikiArray.EditItem(_selectedIndex, 1, _categoryChangedText);
                        }

                        if (_structureChangedText != null)
                        {
                            _wikiArray.EditItem(_selectedIndex, 2, _structureChangedText);
                        }

                        if (_definitionChangedText != null)
                        {
                            _wikiArray.EditItem(_selectedIndex, 3, _definitionChangedText);
                        }

                        UpdateStatusStrip($"Item {actioned}");
                        _wikiArray.SortArray();
                        DisplayListView();
                        _textChanged = false;
                    }

                    else
                    {
                        UpdateStatusStrip($"Item not {actioned}");
                        _textChanged = false;
                    }
                }
                else
                {
                    UpdateStatusStrip($"No changes to {action}");
                    _textChanged = false;
                }
            }
            else
            {
                UpdateStatusStrip($"Nothing selected to {action}");
                _textChanged = false;
            }
        }

        // 9.4 Create a DELETE button that removes all the information from a single entry of the array; the user must be prompted before the final deletion occurs
        private void ButtonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "delete";
            const string actioned = "deleted";
            //var array = _wikiArray.Array;

            //if (CheckArrayFull(array)) return;
            if (!CheckArrayNull()) return;
            if (!CheckOutOfBound()) return;
            if (CheckSelectedEdits())
            {
                if (ConfirmationMessage(action))
                {
                    _wikiArray.DeleteItem(_selectedIndex);
                    UpdateStatusStrip($"Item {actioned}");
                    ClearTextBoxes();
                    TextBoxSearch.Clear();
                    _wikiArray.SortArray();
                    DisplayListView();
                    _textChanged = false;
                }

                else
                {
                    UpdateStatusStrip($"Item not {actioned}");
                    _textChanged = false;
                }
            }
            else
            {
                UpdateStatusStrip($"Nothing selected to {action}");
                _textChanged = false;
            }

        }

        private void ButtonSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (!CheckArrayNull()) return;
            var searchResult = _wikiArray.BinarySearch(TextBoxSearch.Text);
            if (CheckTextChangedSearch())
            {
                switch (searchResult)
                {
                    case -1:
                        UpdateStatusStrip("No data in the array");
                        _textChangedSearch = false;
                        return;
                    case -2:
                        UpdateStatusStrip("Item not found");
                        TextBoxSearch.Focus();
                        ClearTextBoxes();
                        DeselectItem(_selectedIndex);
                        _textChangedSearch = false;
                        break;
                    default:
                        UpdateStatusStrip("Item found");
                        SelectItem(searchResult);
                        TextBoxSearch.Focus();
                        TextBoxSearch.Clear();
                        _textChangedSearch = false;
                        break;
                }
            }
            else
            {
                UpdateStatusStrip("Please enter search");
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

        //CHECK - NEED TO FIX
        #region Events for TextChanged in TextBoxes for Edit and Search

        private void TextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            _textChangedSearch = true;
            CheckTextChangedSearch();
        }

        private void TextBoxNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            _textChanged = true;
            CheckTextChangedEdits();
            
        }

        private void TextBoxCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            _textChanged = true;
            CheckTextChangedEdits();
        }

        private void TextBoxStr_KeyPress(object sender, KeyPressEventArgs e)
        {
            _textChanged = true;
            CheckTextChangedEdits();
        }

        private void TextBoxDef_KeyPress(object sender, KeyPressEventArgs e)
        {
            _textChanged = true;
            CheckTextChangedEdits();
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            _searchChangedText = TextBoxSearch.Text;
            CheckSelectedEdits();
        }

        private void TextBoxNam_TextChanged(object sender, EventArgs e)
        {
            _nameChangedText = TextBoxNam.Text;
            CheckSelectedEdits();
        }

        private void TextBoxCat_TextChanged(object sender, EventArgs e)
        {
            _categoryChangedText = TextBoxCat.Text;
            CheckSelectedEdits();
        }

        private void TextBoxStr_TextChanged(object sender, EventArgs e)
        {
            _structureChangedText = TextBoxStr.Text;
            CheckSelectedEdits();
        }

        private void TextBoxDef_TextChanged(object sender, EventArgs e)
        {
            _definitionChangedText = TextBoxDef.Text;
            CheckSelectedEdits();
        }

        #endregion

        #region Tooltips
        private void ButtonSearch_MouseHover(object sender, EventArgs e)
        {
            ToolTipButtons.SetToolTip(ButtonSearch, "Search for an item in the data");
        }

        private void ButtonAdd_MouseHover(object sender, EventArgs e)
        {
            ToolTipButtons.SetToolTip(ButtonAdd, "Add item to data");
        }

        private void ButtonEdit_MouseHover(object sender, EventArgs e)
        {
            ToolTipButtons.SetToolTip(ButtonEdit, "Edit item in data");
        }

        private void ButtonDelete_MouseHover(object sender, EventArgs e)
        {
            ToolTipButtons.SetToolTip(ButtonDelete, "Delete item from data");
        }

        private void ButtonClear_MouseHover(object sender, EventArgs e)
        {
            ToolTipButtons.SetToolTip(ButtonClear, "Clear items from text boxes");
        }

        private void ButtonLoad_MouseHover(object sender, EventArgs e)
        {
            ToolTipButtons.SetToolTip(ButtonLoad, "Load data into the tables");
        }

        private void ButtonSave_MouseHover(object sender, EventArgs e)
        {
            ToolTipButtons.SetToolTip(ButtonSave, "Save data from tables into a file");
        }

        private void TextBoxSearch_MouseHover(object sender, EventArgs e)
        {
            ToolTipTextBox.SetToolTip(TextBoxSearch, "Enter text to search for");
        }

        private void TextBoxNam_MouseHover(object sender, EventArgs e)
        {
            ToolTipTextBox.SetToolTip(TextBoxNam, "Data name, update to edit item");
        }

        private void TextBoxCat_MouseHover(object sender, EventArgs e)
        {
            ToolTipTextBox.SetToolTip(TextBoxCat, "Data category, update to edit item");
        }

        private void TextBoxStr_MouseHover(object sender, EventArgs e)
        {
            ToolTipTextBox.SetToolTip(TextBoxStr, "Data structure, update to edit item");
        }

        private void TextBoxDef_MouseHover(object sender, EventArgs e)
        {
            ToolTipTextBox.SetToolTip(TextBoxDef, "Data description, update to edit item");
        }

        private void ListViewDataStructure_MouseHover(object sender, EventArgs e)
        {
            ToolTipTextBox.SetToolTip(TextBoxDef, "Data description, update to edit item");
        }

        #endregion

        #endregion

        // 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D array
        private void ButtonAdd_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "add";
            const string actioned = "added";
            var array = _wikiArray.Array;

            if (CheckArrayFull(array)) return;
            if (!CheckArrayNull()) return;
            if (!CheckOutOfBound()) return;
            if (CheckSelectedEdits())
            {
                if (ConfirmationMessage(action))
                {
                    _wikiArray.AddItem();
                    _textChanged = false;
                }
                else
                {
                    UpdateStatusStrip($"Item not {actioned}");
                    _textChanged = false;
                }
            }
            else
            {
                UpdateStatusStrip($"Nothing selected to {action}");
                _textChanged = false;
            }
        }

        // 9.10 Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat which is _sorted by Name, ensure the user has the option to select an alternative file. Use a file stream and BinaryWriter to create the file
        private void ButtonSave_MouseClick(object sender, MouseEventArgs e)
        {
            var array = _wikiArray.Array;

            if (CheckArrayFull(array)) return;
            SaveFile();
            //add
        }

        // 9.11 Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array, ensure the user has the option to select an alternative file. Use a file stream and BinaryReader to complete this task
        // CHECK NEED TO LOAD BINARY FILE USING BINARY READER
        // CREATE FUNCTION TO OPEN FILE DIALOGUE BOX
        // FIX FILTER LIMITS
        private void ButtonLoad_MouseClick(object sender, MouseEventArgs e)
        {
            const string filterLimits = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            var openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = filterLimits,
                FilterIndex = 2,
                RestoreDirectory = true
            };
            var result = openFileDialog1.ShowDialog();

            if (result != DialogResult.OK) return;
            _wikiArray = new WikiSortedArray();
            _wikiArray.LoadData(openFileDialog1.FileName);
            UpdateStatusStrip("Data successfully loaded");
            _wikiArray.SortArray();
            DisplayListView();
            CheckArrayNull();
        }

        #endregion

        #region Functions
        // CHECK NEED TO CREATE FUNCTION
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
        
        private bool CheckSelectedEdits()
        {
            if (_selectedIndex != -1)
            {
                ButtonEdit.Enabled = true;
                ButtonDelete.Enabled = true;
                ButtonAdd.Enabled = true;
                ButtonClear.Enabled = true;
                return true;
            }
            ButtonEdit.Enabled = false;
            ButtonDelete.Enabled = false;
            ButtonAdd.Enabled = false;
            ButtonClear.Enabled = false;
            return false;
        } 

        private bool CheckOutOfBound()
        {
            if (_selectedIndex <= _wikiArray.Array.Length) return true;
            UpdateStatusStrip("outside");
            return false;
        }

        private bool CheckArrayNull()
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

        private bool CheckTextChangedEdits()
        {
            if (_textChanged)
            {
                ButtonEdit.Enabled = true;
                return true;
            }
            ButtonEdit.Enabled = false;
            return false;
        }

        private bool CheckTextChangedSearch()
        {

            if (_textChangedSearch)
            {
                ButtonSearch.Enabled = true;
                return true;
            }
            else
            {
                ButtonSearch.Enabled = false;
                return false;
            }
        }

        private bool CheckArrayFull(Array array)
        {
            if (array.Length != (4 * 12)) return false;
            ButtonAdd.Enabled = false;
            return true;
        }

        #endregion

        #endregion

        #endregion

    } //class
} //namespace
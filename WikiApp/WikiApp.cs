using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

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

        // CHECK PREVENT USING GLOBAL VARIABLES
        #region Variables

        private WikiSortedArray _wikiArray;
        private int _selectedIndexRow = -1;
        private int _selectedIndexColumn = -2;
        private string _changedText;
        private bool _textChanged;

        #endregion

        // TEXTBOX FOCUS IN APPROPRIATE PLACES
        #region Events

        //CHECK NOT WORKING
        private void ButtonClearAll_MouseClick(object sender, MouseEventArgs e)
        {
            if (!CheckArrayNull()) return;
            _wikiArray.ClearArray();
        }

        // CHECK - NEED TO FIX "ARRAY IS FULL"
        // 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D array
        private void ButtonAdd_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "add";
            const string actioned = "added";
   
            if (!CheckArrayNull()) return;
            if (!CheckOutOfBound()) return;

            // CHECK GET RID OF HARD CODED NUMBERS
            if (_wikiArray.Array.Length != (WikiSortedArray.Col * WikiSortedArray.Row))
            {
                if (ConfirmationUserRequest(action))
                {
                    _wikiArray.AddItem();
                }
                else
                {
                    UpdateStatusStrip($"Item not {actioned}");
                }
            }
            else
            {
                UpdateStatusStrip($"Array is full, not {actioned}");
            }
            _selectedIndexColumn = -2;
        }

        // 9.3 Create and EDIT button that will allow the user to modify any information from the 4 text boxes into the 2D array
        private void ButtonEdit_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "edit";
            const string actioned = "edited";

            if (!CheckArrayNull()) return;
            if (!CheckOutOfBound()) return;
            if (CheckSelected())
            {
                if (_textChanged)
                {
                    if (ConfirmationUserRequest(action))
                    {
                        switch (_selectedIndexColumn)
                        {
                            case 0:
                                _wikiArray.EditItem(_selectedIndexRow, _selectedIndexColumn, _changedText);
                                break;
                            case 1:
                                _wikiArray.EditItem(_selectedIndexRow, _selectedIndexColumn, _changedText);
                                break;
                            case 2:
                                _wikiArray.EditItem(_selectedIndexRow, _selectedIndexColumn, _changedText);
                              
                                break;
                            case 3:
                                _wikiArray.EditItem(_selectedIndexRow, _selectedIndexColumn, _changedText);
                                break;
                        }
                        _wikiArray.SortArray();
                        DisplayListView();
                        UpdateStatusStrip($"Item {actioned}");
                    }
                    else
                    {
                        UpdateStatusStrip($"Item not {actioned}");
                    }
                }
                else
                {
                    UpdateStatusStrip($"No changes to {action}");
                }
            }
            else
            {
                UpdateStatusStrip($"Nothing selected to {action}");
            }
            TextBoxSearch.Focus();
            _selectedIndexColumn = -2;
            _textChanged = false;
        }

        // 9.4 Create a DELETE button that removes all the information from a single entry of the array; the user must be prompted before the final deletion occurs
        private void ButtonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "delete";
            const string actioned = "deleted";

            if (!CheckArrayNull()) return;
            if (!CheckOutOfBound()) return;
            if (CheckSelected())
            {
                if (ConfirmationUserRequest(action))
                {
                    _wikiArray.DeleteItem(_selectedIndexRow);
                    _wikiArray.SortArray();
                    DisplayListView();
                    ClearTextBoxes();
                    UpdateStatusStrip($"Item {actioned}");
                }
                else
                {
                    UpdateStatusStrip($"Item not {actioned}");
                }
            }
            else
            {
                UpdateStatusStrip($"Nothing selected to {action}");
            }
            TextBoxSearch.Clear();
            TextBoxSearch.Focus();
            _selectedIndexColumn = -2;
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
            //if (!CheckArrayNull()) return;

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
            //if (!CheckArrayNull()) return;

            

            // CHECK REMOVE THIS AFTER EVERYTHING IS WORKING
            var fileName = "C:\\Users\\Bananus\\Downloads\\definitions.bin";

            _wikiArray = new WikiSortedArray();
            _wikiArray.LoadData(fileName);
            _wikiArray.SortArray();
            TextBoxSearch.Focus();
            DisplayListView();
            UpdateStatusStrip("Data successfully loaded");
            CheckArrayNull();
        }

        private void ButtonSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (!CheckArrayNull()) return;

            var searchResult = _wikiArray.BinarySearch(TextBoxSearch.Text);
            if (!string.IsNullOrEmpty(TextBoxSearch.Text))
            {
                if (_textChanged && _selectedIndexColumn == -1)
                {
                    switch (searchResult)
                    {
                        //CHECK ALREADY BEING CHECKED IN ANOTHER METHOD
                        case -1:
                            UpdateStatusStrip("No data in the array");
                            return;
                        case -2:
                            UpdateStatusStrip("Item not found");
                            DeselectItem(_selectedIndexRow);
                            ClearTextBoxes();
                            break;
                        default:
                            UpdateStatusStrip("Item found");
                            DeselectItem(_selectedIndexRow);
                            TextBoxSearch.Clear();
                            SelectItem(searchResult);
                            break;
                    }
                }
            }
            else
            {
                UpdateStatusStrip("Please enter search");
            }
            TextBoxSearch.Focus();
            _selectedIndexColumn = -2;
            _textChanged = false;
        }

        private void ButtonClear_MouseClick(object sender, MouseEventArgs e)
        {
            ClearTextBoxes();
            TextBoxSearch.Clear();
            TextBoxSearch.Focus();
            DeselectItem(_selectedIndexRow);
        }

        private void ListViewSelect_MouseClick(object sender, EventArgs e)
        {
            if (ListViewDataStructure.SelectedItems.Count <= 0) return;
            _selectedIndexRow = ListViewDataStructure.SelectedIndices[0];
            SelectItem(_selectedIndexRow);
        }
      

        #region Events for TextChanged in TextBoxes for Edit and Search
        private void TextBoxNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextChangedEdits();
            _textChanged = true;
        }
        private void TextBoxCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextChangedEdits();
            _textChanged = true;
        }
        private void TextBoxStr_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextChangedEdits();
            _textChanged = true;
        }
        private void TextBoxDef_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextChangedEdits();
            _textChanged = true;
        }
        private void TextBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            _textChanged = true;
        }
        private void TextBoxNam_TextChanged(object sender, EventArgs e)
        {
            CheckSelected();
            _changedText = TextBoxNam.Text;
            _selectedIndexColumn = 0;
        }
        private void TextBoxCat_TextChanged(object sender, EventArgs e)
        {
            CheckSelected();
            _changedText = TextBoxCat.Text;
            _selectedIndexColumn = 1;
        }
        private void TextBoxStr_TextChanged(object sender, EventArgs e)
        {
            CheckSelected();
            _changedText = TextBoxStr.Text;
            _selectedIndexColumn = 2;
        }
        private void TextBoxDef_TextChanged(object sender, EventArgs e)
        {
            CheckSelected();
            _changedText = TextBoxDef.Text;
            _selectedIndexColumn = 3;
        }
        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            CheckSelected();
            _changedText = TextBoxSearch.Text;
            _selectedIndexColumn = -1;
        }

        #endregion

        #endregion

        #region Methods
        // CHECK DOUBLE CLICK TEXTBOX TO CLEAR??
        /// <summary>
        /// 9.5 Create a CLEAR method to clear the four text boxes so a new definition can be added
        /// </summary>
        private void ClearTextBoxes()
        {
            TextBoxNam.Clear();
            TextBoxDef.Clear();
            TextBoxStr.Clear();
            TextBoxCat.Clear();
            DeselectItem(_selectedIndexRow);
        }

        // CHECK - JUST NAME AND CATEGORY IN TEXTBOXES
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
                // item.SubItems.Add(Array[x, 4]);
                ListViewDataStructure.Items.Add(item);
            }
        }

        /// <summary>
        /// 9.9 Create a method so the user can select a definition (Name) from the ListView 
        /// and all the information is displayed in the appropriate Textboxes
        /// </summary>
        /// <param name="index"></param>
        #region
        private void SelectItem(int index)
        {
            ListViewDataStructure.HideSelection = false;
            ListViewDataStructure.FullRowSelect = true;
            ListViewDataStructure.Items[index].Selected = true;
            DisplayTextBoxes(index);
        }
        private void DisplayTextBoxes(int index)
        {
            TextBoxDef.Text = _wikiArray.Array[index, 3];
            TextBoxStr.Text = _wikiArray.Array[index, 2];
            TextBoxCat.Text = _wikiArray.Array[index, 1];
            TextBoxNam.Text = _wikiArray.Array[index, 0];
        }
        #endregion

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
        /// Update the status strip and confirm action request box
        /// </summary>
        /// <param name="message"></param>
        #region
        private void UpdateStatusStrip(string message)
        {
            StatusLabel.Text = message;
        }

        private static bool ConfirmationUserRequest(string action)
        {
            var message = $"Are you sure you want to {action} this item?";
            var caption = $"Please confirm {action}";
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                   == DialogResult.Yes;
        }
        #endregion


        #region Error trapping
        /// <summary>
        /// Method to check if the index is out of bounds of the array
        /// </summary>
        /// <returns></returns>
        private bool CheckOutOfBound()
        {
            if (_selectedIndexRow <= _wikiArray.Array.Length) return true;
            UpdateStatusStrip("outside");
            return false;
        }

        /// <summary>
        /// Method to check if the array contains values
        /// If no values in the array, return false and disable buttons
        /// If values in the array, return true and enable buttons
        /// </summary>
        /// <returns></returns>
        private bool CheckArrayNull()
        {
            if (_wikiArray == null || _wikiArray.Empty)
            {
                UpdateStatusStrip("No data in the array");
                ClearTextBoxes();
                TextBoxSearch.Clear();
                TextBoxCat.Enabled = false;
                TextBoxNam.Enabled = false;
                TextBoxStr.Enabled = false;
                TextBoxDef.Enabled = false;
                TextBoxSearch.Enabled = false;
                ButtonClear.Enabled = false;
                ButtonAdd.Enabled = false;
                ButtonSearch.Enabled = false;
                CheckSelected();
                CheckTextChangedEdits();
                return false;
            }
            TextBoxCat.Enabled = true;
            TextBoxNam.Enabled = true;
            TextBoxStr.Enabled = true;
            TextBoxDef.Enabled = true;
            TextBoxSearch.Enabled = true;
            ButtonClear.Enabled = true;
            ButtonAdd.Enabled = true;
            ButtonSearch.Enabled = true;
            CheckSelected();
            CheckTextChangedEdits();
            return true;
        }

        /// <summary>
        /// Method to check if something has been selected before carrying out an action.
        /// If something selected, return true, enable buttons
        /// If nothing selected, return false, disable buttons
        /// </summary>
        /// <returns></returns>
        private bool CheckSelected()
        {
            if (_selectedIndexRow != -1)
            {
                ButtonEdit.Enabled = true;
                ButtonDelete.Enabled = true;
                return true;
            }
            ButtonEdit.Enabled = false;
            ButtonDelete.Enabled = false;
            return false;
        }
        /// <summary>
        /// Method to check if edits have been made in the text boxes
        /// If no edits made, return false, disable edit button
        /// If edits made, return true, enable edit button
        /// </summary>
        /// <returns></returns>
        /// 
        private void CheckTextChangedEdits()
        {
            if (_selectedIndexColumn != -2)
            {
                ButtonEdit.Enabled = true;
            }
            ButtonEdit.Enabled = false;
        }

        #endregion

        #endregion

    } //class
} //namespace
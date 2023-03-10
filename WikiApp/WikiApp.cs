using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
        // All events and functions relating to the interface are below
        public WikiApp()
        {
            InitializeComponent();
        }

        private WikiSortedArray _wikiArray;
        private int _selectedIndexRow = -1;

        #region Events
        // 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D
        // array
        private void ButtonAdd_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "add";
            const string item = "item";
            const string actioned = "added";

            if (!CheckArrayNull())
            {
                _wikiArray = new WikiSortedArray();
                TextBoxNam.Focus();
            }
            if (_wikiArray.Array[WikiSortedArray.Row-1, 0] == "~")
            {
                if (!CheckTextBoxEmpty())
                {
                    if (CheckIfDuplicate())
                    {
                        UpdateItems(action, actioned, item);
                    }
                    else
                    {
                        UpdateStatusStrip($"Duplicate entry found, cannot {action}");
                        TextBoxNam.Focus();
                    }
                }
                else
                {
                    UpdateStatusStrip("Empty fields found, please input data to add and ensure all fields are full");
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

        // 9.3 Create and EDIT button that will allow the user to modify any information from the 4 text boxes
        // into the 2D array
        private void ButtonEdit_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "edit";
            const string item = "item";
            const string actioned = "edited";

            if (!GreyBoxArrayNull()) return;
            if (!CheckOutOfBound()) return;
            if (CheckItemSelected() && !CheckTextBoxEmpty())
            {
                if (CheckIfTextBoxChanged())
                {
                    if (CheckIfDuplicate())
                    {
                        UpdateItems(action, actioned, item);
                        ButtonSave.Enabled = true;
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

        // 9.4 Create a DELETE button that removes all the information from a single entry of the array; the user must be prompted
        // before the final deletion occurs
        private void ButtonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "delete";
            const string item = "item";
            const string actioned = "deleted";

            if (!GreyBoxArrayNull()) return;
            if (!CheckOutOfBound()) return;
            if (CheckItemSelected() && !CheckTextBoxEmpty())
            {
                if (ConfirmationUserRequest(action, item))
                {
                    _wikiArray.DeleteItem(_selectedIndexRow);
                    DisplayListView();
                    ClearTextBoxes();
                    UpdateStatusStrip($"Item {actioned}");
                    ButtonAdd.Enabled = true;
                    ButtonSave.Enabled = true;
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

        // 9.10 Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat
        // which is sorted by Name, ensure the user has the option to select an alternative file. Use a file stream and BinaryWriter
        // to create the file
        private void ButtonSave_MouseClick(object sender, MouseEventArgs e)
        {
            string fileName = null;
            var fileList = new List<string>();
            var place = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = place.GetFiles("*.dat");

            if (!GreyBoxArrayNull()) return;

            // Look for files in the folder
            // Remove file extensions and add each file name to the list and sort list
            foreach (var file in files)
            {
                var fileContent = Path.GetFileNameWithoutExtension(file.Name);
                fileList.Add(fileContent);
                fileList.Sort();
            }

            // Look for existing files with the same name
            if (fileList.Any(l => l.Contains("definitions")))
            {
                if (fileList.Count > 0)
                {
                    // Get the last item in the list, remove spaces, letters and underscores and convert to integer.
                    var lastItem = fileList.LastOrDefault();
                    if (lastItem != null)
                    {
                        var numberOnly = Regex.Replace(lastItem, "[A-Za-z, _ ]", "").Trim();
                        if (int.TryParse(numberOnly, out var x))
                        {
                            // Increment file number
                            var fileNameIncrement = x + 1;

                            // Create default file names using an increment
                            var fileNameIncrementWhole = x < 10 ? $"0{fileNameIncrement}" : fileNameIncrement.ToString();
                            fileName = Path.Combine($"definitions_{fileNameIncrementWhole}");
                        }
                    }
                }
            }

            // Create default file name if no file name already exists
            else
            {
                fileName = Path.Combine($"definitions_01.dat");
            }

            // Open save file dialog and Save file
            const string filterLimits = "All files (*.*)|*.*|dat files (*.*)|*.dat";
            var saveFileDialog1 = new SaveFileDialog
            {
                Title = @"Save data to file",
                FileName = fileName,
                InitialDirectory = Directory.GetCurrentDirectory(),
                CheckPathExists = true,
                Filter = filterLimits,
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            _wikiArray.SaveFile(saveFileDialog1.FileName);
            TextBoxNam.Focus();
            UpdateStatusStrip("File successfully saved");
        }

        // 9.11 Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array,
        // ensure the user has the option to select an alternative file. Use a file stream and BinaryReader to complete this task
        private void ButtonLoad_MouseClick(object sender, MouseEventArgs e)
        {
            const string filterLimits = "All files (*.*)|*.*|bin files (*.*)|*.bin";
            
            // Check if array is null or if user cancels the request
            if (!CheckArrayNull())
            {
                var confirm = ConfirmationUserRequest("clear", "data",
                    "\nThis action will clear the current data and load new data");
                if (!confirm) return;
            }

            var openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = filterLimits,
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            // Error catch if file is empty, do not load data
            if (new FileInfo(openFileDialog1.FileName).Length == 0)
            {
                UpdateStatusStrip("File is empty, no data to load, please select a different file");
                return;
            }

            // Error catch if extension is not a a bin file, do not load data
            if (new FileInfo(openFileDialog1.FileName).Extension != ".bin" && new FileInfo(openFileDialog1.FileName).Extension != ".dat")
            {
                UpdateStatusStrip("Incorrect file format selected, please select a bin file");
                return;
            }

            // Initialise array and load data into list view
            _wikiArray = new WikiSortedArray();
            _wikiArray.LoadData(openFileDialog1.FileName);
            DisplayListView();
            UpdateStatusStrip("Data successfully loaded");
            GreyBoxArrayNull();
            TextBoxSearch.Focus();
        }

        // Search button which uses a binary search from the wiki array class
        private void ButtonSearch_MouseClick(object sender, MouseEventArgs e)
        {
            Search();
        }

        // Select something in the list view
        private void ListViewSelect_MouseClick(object sender, EventArgs e)
        {
            if (!GreyBoxArrayNull()) return;
            if (ListViewDataStructure.SelectedItems.Count <= 0) return;
            _selectedIndexRow = ListViewDataStructure.SelectedIndices[0];
            SelectItem(_selectedIndexRow);
        }

        // Double mouse click on the "Name" text box to clear all text boxes
        private void TextBoxNam_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearTextBoxes();
        }

        // Button to clear all the data from the array and list view
        private void ButtonClearAll_MouseClick(object sender, MouseEventArgs e)
        {
            ClearAllData();
        }

        // Button to clear the text boxes only
        private void ButtonClear_MouseClick(object sender, MouseEventArgs e)
        {
            ClearTextBoxes();
        }

        // Double click to clear all data from the list view and array
        private void ListViewDataStructure_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearAllData();
        }

        // Button to exit confirm user action
        private void WikiApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string action = "close";
            const string item = "form";

            if (!ConfirmationUserRequest(action, item,
                    "\nWARNING: you will lose all progress"))
            {
                e.Cancel = true;
            }
            else { Application.Exit(); }
        }

        // Carry out binary search on 'Enter' keydown
        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        #endregion

        #region Methods

        /// <summary>
        /// 9.5 Create a CLEAR method to clear the four text boxes so a new definition can be added
        /// </summary>
        private void ClearTextBoxes()
        {
            if (CheckTextBoxEmpty())
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
                TextBoxSearch.Clear();
                TextBoxSearch.Focus();
            }
        }

        /// <summary>
        /// 9.8 Create a display method that will show the following information in a ListView: Name and Category.
        /// </summary>
        private void DisplayListView()
        {
            _wikiArray.BubbleSort();
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
        /// <param name="item"></param>
        /// <param name="optionalString"></param>
        /// <returns></returns>
        private static bool ConfirmationUserRequest(string action, string item, string optionalString = "")
        {
            var message = $"Are you sure you want to {action} the {item}?";
            var optionalMsg = $"\n{optionalString}";
            var caption = $"Please confirm {action}";
            return MessageBox.Show(message + optionalMsg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                   == DialogResult.Yes;
        }

        /// <summary>
        /// Update items in the array for edit or add
        /// </summary>
        /// <param name="action"></param>
        /// <param name="actioned"></param>
        /// <param name="item"></param>
        private void UpdateItems(string action, string actioned, string item)
        {
            var newName = TextBoxNam.Text;
            var newCat = TextBoxCat.Text;
            var newStr = TextBoxStr.Text;
            var newDef = TextBoxDef.Text;
            
            if (ConfirmationUserRequest(action, item))
            {
                if (action == "add")
                {
                    _wikiArray.EditItem(WikiSortedArray.Row - 1, 0, newName);
                    _wikiArray.EditItem(WikiSortedArray.Row - 1, 1, newCat);
                    _wikiArray.EditItem(WikiSortedArray.Row - 1, 2, newStr);
                    _wikiArray.EditItem(WikiSortedArray.Row - 1, 3, newDef);
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
                DisplayListView();
                ListViewDataStructure.Enabled = true;
                UpdateStatusStrip($"Item {actioned}");
            }
            else
            {
                UpdateStatusStrip($"Item not {actioned}");
            }
        }

        /// <summary>
        /// Clear all the data from the array and list view
        /// </summary>
        private void ClearAllData()
        {
            if (!GreyBoxArrayNull()) return;

            var confirm = ConfirmationUserRequest("clear all", "data",
                "\nThis action will clear all the data in the tables");

            if (!confirm) return;

            _wikiArray.ClearArray();
            ClearTextBoxes();
            DisplayListView();
            UpdateStatusStrip("Data cleared");
            GreyBoxArrayNull();
            ButtonAdd.Enabled = true;
        }

        /// <summary>
        /// Search the data
        /// </summary>
        private void Search()
        {
            //Debug.WriteLine("Debug Information: Binary Search Starting");
            //Debug.WriteLine("Debug Information: Returns an integer index, returns -1 if not found");

            if (!GreyBoxArrayNull()) return;

            // Integer variable which is a row index number, or -1 if not found
            var searchResult = _wikiArray.BinarySearch(TextBoxSearch.Text);
            var emptyString = string.IsNullOrEmpty(TextBoxSearch.Text);

            //Debug.WriteLine($"\nSearch input: {TextBoxSearch.Text}");
            //Debug.WriteLine($"Search result: {searchResult}");

            if (!emptyString)
            {
                if (searchResult == -1)
                {
                    UpdateStatusStrip("Item not found");
                    TextBoxSearch.Focus();
                    DeselectItem(_selectedIndexRow);
                    ClearTextBoxes();
                    //Debug.WriteLine("\nItem not found");
                    return;
                }
                UpdateStatusStrip("Item found");
                DeselectItem(_selectedIndexRow);
                TextBoxSearch.Clear();
                TextBoxNam.Focus();
                SelectItem(searchResult);
                //Debug.WriteLine("\nItem found");
            }
            else
            {
                UpdateStatusStrip("Please enter search");
                TextBoxSearch.Focus();
            }

            //Debug.WriteLine("\nDebug Information: Binary Search Ending");
        }
        #endregion

        #region Booleans for error trapping
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
                ButtonSave.Enabled = false;
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
        private bool CheckItemSelected()
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
        private bool CheckIfDuplicate()
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
        private bool CheckTextBoxEmpty()
        {
            return string.IsNullOrEmpty(TextBoxNam.Text) || string.IsNullOrEmpty(TextBoxCat.Text) ||
                   string.IsNullOrEmpty(TextBoxStr.Text) || string.IsNullOrEmpty(TextBoxDef.Text) || TextBoxNam.Text == "~";
        }

        #endregion

    } //class
} //namespace
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
        public WikiApp()
        {
            InitializeComponent();
        }

        private WikiSortedArray _wikiArray;
        private int _selectedIndexRow = -1;

        #region Events
       
        // 9.2 Create an ADD button that will store the information from the 4 text boxes into the 2D array
        private void ButtonAdd_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "add";
            const string item = "item";
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
                        UpdateItems(action, actioned, item);
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
            const string item = "item";
            const string actioned = "edited";

            if (!GreyBoxArrayNull()) return;
            if (!CheckOutOfBound()) return;
            if (ButtonEdit.Enabled == false)
            {
                UpdateStatusStrip($"Please select an {item} to {action}");
            }
            else
            {
                if (CheckIfSelected() && !CheckIfTextBoxEmpty())
                {
                    if (CheckIfTextBoxChanged())
                    {
                        if (CheckIfExists())
                        {
                            UpdateItems(action, actioned, item);
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
           
        }

        // 9.4 Create a DELETE button that removes all the information from a single entry of the array; the user must be prompted
        // before the final deletion occurs
        private void ButtonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            const string action = "delete";
            const string item = "item";
            const string actioned = "deleted";

            //  UpdateStatusStrip("");
            if (!GreyBoxArrayNull()) return;
            if (!CheckOutOfBound()) return;
            if (CheckIfSelected() && !CheckIfTextBoxEmpty())
            {
                var selectedItem = _wikiArray.Array[_selectedIndexRow, 0];
                if (selectedItem != "")
                {
                    if (ConfirmationUserRequest(action, item))
                    {
                        _wikiArray.DeleteItem(_selectedIndexRow);
                        _wikiArray.BubbleSort();
                        DisplayListView();
                        ClearTextBoxes();
                        UpdateStatusStrip($"Item {actioned}");
                        ButtonAdd.Enabled = true;
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

        // 9.10 Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat
        // which is _sorted by Name, ensure the user has the option to select an alternative file. Use a file stream and BinaryWriter
        // to create the file
        private void ButtonSave_MouseClick(object sender, MouseEventArgs e)
        {
            string fileName = null;
            var fileList = new List<string>();
            var place = new DirectoryInfo(Directory.GetCurrentDirectory());
            var files = place.GetFiles("*.dat");

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
                            var fileNameIncrementWhole = "";
                            if (x < 10)
                            {
                                fileNameIncrementWhole = $"0{fileNameIncrement}";
                            }
                            else
                            {
                                fileNameIncrementWhole = fileNameIncrement.ToString();
                            }
                            fileName = Path.Combine($"definitions_{fileNameIncrementWhole}");
                        }
                    }
                }
            }

            // Default file name if no file name already exists
            else
            {
                fileName = Path.Combine($"definitions_01.dat");
            }

            const string filterLimits = "All files (*.*)|*.*|dat files (*.*)|*.dat";
            var saveFileDialog1 = new SaveFileDialog
            {
                Title = "Save data to file",
                FileName = fileName,
                InitialDirectory = Directory.GetCurrentDirectory(),
                CheckPathExists = true,
                Filter = filterLimits,
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            _wikiArray.SaveFile(saveFileDialog1.FileName);
            TextBoxSearch.Focus();
            UpdateStatusStrip("File successfully saved");
        }

        // 9.11 Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array,
        // ensure the user has the option to select an alternative file. Use a file stream and BinaryReader to complete this task
        private void ButtonLoad_MouseClick(object sender, MouseEventArgs e)
        {
            if (!CheckArrayNull() && !ConfirmationUserRequest("clear", "data")) return;
         
            var (result, fileName) = OpenFileDialogue();
            if (result != DialogResult.OK) return;

            if (new FileInfo(fileName).Length == 0)
            {
                UpdateStatusStrip("File is empty, no data to load, please select a different file");
                return;
            }

            if (new FileInfo(fileName).Extension != ".bin")
            {
                UpdateStatusStrip("Incorrect file format selected, please select a bin file");
                return;
            }

            _wikiArray = new WikiSortedArray();
            _wikiArray.LoadData(fileName);
            _wikiArray.BubbleSort();
            DisplayListView();
            UpdateStatusStrip("Data successfully loaded");
            GreyBoxArrayNull();
            TextBoxSearch.Focus();
        }

        // Search button which uses a binary search from the wiki array class
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
            if (!GreyBoxArrayNull()) return;
            _wikiArray.ClearArray();
            ClearTextBoxes();
            DisplayListView();
            UpdateStatusStrip("Data cleared");
            GreyBoxArrayNull();
        }

        // Button to clear the text boxes only
        private void ButtonClear_MouseClick(object sender, MouseEventArgs e)
        {
            ClearTextBoxes();
        }

        #endregion

        #region Methods
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
                TextBoxSearch.Clear();
                TextBoxSearch.Focus();
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
        private static bool ConfirmationUserRequest(string action, string item)
        {
            var message = $"Are you sure you want to {action} the current {item}?";
            var caption = $"Please confirm {action}";
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                   == DialogResult.Yes;
        }

        /// <summary>
        /// Update items in the array for edit or add
        /// </summary>
        /// <param name="action"></param>
        /// <param name="actioned"></param>
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

        /// <summary>
        /// Dialogue box to open a file
        /// </summary>
        /// <returns></returns>
        private static (DialogResult result, string fileName) OpenFileDialogue()
        {
            const string filterLimits = "All files (*.*)|*.*|bin files (*.*)|*.bin";
            var openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = filterLimits,
                FilterIndex = 2,
                RestoreDirectory = true
            };
            var result = openFileDialog1.ShowDialog();
            return (result, openFileDialog1.FileName);
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

    } //class
} //namespace
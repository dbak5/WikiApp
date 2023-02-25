using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private const string StatusStripItemFound = "Item found";
        private const string StatusStripItemNotFound = "Item not found";
        private const string StatusStripErrorInteger = "Error! Please enter a valid integer";
        private const string StatusStripErrorNoValue = "Error! Please enter a value";
        private const string StatusStripErrorSelectItem = "Error! Please select an item from the list";
        private const string StatusStripUpdateSuccess = "Data successfully updated";
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
            // ADD CODE
        }

        private void ButtonBinarySearch_MouseClick(object sender, MouseEventArgs e)
        {
            BinarySearch();
            // ADD CODE
        }
        
        private void ButtonSort_MouseClick(object sender, MouseEventArgs e)
        {
            BubbleSort();
            // ADD CODE
        }
        #endregion

        #region Functions
        // 9.6 Write the code for a Bubble Sort method to sort the 2D array by Name ascending, ensure you use a separate swap method that passes the array element to be swapped (do not use any built-in array methods)
        /// <summary>
        /// Bubble sort function
        /// </summary>
        private void BubbleSort()
        {
            // ADD CODE
        }

        // 9.7 Write the code for a Binary Search for the Name in the 2D array and display the information in the other textboxes when found, add suitable feedback if the search in not successful and clear the search textbox (do not use any built-in array methods)
        /// <summary>
        /// Binary search function that would return a index
        /// </summary>
        /// <returns></returns>
        private int BinarySearch()
        {
            // ADD CODE
            return -1;
        }

        // 9.8 Create a display method that will show the following information in a ListView: Name and Category
        /// <summary>
        /// Display function
        /// </summary>
        private void Display()
        {
            // ADD CODE
        }

        // 9.9 Create a method so the user can select a definition (Name) from the ListView and all the information is displayed in the appropriate Textboxes
        /// <summary>
        /// Select function
        /// </summary>
        private void Select()
        {
            // ADD CODE
        }

        /// <summary>
        /// Update list box function
        /// </summary>
        private void UpdateList()
        {
            // ADD CODE
        }
        #endregion
    }
}
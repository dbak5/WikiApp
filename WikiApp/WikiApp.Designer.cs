﻿namespace WikiApp
{
    partial class WikiApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ListViewDataStructure = new System.Windows.Forms.ListView();
            this.ColumnNam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnCat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.ButtonClearTextBoxes = new System.Windows.Forms.Button();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.TextBoxCat = new System.Windows.Forms.TextBox();
            this.TextBoxStr = new System.Windows.Forms.TextBox();
            this.TextBoxDef = new System.Windows.Forms.TextBox();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.TextBoxNam = new System.Windows.Forms.TextBox();
            this.GroupChangeData = new System.Windows.Forms.GroupBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelDataStructure = new System.Windows.Forms.Label();
            this.labelDataCategory = new System.Windows.Forms.Label();
            this.labelDataName = new System.Windows.Forms.Label();
            this.GroupSearch = new System.Windows.Forms.GroupBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ButtonClearAll = new System.Windows.Forms.Button();
            this.StatusStrip.SuspendLayout();
            this.GroupChangeData.SuspendLayout();
            this.GroupSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.Location = new System.Drawing.Point(31, 27);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(130, 20);
            this.TextBoxSearch.TabIndex = 0;
            this.ToolTip.SetToolTip(this.TextBoxSearch, "Enter text to search for");
            this.TextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearch_KeyDown);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 405);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(771, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "Status";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ListViewDataStructure
            // 
            this.ListViewDataStructure.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnNam,
            this.ColumnCat});
            this.ListViewDataStructure.HideSelection = false;
            this.ListViewDataStructure.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.ListViewDataStructure.Location = new System.Drawing.Point(31, 74);
            this.ListViewDataStructure.Name = "ListViewDataStructure";
            this.ListViewDataStructure.Size = new System.Drawing.Size(235, 264);
            this.ListViewDataStructure.TabIndex = 2;
            this.ToolTip.SetToolTip(this.ListViewDataStructure, "View list of data structures");
            this.ListViewDataStructure.UseCompatibleStateImageBehavior = false;
            this.ListViewDataStructure.View = System.Windows.Forms.View.Details;
            this.ListViewDataStructure.SelectedIndexChanged += new System.EventHandler(this.ListViewSelect_MouseClick);
            this.ListViewDataStructure.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewDataStructure_MouseDoubleClick);
            // 
            // ColumnNam
            // 
            this.ColumnNam.Tag = "1";
            this.ColumnNam.Text = "Name";
            this.ColumnNam.Width = 100;
            // 
            // ColumnCat
            // 
            this.ColumnCat.Tag = "1";
            this.ColumnCat.Text = "Category";
            this.ColumnCat.Width = 100;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(275, 27);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 3;
            this.ButtonAdd.Text = "Add New Record";
            this.ToolTip.SetToolTip(this.ButtonAdd, "Add item to data");
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonAdd_MouseClick);
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Location = new System.Drawing.Point(544, 343);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(75, 23);
            this.ButtonLoad.TabIndex = 12;
            this.ButtonLoad.Text = "Load Data";
            this.ToolTip.SetToolTip(this.ButtonLoad, "Load data into the tables");
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonLoad_MouseClick);
            // 
            // ButtonClearTextBoxes
            // 
            this.ButtonClearTextBoxes.Location = new System.Drawing.Point(275, 164);
            this.ButtonClearTextBoxes.Name = "ButtonClearTextBoxes";
            this.ButtonClearTextBoxes.Size = new System.Drawing.Size(75, 23);
            this.ButtonClearTextBoxes.TabIndex = 6;
            this.ButtonClearTextBoxes.Text = "Clear Text";
            this.ToolTip.SetToolTip(this.ButtonClearTextBoxes, "Clear items from text boxes");
            this.ButtonClearTextBoxes.UseVisualStyleBackColor = true;
            this.ButtonClearTextBoxes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonClearTextBox_MouseClick);
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(191, 25);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 1;
            this.ButtonSearch.Text = "Search";
            this.ToolTip.SetToolTip(this.ButtonSearch, "Click to search for an item in the data");
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonSearch_MouseClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(275, 117);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(75, 23);
            this.ButtonDelete.TabIndex = 5;
            this.ButtonDelete.Text = "Delete Item";
            this.ToolTip.SetToolTip(this.ButtonDelete, "Delete item from data");
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonDelete_MouseClick);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(661, 343);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 13;
            this.ButtonSave.Text = "Save File";
            this.ToolTip.SetToolTip(this.ButtonSave, "Save data from tables into a file");
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonSave_MouseClick);
            // 
            // TextBoxCat
            // 
            this.TextBoxCat.Location = new System.Drawing.Point(101, 71);
            this.TextBoxCat.Name = "TextBoxCat";
            this.TextBoxCat.Size = new System.Drawing.Size(121, 20);
            this.TextBoxCat.TabIndex = 8;
            this.ToolTip.SetToolTip(this.TextBoxCat, "Data category, update to edit item");
            // 
            // TextBoxStr
            // 
            this.TextBoxStr.Location = new System.Drawing.Point(101, 115);
            this.TextBoxStr.Name = "TextBoxStr";
            this.TextBoxStr.Size = new System.Drawing.Size(121, 20);
            this.TextBoxStr.TabIndex = 9;
            this.ToolTip.SetToolTip(this.TextBoxStr, "Data structure, update to edit item");
            // 
            // TextBoxDef
            // 
            this.TextBoxDef.Location = new System.Drawing.Point(101, 162);
            this.TextBoxDef.Multiline = true;
            this.TextBoxDef.Name = "TextBoxDef";
            this.TextBoxDef.Size = new System.Drawing.Size(121, 100);
            this.TextBoxDef.TabIndex = 10;
            this.ToolTip.SetToolTip(this.TextBoxDef, "Data description, update to edit item");
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Location = new System.Drawing.Point(275, 73);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(75, 23);
            this.ButtonEdit.TabIndex = 4;
            this.ButtonEdit.Text = "Edit Item";
            this.ToolTip.SetToolTip(this.ButtonEdit, "Edit item in data");
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonEdit_MouseClick);
            // 
            // TextBoxNam
            // 
            this.TextBoxNam.Location = new System.Drawing.Point(101, 28);
            this.TextBoxNam.Name = "TextBoxNam";
            this.TextBoxNam.Size = new System.Drawing.Size(121, 20);
            this.TextBoxNam.TabIndex = 7;
            this.ToolTip.SetToolTip(this.TextBoxNam, "Data name, update to edit item");
            this.TextBoxNam.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxNam_MouseDoubleClick);
            // 
            // GroupChangeData
            // 
            this.GroupChangeData.Controls.Add(this.labelDescription);
            this.GroupChangeData.Controls.Add(this.labelDataStructure);
            this.GroupChangeData.Controls.Add(this.labelDataCategory);
            this.GroupChangeData.Controls.Add(this.labelDataName);
            this.GroupChangeData.Controls.Add(this.ButtonAdd);
            this.GroupChangeData.Controls.Add(this.TextBoxDef);
            this.GroupChangeData.Controls.Add(this.TextBoxNam);
            this.GroupChangeData.Controls.Add(this.TextBoxStr);
            this.GroupChangeData.Controls.Add(this.ButtonEdit);
            this.GroupChangeData.Controls.Add(this.TextBoxCat);
            this.GroupChangeData.Controls.Add(this.ButtonDelete);
            this.GroupChangeData.Controls.Add(this.ButtonClearTextBoxes);
            this.GroupChangeData.Location = new System.Drawing.Point(354, 28);
            this.GroupChangeData.Name = "GroupChangeData";
            this.GroupChangeData.Size = new System.Drawing.Size(382, 287);
            this.GroupChangeData.TabIndex = 17;
            this.GroupChangeData.TabStop = false;
            this.GroupChangeData.Text = "Change the data";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(16, 165);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(66, 13);
            this.labelDescription.TabIndex = 14;
            this.labelDescription.Text = "Descrtiption:";
            // 
            // labelDataStructure
            // 
            this.labelDataStructure.AutoSize = true;
            this.labelDataStructure.Location = new System.Drawing.Point(16, 118);
            this.labelDataStructure.Name = "labelDataStructure";
            this.labelDataStructure.Size = new System.Drawing.Size(77, 13);
            this.labelDataStructure.TabIndex = 13;
            this.labelDataStructure.Text = "Data structure:";
            // 
            // labelDataCategory
            // 
            this.labelDataCategory.AutoSize = true;
            this.labelDataCategory.Location = new System.Drawing.Point(16, 74);
            this.labelDataCategory.Name = "labelDataCategory";
            this.labelDataCategory.Size = new System.Drawing.Size(77, 13);
            this.labelDataCategory.TabIndex = 12;
            this.labelDataCategory.Text = "Data category:";
            // 
            // labelDataName
            // 
            this.labelDataName.AutoSize = true;
            this.labelDataName.Location = new System.Drawing.Point(16, 31);
            this.labelDataName.Name = "labelDataName";
            this.labelDataName.Size = new System.Drawing.Size(62, 13);
            this.labelDataName.TabIndex = 11;
            this.labelDataName.Text = "Data name:";
            // 
            // GroupSearch
            // 
            this.GroupSearch.Controls.Add(this.TextBoxSearch);
            this.GroupSearch.Controls.Add(this.ButtonSearch);
            this.GroupSearch.Controls.Add(this.ListViewDataStructure);
            this.GroupSearch.Location = new System.Drawing.Point(25, 28);
            this.GroupSearch.Name = "GroupSearch";
            this.GroupSearch.Size = new System.Drawing.Size(301, 361);
            this.GroupSearch.TabIndex = 18;
            this.GroupSearch.TabStop = false;
            this.GroupSearch.Text = "Search the data";
            // 
            // ButtonClearAll
            // 
            this.ButtonClearAll.Location = new System.Drawing.Point(354, 343);
            this.ButtonClearAll.Name = "ButtonClearAll";
            this.ButtonClearAll.Size = new System.Drawing.Size(75, 23);
            this.ButtonClearAll.TabIndex = 11;
            this.ButtonClearAll.Text = "Clear All Data";
            this.ToolTip.SetToolTip(this.ButtonClearAll, "Clear all data from the table");
            this.ButtonClearAll.UseVisualStyleBackColor = true;
            this.ButtonClearAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonClearAll_MouseClick);
            // 
            // WikiApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 427);
            this.Controls.Add(this.ButtonClearAll);
            this.Controls.Add(this.GroupSearch);
            this.Controls.Add(this.GroupChangeData);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonLoad);
            this.Controls.Add(this.StatusStrip);
            this.Name = "WikiApp";
            this.Text = "Data Structures Wiki";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WikiApp_FormClosing);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.GroupChangeData.ResumeLayout(false);
            this.GroupChangeData.PerformLayout();
            this.GroupSearch.ResumeLayout(false);
            this.GroupSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxSearch;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ListView ListViewDataStructure;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.ColumnHeader ColumnNam;
        private System.Windows.Forms.ColumnHeader ColumnCat;
        private System.Windows.Forms.Button ButtonClearTextBoxes;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.TextBox TextBoxCat;
        private System.Windows.Forms.TextBox TextBoxStr;
        private System.Windows.Forms.TextBox TextBoxDef;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.TextBox TextBoxNam;
        private System.Windows.Forms.GroupBox GroupChangeData;
        private System.Windows.Forms.GroupBox GroupSearch;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button ButtonClearAll;
        private System.Windows.Forms.Label labelDataName;
        private System.Windows.Forms.Label labelDataCategory;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelDataStructure;
    }
}


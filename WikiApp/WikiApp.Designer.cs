namespace WikiApp
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
            this.ColumnStr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnDef = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.TextBoxCat = new System.Windows.Forms.TextBox();
            this.TextBoxStr = new System.Windows.Forms.TextBox();
            this.TextBoxDef = new System.Windows.Forms.TextBox();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.TextBoxNam = new System.Windows.Forms.TextBox();
            this.GroupChangeData = new System.Windows.Forms.GroupBox();
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
            this.TextBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            this.TextBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSearch_KeyPress);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 382);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(789, 22);
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
            this.ColumnCat,
            this.ColumnStr,
            this.ColumnDef});
            this.ListViewDataStructure.HideSelection = false;
            this.ListViewDataStructure.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.ListViewDataStructure.Location = new System.Drawing.Point(31, 74);
            this.ListViewDataStructure.Name = "ListViewDataStructure";
            this.ListViewDataStructure.Size = new System.Drawing.Size(243, 202);
            this.ListViewDataStructure.TabIndex = 2;
            this.ToolTip.SetToolTip(this.ListViewDataStructure, "View list of data structures");
            this.ListViewDataStructure.UseCompatibleStateImageBehavior = false;
            this.ListViewDataStructure.View = System.Windows.Forms.View.Details;
            this.ListViewDataStructure.SelectedIndexChanged += new System.EventHandler(this.ListViewSelect_MouseClick);
            // 
            // ColumnNam
            // 
            this.ColumnNam.Text = "Name";
            this.ColumnNam.Width = 48;
            // 
            // ColumnCat
            // 
            this.ColumnCat.Text = "Category";
            // 
            // ColumnStr
            // 
            this.ColumnStr.Text = "Structure";
            // 
            // ColumnDef
            // 
            this.ColumnDef.Text = "Definition";
            this.ColumnDef.Width = 101;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(17, 27);
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
            this.ButtonLoad.Location = new System.Drawing.Point(544, 344);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(75, 23);
            this.ButtonLoad.TabIndex = 5;
            this.ButtonLoad.Text = "Load Data";
            this.ToolTip.SetToolTip(this.ButtonLoad, "Load data into the tables");
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonLoad_MouseClick);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(307, 27);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 23);
            this.ButtonClear.TabIndex = 6;
            this.ButtonClear.Text = "ClearTextBoxes";
            this.ToolTip.SetToolTip(this.ButtonClear, "Clear items from text boxes");
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonClear_MouseClick);
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(199, 27);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 9;
            this.ButtonSearch.Text = "Search";
            this.ToolTip.SetToolTip(this.ButtonSearch, "Click to search for an item in the data");
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonSearch_MouseClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(214, 27);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(75, 23);
            this.ButtonDelete.TabIndex = 10;
            this.ButtonDelete.Text = "Delete Item";
            this.ToolTip.SetToolTip(this.ButtonDelete, "Delete item from data");
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonDelete_MouseClick);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(661, 344);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 11;
            this.ButtonSave.Text = "Save File";
            this.ToolTip.SetToolTip(this.ButtonSave, "Save data from tables into a file");
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonSave_MouseClick);
            // 
            // TextBoxCat
            // 
            this.TextBoxCat.Location = new System.Drawing.Point(27, 131);
            this.TextBoxCat.Name = "TextBoxCat";
            this.TextBoxCat.Size = new System.Drawing.Size(100, 20);
            this.TextBoxCat.TabIndex = 12;
            this.ToolTip.SetToolTip(this.TextBoxCat, "Data category, update to edit item");
            this.TextBoxCat.TextChanged += new System.EventHandler(this.TextBoxCat_TextChanged);
            this.TextBoxCat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxCat_KeyPress);
            // 
            // TextBoxStr
            // 
            this.TextBoxStr.Location = new System.Drawing.Point(27, 173);
            this.TextBoxStr.Name = "TextBoxStr";
            this.TextBoxStr.Size = new System.Drawing.Size(100, 20);
            this.TextBoxStr.TabIndex = 13;
            this.ToolTip.SetToolTip(this.TextBoxStr, "Data structure, update to edit item");
            this.TextBoxStr.TextChanged += new System.EventHandler(this.TextBoxStr_TextChanged);
            this.TextBoxStr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxStr_KeyPress);
            // 
            // TextBoxDef
            // 
            this.TextBoxDef.Location = new System.Drawing.Point(156, 87);
            this.TextBoxDef.Multiline = true;
            this.TextBoxDef.Name = "TextBoxDef";
            this.TextBoxDef.Size = new System.Drawing.Size(226, 189);
            this.TextBoxDef.TabIndex = 14;
            this.ToolTip.SetToolTip(this.TextBoxDef, "Data description, update to edit item");
            this.TextBoxDef.TextChanged += new System.EventHandler(this.TextBoxDef_TextChanged);
            this.TextBoxDef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDef_KeyPress);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Location = new System.Drawing.Point(116, 27);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(75, 23);
            this.ButtonEdit.TabIndex = 15;
            this.ButtonEdit.Text = "Edit Item";
            this.ToolTip.SetToolTip(this.ButtonEdit, "Edit item in data");
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonEdit_MouseClick);
            // 
            // TextBoxNam
            // 
            this.TextBoxNam.Location = new System.Drawing.Point(27, 87);
            this.TextBoxNam.Name = "TextBoxNam";
            this.TextBoxNam.Size = new System.Drawing.Size(100, 20);
            this.TextBoxNam.TabIndex = 16;
            this.ToolTip.SetToolTip(this.TextBoxNam, "Data name, update to edit item");
            this.TextBoxNam.TextChanged += new System.EventHandler(this.TextBoxNam_TextChanged);
            this.TextBoxNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxNam_KeyPress);
            // 
            // GroupChangeData
            // 
            this.GroupChangeData.Controls.Add(this.ButtonAdd);
            this.GroupChangeData.Controls.Add(this.TextBoxDef);
            this.GroupChangeData.Controls.Add(this.TextBoxNam);
            this.GroupChangeData.Controls.Add(this.TextBoxStr);
            this.GroupChangeData.Controls.Add(this.ButtonEdit);
            this.GroupChangeData.Controls.Add(this.TextBoxCat);
            this.GroupChangeData.Controls.Add(this.ButtonDelete);
            this.GroupChangeData.Controls.Add(this.ButtonClear);
            this.GroupChangeData.Location = new System.Drawing.Point(354, 28);
            this.GroupChangeData.Name = "GroupChangeData";
            this.GroupChangeData.Size = new System.Drawing.Size(411, 301);
            this.GroupChangeData.TabIndex = 17;
            this.GroupChangeData.TabStop = false;
            this.GroupChangeData.Text = "Change the data";
            // 
            // GroupSearch
            // 
            this.GroupSearch.Controls.Add(this.TextBoxSearch);
            this.GroupSearch.Controls.Add(this.ButtonSearch);
            this.GroupSearch.Controls.Add(this.ListViewDataStructure);
            this.GroupSearch.Location = new System.Drawing.Point(25, 28);
            this.GroupSearch.Name = "GroupSearch";
            this.GroupSearch.Size = new System.Drawing.Size(301, 301);
            this.GroupSearch.TabIndex = 18;
            this.GroupSearch.TabStop = false;
            this.GroupSearch.Text = "Search";
            // 
            // ButtonClearAll
            // 
            this.ButtonClearAll.Location = new System.Drawing.Point(354, 344);
            this.ButtonClearAll.Name = "ButtonClearAll";
            this.ButtonClearAll.Size = new System.Drawing.Size(75, 23);
            this.ButtonClearAll.TabIndex = 19;
            this.ButtonClearAll.Text = "Clear All Data";
            this.ButtonClearAll.UseVisualStyleBackColor = true;
            this.ButtonClearAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonClearAll_MouseClick);
            // 
            // WikiApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 404);
            this.Controls.Add(this.ButtonClearAll);
            this.Controls.Add(this.GroupSearch);
            this.Controls.Add(this.GroupChangeData);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonLoad);
            this.Controls.Add(this.StatusStrip);
            this.Name = "WikiApp";
            this.Text = "Data Structures Wiki";
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
        private System.Windows.Forms.ColumnHeader ColumnStr;
        private System.Windows.Forms.ColumnHeader ColumnDef;
        private System.Windows.Forms.Button ButtonClear;
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
    }
}


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
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("");
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.TextBoxCat = new System.Windows.Forms.TextBox();
            this.TextBoxStr = new System.Windows.Forms.TextBox();
            this.TextBoxDef = new System.Windows.Forms.TextBox();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.TextBoxNam = new System.Windows.Forms.TextBox();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.Location = new System.Drawing.Point(89, 51);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(100, 20);
            this.TextBoxSearch.TabIndex = 0;
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 428);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(800, 22);
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
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20});
            this.ListViewDataStructure.Location = new System.Drawing.Point(355, 103);
            this.ListViewDataStructure.Name = "ListViewDataStructure";
            this.ListViewDataStructure.Size = new System.Drawing.Size(362, 226);
            this.ListViewDataStructure.TabIndex = 2;
            this.ListViewDataStructure.UseCompatibleStateImageBehavior = false;
            this.ListViewDataStructure.View = System.Windows.Forms.View.Details;
            this.ListViewDataStructure.SelectedIndexChanged += new System.EventHandler(this.ListViewDataStructure_MouseClick);
            // 
            // ColumnNam
            // 
            this.ColumnNam.Text = "Name";
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
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(240, 189);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 3;
            this.ButtonAdd.Text = "Add New Record";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonAdd_MouseClick);
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Location = new System.Drawing.Point(374, 51);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(75, 23);
            this.ButtonLoad.TabIndex = 5;
            this.ButtonLoad.Text = "Load Data";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonLoad_MouseClick);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(240, 237);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 23);
            this.ButtonClear.TabIndex = 6;
            this.ButtonClear.Text = "ClearTextBoxes";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonClear_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(240, 51);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 9;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonBinarySearch_MouseClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(240, 147);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(75, 23);
            this.ButtonDelete.TabIndex = 10;
            this.ButtonDelete.Text = "Delete Item";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonDelete_MouseClick);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(631, 382);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 11;
            this.ButtonSave.Text = "Save File";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonSave_MouseClick);
            // 
            // TextBoxCat
            // 
            this.TextBoxCat.Location = new System.Drawing.Point(89, 176);
            this.TextBoxCat.Name = "TextBoxCat";
            this.TextBoxCat.Size = new System.Drawing.Size(100, 20);
            this.TextBoxCat.TabIndex = 12;
            this.TextBoxCat.TextChanged += new System.EventHandler(this.TextBoxCat_TextChanged);
            // 
            // TextBoxStr
            // 
            this.TextBoxStr.Location = new System.Drawing.Point(89, 240);
            this.TextBoxStr.Name = "TextBoxStr";
            this.TextBoxStr.Size = new System.Drawing.Size(100, 20);
            this.TextBoxStr.TabIndex = 13;
            this.TextBoxStr.TextChanged += new System.EventHandler(this.TextBoxStr_TextChanged);
            // 
            // TextBoxDef
            // 
            this.TextBoxDef.Location = new System.Drawing.Point(89, 276);
            this.TextBoxDef.Name = "TextBoxDef";
            this.TextBoxDef.Size = new System.Drawing.Size(100, 20);
            this.TextBoxDef.TabIndex = 14;
            this.TextBoxDef.TextChanged += new System.EventHandler(this.TextBoxDef_TextChanged);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Location = new System.Drawing.Point(240, 103);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(75, 23);
            this.ButtonEdit.TabIndex = 15;
            this.ButtonEdit.Text = "Edit Item";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonEdit_MouseClick);
            // 
            // TextBoxNam
            // 
            this.TextBoxNam.Location = new System.Drawing.Point(89, 124);
            this.TextBoxNam.Name = "TextBoxNam";
            this.TextBoxNam.Size = new System.Drawing.Size(100, 20);
            this.TextBoxNam.TabIndex = 16;
            this.TextBoxNam.TextChanged += new System.EventHandler(this.TextBoxNam_TextChanged);
            // 
            // WikiApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TextBoxNam);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.TextBoxDef);
            this.Controls.Add(this.TextBoxStr);
            this.Controls.Add(this.TextBoxCat);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonLoad);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ListViewDataStructure);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.TextBoxSearch);
            this.Name = "WikiApp";
            this.Text = "Data Structures Wiki";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.TextBox TextBoxCat;
        private System.Windows.Forms.TextBox TextBoxStr;
        private System.Windows.Forms.TextBox TextBoxDef;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.TextBox TextBoxNam;
    }
}


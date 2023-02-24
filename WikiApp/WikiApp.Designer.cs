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
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("");
            this.TextboxSearch = new System.Windows.Forms.TextBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ListViewDataStructure = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonSort = new System.Windows.Forms.Button();
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextboxSearch
            // 
            this.TextboxSearch.Location = new System.Drawing.Point(470, 39);
            this.TextboxSearch.Name = "TextboxSearch";
            this.TextboxSearch.Size = new System.Drawing.Size(100, 20);
            this.TextboxSearch.TabIndex = 0;
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
            // ListViewDataStructure
            // 
            this.ListViewDataStructure.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.ListViewDataStructure.HideSelection = false;
            this.ListViewDataStructure.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.ListViewDataStructure.Location = new System.Drawing.Point(355, 103);
            this.ListViewDataStructure.Name = "ListViewDataStructure";
            this.ListViewDataStructure.Size = new System.Drawing.Size(362, 226);
            this.ListViewDataStructure.TabIndex = 2;
            this.ListViewDataStructure.UseCompatibleStateImageBehavior = false;
            this.ListViewDataStructure.View = System.Windows.Forms.View.Details;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(90, 39);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 3;
            this.ButtonAdd.Text = "Add New Record";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonAdd_MouseClick);
            // 
            // ButtonSort
            // 
            this.ButtonSort.Location = new System.Drawing.Point(89, 103);
            this.ButtonSort.Name = "ButtonSort";
            this.ButtonSort.Size = new System.Drawing.Size(75, 23);
            this.ButtonSort.TabIndex = 4;
            this.ButtonSort.Text = "Sort Data";
            this.ButtonSort.UseVisualStyleBackColor = true;
            this.ButtonSort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonSort_MouseClick);
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Location = new System.Drawing.Point(130, 155);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(75, 23);
            this.ButtonLoad.TabIndex = 5;
            this.ButtonLoad.Text = "Load Data";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonLoad_MouseClick);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(130, 236);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 23);
            this.ButtonClear.TabIndex = 6;
            this.ButtonClear.Text = "Clear Data";
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
            this.ButtonSearch.Location = new System.Drawing.Point(268, 58);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 9;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonBinarySearch_MouseClick);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // WikiApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonLoad);
            this.Controls.Add(this.ButtonSort);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ListViewDataStructure);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.TextboxSearch);
            this.Name = "WikiApp";
            this.Text = "Data Structures Wiki";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextboxSearch;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ListView ListViewDataStructure;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonSort;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
    }
}


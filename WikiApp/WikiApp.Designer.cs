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
            this.TextboxSearch = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.StatusStrip();
            this.ListViewDataStructure = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // TextboxSearch
            // 
            this.TextboxSearch.Location = new System.Drawing.Point(137, 173);
            this.TextboxSearch.Name = "TextboxSearch";
            this.TextboxSearch.Size = new System.Drawing.Size(100, 20);
            this.TextboxSearch.TabIndex = 0;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Location = new System.Drawing.Point(0, 428);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(800, 22);
            this.StatusLabel.TabIndex = 1;
            this.StatusLabel.Text = "Status";
            // 
            // ListViewDataStructure
            // 
            this.ListViewDataStructure.HideSelection = false;
            this.ListViewDataStructure.Location = new System.Drawing.Point(355, 156);
            this.ListViewDataStructure.Name = "ListViewDataStructure";
            this.ListViewDataStructure.Size = new System.Drawing.Size(121, 97);
            this.ListViewDataStructure.TabIndex = 2;
            this.ListViewDataStructure.UseCompatibleStateImageBehavior = false;
            // 
            // WikiApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListViewDataStructure);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.TextboxSearch);
            this.Name = "WikiApp";
            this.Text = "Data Structures Wiki";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextboxSearch;
        private System.Windows.Forms.StatusStrip StatusLabel;
        private System.Windows.Forms.ListView ListViewDataStructure;
    }
}


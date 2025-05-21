namespace Kurs
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            treeView1 = new TreeView();
            addRootBtn = new Button();
            propertyGrid = new PropertyGrid();
            addChildBtn = new Button();
            topBtn = new Button();
            bottomBtn = new Button();
            delBtn = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(18, 39);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(330, 426);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // addRootBtn
            // 
            addRootBtn.Location = new Point(18, 471);
            addRootBtn.Name = "addRootBtn";
            addRootBtn.Size = new Size(162, 48);
            addRootBtn.TabIndex = 1;
            addRootBtn.Text = "Добавить группу";
            addRootBtn.UseVisualStyleBackColor = true;
            addRootBtn.Click += addRootBtn_Click;
            // 
            // propertyGrid
            // 
            propertyGrid.Location = new Point(423, 39);
            propertyGrid.Name = "propertyGrid";
            propertyGrid.Size = new Size(330, 480);
            propertyGrid.TabIndex = 2;
            // 
            // addChildBtn
            // 
            addChildBtn.Location = new Point(186, 471);
            addChildBtn.Name = "addChildBtn";
            addChildBtn.Size = new Size(162, 48);
            addChildBtn.TabIndex = 3;
            addChildBtn.Text = "Добавить сотрудника";
            addChildBtn.UseVisualStyleBackColor = true;
            addChildBtn.Click += addChildBtn_Click;
            // 
            // topBtn
            // 
            topBtn.Location = new Point(354, 39);
            topBtn.Name = "topBtn";
            topBtn.Size = new Size(35, 35);
            topBtn.TabIndex = 4;
            topBtn.Text = "↑";
            topBtn.UseVisualStyleBackColor = true;
            topBtn.Click += topBtn_Click;
            // 
            // bottomBtn
            // 
            bottomBtn.Location = new Point(354, 80);
            bottomBtn.Name = "bottomBtn";
            bottomBtn.Size = new Size(35, 35);
            bottomBtn.TabIndex = 5;
            bottomBtn.Text = "↓";
            bottomBtn.UseVisualStyleBackColor = true;
            bottomBtn.Click += bottomBtn_Click;
            // 
            // delBtn
            // 
            delBtn.Location = new Point(354, 171);
            delBtn.Name = "delBtn";
            delBtn.Size = new Size(35, 35);
            delBtn.TabIndex = 6;
            delBtn.Text = "❌";
            delBtn.UseVisualStyleBackColor = true;
            delBtn.Click += delBtn_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(765, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click_1;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(180, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "JSON files (*.json)|*.json";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "JSON files (*.json)|*.json";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 533);
            Controls.Add(delBtn);
            Controls.Add(bottomBtn);
            Controls.Add(topBtn);
            Controls.Add(addChildBtn);
            Controls.Add(propertyGrid);
            Controls.Add(addRootBtn);
            Controls.Add(treeView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Иерархическая структура";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Button addRootBtn;
        private PropertyGrid propertyGrid;
        private Button addChildBtn;
        private Button topBtn;
        private Button bottomBtn;
        private Button delBtn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
    }
}

namespace WindowsFormsApp1
{
    partial class ToDoList
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
            this.addBtn = new System.Windows.Forms.Button();
            this.newTaskNameTextBox = new System.Windows.Forms.TextBox();
            this.newTaskDueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.unfinishTaskListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.editBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.finishTaskListView = new System.Windows.Forms.ListView();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.setCompleteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(31, 153);
            this.addBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(60, 23);
            this.addBtn.TabIndex = 0;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // newTaskNameTextBox
            // 
            this.newTaskNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.newTaskNameTextBox.Location = new System.Drawing.Point(87, 60);
            this.newTaskNameTextBox.Name = "newTaskNameTextBox";
            this.newTaskNameTextBox.Size = new System.Drawing.Size(364, 20);
            this.newTaskNameTextBox.TabIndex = 1;
            // 
            // newTaskDueDatePicker
            // 
            this.newTaskDueDatePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.newTaskDueDatePicker.Location = new System.Drawing.Point(87, 95);
            this.newTaskDueDatePicker.Name = "newTaskDueDatePicker";
            this.newTaskDueDatePicker.Size = new System.Drawing.Size(364, 20);
            this.newTaskDueDatePicker.TabIndex = 2;
            // 
            // unfinishTaskListView
            // 
            this.unfinishTaskListView.HideSelection = false;
            this.unfinishTaskListView.Location = new System.Drawing.Point(31, 183);
            this.unfinishTaskListView.Margin = new System.Windows.Forms.Padding(5);
            this.unfinishTaskListView.MultiSelect = false;
            this.unfinishTaskListView.Name = "unfinishTaskListView";
            this.unfinishTaskListView.Size = new System.Drawing.Size(420, 176);
            this.unfinishTaskListView.TabIndex = 3;
            this.unfinishTaskListView.UseCompatibleStateImageBehavior = false;
            this.unfinishTaskListView.SelectedIndexChanged += new System.EventHandler(this.unfinishedTaskListView_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Task:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Due Date:";
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(95, 153);
            this.editBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(60, 23);
            this.editBtn.TabIndex = 6;
            this.editBtn.Text = "Edit";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(159, 153);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(60, 23);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // finishTaskListView
            // 
            this.finishTaskListView.HideSelection = false;
            this.finishTaskListView.Location = new System.Drawing.Point(31, 369);
            this.finishTaskListView.Margin = new System.Windows.Forms.Padding(5);
            this.finishTaskListView.MultiSelect = false;
            this.finishTaskListView.Name = "finishTaskListView";
            this.finishTaskListView.Size = new System.Drawing.Size(420, 157);
            this.finishTaskListView.TabIndex = 9;
            this.finishTaskListView.UseCompatibleStateImageBehavior = false;
            this.finishTaskListView.SelectedIndexChanged += new System.EventHandler(this.finishTaskListView_SelectedIndexChanged);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(223, 153);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(60, 23);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // setCompleteBtn
            // 
            this.setCompleteBtn.Location = new System.Drawing.Point(287, 153);
            this.setCompleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.setCompleteBtn.Name = "setCompleteBtn";
            this.setCompleteBtn.Size = new System.Drawing.Size(164, 23);
            this.setCompleteBtn.TabIndex = 11;
            this.setCompleteBtn.Text = "Set Complete/Incomplete";
            this.setCompleteBtn.UseVisualStyleBackColor = true;
            this.setCompleteBtn.Click += new System.EventHandler(this.setCompleteBtn_Click);
            // 
            // ToDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Controls.Add(this.setCompleteBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.finishTaskListView);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unfinishTaskListView);
            this.Controls.Add(this.newTaskDueDatePicker);
            this.Controls.Add(this.newTaskNameTextBox);
            this.Controls.Add(this.addBtn);
            this.Name = "ToDoList";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.Text = "To Do List";
            this.Load += new System.EventHandler(this.ToDoList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox newTaskNameTextBox;
        private System.Windows.Forms.DateTimePicker newTaskDueDatePicker;
        private System.Windows.Forms.ListView unfinishTaskListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ListView finishTaskListView;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button setCompleteBtn;
    }
}


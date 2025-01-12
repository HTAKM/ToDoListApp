using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class ToDoList : Form
    {
        public ToDoList() => InitializeComponent();

        DataSet ds = new DataSet();
        DataTable taskList = new DataTable();
        string taskDataFile = "taskList.xml";
        bool isEditing = false;
        int nextID = -1;
        int selectedID = -1;
        private void ToDoList_Load(object sender, EventArgs e)
        {
            taskList.Columns.Add("ID", typeof(int));
            taskList.Columns.Add("TaskName", typeof(string));
            taskList.Columns.Add("DueDate", typeof(string));
            taskList.Columns.Add("completeStatus", typeof(bool));
            ds.Tables.Add(taskList);
            if (File.Exists(taskDataFile))
            {
                using (StreamReader sr = new StreamReader(taskDataFile))
                {
                    ds.ReadXml(sr);
                }
                taskList = ds.Tables[0];
            }

            InitializeList();

            unfinishTaskListView.Columns.Add("ID", unfinishTaskListView.Width / 8 - 2, HorizontalAlignment.Left);
            unfinishTaskListView.Columns.Add("Task Name", unfinishTaskListView.Width * 5 / 8 - 2, HorizontalAlignment.Left);
            unfinishTaskListView.Columns.Add("Due Date", -2, HorizontalAlignment.Center);
            finishTaskListView.Columns.Add("ID", finishTaskListView.Width / 8 - 2, HorizontalAlignment.Left);
            finishTaskListView.Columns.Add("Task Name", finishTaskListView.Width * 5 / 8 - 2, HorizontalAlignment.Left);
            finishTaskListView.Columns.Add("Due Date", -2, HorizontalAlignment.Center);
            reloadListView();
        }

        private void InitializeList()
        {
            unfinishTaskListView.GridLines = true;
            unfinishTaskListView.AllowColumnReorder = true;
            unfinishTaskListView.LabelEdit = true;
            unfinishTaskListView.FullRowSelect = true;
            unfinishTaskListView.Sorting = SortOrder.Ascending;
            unfinishTaskListView.View = View.Details;
            finishTaskListView.GridLines = true;
            finishTaskListView.AllowColumnReorder = true;
            finishTaskListView.LabelEdit = true;
            finishTaskListView.FullRowSelect = true;
            finishTaskListView.Sorting = SortOrder.Ascending;
            finishTaskListView.View = View.Details;
        }

        private void unfinishedTaskListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (finishTaskListView.SelectedIndices.Count > 0)
            {
                finishTaskListView.Items[finishTaskListView.SelectedIndices[0]].Selected = false;
            }
            unEdit();
        }

        private void finishTaskListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (unfinishTaskListView.SelectedIndices.Count > 0)
            {
                unfinishTaskListView.Items[unfinishTaskListView.SelectedIndices[0]].Selected = false;
            }
            unEdit();
        }

        private void writeToFile()
        {
            if (File.Exists(taskDataFile))
            {
                using (StreamWriter fs = new StreamWriter(taskDataFile))
                {
                    ds.WriteXml(fs);
                }
            }
            else
            {
                int metaIdx = 0;
                XDocument xdoc = new XDocument(
                    new XElement(taskList.TableName,
                        from column in taskList.Columns.Cast<DataColumn>()
                        where column != taskList.Columns[metaIdx]
                        select new XElement(column.ColumnName,
                            from row in taskList.AsEnumerable()
                            select new XElement("Task" + row[metaIdx].ToString(), row[column])
                            )
                        )
                    );
                xdoc.Save(taskDataFile);
            }
        }

        private void reloadListView()
        {
            unfinishTaskListView.Items.Clear();
            finishTaskListView.Items.Clear();
            nextID = -1;
            foreach (DataRow row in taskList.Rows)
            {
                if (int.Parse(row[0].ToString()) > nextID)
                {
                    nextID = int.Parse(row[0].ToString());
                }
                ListViewItem item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row[1].ToString());
                item.SubItems.Add(row[2].ToString());
                if (bool.Parse(row[taskList.Columns.Count - 1].ToString()))
                {
                    finishTaskListView.Items.Add(item);
                }
                else
                {
                    unfinishTaskListView.Items.Add(item);
                }
            }
            nextID++;
        }

        private void unEdit()
        {
            isEditing = false;
            selectedID = -1;
            newTaskNameTextBox.Text = string.Empty;
            newTaskDueDatePicker.Value = DateTime.Today;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newTaskNameTextBox.Text))
            {
                MessageBox.Show("Please provide a name for the new task.");
                return;
            }
            DataRow newTask = taskList.NewRow();
            newTask[0] = nextID;
            newTask[1] = newTaskNameTextBox.Text;
            newTask[2] = newTaskDueDatePicker.Value.ToShortDateString();
            newTask[3] = false;
            taskList.Rows.Add(newTask);
            nextID++;
            ListViewItem item = new ListViewItem(newTask[0].ToString());
            item.Checked = false;
            for (int i = 1; i < taskList.Columns.Count; i++)
            {
                item.SubItems.Add(newTask[i].ToString());
            }
            unfinishTaskListView.Items.Add(item);
            newTaskNameTextBox.Text = string.Empty;
            newTaskDueDatePicker.Value = DateTime.Today;
            writeToFile();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            ListViewItem selectedRow;
            if (unfinishTaskListView.SelectedIndices.Count > 0)
            {
                selectedRow = unfinishTaskListView.SelectedItems[0];
                selectedID = int.Parse(selectedRow.SubItems[0].Text);
                newTaskNameTextBox.Text = selectedRow.SubItems[1].Text;
                newTaskDueDatePicker.Value = DateTime.Parse(selectedRow.SubItems[2].Text);
                isEditing = true;
            }
            else if (finishTaskListView.SelectedIndices.Count > 0)
            {
                selectedRow = finishTaskListView.SelectedItems[0];
                selectedID = int.Parse(selectedRow.SubItems[0].Text);
                newTaskNameTextBox.Text = selectedRow.SubItems[1].Text;
                newTaskDueDatePicker.Value = DateTime.Parse(selectedRow.SubItems[2].Text);
                isEditing = true;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                foreach (DataRow row in taskList.Rows)
                {
                    if (int.Parse(row[0].ToString()) == selectedID)
                    {
                        row[1] = newTaskNameTextBox.Text;
                        row[2] = newTaskDueDatePicker.Value.ToShortDateString();
                    }
                }
                writeToFile();
                reloadListView();
                unEdit();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int deleteID;
            if (unfinishTaskListView.SelectedIndices.Count > 0)
            {
                deleteID = int.Parse(unfinishTaskListView.SelectedItems[0].SubItems[0].Text);
                for (int i = 0; i < taskList.Rows.Count; i++)
                {
                    DataRow dr = taskList.Rows[i];
                    if (int.Parse(dr[0].ToString()) == deleteID)
                    {
                        taskList.Rows.Remove(dr);
                    }
                }
                foreach (DataRow dr in taskList.Rows)
                {
                    if (int.Parse(dr[0].ToString()) > deleteID)
                    {
                        dr[0] = int.Parse(dr[0].ToString()) - 1;
                    }
                }
                writeToFile();
                reloadListView();
                unEdit();
            }
            else if (finishTaskListView.SelectedIndices.Count > 0)
            {
                deleteID = int.Parse(finishTaskListView.SelectedItems[0].SubItems[0].Text);
                for (int i = 0; i < taskList.Rows.Count; i++)
                {
                    DataRow dr = taskList.Rows[i];
                    if (int.Parse(dr[0].ToString()) == deleteID)
                    {
                        taskList.Rows.Remove(dr);
                    }
                }
                foreach (DataRow dr in taskList.Rows)
                {
                    if (int.Parse(dr[0].ToString()) > deleteID)
                    {
                        dr[0] = int.Parse(dr[0].ToString()) - 1;
                    }
                }
                writeToFile();
                reloadListView();
                unEdit();
            }
        }

        private void setCompleteBtn_Click(object sender, EventArgs e)
        {
            ListViewItem selectedRow;
            if (unfinishTaskListView.SelectedIndices.Count > 0)
            {
                selectedRow = unfinishTaskListView.SelectedItems[0];
                selectedID = int.Parse(selectedRow.SubItems[0].Text);
                foreach (DataRow row in taskList.Rows)
                {
                    if (int.Parse(row[0].ToString()) == selectedID)
                    {
                        row[3] = true;
                    }
                }
                writeToFile();
                reloadListView();
            }
            else if (finishTaskListView.SelectedIndices.Count > 0)
            {
                selectedRow = finishTaskListView.SelectedItems[0];
                selectedID = int.Parse(selectedRow.SubItems[0].Text);
                foreach (DataRow row in taskList.Rows)
                {
                    if (int.Parse(row[0].ToString()) == selectedID)
                    {
                        row[3] = false;
                    }
                }
                writeToFile();
                reloadListView();
            }
        }
    }
}

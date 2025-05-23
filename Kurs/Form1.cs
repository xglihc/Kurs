using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Text.Json;
using System.Xml.Serialization;
using System.Reflection;

namespace Kurs
{
    public partial class Form1 : Form
    {
        private string currentFilePath = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadJsonIntoTreeView(string jsonData)
        {
            JsonDocument document = JsonDocument.Parse(jsonData);

            JsonElement root = document.RootElement;

            foreach (JsonElement element in root.EnumerateArray())
            {
                AddNodeFromJsonElement(element, treeView1.Nodes);
            }
        }

        private void AddNodeFromJsonElement(JsonElement element, TreeNodeCollection parentNodes)
        {
            string name = element.GetProperty("name").GetString();
            string type = element.GetProperty("type").GetString();

            TreeNode node = new TreeNode(name);

            switch (type)
            {
                case "Kurs.Group":
                    Group group = new Group
                    (
                        element.GetProperty("GName").GetString(),
                        element.GetProperty("Head").GetString()
                    );
                    node.Tag = group;
                    break;
                case "Kurs.Person":
                    Person person = new Person
                    (
                        element.GetProperty("FullName").GetString(),
                        DateTime.Parse(element.GetProperty("BirthDate").GetString()),
                        element.GetProperty("Email").GetString(),
                        element.GetProperty("JobTitle").GetString(),
                        element.GetProperty("LaborContractNumber").GetString(),
                        element.GetProperty("Schedule").GetString(),
                        Decimal.Parse(element.GetProperty("Salary").GetString())
                    );
                    node.Tag = person;
                    break;
            }

            parentNodes.Add(node);

            if (element.TryGetProperty("nodes", out JsonElement children))
            {
                foreach (JsonElement child in children.EnumerateArray())
                {
                    AddNodeFromJsonElement(child, node.Nodes);
                }
            }
        }



        private string RecursionSaving(TreeNode node)
        {
            string body = "{";
            body += "\"name\": \"" + node.Text + "\",";
            Type tagType = node.Tag.GetType();
            body += "\"type\": \"" + tagType.ToString() + "\",";

            if (node.Tag is Kurs.Group groupInstance)
            {
                body += "\"GName\": \"" + groupInstance.GName + "\",";
                body += "\"Head\": \"" + groupInstance.Head + "\",";
            }
            else if (node.Tag is Kurs.Person personInstance)
            {
                body += "\"FullName\": \"" + personInstance.FullName + "\",";
                body += "\"BirthDate\": \"" + personInstance.BirthDate.ToString("yyyy-MM-dd HH:mm:ss") + "\",";
                body += "\"Email\": \"" + personInstance.Email + "\",";
                body += "\"JobTitle\": \"" + personInstance.JobTitle + "\",";
                body += "\"LaborContractNumber\": \"" + personInstance.LaborContractNumber + "\",";
                body += "\"Schedule\": \"" + personInstance.Schedule + "\",";
                body += "\"Salary\": \"" + personInstance.Salary.ToString() + "\",";
            }

            body += "\"nodes\": [";
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode node1 in node.Nodes)
                {
                    body += RecursionSaving(node1);
                }

                body = body[..^1];
            }

            body += "]";

            body += "},";
            return body;

        }
        private void SaveToJSON(string path)
        {
            string body = "[";
            if (treeView1.Nodes.Count > 0)
            {
                foreach (TreeNode node in treeView1.Nodes)
                {
                    body += RecursionSaving(node);
                }
            }
            body = body[..^1];
            body += "]";
            File.WriteAllText(path, body);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    treeView1.Nodes.Clear();
                    string jsonContent = File.ReadAllText(openFileDialog1.FileName);
                    LoadJsonIntoTreeView(jsonContent);
                    currentFilePath = openFileDialog1.FileName;
                    MessageBox.Show("Файл успешно открыт.", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при открытии файла:\n {ex.Message}", "Ошибка");
                }
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFilePath != null && !string.IsNullOrWhiteSpace(currentFilePath))
            {
                SaveToJSON(currentFilePath);
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SaveToJSON(saveFileDialog1.FileName);
                    currentFilePath = saveFileDialog1.FileName;
                    MessageBox.Show("Экспорт успешно выполнен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при экспорте: {ex.Message}");
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addRootBtn_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null || treeView1.SelectedNode.Tag is Group group)
            {
                TreeNode selectedNode = treeView1.SelectedNode;
                string result = Interaction.InputBox("Введите название группы", "Создание группы");
                if (string.IsNullOrEmpty(result)) result = "Новая группа";
                TreeNode newGroupNode = new TreeNode(result);
                newGroupNode.Tag = new Group("", "");
                if (selectedNode != null)
                {
                    selectedNode.Nodes.Add(newGroupNode);
                }
                else
                {
                    treeView1.Nodes.Add(newGroupNode);
                }

                newGroupNode.EnsureVisible();
                treeView1.SelectedNode = newGroupNode;
            }
        }

        private void addChildBtn_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag is Group group)
            {
                TreeNode selectedNode = treeView1.SelectedNode;
                string result = Interaction.InputBox("Введите Фамилию сотрудника", "Создание сотрудника");
                if (string.IsNullOrEmpty(result)) result = "Новый сотрудник";
                TreeNode newGroupNode = new TreeNode(result);
                newGroupNode.Tag = new Person("", DateTime.MinValue, "", "", "", "", 0);
                if (selectedNode != null)
                {
                    selectedNode.Nodes.Add(newGroupNode);
                }
                else
                {
                    treeView1.Nodes.Add(newGroupNode);
                }

                newGroupNode.EnsureVisible();
                treeView1.SelectedNode = newGroupNode;
            }
        }

        private void topBtn_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            if (selectedNode != null && selectedNode.PrevNode != null)
            {
                int currentIndex = selectedNode.Index;
                int prevIndex = currentIndex - 1;

                TreeNodeCollection parent;

                if (selectedNode.Parent != null)
                {
                    parent = selectedNode.Parent.Nodes;
                }
                else
                {
                    parent = treeView1.Nodes;
                }
                parent.RemoveAt(currentIndex);

                parent.Insert(prevIndex, selectedNode);
            }
        }
        private void bottomBtn_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            TreeNodeCollection parent;

            if (selectedNode.Parent != null)
            {
                parent = selectedNode.Parent.Nodes;
            }
            else
            {
                parent = treeView1.Nodes;
            }

            int currentIndex = selectedNode.Index;

            parent.Remove(selectedNode);

            parent.Insert(currentIndex + 1, selectedNode);
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            if (selectedNode != null)
            {
                TreeNodeCollection parent;
                if (selectedNode.Parent != null)
                {
                    parent = selectedNode.Parent.Nodes;
                }
                else
                {
                    parent = treeView1.Nodes;
                }

                parent.Remove(selectedNode);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Tag != null)
            {
                object objFromTag = treeView1.SelectedNode.Tag;

                propertyGrid.SelectedObject = objFromTag;
            }
        }

        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);

            TreeNode nodeAtPoint = treeView1.HitTest(point).Node;

            if (nodeAtPoint == null)
            {
                treeView1.SelectedNode = null;
                propertyGrid.SelectedObject = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            treeView1_MouseDown(sender, e);
        }
    }
}

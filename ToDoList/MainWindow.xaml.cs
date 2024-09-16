using Microsoft.Win32;
using System.Windows;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Task> tasks = new List<Task>();
        public MainWindow()
        {
            InitializeComponent();
            // set background color
            this.Background = System.Windows.Media.Brushes.Gray;
        }

        public void UpdateList()
        {
            lstTasks.Items.Clear();
            foreach (Task task in tasks)
            {
                lstTasks.Items.Add(task.ToString());
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task(txtEingabe.Text);
            tasks.Add(task);
            txtEingabe.Text = "";
            UpdateList();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = lstTasks.SelectedIndex;

            // wenn nichts ausgewählt wurde, dann wird index -1 sein, daher check
            if (index >= 0)
            {
                tasks.RemoveAt(index);
                UpdateList();
            }
        }

        private void ButtonComplete_Click(object sender, RoutedEventArgs e)
        {
            int index = lstTasks.SelectedIndex;

            // wenn nichts ausgewählt wurde, dann wird index -1 sein, daher check
            if (index >= 0)
            {
                tasks[index].CompleteTask();
                UpdateList();
            }
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            // open file explorer to select .tasks file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Task files (*.tasks)|*.tasks";
            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;

                LoadTasks(filename);

                UpdateList();
            }
        }

        public void LoadTasks(string filename)
        {
            tasks.Clear();
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                Task task = new Task(parts[0]);
                if (parts[1] == "True")
                {
                    task.CompleteTask();
                }
                task.WriteDate(DateTime.Parse(parts[2]));

                tasks.Add(task);
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Task files (*.tasks)|*.tasks";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filename = saveFileDialog.FileName;
                SaveTasks(filename);
            }
        }


        public void SaveTasks(string filename)
        {
            List<string> lines = new List<string>();
            foreach (Task task in tasks)
            {
                string line = $"{task.Description};{task.isComplete};{task.date}";
                lines.Add(line);
            }
            System.IO.File.WriteAllLines(filename, lines);
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            tasks.Clear();
            UpdateList();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
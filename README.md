# ToDoList
Ein simples Programm um Aufgaben zu managen.

## Anleitung
Um eine Task zu erstellen, muss eine Beschreibung in der TextBox gegeben werden, dann auf "Add" klicken. Um eine Task abzuschließen oder zu löschen, die entsprechende Aufgabe in der Liste auswählen und dann den gewünschten Button drücken. Um eine Datei zu Laden oder zu speichern im Menu auf File, dann Laden/Speichern auswählen und die Datei wählen.

## Klassendiagramm
![image](https://github.com/user-attachments/assets/1d8a1609-a76f-4126-9cd2-d26315938bb5)

## Funktionen
### Speichern und laden von Aufgabenlisten
```c#
private void ButtonLoad_Click(object sender, RoutedEventArgs e)
{
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
```

### Two-Click Completion / Removal
Ein Eintrag auswählen, dann nur auf Complete oder Delete klicken
```c#
private void ButtonDelete_Click(object sender, RoutedEventArgs e)
{
    int index = lstTasks.SelectedIndex;

    if (index >= 0)
    {
        tasks.RemoveAt(index);
        UpdateList();
    }
}

private void ButtonComplete_Click(object sender, RoutedEventArgs e)
{
    int index = lstTasks.SelectedIndex;

    if (index >= 0)
    {
        tasks[index].CompleteTask();
        UpdateList();
    }
}
```

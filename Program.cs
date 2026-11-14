Console.Write("Сколько задач добавить сначала: ");
int count = Convert.ToInt32(Console.ReadLine());
List<string> tasks = new List<string>();
for (int i = 0; i < count; i++)
{
    Console.Write($"Задача {i + 1}: ");
    string title = Console.ReadLine() ?? "";
    tasks.Add(title);
}

PrintTasks(tasks);

Console.Write("Задайте название новой задачи: ");
string newTask = Console.ReadLine() ?? "";
tasks.Add(newTask);
Console.WriteLine("Задача добавлена");

Console.Write("Задайте название новой задачи: ");
string insertTask = Console.ReadLine() ?? "";
Console.Write("Задайте индекс вставки: ");
int index = int.Parse(Console.ReadLine() ?? "");
if (InsertTaskSafe(tasks, index, insertTask))
{
    Console.WriteLine("Задача вставлена");
}
else 
{
    Console.WriteLine("Недопустимый индекс вставки");
}

Console.Write("Задайте название задачи для удаления: ");
string removeTask = Console.ReadLine() ?? "";
if (tasks.Remove(removeTask))
{
    Console.WriteLine("Первое совпадение удалено");
}
else
{
    Console.WriteLine("Задача не найдена");
}

Console.Write("Задайте индекс задачи для удаления: ");
int removeIndex = int.Parse(Console.ReadLine() ?? "");
if (RemoveTaskAtSafe(tasks, removeIndex))
{
    Console.WriteLine("Задача по индексу удалена");
}
else
{
    Console.WriteLine("Недопустимый индекс удаления");
}

Console.Write("Задайте название задачи для поиска: ");
string findTask = Console.ReadLine() ?? "";
int findIndex = tasks.IndexOf(findTask);
if (findIndex >= 0)
{
    Console.WriteLine($"Первый индекс: {findIndex}");
}
else
{
    Console.WriteLine("Задача не найдена");
}
Console.WriteLine();
Console.WriteLine(">>> Итоговый список дел <<<");
Console.WriteLine();
Console.WriteLine($"Количество задач: {tasks.Count}");
PrintTasks(tasks);

int RemoveAllTasks(List<string> tasks, string title) {
    int count = 0;
    for (int i = tasks.Count - 1; i >= 0; i--) {
        if (tasks[i] == title) {
            tasks.RemoveAt(i);
            count ++;
        }
    }
    return count;
}


bool InsertTaskSafe(List<string> tasks, int index, string title)
{
    if (index < 0 || index > tasks.Count)
    {
        return false;
    }

    tasks.Insert(index, title);
    return true;
}


void PrintTasks(List<string> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Список пуст");
        return;
    }

    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i}: {tasks[i]}");
    }
}

bool RemoveTaskAtSafe(List<string> tasks, int index)
{
    if (index < 0 || index >= tasks.Count)
    {
        return false;
    }

    tasks.RemoveAt(index);
    return true;
}

/*
 * ЗАДАНИЕ 1
Напишите программу, которая чистит нужную нам папку от файлов  и папок, которые не использовались более 30 минут 
*/

public class FolderCleaner30
{
    public static void Cleaner (string path)
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Папка {dirInfo.Name} по пути: {path} - отсутсвует!");
            }
            else if (dirInfo.LastAccessTime == DateTime.Now - TimeSpan.FromMinutes(30))
            {
                foreach (FileInfo file in dirInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    dir.Delete(true);
                }
                Console.WriteLine($"{dirInfo.Name} очищена!");
            }
            else
            {
                Console.WriteLine($"Папка {dirInfo.Name} активно используется");
            }

            dirInfo.Refresh();
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine($"Ошибка доступа {e.Message}");
        }
        catch (Exception e) 
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        const string path = @"D:\TestFolderForTask1";
        FolderCleaner30.Cleaner(path);
    }
}
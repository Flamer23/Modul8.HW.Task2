using System.Security.Cryptography;

namespace Modul8.HW.Task2
{
    
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string path = "C:\\Users\\zuevi\\Desktop\\HW";

            long size = 0;

            if (Directory.Exists(path))
            {
                Count(path, ref size);
                Console.WriteLine($"{size} байт");
            }
            else
            {
                Console.WriteLine("Папка по указанному пути не существует");
            }
        }

        public static void Count(string path, ref long size)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            DirectoryInfo[] subDirectories = directory.GetDirectories();
            FileInfo[] files = directory.GetFiles();

            foreach (FileInfo file in files)
            {
                try
                {
                    size += file.Length;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Файл не найден. Ошибка: " + ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка: " + ex.Message);
                }
                                
            }

            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                if(subDirectory.GetDirectories() != null)
                {
                    try
                    {
                        Count(subDirectory.FullName, ref size);
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошла ошибка: " + ex.Message);
                    }
                }
                
            }
            
        }
    }
}

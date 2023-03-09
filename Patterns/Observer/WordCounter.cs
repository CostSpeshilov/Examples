using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer
{
    public class WordCounter: IProgressObservable
    {
        // Хранение всех наблюдателей за данным объектом.
        // поле закрытое, так как подмиска и отписка должны производиться только
        // через интерфейс IProgressObservable
        List<IProgressObserver> observers = new List<IProgressObserver>();
        public void AddObserver(IProgressObserver observer)
        {
            if (observer is null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            observers.Add(observer);
        }
        public void RemoveObserver(IProgressObserver observer)
        {
            if (observer is null)
            {
                throw new ArgumentNullException(nameof(observer));
            }
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        // Оповещение всех наблюдателей о произошедшем событии
        private void NotifyAll(double percent, string currentFileName)
        {
            foreach (var observer in observers)
            {
                observer.Notify(percent, currentFileName);
            }
        }

        // подсчёт количества слов во всех txt файлах в заданной папке
        public void CountWords(string directoryPath)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();

            if (Directory.Exists(directoryPath))
            {
                var files = Directory
                    .GetFiles(directoryPath, ".", SearchOption.AllDirectories)
                    .Where(x => x.EndsWith("txt"))
                    .ToList();

                double totalFilesCount = files.Count;
                for (int i = 0; i < totalFilesCount; i++)
                {
                    string currentFileName = files[i];
                    string fileContent = File.ReadAllText(currentFileName);
                    string[] fileContentSplitted = fileContent.Split();
                    foreach (var word in fileContentSplitted)
                    {
                        if (counts.ContainsKey(word))
                        {
                            counts[word]++;
                        }
                        else
                        {
                            counts.Add(word, 1);
                        }
                    }
                    // Вызов метода оповещения наблюдателей
                    NotifyAll(i / totalFilesCount * 100, currentFileName);
                }
            }
        }
    }
}

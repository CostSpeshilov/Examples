using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Observer.Events
{
    // Издатель события (Наблюдаемый объект)
    public class WordCounterEvents
    {
        // при реализации события всегда используйте обобщённый делегат EventHandler
        // свои делегаты сейчас не пишутся
        public event EventHandler<WordProgressEventArgs> ProgressNotified;
        public void CountWords(string directoryPath)
        {
            Dictionary<string, int> counts = new Dictionary<string, int>();

            if (Directory.Exists(directoryPath))
            {
                var files = Directory.GetFiles(directoryPath, ".", SearchOption.AllDirectories).Where(x => x.EndsWith("txt")).ToList();

                double totalFilesCount = files.Count();
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
                            counts.Add(word, 0);
                        }
                    }

                    // Следующие две фомы записи (с ?.Invoke и if()) эквивалентны
                    // ?. - Null-conditional operator. Событие не будет инициировано,
                    // если у него не будет подписчиков

                    ProgressNotified?.Invoke(null, new WordProgressEventArgs()
                    {
                        CurrentFileName = currentFileName,
                        Progress = i / totalFilesCount
                    }
                    );

                    //if (ProgressNotified != null)
                    //{
                    //    ProgressNotified.Invoke(null, new WordProgressEventArgs() { CurrentFileName = currentFileName, Progress = i / totalFilesCount });
                    //}

                }
            }
        }
    }
}

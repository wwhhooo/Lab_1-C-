using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; // библиотека для проверки наличия дубликатов
using System.Text.RegularExpressions;
using System.Xml.Serialization;

public class Tasks
{
    // Задание 1: Проверка наличия хотя бы двух одинаковых элементов в списке
    public static bool HasDuplicates(List<int> list)
    {
        return list.GroupBy(x => x).Any(g => g.Count() > 1);
    }

    // Задание 2: Удаление первого вхождения заданного элемента из связанного списка
    public static void RemoveFirstOccurrence(LinkedList<int> list, int element)
    {
        var node = list.First;
        while (node != null)
        {
            if (node.Value == element)
            {
                list.Remove(node);
                break;
            }
            node = node.Next;
        }
    }

    // Задание 3: Определение популярности музыкальных произведений среди меломанов
    public static void AnalyzeMusicPreferences(List<string> compositions, List<HashSet<string>> melomansPreferences)
    {
        //инициализируем мн-ва
        var allLikes = new HashSet<string>(compositions);
        var someLikes = new HashSet<string>();
        var noLikes = new HashSet<string>(compositions);
        
        //обработка предпочтений меломанов
        foreach (var preferences in melomansPreferences)
        {
            allLikes.IntersectWith(preferences); // оставляем только те произведения, которые есть в тек-м мн-ве предпочтений
            someLikes.UnionWith(preferences); // добавляем все произведения из тек-го мн-ва предпочтений
            noLikes.ExceptWith(preferences); // удаляем все произведения, которые есть в тек-м мн-ве предпочтений
        }
        
        //вывод рез-ов
        Console.WriteLine("Произведения, которые нравятся всем меломанам:");
        foreach (var compose in allLikes)
        {
            Console.WriteLine(compose);
        }

        Console.WriteLine("Произведения, которые нравятся некоторым меломанам:");
        foreach (var compose in someLikes.Except(allLikes))
        {
            Console.WriteLine(compose);
        }

        Console.WriteLine("Произведения, которые не нравятся никому из меломанов:");
        foreach (var compose in noLikes)
        {
            Console.WriteLine(compose);
        }
    }

    // Задание 4: Напечатать все гласные буквы, которые не входят более чем в одно слово
    public static void PrintUniqueVowels(string text)
    {
        var words = Regex.Split(text, @"\W+"); // разделение текста на слова (\W+ = один символ не являющийся буквой, цифрой или подчеркиванием)
        var vowels = new HashSet<char> { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' }; // мн-во ггласных букв
        var uniqueVowels = new HashSet<char>(); // мн-во уникальных гласных
        var multiVowels = new HashSet<char>(); // мн-во повторяющихся гласных

        foreach (var word in words) // проход по каждому слову в тексте
        {
            var wordVowels = word.Where(c => vowels.Contains(c)).ToHashSet(); // мн-во, содерж. все гласные из слова
            foreach (var vowel in wordVowels)
            {   
                // если гласная уже содержится в uniqeVowels - удаляем ее оттуда и доабвяем в multiVowels
                if (uniqueVowels.Contains(vowel))
                {
                    uniqueVowels.Remove(vowel);
                    multiVowels.Add(vowel);
                }
                else if (!multiVowels.Contains(vowel))
                {
                    uniqueVowels.Add(vowel);
                }
            }
        }
        //вывод уникальных гласных букв
        Console.WriteLine("Гласные буквы, которые входят не более чем в одно слово:");
        foreach (var vowel in uniqueVowels.OrderBy(c => c))
        {
            Console.WriteLine(vowel);
        }
    }
    
    // 1 Вспомогательный метод для ввода списка чисел с клавиатуры 1
    private static List<int> ReadListFromConsole()
    {
        Console.WriteLine("Введите целые числа через пробел:");
        var input = Console.ReadLine();
        var numbers = new List<int>();
        var parts = input.Split(' ');
        
        // проверка пустого ввода
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Ввод не может быть пустым. Пожалуйста, введите целые числа через пробел:");
            ReadListFromConsole();
        }
        
        // проверка каждой части строки на то, является ли она целым числом
        foreach (var part in parts)
        {
            if (int.TryParse(part, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine($"Некорректное значение: {part}. Пожалуйста, введите целые числа через пробел:");
                ReadListFromConsole();
            }
        }
        return numbers;
    }
    
    // 22 Вспомогательный метод для ввода связанного списка чисел с клавиатуры 22
    private static LinkedList<int> ReadLinkedListFromConsole()
    {
        Console.WriteLine("Введите элементы связанного списка(целые числа) через пробел:");
        var input = Console.ReadLine();
        var numbers = new List<int>();
        var parts = input.Split(' ');
        
        // проверка пустого ввода
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Ввод не может быть пустым. Пожалуйста, введите целые числа через пробел:");
            ReadListFromConsole();
        }
        
        // проверка каждой части строки на то, является ли она целым числом
        foreach (var part in parts)
        {
            if (int.TryParse(part, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine($"Некорректное значение: {part}. Пожалуйста, введите целые числа через пробел:");
                ReadListFromConsole();
            }
        }
        return new LinkedList<int>(numbers);
    }

    // 333 Вспомогательный метод для ввода списка музыкальных произведений с клавиатуры 333
    private static List<string> ReadMusicPiecesFromConsole()
    {
        Console.WriteLine("Введите музыкальные произведения через запятую:");
        var input = Console.ReadLine();
        // разделяем по ",", удаляем начальные и конечные пробелы, преобразуем в список
        var compose = input.Split(',').Select(p => p.Trim()).ToList();
        return compose;
    }

    // 4444 Вспомогательный метод для ввода предпочтений меломанов с клавиатуры 4444
    private static List<HashSet<string>> ReadMelomansPreferencesFromConsole(List<string> musicPieces)
    {
        var preferences = new List<HashSet<string>>();
        Console.WriteLine("Введите количество меломанов:");
        int n;
        // если введено не число или число <= 0, то запрашивается повтореный ввод
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Некорректное количество меломанов. Пожалуйста, введите целое положительное число: ");
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите предпочтения меломана {i + 1} через запятую:");
            var input = Console.ReadLine();
            var pref = input.Split(',').Select(p => p.Trim()).ToHashSet();
            preferences.Add(pref);
        }

        return preferences;
    }

    // Вспомогательный метод для ввода текста с клавиатуры
    private static string ReadTextFromConsole()
    {
        Console.WriteLine("Введите текст на русском языке: ");
        return Console.ReadLine();
    }
    
    /*
    public class Participant
    {
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("Class")]
        public int Class { get; set; }

        [XmlElement("Score")]
        public int Score { get; set; }
    }*/
    
    // класс, который будет использоваться для сереализации и десереализации участников
    public class Participant
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Class { get; set; }
        public int Score { get; set; }
    }
    
    // метод для считывания данных с клавиатуры и проверки их на корректность
    public static List<Participant> ReadParticipantsFromConsole()
    {
        var participants = new List<Participant>();

        Console.WriteLine("Введите количество участников олимпиады:");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Некорректное количество участников. Пожалуйста, введите целое положительное число:");
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите данные участника {i + 1} в формате <Фамилия> <Имя> <класс>(7-11) <баллы>(целое положительное число):");
            var input = Console.ReadLine();
            var parts = input.Split(' ');

            if (parts.Length != 4)
            {
                Console.WriteLine("Некорректный формат ввода. Пожалуйста, введите данные снова:");
                i--;
                continue;
            }

            var lastName = parts[0];
            var firstName = parts[1];

            if (!int.TryParse(parts[2], out int classNumber) || classNumber < 7 || classNumber > 11)
            {
                Console.WriteLine("Некорректный класс. Пожалуйста, введите данные снова:");
                i--;
                continue;
            }

            if (!int.TryParse(parts[3], out int score) || score < 0)
            {
                Console.WriteLine("Некорректные баллы. Пожалуйста, введите данные снова:");
                i--;
                continue;
            }

            participants.Add(new Participant
            {
                LastName = lastName,
                FirstName = firstName,
                Class = classNumber,
                Score = score
            });
        }

        return participants;
    }
    
    // метод для сохранения данных в XML-файл
    public static void SaveParticipantsToFile(string filePath, List<Participant> participants)
    {
        var serializer = new XmlSerializer(typeof(List<Participant>));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, participants);
        }
    }
    // метод для чтения данных из XML-файла
    public static List<Participant> ReadParticipantsFromFile(string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<Participant>));
        using (var reader = new StreamReader(filePath))
        {
            return (List<Participant>)serializer.Deserialize(reader);
        }
    }
    
    public static void FindBestNonWinner(string filePath) // нахождение победителя
    {
        var participants = ReadParticipantsFromFile(filePath);

        var maxScore = participants.Max(p => p.Score);
        var winners = participants.Where(p => p.Score == maxScore && p.Score > 200).ToList();

        if (winners.Count > 0 && winners.Count <= participants.Count * 0.2)
        {
            var secondMaxScore = participants.Where(p => p.Score < maxScore).Max(p => p.Score);
            var bestNonWinners = participants.Where(p => p.Score == secondMaxScore).ToList();

            if (bestNonWinners.Count == 1)
            {
                Console.WriteLine($"{bestNonWinners[0].LastName} {bestNonWinners[0].FirstName}");
            }
            else
            {
                Console.WriteLine(bestNonWinners.Count);
            }
        }
        else
        {
            var bestNonWinners = participants.Where(p => p.Score == maxScore).ToList();
            if (bestNonWinners.Count == 1)
            {
                Console.WriteLine($"Победитель: {bestNonWinners[0].LastName} {bestNonWinners[0].FirstName}");
            }
            else
            {
                Console.WriteLine("Победителей: ");
                Console.WriteLine(bestNonWinners.Count);
            }
        }
    }

    // Пример использования методов
    public static void Main(string[] args)
    {
        // Задание 1
        var list = ReadListFromConsole();
        Console.WriteLine("Есть ли дубликаты в списке: " + HasDuplicates(list));

        // Задание 2
        var linkedList = ReadLinkedListFromConsole();
        Console.WriteLine("Введите элемент для удаления:");
        //int elementToRemove = int.Parse(Console.ReadLine());
        int elementToRemove;
        // если введено не число, то запрашивается повторный ввод
        while (!int.TryParse(Console.ReadLine(), out elementToRemove))
        { 
            Console.WriteLine("Некорректное количество меломанов. Пожалуйста, введите целое число: ");
        }
        RemoveFirstOccurrence(linkedList, elementToRemove);
        Console.WriteLine("Связанный список после удаления первого вхождения элемента:");
        foreach (var item in linkedList)
        {
            Console.WriteLine(item);
        }

        // Задание 3
        var musicPieces = ReadMusicPiecesFromConsole();
        var melomansPreferences = ReadMelomansPreferencesFromConsole(musicPieces);
        AnalyzeMusicPreferences(musicPieces, melomansPreferences);

        // Задание 4
        var text = ReadTextFromConsole();
        PrintUniqueVowels(text);
        
        //Задание 5
        string filePath = "participants.xml";
        var participants = ReadParticipantsFromConsole();
        SaveParticipantsToFile(filePath, participants);
        FindBestNonWinner(filePath);
    }
}

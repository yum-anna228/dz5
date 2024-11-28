namespace dz
{
    internal class Program
    {
        /// <summary>
        /// Класс графф
        /// </summary>
        class Graph
        {
            /// <summary>
            /// Словарь для хранения списка смежности графа
            /// </summary>
            private Dictionary<int, List<int>> adjacencyList;

            /// <summary>
            /// Конструктор класса Graph
            /// </summary>
            public Graph()
            {
                adjacencyList = new Dictionary<int, List<int>>();
            }

            /// <summary>
            /// Метод для добавления ребра между двумя вершинами
            /// </summary>
            public void AddEdge(int source, int destination)
            {
                if (!adjacencyList.ContainsKey(source))
                {
                    adjacencyList[source] = new List<int>();
                }
                adjacencyList[source].Add(destination);

                if (!adjacencyList.ContainsKey(destination))
                {
                    adjacencyList[destination] = new List<int>();
                }
                adjacencyList[destination].Add(source);
            }

            /// <summary>
            /// // Метод для обхода графа в ширину и поиска кратчайшего пути
            /// </summary>
            public List<int> BFS(int start, int end)
            {
                Queue<int> queue = new Queue<int>();
                Dictionary<int, int> parent = new Dictionary<int, int>();
                HashSet<int> visited = new HashSet<int>();

                queue.Enqueue(start);
                visited.Add(start);
                parent[start] = -1; // Начальная вершина не имеет родителя

                while (queue.Count > 0)
                {
                    int current = queue.Dequeue();

                    if (current == end)
                    {
                        return GetPath(parent, start, end);
                    }

                    foreach (var neighbor in adjacencyList[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                            parent[neighbor] = current; // Запоминаем родителя
                        }
                    }
                }

                return new List<int>(); // Путь не найден
            }

            /// <summary>
            /// // Метод для построения пути от начальной до конечной вершины
            /// </summary>
            private List<int> GetPath(Dictionary<int, int> parent, int start, int end)
            {
                List<int> path = new List<int>();
                for (int at = end; at != -1; at = parent[at])
                {
                    path.Add(at);
                }
                path.Reverse(); // Переворачиваем путь, чтобы получить правильный порядок
                return path;
            }
        }
        /// <summary>
        /// Класс, который представляет бабушку
        /// </summary>
        class Grandma
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Diseases { get; set; }
            public List<string> Medications { get; set; }

            /// <summary>
            /// Конструктор класса Grandma, который позволяет инициализировать экземпляр с заданными значениями для имени, возраста, заболеваний и медикаментов.
            /// </summary>
            public Grandma(string name, int age, List<string> diseases, List<string> medications)
            {
                Name = name;
                Age = age;
                Diseases = diseases;
                Medications = medications;
            }
        }
        /// <summary>
        /// Класс, который представляет больницу
        /// </summary>
        class Hospital
        {
            public string Name { get; set; }
            public List<string> TreatedDiseases { get; set; }
            public int Capacity { get; set; }
            public Queue<Grandma> Grandmas { get; set; }

            /// <summary>
            /// Конструктор класса Hospital, который позволяет инициализировать экземпляр с заданными значениями для имени, лечимых заболеваний и емкости.
            /// </summary>
            public Hospital(string name, List<string> treatedDiseases, int capacity)
            {
                Name = name;
                TreatedDiseases = treatedDiseases;
                Capacity = capacity;
                Grandmas = new Queue<Grandma>();
            }
            /// <summary>
            /// Метод для вычисления и возврата уровня заполняемости больницы в процентах.
            /// </summary>
            /// <returns></returns>
            public double OccupancyRate()
            {
                return (double)Grandmas.Count / Capacity * 100;
            }
            /// <summary>
            /// Метод, который проверяет, может ли больница принять бабушку.
            /// </summary>
            public bool CanAdmit(Grandma grandma)
            {
                if (Grandmas.Count >= Capacity)
                    return false;

                if (grandma.Diseases.Count == 0)
                    return true;

                int treatedCount = 0;
                foreach (var disease in grandma.Diseases)
                {
                    if (TreatedDiseases.Contains(disease))
                        treatedCount++;
                }

                return (treatedCount / (double)grandma.Diseases.Count) > 0.5;
            }
        }
        /// <summary>
        /// Метод перемешивает фотографии
        /// </summary>
        static List<string> ShuffleList(List<string> list, Random random)
        {
            List<string> shuffledList = new List<string>(list);
            for (int i = shuffledList.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                string temp = shuffledList[i];
                shuffledList[i] = shuffledList[j];
                shuffledList[j] = temp;
            }
            return shuffledList;
        }

        static void Task2()
        {
            List<string> images = new List<string>();
            for (int i = 1; i <= 32; i++)
            {
                string imageName = $"Image_{i}";
                images.Add(imageName);
                images.Add(imageName);
            }

            Console.WriteLine("Изначальный список:");
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {images[i]}");
            }

            Random random = new Random();
            List<string> shuffledImages = ShuffleList(images, random);

            Console.WriteLine("\nПеремешанный список:");
            for (int i = 0; i < shuffledImages.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {shuffledImages[i]}");
            }
        }
        //2
        class Student
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public int BirthYear { get; set; }
            public string Exam { get; set; }
            public int Score { get; set; }

            public override string ToString()
            {
                return $"{LastName} {FirstName}, {BirthYear}, {Exam}, {Score}";
            }
        }
        //1
        static void Shuffle(List<string> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                string value = list[n];
                list[n] = list[k];
                list[k] = value;
            }
        }
        static void Main(string[] args)
        {
            Task1(args);
            Task2();
            Task3(args);
            Task4(args);
        }

        static void Task1(string[] args)
        {
            Console.WriteLine("Задание 2");
            List<Student> students = LoadStudentsFromFile("students.txt");

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Новый студент");
                Console.WriteLine("2. Удалить");
                Console.WriteLine("3. Сортировать");
                Console.WriteLine("4. Вывести студентов");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(students);
                        break;
                    case "2":
                        RemoveStudent(students);
                        break;
                    case "3":
                        SortStudents(students);
                        break;
                    case "4":
                        DisplayStudents(students);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор, попробуйте снова.");
                        break;
                }
            }
        }

        static void AddStudent(List<Student> students)
        {
            Student newStudent = new Student();

            Console.Write("Введите фамилию: ");
            newStudent.LastName = Console.ReadLine();

            Console.Write("Введите имя: ");
            newStudent.FirstName = Console.ReadLine();

            Console.Write("Введите год рождения: ");
            newStudent.BirthYear = int.Parse(Console.ReadLine());

            Console.Write("Введите экзамен: ");
            newStudent.Exam = Console.ReadLine();

            Console.Write("Введите баллы: ");
            newStudent.Score = int.Parse(Console.ReadLine());

            students.Add(newStudent);
            Console.WriteLine("Студент добавлен.");
        }
        static void RemoveStudent(List<Student> students)
        {
            Console.Write("Введите фамилию студента для удаления: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите имя студента для удаления: ");
            string firstName = Console.ReadLine();

            var studentToRemove = students.FirstOrDefault(s => s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)
                                                              && s.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));

            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                Console.WriteLine("Студент удален.");
            }
            else
            {
                Console.WriteLine("Студент не найден.");
            }
        }

        static void SortStudents(List<Student> students)
        {
            students = students.OrderBy(s => s.Score).ToList();
            Console.WriteLine("Студенты отсортированы по баллам.");
        }

        static void DisplayStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Список студентов пуст.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        static List<Student> LoadStudentsFromFile(string filePath)
        {
            List<Student> students = new List<Student>();
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        students.Add(new Student
                        {
                            LastName = parts[0],
                            FirstName = parts[1],
                            BirthYear = int.Parse(parts[2]),
                            Exam = parts[3],
                            Score = int.Parse(parts[4])
                        });
                    }
                }
            }
            return students;
        }
        //Создать бабулю.У бабули есть Имя, возраст, болезнь и лекарство от этой болезни,которое она принимает. Реализовать список бабуль. Также есть боьница.
        static void Task3(string[] args)
        {
            Console.WriteLine("Задание 3");
            List<Grandma> grandmas = new List<Grandma>();
            Stack<Hospital> hospitals = new Stack<Hospital>();
            hospitals.Push(new Hospital("Больница №1", new List<string> { "грипп", "кашель" }, 2));
            hospitals.Push(new Hospital("Больница №2", new List<string> { "простуда", "боль в горле" }, 2));
            hospitals.Push(new Hospital("Больница №3", new List<string> { "грипп", "боль в спине" }, 2));

            while (true)
            {
                Console.WriteLine("Введите имя бабушки (или 'exit' для выхода):");
                string name = Console.ReadLine();
                if (name.ToLower() == "exit")
                    break;

                Console.WriteLine("Введите возраст бабушки:");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите количество болезней (0, если нет):");
                int diseaseCount = int.Parse(Console.ReadLine());
                List<string> diseases = new List<string>();
                List<string> medications = new List<string>();

                for (int i = 0; i < diseaseCount; i++)
                {
                    Console.WriteLine($"Введите болезнь #{i + 1}:");
                    diseases.Add(Console.ReadLine());

                    Console.WriteLine($"Введите лекарство от болезни #{i + 1}:");
                    medications.Add(Console.ReadLine());
                }

                Grandma grandma = new Grandma(name, age, diseases, medications);
                grandmas.Add(grandma);

                Hospital assignedHospital = null;
                foreach (var hospital in hospitals)
                {
                    if (hospital.CanAdmit(grandma))
                    {
                        hospital.Grandmas.Enqueue(grandma);
                        assignedHospital = hospital;
                        break;
                    }
                }
                if (assignedHospital == null)
                {
                    if (diseaseCount == 0)
                    {
                        foreach (var hospital in hospitals)
                        {
                            if (hospital.Grandmas.Count < hospital.Capacity)
                            {
                                hospital.Grandmas.Enqueue(grandma);
                                assignedHospital = hospital;
                                break;
                            }
                        }
                    }

                    if (assignedHospital == null)
                    {
                        Console.WriteLine($"{grandma.Name} остается на улице плакать.");
                    }
                }
                else
                {
                    Console.WriteLine($"{grandma.Name} была распределена в {assignedHospital.Name}.");
                }
                Console.WriteLine("\nСписок всех бабушек:");
                foreach (var g in grandmas)
                {
                    Console.WriteLine($"Имя: {g.Name}, Возраст: {g.Age}, Болезни: {string.Join(", ", g.Diseases)}");
                }

                Console.WriteLine("\nСписок всех больниц:");
                foreach (var hospital in hospitals)
                {
                    Console.WriteLine($"Название: {hospital.Name}, Болезни: {string.Join(", ", hospital.TreatedDiseases)}, " +
                                      $"Заполненность: {hospital.OccupancyRate():F2}% ({hospital.Grandmas.Count}/{hospital.Capacity})");
                }
                Console.WriteLine();
            }
        }

        //Написать метод для обхода графа в глубину или ширину - вывести на экран кратчайший путь.
        static void Task4(string[] args)
        {
            Console.WriteLine("Задание 4");
            Graph graph = new Graph();
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 6);
            graph.AddEdge(4, 7);
            graph.AddEdge(5, 7);
            graph.AddEdge(6, 7);

            Console.WriteLine("Введите начальную вершину:");
            int start = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите конечную вершину:");
            int end = int.Parse(Console.ReadLine());

            List<int> path = graph.BFS(start, end);

            if (path.Count > 0)
            {
                Console.WriteLine($"Кратчайший путь от {start} до {end}: {string.Join(" -> ", path)}");
            }
            else
            {
                Console.WriteLine($"Нет пути от {start} до {end}.");
            }
        }


    }
}

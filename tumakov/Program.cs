namespace tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1(args);
            Task2(args);
            Task3(args);
            Task4(args);
            Task5();

        }
        /// <summary>
        /// Метод для заполнения матрицы случайными числами
        /// </summary>
        static void FillMatrix(int[,] matrix)
        {
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(1, 10); // Заполняем случайными числами от 1 до 9
                }
            }
        }
        //6.3
        static double[] CalculateAverageTemperatures(int[,] temperature)
        {
            double[] averages = new double[12];

            for (int month = 0; month < 12; month++)
            {
                double sum = 0;
                for (int day = 0; day < 30; day++)
                {
                    sum += temperature[month, day];
                }
                averages[month] = sum / 30;
            }

            return averages;
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Умножение матриц
        public static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0); // Количество строк в первой матрице
            int colsA = matrixA.GetLength(1); // Количество столбцов в первой матрице
            int rowsB = matrixB.GetLength(0); // Количество строк во второй матрице
            int colsB = matrixB.GetLength(1); // Количество столбцов во второй матрице

            if (colsA != rowsB)
            {
                throw new ArgumentException("Количество столбцов первой матрицы должно совпадать с количеством строк второй матрицы.");
            }

            int[,] result = new int[rowsA, colsB];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }
        //6.1
        static int CountVowels(char[] text)
        {
            const string Vowels = "аoеёиоуыэюяАЕЁИОУЫЭЮЯ";
            return text.Count(c => Vowels.Contains(c));
        }

        /// <summary>
        /// Метод для подсчета гласных и согласных букв.
        /// </summary>
        static int CountConsonants(char[] text)
        {
            const string Consonants = "бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩ";
            return text.Count(c => Consonants.Contains(c));
        }
        static void Task1(string[] args)
        {

            Console.WriteLine("Упражнение 6.1");

            //C:\Users\anna\source\repos\dz5\tumakov\bin\Debug\net8.0\tumakov.exe "C:\\Users\\anna\\source\\repos\\dz5\\tumakov\\file.txt" путь в командную строку
            if (args.Length > 0)
            {

                string filename = args[0];
                try
                {
                    char[] content = File.ReadAllText(filename).ToCharArray();

                    var vowelsCount = CountVowels(content);
                    var consonantsCount = CountConsonants(content);

                    Console.WriteLine($"Гласных букв: {vowelsCount}");
                    Console.WriteLine($"Согласных букв: {consonantsCount}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Не указано имя файла.");
            }
        }


        static void Task2(string[] args)
        {
            Console.WriteLine("Упражнение 6.2");
            Console.WriteLine("Введите количество строк первой матрицы:");
            int rowsA = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов первой матрицы:");
            int colsA = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество строк второй матрицы (должно быть равно количеству столбцов первой):");
            int rowsB = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов второй матрицы:");
            int colsB = int.Parse(Console.ReadLine());
            if (colsA != rowsB)
            {
                Console.WriteLine("Ошибка: количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
                return;
            }
            int[,] matrixA = new int[rowsA, colsA];
            FillMatrix(matrixA);
            Console.WriteLine("Первая матрица:");
            PrintMatrix(matrixA);
            int[,] matrixB = new int[rowsB, colsB];
            FillMatrix(matrixB);
            Console.WriteLine("Вторая матрица:");
            PrintMatrix(matrixB);
            int[,] resultMatrix = MultiplyMatrices(matrixA, matrixB);
            Console.WriteLine("Результат умножения матриц:");
            PrintMatrix(resultMatrix);

        }

        static void Task3(string[] args)
        {

            Console.WriteLine("Упражнение 6.3");
            int[,] temperature = new int[12, 30];
            Random random = new Random();
            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    temperature[month, day] = random.Next(-10, 36);
                }
            }
            double[] averageTemperatures = CalculateAverageTemperatures(temperature);
            Console.WriteLine("Средняя температура за каждый месяц:");
            for (int month = 0; month < averageTemperatures.Length; month++)
            {
                Console.WriteLine($"Месяц {month + 1}: {averageTemperatures[month]:F2}°C");
            }
            Array.Sort(averageTemperatures);
            Console.WriteLine("\nОтсортированные средние температуры:");
            foreach (var avgTemp in averageTemperatures)
            {

                Console.WriteLine($"{avgTemp:F2}°C");
            }
        }
        
        static void Task4(string[] args)
        {
                Console.WriteLine("Домашнее задание 6.3");
                const int months = 12;
                const int days = 30;

                int[,] temperatures = new int[months, days];
                Random random = new Random();
                for (int i = 0; i < months; i++)
                {
                    for (int j = 0; j < days; j++)
                    {
                        temperatures[i, j] = random.Next(-10, 36);
                    }
        }
        Dictionary<string, int[]> temperatureData = new Dictionary<string, int[]>
        {
            { "Январь", GetMonthTemperatures(temperatures, 0) },
            { "Февраль", GetMonthTemperatures(temperatures, 1) },
            { "Март", GetMonthTemperatures(temperatures, 2) },
            { "Апрель", GetMonthTemperatures(temperatures, 3) },
            { "Май", GetMonthTemperatures(temperatures, 4) },
            { "Июнь", GetMonthTemperatures(temperatures, 5) },
            { "Июль", GetMonthTemperatures(temperatures, 6) },
            { "Август", GetMonthTemperatures(temperatures, 7) },
            { "Сентябрь", GetMonthTemperatures(temperatures, 8) },
            { "Октябрь", GetMonthTemperatures(temperatures, 9) },
            { "Ноябрь", GetMonthTemperatures(temperatures, 10) },
            { "Декабрь", GetMonthTemperatures(temperatures, 11) }
        };

                // Вычисление средних температур
                double[] averageTemperatures = new double[months];
                for (int i = 0; i < months; i++)
                {
                    averageTemperatures[i] = CalculateAverageTemperature(temperatureData.ElementAt(i).Value);
                }

                // Сортировка средних температур и получение отсортированного массива
                var sortedAverageTemperatures = averageTemperatures.OrderBy(temp => temp).ToArray();

                // Вывод средних температур по месяцам
                Console.WriteLine("Средняя температура за месяц:");
                for (int i = 0; i < months; i++)
                {
                    Console.WriteLine($"{temperatureData.ElementAt(i).Key}: {averageTemperatures[i]:F2} °C");
                }

                // Вывод отсортированных средних температур
                Console.WriteLine("\nОтсортированные средние температуры:");
                foreach (var temp in sortedAverageTemperatures)
                {
                    Console.WriteLine($"{temp:F2} °C");
                }
            

            // Метод для получения температур за месяц
            static int[] GetMonthTemperatures(int[,] temperatures, int month)
            {
                int days = temperatures.GetLength(1);
                int[] monthTemperatures = new int[days];
                for (int j = 0; j < days; j++)
                {
                    monthTemperatures[j] = temperatures[month, j];
                }
                return monthTemperatures;
            }

            // Метод для вычисления средней температуры
            static double CalculateAverageTemperature(int[] monthTemperatures)
            {
                return monthTemperatures.Average();
            }
        }
        static void Task5()
        {
            Console.WriteLine("Домашнее задание 6.2");
            LinkedList<LinkedList<int>> matrixA = new LinkedList<LinkedList<int>>(new[]
            {
            new LinkedList<int>(new[] { 1, 2, 3 }),
            new LinkedList<int>(new[] { 4, 5, 6 })
        });

            LinkedList<LinkedList<int>> matrixB = new LinkedList<LinkedList<int>>(new[]
            {
            new LinkedList<int>(new[] { 7, 8 }),
            new LinkedList<int>(new[] { 9, 10 }),
            new LinkedList<int>(new[] { 11, 12 })
        });

            try
            {

                Console.WriteLine("Matrix A:");
                PrintMatrixLinkedList(matrixA);

                Console.WriteLine("\nMatrix B:");
                PrintMatrixLinkedList(matrixB);


                LinkedList<LinkedList<int>> resultMatrix = MultiplyMatricesLinkedList(matrixA, matrixB);


                Console.WriteLine("\nResulting Matrix:");
                PrintMatrixLinkedList(resultMatrix);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static void PrintMatrixLinkedList(LinkedList<LinkedList<int>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var value in row)
                {
                    Console.Write(value + "\t");
                }
                Console.WriteLine();
            }
        }
        static LinkedList<LinkedList<int>> MultiplyMatricesLinkedList(LinkedList<LinkedList<int>> matrixA, LinkedList<LinkedList<int>> matrixB)
        {
            int colsA = matrixA.First.Value.Count;
            int rowsB = matrixB.Count;

            if (colsA != rowsB)
            {
                throw new InvalidOperationException("Матрицы нельзя умножить: число столбцов первой матрицы не равно числу строк второй.");
            }

            int colsB = matrixB.First.Value.Count;

            LinkedList<LinkedList<int>> resultMatrix = new LinkedList<LinkedList<int>>();
            int[,] matrixBArray = ConvertTo2DArray(matrixB);

            foreach (var rowA in matrixA)
            {
                LinkedList<int> resultRow = new LinkedList<int>();
                for (int j = 0; j < colsB; j++)
                {
                    int value = 0;
                    int index = 0;
                    foreach (var valueA in rowA)
                    {
                        value += valueA * matrixBArray[index, j];
                        index++;
                    }
                    resultRow.AddLast(value);
                }
                resultMatrix.AddLast(resultRow);
            }

            return resultMatrix;
        }
        static int[,] ConvertTo2DArray(LinkedList<LinkedList<int>> matrix)
        {
            int rows = matrix.Count;
            int cols = matrix.First.Value.Count;
            int[,] array = new int[rows, cols];

            int i = 0;
            foreach (var row in matrix)
            {
                int j = 0;
                foreach (var value in row)
                {
                    array[i, j] = value;
                    j++;
                }
                i++;
            }

            return array;
        }

    }
}



   
   




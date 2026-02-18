using Lab_1_Ivanchenko_appr;

Console.Write("Введiть кiлькiсть рядкiв: ");
int rows = int.Parse(Console.ReadLine());

Console.Write("Введiть кiлькiсть стовпцiв: ");
int cols = int.Parse(Console.ReadLine());

double[,] data = new double[rows, cols];

Console.WriteLine($"Введiть рядок матрицi:");

for (int i = 0; i < rows; i++)
{
    while (true)
    {
        Console.Write($"Рядок {i + 1}: ");
        string input = Console.ReadLine();

        string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != cols)
        {
            Console.WriteLine($"Помилка! Ви ввели {parts.Length} чисел, а потрiбно {cols}. Спробуйте ще раз.");
            continue;
        }

        try
        {
            for (int j = 0; j < cols; j++)
            {
                data[i, j] = double.Parse(parts[j].Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            }
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка! Введено некоректне число. Спробуйте ще раз.");
        }
    }
}

Console.Write("Введiть кiлькiсть констант: ");
int constNum = int.Parse(Console.ReadLine());

double[] constants = new double[constNum];

for (int i = 0; i < constNum; i++)
{
    while (true)
    {
        Console.Write($"Константа {i + 1}: ");
        string input = Console.ReadLine();
        try
        {
            constants[i] = double.Parse(input.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка! Введено некоректне число. Спробуйте ще раз.");
        }
    }
}

Matrix matrix = new Matrix(data);

InverseMatrixCalculator eliminator = new InverseMatrixCalculator();
SystemCalculator systemCalculator = new SystemCalculator();

List<Matrix> iterations = eliminator.Eliminate(matrix);
double[] solutions = systemCalculator.Calculate(matrix, constants);

int iterationsCount = 1;
foreach (Matrix m in iterations)
{
    Console.WriteLine($"\nРозв\'язок для {iterationsCount} елементу дiагоналi:");
    for (int i = 0; i < m.Rows; i++)
    {
        for (int j = 0; j < m.Columns; j++)
        {
            Console.Write($"{m[i, j]:F2} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    iterationsCount++;
}

int solutionIndex = 1;
Console.WriteLine("Розв\'язок системи:");
foreach (double n in solutions)
{
    Console.WriteLine($"X[{solutionIndex}]: " + n);
    solutionIndex++;
}

Console.WriteLine("\nРанг матрицi: " + matrix.Rank);
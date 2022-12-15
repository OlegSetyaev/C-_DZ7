//Задаём двумерный массив размером m×n, заполненный случайными вещественными числами (Задача 47)

void FillMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(1, 11);
        }

    }
}

void PrintMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write($"{matrix[i, j]} \t");
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

// Находим среднее арифметическое каждого столбца (Задача 52)

void ArithmeticMean(double[,] matrix)
{
    int horizontalLength = matrix.GetLength(1);
    int verticalLength = matrix.GetLength(0);
    double[] arifMean = new double[horizontalLength];
    double sum = 0;
    for (int i = 0; i < horizontalLength; i++)
    {
        for (int j = 0; j < verticalLength; j++)
        {
            sum += matrix[j, i];
        }
        arifMean[i] = Math.Round(sum / verticalLength, 2);
        sum = 0;
    }
    System.Console.WriteLine($"Среднее арифметическое каждого столбца = [{string.Join("; ", arifMean)}]");

}

// Проверяем наличие элемента (Задача 50)

void CheckElement(double[,] matrix)
{
    int horizontalLength = matrix.GetLength(1);
    int verticalLength = matrix.GetLength(0);
    System.Console.WriteLine("Введите индексы элемента матрицы: ");
    string[] index = Console.ReadLine().Split(" ");
    if (int.Parse(index[0]) > horizontalLength && int.Parse(index[1]) > verticalLength && int.Parse(index[0]) > verticalLength && int.Parse(index[1]) > horizontalLength)
    {
        System.Console.WriteLine("Нет такого элемента");
        return;
    }
    else System.Console.WriteLine(matrix[int.Parse(index[0]), int.Parse(index[1])]);
}

// Транспонируем матрицу относительно горизонтали (Доп1)

void SwapLines(double[,] matrix, int index, int index2)
{
    double bufer = 0;
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        bufer = matrix[index, i];
        matrix[index, i] = matrix[index2, i];
        matrix[index2, i] = bufer;
    }
}

void TransposeMatrixHorizntal(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0) / 2; i++)
    {
        SwapLines(matrix, i, matrix.GetLength(0) - 1 - i);
    }
}



System.Console.WriteLine("Введите размеры матрицы: ");
string[] numbers = Console.ReadLine().Split(" ");
double[,] newMatrix = new double[int.Parse(numbers[0]), int.Parse(numbers[1])];
FillMatrix(newMatrix);
PrintMatrix(newMatrix);
ArithmeticMean(newMatrix);
CheckElement(newMatrix);
TransposeMatrixHorizntal(newMatrix);
PrintMatrix(newMatrix);
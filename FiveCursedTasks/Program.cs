// 1) Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию
// элементы каждой строки двумерного массива.
// 2) Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить
// строку с наименьшей суммой элементов.

int[,] materDei = GetRandomMatrix(5, 5, -10, 10);
PrintMatrix(materDei);
SortMatrix(materDei);
PrintMatrix(materDei);
int min = GetMinSum(materDei);
MinRow(materDei);


int[,] GetRandomMatrix(int rows, int columns, int minValue, int maxValue)
{
    Console.WriteLine("Несортированная матрица");
    Console.WriteLine();
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return matrix;
}


int[,] SortMatrix(int[,] matr)
{
    Console.WriteLine("Сортированная матрица");
    Console.WriteLine();
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            for (int k = j + 1; k < matr.GetLength(1); k++)
            {
                if (matr[i, j] < matr[i, k])
                {
                    int temp = matr[i, j];
                    matr[i, j] = matr[i, k];
                    matr[i, k] = temp;
                }
            }
        }
    }
    return matr;
}


void PrintMatrix(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"{matr[i, j]} | ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}


int GetMinSum(int[,] matr)
{
    int tempMin = int.MaxValue;
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            sum = sum + matr[i, j];
        }
        if (sum < tempMin) tempMin = sum;
    }
    Console.WriteLine($"Минимальная сумма = {tempMin}");
    return tempMin;
}


void MinRow(int[,] matr)
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            sum = sum + matr[i, j];
            if (sum == min)
            {
                Console.WriteLine($"Минимальная строка - {i + 1} .");
            }
        }
    }
}


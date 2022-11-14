// 1) Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию
// элементы каждой строки двумерного массива.

int[,] materDei = GetRandomMatrix(5, 5, -10, 10);
PrintMatrix(materDei);
SortMatrix(materDei);
PrintMatrix(materDei);

int[,] GetRandomMatrix(int rows, int columns, int minValue, int maxValue)
{
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
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            int temp = matr[i, j];
            if (matr[i, j] < matr[i, j + 1])
            {
                matr[i, j] = matr[i, j + 1];
                matr[i, j + 1] = temp;
            }
        }
    }
    return matr;
}


void PrintMatrix(int[,] matr)
{
    Console.WriteLine("Матрица целочисленных готова");
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            Console.Write($"{matr[i, j]} | ");
        }
        Console.WriteLine();
    }
}



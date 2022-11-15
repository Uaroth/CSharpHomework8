// 1) Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию
// элементы каждой строки двумерного массива.
// 2) Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить
// строку с наименьшей суммой элементов.
// 3) Задайте две матрицы. Напишите программу,
// которая будет находить произведение двух матриц.
// 4) Сформируйте трёхмерный массив из неповторяющихся
// двузначных чисел. Напишите программу, которая будет
// построчно выводить массив, добавляя индексы каждого элемента.
// 5) Напишите программу, которая заполнит спирально
// массив 4 на 4.
// Сделал примитивизм и позор, но с учётом наступающего дэдлайна
// наступающего дэдлайна - грамотное распоряжение временем.
// Сутками разбирался с произведением и трёхмерным массивом,
// тут ничего не успеваю придумать, зато работает)


int[,] matrixA = GetRandomMatrix(3, 4, -10, 10);
PrintMatrix(matrixA);
SortMatrix(matrixA);
PrintMatrix(matrixA);
int min = GetMinSum(matrixA);
MinRow(matrixA);
int[,] matrixB = GetRandomMatrix(4, 3, -10, 10);
Console.WriteLine("Умножить на матрицу");
PrintMatrix(matrixB);
PrintMatrix(MultiMatrix(matrixA, matrixB));
int[,,] matrixC = Get3DMatrix(2, 2, 2, 10, 99);
Print3DMatrix(matrixC);
int[,] matrixD = GetRandomMatrix(4, 4, 1, 16);
PrintMatrix(matrixD);
Console.WriteLine("Спиральный квадрат");
PrintMatrix(SpiralFourMatrix(4, 4));




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





int[,] SpiralFourMatrix(int rows, int columns)
{
    int[,] matr = new int[rows, columns];
    int i = 0;
    int j = 0;

    int value = 1;

    int k = 0;
    do { matr[i, j++] = value++; } while (++k < rows - 1);
    for (k = 0; k < rows - 1; k++) matr[i++, j] = value++;
    for (k = 0; k < rows - 1; k++) matr[i, j--] = value++;
    for (k = 0; k < rows - 1; k++) matr[i--, j] = value++;
    

    ++i; ++j;

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
                Console.WriteLine($"Минимальная строка - {i} .");
            }
        }
    }
}



int[,] MultiMatrix(int[,] matr1, int[,] matr2)

{
    Console.WriteLine("Произведение матриц");
    int[,] matr3 = new int[matr1.GetLength(0), matr2.GetLength(1)];
    int mult = 0;
    int i = 0;
    for (int x = 0; x < matr3.GetLength(0); x++)
    {
        int n = 0;
        for (int y = 0; y < matr3.GetLength(1); y++)
        {
            int j = 0;
            int m = 0;
            int sum = 0;
            for (j = 0; j < matr1.GetLength(1); j++)
            {
                mult = matr1[i, j] * matr2[m, n];
                if (m < matr2.GetLength(1)) m++;
                sum = sum + mult;
            }
            if (n < matr2.GetLength(1)) n++;

            matr3[x, y] = sum;
        }
        if (i < matr1.GetLength(0)) i++;

    }
    return matr3;
}


int[,,] Get3DMatrix(int rows, int columns, int spaces, int minValue, int maxValue)
{
    Console.WriteLine("Трёхмерный массив");
    Console.WriteLine();
    int[,,] matrix = new int[rows, columns, spaces];
    for (int x = 0; x < rows; x++)
    {
        for (int y = 0; y < columns; y++)
        {

            for (int z = 0; z < spaces; z++)
            {
                matrix[x, y, z] = new Random().Next(minValue, maxValue + 1);

            }
        }

    }
    return matrix;
}



void Print3DMatrix(int[,,] matr)
{
    for (int x = 0; x < matr.GetLength(0); x++)
    {
        for (int y = 0; y < matr.GetLength(1); y++)
        {
            for (int z = 0; z < matr.GetLength(2); z++)
            {
                Console.Write($"{matr[x, y, z]} ({x},{y},{z}) | ");
            }
            Console.WriteLine();
        }

    }
    Console.WriteLine();
}



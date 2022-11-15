﻿// 1) Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию
// элементы каждой строки двумерного массива.
// 2) Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить
// строку с наименьшей суммой элементов.
// 3) Задайте две матрицы. Напишите программу,
// которая будет находить произведение двух матриц.

int[,] matrixA = GetRandomMatrix(3, 3, -10, 10);
PrintMatrix(matrixA);
SortMatrix(matrixA);
PrintMatrix(matrixA);
int min = GetMinSum(matrixA);
MinRow(matrixA);
int[,] matrixB = GetRandomMatrix(3, 3, -10, 10);
Console.WriteLine("Умножить на матрицу");
PrintMatrix(matrixB);
// PrintMatrix(MultiMatrix(matrixA, matrixB));
PrintMatrix(TestMult(matrixA, matrixB));



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



int[,] TestMult(int[,] matr1, int[,] matr2)

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
                Console.WriteLine($"Вот {matr1[i, j]} * {matr2[m, n]} = {mult}");
                if (m < matr2.GetLength(1)) m++;

                sum = sum + mult;
            }
            if (n < matr2.GetLength(1)) n++;

            matr3[x, y] = sum;
            Console.Write($"{matr3[x, y]} | ");
            Console.WriteLine();
        }
        if (i < matr1.GetLength(0)) i++;

    }
    return matr3;
}

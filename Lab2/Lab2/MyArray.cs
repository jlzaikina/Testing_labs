using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab2;

public class MyArray
{
    private double[] array;
    private Random random = new Random();
    public MyArray(int length)
    {
        if (length > 0)
        {
            array = new double[length];
        }
        else
            throw new FormatException("Неверный формат данных. Длина массива является целым положительным числом. Повторите ввод заново.");
    }
    public double[] Array
    {
        get { return array; }
    }
    public double this[int i]
    {
        get
        {
            if (i >= 0 && i < array.Length)
                return array[i];
            else
                throw new IndexOutOfRangeException();
        }
        set
        {
            if (i >= 0 && i < array.Length)
                array[i] = value;
            else
                throw new IndexOutOfRangeException();
        }
    }

    public double CalculateSum()
    {
        double sum = 0;
        foreach (var number in array)
        {
            sum += number;
        }
        return sum;
    }

    public void GenerateRandomArray(int minValue, int maxValue)
    {
        if (minValue > maxValue)
        {
            (minValue, maxValue) = (maxValue, minValue);
        }
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(minValue, maxValue + 1);
            Console.Write(array[i] + " ");
        }
    }
}


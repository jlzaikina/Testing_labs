using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        bool isValidSize = false;
        int n = 0;
        MyArray array = null;
        while (!isValidSize)
        {
            try
            {
                Console.Write("Введите размер массива: ");
                n = int.Parse(Console.ReadLine());
                array = new MyArray(n);
                isValidSize = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат данных. Длина массива является целым положительным числом. Повторите ввод заново.");
            }
        }
        Console.WriteLine("Выберите действие\n1. Заполнить вручную\n2. Заполнить автоматически");
        Console.Write("Выбранный пункт меню: ");
        string menu = Console.ReadLine();
        switch (menu)
        {
            case "1":
                {
                    for (int i = 0; i < n; i++)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine($"Введите элемент массива {i + 1}: ");
                                double value = Convert.ToDouble(Console.ReadLine());
                                array[i] = value;
                                break;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine("Неверный формат данных. Массив состоит из численных элементов целого типа. Повторите ввод заново");
                            }
                        }
                    }
                    break;
                }
            case "2":
                {
                    int minValue = 0, maxValue = 0;
                    while (true)
                    {
                        try
                        {
                            Console.Write("Введите минимальное значение: ");
                            minValue = int.Parse(Console.ReadLine());

                            Console.Write("Введите максимальное значение: ");
                            maxValue = int.Parse(Console.ReadLine());
                            array.GenerateRandomArray(minValue, maxValue);
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Неверный формат данных. Массив состоит из численных элементов целого типа. Повторите ввод заново");
                        }
                    }
                    Console.WriteLine();
                    break;
                }
            default:
                {
                    Console.WriteLine("Неверный пункт меню");
                    break;
                }
        }
        Console.WriteLine($"Сумма элементов массива: {array.CalculateSum()}");
    }
}
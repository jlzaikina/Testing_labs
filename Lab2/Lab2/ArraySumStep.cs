using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2;

[Binding]
public class ArraySumSteps
{
    private MyArray _array;
    private double _result;

    [Given(@"пользователь создает массив длиной (.*)")]
    public void GivenПользовательСоздаетМассивДлиной(int length)
    {
        _array = new MyArray(length);
    }

    [Given(@"пользователь вводит значения (.*), (.*), (.*)")]
    public void GivenПользовательВводитЗначения(double value1, double value2, double value3)
    {
        _array[0] = value1;
        _array[1] = value2;
        _array[2] = value3;
    }

    [When(@"пользователь запрашивает сумму элементов массива")]
    public void WhenПользовательЗапрашиваетСуммуЭлементовМассива()
    {
        _result = _array.CalculateSum();
    }

    [Then(@"выводится сумма элементов массива (.*)")]
    public void ThenВыводитсяСуммаЭлементовМассива(double expectedSum)
    {
        Assert.AreEqual(expectedSum, _result);
    }
}

[Binding]
public class RandomArraySumSteps
{
    private MyArray _array;
    private double _sum;

    [Given(@"пользователь создает новый массив длиной (.*)")]
    public void GivenПользовательСоздаетМассивДлиной(int length)
    {
        _array = new MyArray(length);
    }

    [When(@"пользователь заполняет массив случайными числами от (.*) до (.*)")]
    public void WhenПользовательЗаполняетМассивСлучайнымиЧисламиОт(int minValue, int maxValue)
    {
        _array.GenerateRandomArray(minValue, maxValue);
        _sum = _array.CalculateSum();
    }

    [Then(@"сумма элементов массива находится в пределах от (.*) до (.*)")]
    public void ThenСуммаЭлементовМассиваНаходитсяВПределахОт(int expectedMinSum, int expectedMaxSum)
    {
        Assert.That(_sum, Is.InRange(expectedMinSum, expectedMaxSum));
    }
}

[Binding]
public class InvalidArrayLenSteps
{
    private MyArray _array;
    private Exception _exception;

    [Given(@"пользователь создает массив некорректной длины (.*)")]
    public void GivenПользовательСоздаетМассивДлиной(int length)
    {
        try
        {
            _array = new MyArray(length);
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [Then(@"выводится сообщение об ошибке ""(.*)""")]
    public void ThenВыводитсяСообщениеОбОшибке(string expectedMessage)
    {
        Assert.AreEqual(expectedMessage, _exception.Message);
    }
}

[Binding]
public class InvalidArrayElementSteps
{
    private MyArray _array;
    private Exception _exception;

    [Given(@"пользователь создает массив корректной длины (.*)")]
    public void GivenПользовательСоздаетМассивДлиной(int length)
    {
        try
        {
            _array = new MyArray(length);
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [When(@"пользователь пытается установить элемент с индексом (.*) равным ""(.*)""")]
    public void WhenПользовательПытаетсяУстановитьЭлементСИндексомРавным(int index, string value)
    {
        try
        {
            _array[index] = Convert.ToDouble(value);
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [Then(@"возникает ошибка ""Неверный формат""")]
    public void ThenВозникаетОшибка()
    {
        Assert.IsNotNull(_exception);
        Assert.IsInstanceOf<FormatException>(_exception);
    }
}

[Binding]
public class ArrayByTableSteps
{
    private MyArray _array;
    private Exception _exception;

    [Given(@"пользователь создает массив1 длиной (.*)")]
    public void GivenПользовательСоздаетМассивДлиной(int length)
    {
        _array = new MyArray(length);
    }

    [When(@"пользователь устанавливает элементы массива:")]
    public void WhenПользовательУстанавливаетЭлементыМассива(Table table)
    {
        foreach (var row in table.Rows)
        {
            int index = int.Parse(row["индекс"]);
            double value = double.Parse(row["значение"]);
            _array[index] = value; // Устанавливаем элемент массива по индексу
        }
    }

    [Then(@"элементы массива установлены корректно")]
    public void ThenЭлементыМассиваУстановленыКорректно()
    {
        Assert.AreEqual(5.0, _array[4]); // Пример проверки, что последний элемент установлен корректно
    }

    [Then(@"сумма элементов массива равна (.*)")]
    public void ThenСуммаЭлементовМассиваРавна(double expectedSum)
    {
        double actualSum = _array.CalculateSum();
        Assert.AreEqual(expectedSum, actualSum); // Проверяем, что сумма элементов массива равна ожидаемой
    }
}

[Binding]
public class ArrayWithDelimiterSteps
{
    private MyArray _myArray;
    private double[] _elements;

    [Given(@"пользователь создает массив из строки ""(.*)"" с разделителем ""(.*)""")]
    public void GivenПользовательСоздаетМассивИзСтрокиСРазделителем(string input, string delimiter)
    {
        // Определяем разделитель
        string[] parts = input.Split(new[] { delimiter }, StringSplitOptions.None);
        _elements = Array.ConvertAll(parts, double.Parse);
    }

    [When(@"установка элементов массива в MyArray с разделителем ""(.*)""")]
    public void WhenПользовательУстанавливаетЭлементыМассиваВMyArray(string delimiter)
    {
        _myArray = new MyArray(_elements.Length); // Создаем массив необходимой длины
        for (int i = 0; i < _elements.Length; i++)
        {
            _myArray[i] = _elements[i]; // Устанавливаем элементы в MyArray
        }
    }

    [Then(@"элементы массива установлены без ошибок")]
    public void ThenЭлементыМассиваУстановленыБезОшибок()
    {
        Assert.AreEqual(5.0, _myArray[4]); // Проверяем, что последний элемент установлен корректно
    }

    [Then(@"сумма элементов массива (.*)")]
    public void ThenСуммаЭлементовМассиваРавна(double expectedSum)
    {
        double actualSum = _myArray.CalculateSum();
        Assert.AreEqual(expectedSum, actualSum); // Проверяем, что сумма элементов массива равна ожидаемой
    }
}


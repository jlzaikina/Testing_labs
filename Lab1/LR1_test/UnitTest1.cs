using ConsoleApp1;

namespace LR1_test;

public class UnitTest1
{
    MyArray array;

    [Fact]
    public void Test_valid_size_array()
    {
        // Arrange
        int length = 5;

        // Act
        array = new MyArray(length);

        // Assert
        Assert.Equal(length, array.Array.Length);
    }

    [Fact]
    public void Test_valid_element_array()
    {
        // Arrange
        array = new MyArray(5);
        array[0] = 1;

        // Act
        double result = array[0];
        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Sum_int_valid_array()
    {
        // Arrange
        array = new MyArray(5);
        array[0] = 1;
        array[1] = -2;
        array[2] = 3;
        array[3] = -4;
        array[4] = 5;

        // Act
        double result = array.CalculateSum();

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Sum_double_valid_array()
    {
        // Arrange
        array = new MyArray(5);
        array[0] = 1.1;
        array[1] = -2.1;
        array[2] = 3.1;
        array[3] = -4.1;
        array[4] = 5.1;

        // Act
        double result = array.CalculateSum();

        // Assert
        Assert.Equal(3.1, result);
    }

    [Fact]
    public void Test_Invalid_size_array()
    {
        // Act & Assert
        var exception = Assert.Throws<FormatException>(() => new MyArray(-1));
        Assert.Equal("Неверный формат данных. Длина массива является целым положительным числом. Повторите ввод заново.", exception.Message);
    }

    [Fact]
    public void Test_with_valid_random_array()
    {
        // Arrange
        array = new MyArray(5);

        // Act
        array.GenerateRandomArray(1, 10);
        double sum = array.CalculateSum();

        // Assert
        foreach (var number in array.Array)
        {
            Assert.InRange(number, 1, 10);
        }
        Assert.InRange(sum, 5, 50);
    }

    [Fact]
    public void Test_Invalid_Element_array()
    {
        // Arrange
        array = new MyArray(5);
        array[0] = 1;

        // Act
        Action act1 = () => array[0] = double.Parse("abc");

        //Assert
        var exception = Assert.Throws<FormatException>(act1);
    }
}
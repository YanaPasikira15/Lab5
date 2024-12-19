using System;

class MathOperations
{
    // Додавання
    public int Add(int a, int b) => a + b;
    public double Add(double a, double b) => a + b;
    public int[] Add(int[] arr1, int[] arr2) => OperateArrays(arr1, arr2, (x, y) => x + y);
    public int[,] Add(int[,] mat1, int[,] mat2) => OperateMatrices(mat1, mat2, (x, y) => x + y);

    // Віднімання
    public int Subtract(int a, int b) => a - b;
    public int[] Subtract(int[] arr1, int[] arr2) => OperateArrays(arr1, arr2, (x, y) => x - y);
    public int[,] Subtract(int[,] mat1, int[,] mat2) => OperateMatrices(mat1, mat2, (x, y) => x - y);

    // Множення
    public int Multiply(int a, int b) => a * b;
    public int[] Multiply(int[] arr, int scalar) => OperateArrayScalar(arr, scalar, (x, y) => x * y);
    public int[,] Multiply(int[,] mat, int scalar) => OperateMatrixScalar(mat, scalar, (x, y) => x * y);

    // Утиліти
    private int[] OperateArrays(int[] arr1, int[] arr2, Func<int, int, int> op)
    {
        if (arr1.Length != arr2.Length) throw new ArgumentException("Масиви мають бути однакової довжини");
        int[] result = new int[arr1.Length];
        for (int i = 0; i < arr1.Length; i++) result[i] = op(arr1[i], arr2[i]);
        return result;
    }

    private int[,] OperateMatrices(int[,] mat1, int[,] mat2, Func<int, int, int> op)
    {
        if (mat1.GetLength(0) != mat2.GetLength(0) || mat1.GetLength(1) != mat2.GetLength(1))
            throw new ArgumentException("Матриці мають бути однакового розміру");
        int[,] result = new int[mat1.GetLength(0), mat1.GetLength(1)];
        for (int i = 0; i < mat1.GetLength(0); i++)
            for (int j = 0; j < mat1.GetLength(1); j++)
                result[i, j] = op(mat1[i, j], mat2[i, j]);
        return result;
    }

    private int[] OperateArrayScalar(int[] arr, int scalar, Func<int, int, int> op)
    {
        int[] result = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++) result[i] = op(arr[i], scalar);
        return result;
    }

    private int[,] OperateMatrixScalar(int[,] mat, int scalar, Func<int, int, int> op)
    {
        int[,] result = new int[mat.GetLength(0), mat.GetLength(1)];
        for (int i = 0; i < mat.GetLength(0); i++)
            for (int j = 0; j < mat.GetLength(1); j++)
                result[i, j] = op(mat[i, j], scalar);
        return result;
    }
}

class Program
{
    static void Main()
    {
        var math = new MathOperations();
        // Тест чисел
        Console.WriteLine("Add: " + math.Add(5, 3));
        Console.WriteLine("Multiply: " + math.Multiply(4, 2));
        // Тест масивів
        int[] arr1 = { 1, 2, 3 }, arr2 = { 4, 5, 6 };
        Console.WriteLine("Array Add: " + string.Join(", ", math.Add(arr1, arr2)));
        // Тест матриць
        int[,] mat1 = { { 1, 2 }, { 3, 4 } }, mat2 = { { 5, 6 }, { 7, 8 } };
        Console.WriteLine("Matrix Add:");
        PrintMatrix(math.Add(mat1, mat2));
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }
}

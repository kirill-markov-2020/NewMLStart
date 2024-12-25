namespace Stage2Library.Helpers;

public static class MathHelper
{
    public static double CalculateK(int oddNumber, double x)
    {
        if (oddNumber == 9)
        {
            return Math.Sin(Math.Sin(Math.Pow((x / (x + 0.5)), x)));
        }
        else if (oddNumber == 5 || oddNumber == 7 || oddNumber == 11 || oddNumber == 15)
        {
            return Math.Pow((0.5 / Math.Tan(2 * x) + (2 / 3)), Math.Pow(x, 1 / 9));
        }
        else
        {
            return Math.Pow(Math.Tan(((Math.Exp(1 - x / Math.PI)) / 3) / 4), 3);
        }
    }

    public static double CalculateMinimalElement(double[,] matrix, int row)
    {
        double minimalElement = matrix[row, 0];
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (matrix[row, col] < minimalElement)
            {
                minimalElement = matrix[row, col];
            }
        }
        return minimalElement;
    }

    public static double CalculateColumnAverage(double[,] matrix, int col)
    {
        double sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            sum += matrix[row, col];
        }
        return sum / matrix.GetLength(0);
    }
}

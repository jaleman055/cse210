using System;

/*Enter a list of numbers, type 0 when finished.
Compute the sum, or total, of the numbers in the list.

Compute the average of the numbers in the list.

Find the maximum, or largest, number in the list.

Stretch Challenge
Have the user enter both positive and negative numbers, then find the smallest positive number (the positive number that is closest to zero).

Sort the numbers in the list and display the new, sorted list. Hint: There are C# libraries that can help you here, try searching the internet for them.
*/

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[100];
        int i = 0;
        int sum = 0;
        int max = 0;
        int min = 0;
        int count = 0;
        int average = 0;
        int temp = 0;
        int smallestPositive = 0;
        bool smallestPositiveFound = false;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (true)
        {
            Console.Write("Enter a number: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
            if (numbers[i] == 0)
            {
                break;
            }
            sum += numbers[i];
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
            if (numbers[i] > 0 && smallestPositiveFound == false)
            {
                smallestPositive = numbers[i];
                smallestPositiveFound = true;
            }
            else if (numbers[i] > 0 && numbers[i] < smallestPositive)
            {
                smallestPositive = numbers[i];
            }
            i++;
            count++;
        }
        average = sum / count;
        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Average: " + average);
        Console.WriteLine("Max: " + max);
        Console.WriteLine("Min: " + min);
        Console.WriteLine("Smallest Positive: " + smallestPositive);

        // Sort the numbers in the list and display the new, sorted list.
        for (int j = 0; j < count; j++)
        {
            for (int k = j + 1; k < count; k++)
            {
                if (numbers[j] > numbers[k])
                {
                    temp = numbers[j];
                    numbers[j] = numbers[k];
                    numbers[k] = temp;
                }
            }
        }
        Console.WriteLine("Sorted List:");
        for (int j = 0; j < count; j++)
        {
            Console.WriteLine(numbers[j]);
        }
    }
}
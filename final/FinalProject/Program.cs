using System;
using System.Data;
using System.IO;

namespace CalorieTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime timeNow = DateTime.Now;
            Console.WriteLine("Welcome to the Calorie Tracker!");
            Console.WriteLine(timeNow.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine();
            try
            {
                while (true)
                {
                    Console.WriteLine("1. Enter user data");
                    Console.WriteLine("2. Enter food data and calories");
                    Console.WriteLine("3. Calculate consumed calories during the day and save calories");
                    Console.WriteLine("4. Print calories left");
                    Console.WriteLine("5. Print user data");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine();
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();
                    Console.WriteLine();
                    if (choice == "1")
                    {
                        UserData user = new UserData();
                        user.GetUserData();
                        user.CalculateBmr();
                        Console.WriteLine("Your BMR is: " + user.Bmr);
                    }
                    else if (choice == "2")
                    {
                        FoodData foodData = new FoodData();
                        foodData.SearchFood();
                    }
                    else if (choice == "3")
                    {
                        CalorieCalculator calorieCalculator = new CalorieCalculator();
                        calorieCalculator.CalculateAndSaveCalories();
                    }
                    else if (choice == "4")
                    {
                        CalorieLeft calorieLeft = new CalorieLeft();
                        calorieLeft.PrintCaloriesLeft();
                    }
                    else if (choice == "5")
                    {
                        UserData user = new UserData();
                        user.PrintUserData();
                    }
                    else if (choice == "6")
                    {
                        Console.WriteLine("Goodbye!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Try again.");
                    }
                    Console.WriteLine();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }
        }
    }

    // UserData class is responsible for getting and storing user data
    public class UserData
    {
        private string _userName;
        private float _userAge;
        private float _userWeight;
        private float _userHeight;
        private float _bmr;

        public string UserName { get => _userName; set => _userName = value; }
        public float UserAge { get => _userAge; set => _userAge = value; }
        public float UserWeight { get => _userWeight; set => _userWeight = value; }
        public float UserHeight { get => _userHeight; set => _userHeight = value; }
        public float Bmr { get => _bmr; set => _bmr = value; }

        public void GetUserData()
        {
            Console.Write("Enter your name: ");
            UserName = Console.ReadLine();
            Console.Write("Enter your age: ");
            UserAge = float.Parse(Console.ReadLine());
            Console.Write("Enter your weight in Kg: ");
            UserWeight = float.Parse(Console.ReadLine());
            Console.Write("Enter your height in cm: ");
            UserHeight = float.Parse(Console.ReadLine());
            Console.WriteLine();
            // calculate BMR and save to a variable "bmr"
            CalculateBmr();
            SaveUserData();
        }

        public void CalculateBmr()
        {
            Bmr = 66 + (13.7f * UserWeight) + (5 * UserHeight) - (6.8f * UserAge);
        }

        public void SaveUserData()
        {
            string[] userData = { UserName, UserAge.ToString(), UserWeight.ToString(), UserHeight.ToString(), Bmr.ToString() };
            File.WriteAllLines("user_data.txt", userData);
        }

        public void PrintUserData()
        {
            string[] userData = File.ReadAllLines("user_data.txt");
            Console.WriteLine("User name: " + userData[0]);
            Console.WriteLine("User age: " + userData[1]);
            Console.WriteLine("User weight in Kg: " + userData[2]);
            Console.WriteLine("User height in cm: " + userData[3]);
            Console.WriteLine("BMR: " + userData[4]);
        }
    }

    // FoodData class is responsible for searching food data
    public class FoodData
    {
        private string _foodName;
        private float _caloriesPer100g;
        private float _quantity;
        private float _calories;

        public string FoodName { get => _foodName; set => _foodName = value; }
        public float CaloriesPer100g { get => _caloriesPer100g; set => _caloriesPer100g = value; }
        public float Quantity { get => _quantity; set => _quantity = value; }
        public float Calories { get => _calories; set => _calories = value; }

        public void SearchFood()
        {
            Console.Write("Enter food name: ");
            FoodName = Console.ReadLine();
            Console.Write("Enter quantity in grams: ");
            Quantity = float.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter calories per 100 grams: ");
            CaloriesPer100g = float.Parse(Console.ReadLine());
            Console.WriteLine();
            Calories = (Quantity / 100) * CaloriesPer100g;
            SaveCalories();
        }

        public void PrintFoodData()
        {
            string[] foodData = File.ReadAllLines("food_data.txt");
            for (int i = 0; i < foodData.Length; i++)
            {
                if (foodData[i] == FoodName)
                {
                    Console.WriteLine("Food name: " + foodData[i]);
                    Console.WriteLine("Calories per 100 grams: " + foodData[i + 1]);
                    Console.WriteLine("Quantity in grams: " + Quantity);
                    Console.WriteLine("Calories: " + Calories);
                    break;
                }
            }

        }

        public void SaveCalories()
        {
            string[] calories = { Calories.ToString() };
            File.AppendAllLines("calories.txt", calories);
        }
    }

    // CalorieCalculator class is responsible for calculating and saving calories
    public class CalorieCalculator
    {
        private float _calories;
        private float _caloriesLeft;

        public float Calories { get => _calories; set => _calories = value; }
        public float CaloriesLeft { get => _caloriesLeft; set => _caloriesLeft = value; }

        public void CalculateAndSaveCalories()
        {
            string[] calories = File.ReadAllLines("calories.txt");
            for (int i = 0; i < calories.Length; i++)
            {
                Calories += float.Parse(calories[i]);
            }

            CaloriesLeft = Calories;
            string[] caloriesLeft = { CaloriesLeft.ToString("0.0") };
            File.WriteAllLines("calories_left.txt", caloriesLeft);
            Console.WriteLine("Calories data saved.");
        }
    }

    // CalorieLeft class is responsible for printing calories left
    public class CalorieLeft
    {
        private float caloriesRemaining;

        public void PrintCaloriesLeft()
        {
            string[] caloriesLeft = File.ReadAllLines("calories_left.txt");
            string[] userData = File.ReadAllLines("user_data.txt");
            float bmr = float.Parse(userData[4]);
            Console.WriteLine("BMR: " + bmr.ToString("0.0"));
            Console.WriteLine("Calories consumed: " + caloriesLeft[0]);
            float caloriesLeftFloat = float.Parse(caloriesLeft[0]);
            caloriesRemaining = bmr - caloriesLeftFloat;
            Console.WriteLine("Calories left: " + caloriesRemaining.ToString("0.0"));
        }
    }
}

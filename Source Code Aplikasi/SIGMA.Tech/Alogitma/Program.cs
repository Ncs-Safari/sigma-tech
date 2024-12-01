// See https://aka.ms/new-console-template for more information
using Alogitma;

Console.WriteLine("TEST Algothm!");

int[] array1 = { 1, 2, 3, 4, 5 };
int[] array2 = { 15, 25, 35 };
int[] array3 = { 8, 8 };

AlgorithmOne algorithmOne = new AlgorithmOne();

Console.WriteLine($"Algorithm One: ");    

Console.WriteLine("Total Score for array1: " + algorithmOne.CalculateScore(array1)); // Expected output: 11
Console.WriteLine("Total Score for array2: " + algorithmOne.CalculateScore(array2)); // Expected output: 9
Console.WriteLine("Total Score for array3: " + algorithmOne.CalculateScore(array3)); // Expected output: 10



Console.WriteLine($"Algorithm Two: ");

AlgorithmTwo algorithmTwo = new AlgorithmTwo();

Console.Write("Input Value n: ");
int n = int.Parse(Console.ReadLine());


Console.WriteLine($"====================== ");
Console.WriteLine("");

Console.WriteLine($"Output A ");
algorithmTwo.OutputA(n);

Console.WriteLine($"====================== ");
Console.WriteLine("");

Console.WriteLine($"Output B ");
algorithmTwo.OutputB(n);

Console.WriteLine($"====================== ");
Console.WriteLine("");

Console.WriteLine($"Output C ");
algorithmTwo.OutputC(n);

Console.WriteLine($"====================== ");
Console.WriteLine("");

Console.WriteLine($"Output D ");
algorithmTwo.OutputD(n);

Console.WriteLine($"====================== ");
Console.WriteLine("");



Console.ReadLine();
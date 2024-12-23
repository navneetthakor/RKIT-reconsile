using System;
//Arrays: store multiple elements in single variable 
//Arrays are mutable in nature
//Are alwasy created on the heap 
//syntax: data_type[] variable_name; 

//ways to create array ----

// 1) Create an array of four elements, and add values later
string[] cars1 = new string[4];

// 2) Create an array of four elements and add values right away 
string[] cars2 = new string[4] { "Volvo", "BMW", "Ford", "Mazda" };

// 3) Create an array of four elements without specifying the size 
string[] cars3 = new string[] { "Volvo", "BMW", "Ford", "Mazda" };

// 4) Create an array of four elements, omitting the new keyword, and without specifying the size
string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
    //-> in 4th way we have to declare and assign value to variable in single line otherwise will result in error.

//special loop for arrays : foreach 
foreach (string str in cars)
{
    Console.Write(str + " ");
}
Console.WriteLine();

//Multi-dimenstional arrays: 
//-> we have two kind of MD arrays in C# 
//1) Rectangular Arrays 
//-> it creates tabular array, where each row and columns have same size;
int[,] num = { { 1, 2, 3 }, { 4, 5, 6 } };  // work fine
       //int[,] num2 = { { 1, 2, 3 }, { 1, 5 } }; // thorws error: size of arrays is not same 

//-> it stores array in single contiguous block of memory (row major)
//-> for num: 1, 2, 3, 4, 5, 6, 7, 8

Console.WriteLine("Rectangular Array");
foreach (int n in num)
{
    Console.Write(n + " ");
}
Console.WriteLine();

//2) Jagged Array 
//-> it is array of arrays, where each array have different size
//-> here each row is seprate array, so it must initialized seprately 
int[][] jagNum = new int[2][];
jagNum[0] = new int[3] { 1, 2, 3 };
jagNum[1] = new int[] { 4, 5, 6 };

//-> physical arrangement: 
    //jagNum: [ref1][ref2]
    //ref1: 1, 2, 3
    //ref2: 4, 5, 6

Console.WriteLine("Jagged Array");
foreach (int[] intArr in jagNum)
{
    foreach (int n in intArr)
    {
        Console.Write(n + " ");
    }
    Console.WriteLine();
}

//Properties and methods ---- 
//1) Length : returns length of array 
Console.WriteLine(cars.Length);

//2) Sort(array) (static method)
Array.Sort(cars); // sorts in acending or alphabetic order

//3) Reverse(array) (static method)
Array.Reverse(cars);

//4) Resize(ref array, newSize) (static method)
Array.Resize(ref cars, 10);
//-> here ref keyword is important 
//-> behind the scene: creates new array with specified size and copys elements to it 

//5) IndexOf(array, eleToFind, startingPos?)
Console.WriteLine(Array.IndexOf(cars, "BMW", 3));
//-> returns -1 if element is not found 

//6) GetLength(dimention)
Console.WriteLine("rows : " + num.GetLength(1)); // returns number or rows
Console.WriteLine("cols : " + num.GetLength(1)); // returns number or columns
//-> returns length of dimention of multidimentional array 
//-> applicable to both rectangular and jagged arrays (only one dimention in jagged array)
Console.WriteLine("cols : " + jagNum.GetLength(1)); // throws runtime error.
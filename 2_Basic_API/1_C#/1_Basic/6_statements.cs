using System;
//1) conditional statements 
int age = 19;

//if - else satement 
if (age > 18)
{
    Console.WriteLine("You can vote now");
}
else
{
    Console.WriteLine("You can't give vote as per now");
}

//swith-case statement 
string day = "Sunday";
switch (day)
{
    case "Saturday":
    case "Sunday":
        Console.WriteLine("You can play today");
        break;
    case "Monday":
    case "Tuesday":
    case "Wednesday":
    case "Thursday":
    case "Friday":
        Console.WriteLine("You can't play today");
        break;
    default:
        Console.WriteLine("Wrong input!!!");
        break;
}


//2) Looping Statements 

//for loop 
for (int i = 0; i < age; i++)
{
    Console.Write(i + " ");
}
Console.WriteLine();

//while loop 
int counter = 0;
while (counter < age)
{
    Console.Write(counter + " ");
    counter++;
}
Console.WriteLine();

//do-while loop 
counter = 0;
do
{
    Console.Write(counter + " ");
    counter++;
} while (counter < age);
Console.WriteLine();

//3) Control statements
/*
break;
continue;
return;
goto [label] ;

*/

counter = 0;
nk:
Console.Write(counter + " ");
if (counter >= (age - 1)) goto mk;
counter++;
goto nk;

mk:
Console.WriteLine("\nGoto finished");



//see later below once 
//-> try-catch-finally-thorw 
//-> lock
//-> async/await 
//-> using Yield statement



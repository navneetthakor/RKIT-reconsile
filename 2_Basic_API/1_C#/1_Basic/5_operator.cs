//1) Arithmetic operators 
//-> simillar as other languages 
//+, -, *, /, %

//2) Assignment operators 
//-> special thing is C# not have unsigned right shift operator 
//-> below is the example to achieve similar behaviour 
int x = -8;
uint dumyX = (uint)x;
x >>= 1;
uint result = dumyX>>1;
System.Console.WriteLine("x : " +  x);
System.Console.WriteLine("result : " + result);
System.Console.WriteLine("result : " + (int)result);    // answere for line 13, 14 will be same because now MSB = 0,

//3) Comparisoin 
//-> have all majority comparators 
//<, >, ==, !=, <=, >=

//4) Logical operators 
//&&, ||,(Short-circuited)
//&, |, (bitwise operators) (not-short circuited)
//! (not operator)

//5) Unariy operators 
//++, -- (increment/decrement)
//+, - (to change sign of numerical values)


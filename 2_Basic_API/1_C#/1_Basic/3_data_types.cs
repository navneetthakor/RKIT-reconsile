using System;
//Data types -----
/*
Data_Type	Size	    Description
int	        4 bytes	    Stores whole numbers from -2,147,483,648 to 2,147,483,647
long	    8 bytes	    Stores whole numbers from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
float	    4 bytes	    Stores fractional numbers. Sufficient for storing 6 to 7 decimal digits
double	    8 bytes	    Stores fractional numbers. Sufficient for storing 15 decimal digits
bool	    1 byte	    Stores true or false values
char	    2 bytes	    Stores a single character/letter, surrounded by single quotes
string	    2 bytes     per character	Stores a sequence of characters, surrounded by double quotes
*/

//1) long 
long x1 = 1000L;

//2) float 
float x2 = 120.5F;


//Type Casting ----- 
//1) implicit type casting -> for smaller to larger data type 

//2) explicit type casting  -> larger to smaller data type 
    //-> two ways to do it 
        //i) (data_type) 
        int x3 = (int) 152.36;

        //ii) using methods of 'Convert' class available in System namespace
        int x4 = Convert.ToInt32(152.36);
//-> other methods are 
//ToInt16(), ToString(), ToInt64(), ToDouble() etc... 

//-> this type casting is very useful in C#, becuase to take input from user we have to use 
Console.ReadLine();
//which always returns String
//therfore type conversion becomes very important in this language 

using System;
// most used Data types -----
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

//---------


//All the data tyeps 


/*
'Category '         'Data Types'
Value Types	        byte, sbyte, short, ushort, int, uint, long, ulong, float, double, decimal, bool, char
Reference Types	    string, object
Special Types	    void, pointers (in unsafe code)
Nullable Types	    Nullable<T>, T?
Enum Types	        enum
Struct Types        struct
Array Types         Arrays(e.g., int[], string[], float[])
*/


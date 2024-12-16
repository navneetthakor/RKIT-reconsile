//string is the collection of characters
//Actually behind the scene -> String is array of character 
//It is immutable in nature 

string name = "Navneetkumar Ramanbhai Thakor";
string prefix = "Mr.";

//-> String interpolation 
System.Console.WriteLine($"My name is {prefix} {name}"); // My name is Mr. Navneetkumar Ramanbhai Thakor

//-> Accessing character by index in string 
System.Console.WriteLine(name[0]); // result -> 'N'
    //-> indexing starts with 0 

//Some methods and properties of String ----
//1) length
System.Console.WriteLine(name.Length); // result -> 29

//2) ToUpper()
System.Console.WriteLine(name.ToUpper()); // result -> NAVNEETKUMAR RAMANBHAI THAKOR

//3) ToLower()
System.Console.WriteLine(name.ToLower()); // result -> navneetkumar ramanbhai thakor

//4) Concat()  (static method)
System.Console.WriteLine(string.Concat(name,prefix)); // result -> Navneetkumar Ramanbhai ThakorMr.
    //-> (note: it doesn't add any space between)
    //-> can take variable number of strings or single Collection of strings like array 
    //-> use StringBuilder class for frequent concatenations 

//5) Join(seprator, collection of strings) (static method)
string[] words = {name,prefix};
System.Console.WriteLine(string.Join(" ", words)); // result -> Navneetkumar Ramanbhai Thakor Mr.

//6) Indexof(char, startingPosition?)
System.Console.WriteLine(name.IndexOf('a', 10)); // result -> navneetkumar ramanbhai thakor
    //-> returns first mathching position from LHS 

//7) Substring(startingPos, length?)
System.Console.WriteLine(name.SubString(2, 5));
//-> startingPos: Must be greater than or equal to 0 and less than the length of the string
//-> length: Must be greater than or equal to 0 and the sum of startIndex + length must not exceed the length of the original string.
//-> startingPos == name.Length -> result: empty string
//-> if params are out of range -> ArgumentOutOfRangeException Exception will be trown


//Behind the scene ------
//->string are reference type 
//-> Strings are created on the heap and variable which are on stack have reference to it 
//-> for String heap is divided into 2 parts: heap + intern pool (constant string pool in java)
//-> all the strings where we not used 'new' keyword are created in this intern pool 
//-> Let string 'hello' is present in intern pool and we try to create same string again it will point to older one
string nk = "navneet";
string nk2 = "navneet"; // both have same reference in intern pool
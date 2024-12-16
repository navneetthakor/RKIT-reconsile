//string is the collection of characters
//Actually behind the scene -> String is array of character 

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
    //-> (note: no space added)
    //-> can take variable number of strings or single Collection of strings like array 
    //-> use StringBuilder class for frequent concatenations 

//5) Join(seprator, collection of strings) (static method)
string[] words = {name,prefix};
System.Console.WriteLine(string.Join(" ", words)); // result -> Navneetkumar Ramanbhai Thakor Mr.

//6) Indexof(char, startingPosition?)
System.Console.WriteLine(name.IndexOf('a', 10)); // result -> navneetkumar ramanbhai thakor
    //-> returns first mathching position from LHS 

//7) Substring()
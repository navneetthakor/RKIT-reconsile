//creating variables is simillar to other languages like java 

//1) normal declaration 
int x1;
x1 = 5;

//2) declaration with assignment 
int x2 = 10;

//3) constant variables 
const int x3 = 10;  // works fine 
const int x4; // will through error : A const field requires a value to be provided.

//4) multiple variables in single line 
int x5, x6 = 10;
int x7 = 10, x8;
x1 = x5 = x7 = x8 = 15;
//etc... 


//rules for identifiers
    //-> must begine with _ or letter 
    //-> should start with lowercase 
    //-> can contain letters, digits or underscores 
    //-> re: ^[_a-zA-z][_a-zA-z0-9]*$\
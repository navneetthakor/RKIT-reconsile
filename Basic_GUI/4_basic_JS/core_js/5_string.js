// two ways to create string 

// First - with String literals 
let myName = "Navneet";

// Second - with String Object constructor 
let myNickName = new String("nk");
    // -> but prefer to used String literals as they are optimized compare to second method 
    // -> Because second method will create String object in heap, 
    // while First will create string on the stack

// Following are the some useful methods of string 
// -> when we apply method to string literal, it temporory creates String Object and after task complete, 
// that object will be deleted 

// 1. charAt() 
// returns character of specified index in string.
console.log(myName.charAt(1)); // result => 'a'
    // -> charAt() returns "" and [ ] returns 'undefined' for out of range indexes

// 2. indexOf()
// returns first index where, specified character will found in the string from LHS
console.log(myName.indexOf('n')); // result => 3
    // -> If character is not present then, result => -1 

// 3. trim()
// it remove white spaces from both end of the string 
let trimExamp = "  hello      ";
console.log(trimExamp.trim()); // result => "hello"

// 4. substring()
// it return substring
console.log(myName.substring(1,3)); // result => 'av'
    // -> ending index is optional
    // -> ending indexed element will not be included 
    // -> if start is greater then end then, they will be swaped 
    // -> start or end is negative then, result => 0
    // -> if any argument is out of the bound then it will be exchanged by the size of string
    // -> if both are out of the range (like for our case 15,20) thus returns "" (empty string)

// 5. replace()
// first matching pattern from LHS will be replaced 
console.log(myName.replace('e','E')); // result => 'NavnEet'

// 6. replaceAll()
// all matching patterns will be replaced 
console.log(myName.replaceAll('e','E')); //result => 'NavnEEt'

// 7. split()
// it will return Array, of splited substring. 
console.log(myName.split('v')); // result => ['Na', 'neet']
    // -> we can specified number of time split can perform, as second parameter 
// Few ways to create Array in javascript 

// First with []
const myArr = [31, "Navneet", 8.97]

// Second with Constructor
const myArr2 = new Array();

// Third - Array from set of elements
const myArr3 = Array.of(1,"nk");

// Fourth - Array from array like elements 
const myArr4 = Array.from("Navneet");

// operations with array 
// -> As array is mutable Object, majority of the properites will modify calling Array object it self 

// 1. push 
// to add element at the end of array 
myArr.push("nk");
console.log(myArr); // result => [31, "Navneet", 8.97, "nk"]

// 2. pop
// to remove element from end 
myArr.pop() // it returns poped element 
console.log(myArr); // result => [31, "Navneet", 8.97]

// 3. unshift 
// to add element at the begining 
myArr.unshift("unshift");
console.log(myArr) // result => ["unshift", 31, "Navneet", 8.97]
    // -> generally, developer avoids it becuase it causes, shift entire array by one position to right 
    // which is overhead 

// 4. shift 
myArr.shift() // returns first shifted element
console.log(myArr) // result => [31, "Navneet", 8.97]

// 5. join 
// join elemets and returns in string format 
// by default seprator is comma, but for customization pass it as paramter 
console.log(myArr.join('-')) // result => '31-Navneet-8.97'


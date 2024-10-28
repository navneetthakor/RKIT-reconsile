"use strict";
// Math object in javascript provides set of,
// very handy properties and methods, to work with mathematics


// ----- Constants
// 1. Math.PI 
console.log(Math.PI); //(approx) 3.14159 
// 2. Math.E 
console.log(Math.E);  //(approx) 2.718   // -> Eulers number, base for logarithm
// 3. Math.SQRT2  
console.log(Math.SQRT2); //(approx) 1.414 
// etc... 


// -------- Methods for rounding & conversions numbers 
// This methods excepts number, boolean or string (which can be converted to number) as argument 

// 1. abs 
// Returns the absolute value of x.
console.log(Math.abs(-6));  // result => 6

// 2. ceil
// Returns the smallest integer greater than or equal to x.
console.log(Math.ceil(9.63)) // result => 10

// 3. floor
//  Returns the largest integer less than or equal to x.
console.log(Math.floor(9.63)); // result => 9

// 4. round
// Rounds x to the nearest integer.
console.log(Math.round(9.63)); // result => 10
console.log(Math.round(9.50)); // result => 10
console.log(Math.round(9.49)); // result => 9

// 5. trunc
// Returns the integer part of x by removing any fractional digits.
console.log(Math.trunc(9.63)); // result => 9
console.log(Math.trunc(9.50)); // result => 9
console.log(Math.trunc(9.49)); // result => 9
// etc... 


// ------- Some useful methods 
// 1. random 
// it generates random number between 0 to 1 
console.log(Math.random()) // result => diffrent every time

// 2. min 
// returns smallest number amongst 
console.log(Math.min(5,2,4,1,-1)) // result => -1
console.log(Math.min()) // result => Infinity

// 3. max
// returns largest number amongst
console.log(Math.max(5,2,4,1,-1)) // result => 5
console.log(Math.max()) // result => -Infinity


// ----- There are so many other useful methods and constants are there 
// which includes 
// - Trignomatircs
// - Exponential
// - logarithmic
// - hyperbolic 
// etc... 

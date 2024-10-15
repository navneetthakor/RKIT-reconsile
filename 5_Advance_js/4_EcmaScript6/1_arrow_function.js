"use strict"; // for illustration of arrow function
// new concise way of writing anonymous functions.
// example:
let myName = () => {
  console.log("My name is Navneet\n");
};
myName(); //calling function

// it have following benefits compare to normal functions in javascript

// 1. Implicit 'this'
// The 'this' keyword inside an arrow function refers to the 'this' of the enclosing lexical scope,
// instead of the function itself
// see below

// ------ it will give error -------------
// function greet(){
//     this.greetmsg = "Namste";
//     function greet2(){
//         this.name = "nk";
//     }
//     greet2();
// }
// const obj = new greet();
// console.log(obj);
// (in normal mode obj will not have 'name' property -> internal function's this is global this)

// ---------work fine --------
function hello() {
  this.name = "Navneet";
  const hello2 = () => {
    this.sname = "nk";
  };
  hello2();
}
const obj2 = new hello();
console.log(obj2);

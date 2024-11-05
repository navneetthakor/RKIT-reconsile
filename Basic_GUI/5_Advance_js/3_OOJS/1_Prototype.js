//---------- Understanding prototype --------
// - Javascript is prototyped language not object-oriented 
// - prototype is inheritance model of javascript 
// - it have following features 
        // -> Dynamic prototyping   (modify prototype at any point of time) 
        // -> Prototype chaining 
        // -> new keyword with Constructor function    (discussed in ./2_prototype_with_func.js)

// --------- Let's see prototype with { string, Object and, Array} ----------
// 1> string ----- 
let str = "hello";

String.prototype.sayName = function(){
    console.log(`${this.toString()}`)
}

// if we call it before defining prototype then it will give error
// prototype chaining is used here 
str.sayName(); 

// 2> Object -----
Object.prototype.gn = "GoodNight";

const obj = {};
console.log(obj.gn);

// one more way to add prototype in objects
const base = {
    name: "Navneet",
    __proto__: {
        myname: myname
    }
}

function myname() {
    console.log(`my name is ${this.name}`);
}

base.myname();

// creating new object with considering 'base' as prototype 
const child = Object.create(base);
child.name = "Mayur";
child.myname();


// 3> Arrays -----
const arr = [1,2,3];

Array.prototype.getFirst = arr[0];

console.log(arr.getFirst);
console.log(arr.gn) // because object is perent of all 

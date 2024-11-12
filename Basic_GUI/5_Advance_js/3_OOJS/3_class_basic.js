// Class is syntactic sugar over prototyped model added in ES6 (2015)
// internally prototyped model is executed for us 

// Why it comes ?
    // -> because many developer comes from different language backgournds like 
    //    C++, java etc. Where class based model is very famous 

class Class{
    static banches = 15;

    constructor(){
        console.log("Class is created\n");
        this.capacity = 30;
    }

    sayCapacity(){
        console.log(`Capacity of this class is ${this.capacity}`);
        console.log(`Banches of this class is ${this.banches}\n`);
    }
}

// creating object 
const class1 = new Class();
class1.sayCapacity();

class1.capacity = 10;
class1.banches = 10; // property for class1 object
class1.sayCapacity();

console.log("Banches of class :", Class.banches, "\n\n");

class School extends Class{
    constructor(){
        super();
        console.log("School is created");
    }
}

const s1 = new School();
console.log(s1.capacity);

// --------
// -> But through this syntax (class and extend) we can't perform multiple inheritance 
// -> for that we can do like following 
// -> params : (target, ...source)
// Object.assign(School.prototype, Class.prototype, MyClass.prototype) 
// how before ES6 JS developer uses class-object kind of behaviour 
function Class(){
    console.log("class is created\n");
    this.capacity = 30; // instance property, -> sepratly created for each instance
}

Class.banches = 15; //static property -> belongs to class not instances
Class.prototype.sayCapacity = function(){
    console.log(`Capacity of this class is ${this.capacity}`);
    console.log(`Banches of this class is ${this.banches}\n`);
}

// creating object 
const class1 = new Class();
class1.sayCapacity();

class1.capacity = 10;
class1.banches = 10; // property for class1 object
class1.sayCapacity();

console.log(`Banches of class : ${Class.banches}`)


// ----------- Let's extend it for one more class ---
function School(){
    console.log("School is created\n");
    this.class = new Class();
}

const s1 = new School();
console.log(s1.class.capacity);
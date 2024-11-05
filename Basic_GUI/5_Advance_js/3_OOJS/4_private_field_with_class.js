// conventionally (before ES2020), we were using "_" to indicate private field 
    // -> but this is just intension of developer
    // -> JS doesn't enforce anything
    // exmpale: 
            // class have intensional private field called name as  "_name"
            // but user can access it directly with the help of "obj._name"

// ES2020 introduced "#" to declare private fields 
    // -> This enforces private field 
    // -> example: 
            // "this.#name" is the private field 
            // direct access to it will give error like : "obj.#name"
    // -> Getter and setter is only way to allow external environment to access private fields 

class Animal{
    // declare private fields (*required)
    #name;

    constructor(name){
        this.#name = name;
    }

    get name(){
        return this.#name
    }

    set name(newname){
        this.#name = newname;
    }
}

const obj = new Animal("BigDog");
console.log("Animal name : ", obj.name); // accessed via getter of name

// setting name 
obj.name = "Lion";  // accessed via setter of name
console.log("Animal name : ", obj.name);

// below will give error 
// console.log(obj.#name)
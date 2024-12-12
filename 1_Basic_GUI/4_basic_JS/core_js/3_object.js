// 3 ways to create object

// first with object literals {}
const myObj = {
  "name is": "Navneet",
  myid: "21CP031",
};

// second with Object constructor
const myObj2 = new Object();

// third with any object as prototype
const myObj3 = Object.create(myObj);

// accessing values

// with "."
console.log(myObj.myid);
// - it has limitation as following will result in error
// console.log(myObj."name is")

// better synatax  "[]"
console.log(myObj["name is"]);

// -------- Advance stuff -----------
// -> How to make any property of object non editable?
console.log("\n----- phase 2 -----");
Object.defineProperty(myObj, "myid", {
  writable: false,
  enumerable: true,
});

myObj.myid = "125";
myObj["name is"] = "nk";
console.log(myObj);

// -> how to make whole object non editable?
console.log("\n----- phase 3 -----");
Object.freeze(myObj);
myObj.newProp = "hello";
myObj["name is"] = "Meet";
console.log(myObj);


// how to get details about any property of the object?
console.log("\n----- phase 3 -----");
console.log(Object.getOwnPropertyDescriptor(myObj,"myid"));
  // this returns object that contains descriptor for given key of the object
  // result => 
  /*  {
      value: '21CP031',
      writable: false,
      enumerable: true,
      configurable: false
    }
    */

// -> all properties in above 3 phases are static properties of Object and that can't be inherted through prototype

console.log(Object.getOwnPropertyDescriptors(myObj))
  // result => 
  /*
  {
    'name is': {
      value: 'nk',
      writable: false,
      enumerable: true,
      configurable: false
    },
    myid: {
      value: '21CP031',
      writable: false,
      enumerable: true,
      configurable: false
    }
  }
  */

// Object key have one attribute called as "configurable"
// -> default it's true
// -> once we set it to false, then except value and writable attribute we can't change anything else, for that key
const obj = {
  name: "navneet"
}

Object.defineProperty(obj,"name",{
  configurable: false
})

//work fine
Object.defineProperty(obj,"name",{
  writable: false,
})

// through error 
Object.defineProperty(obj,"name",{
  enumerable: false,
})


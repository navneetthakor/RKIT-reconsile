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

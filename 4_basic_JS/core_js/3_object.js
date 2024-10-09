// 2 ways to create object 

// first with object literals {}
const myObj = {
    "name is": "Navneet",
    myid : "21CP031"
}

// second with Object constructor 
const myObj2 = new Object();

// accessing values 

// with "."
console.log(myObj.myid);
    // - it has limitation as following will result in error 
    // console.log(myObj."name is")

// better synatax  "[]"
console.log(myObj["name is"]);
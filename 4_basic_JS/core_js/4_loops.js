// following are the four loops available in javascript
// for iterable data-structures 

// used for illustraion 
let myName = "Navneet";
const myArr = [10,20,30,40];


//1. normal for loop 
console.log("Normal loop : ", "String")
for(let i=0; i<myName.length; i++){
    console.log(myName.charAt(i));
}

console.log("Normal loop : ", "Array")
for(let i=0; i<myArr.length; i++){
    console.log(myArr[i]);
}

// 2. for in loop 
console.log("For-in loop : ", "String")
for(let i in myName){
    console.log(myName[i]);
}

console.log("For-in loop : ", "Array")
for(let i in myArr){
    console.log(myArr[i]);
}

// 3. for of loop 
console.log("For-of loop : ", "String");
for( let i of myName){
    console.log(i);
}

console.log("For-of loop : ", "Array");
for( let i of myArr){
    console.log(i);
}

// 4. While loop 
console.log("While loop : ", "String");
let i = 0;
while(i < myName.length){
    console.log(myName[i]);
    i++;
}

console.log("While loop : ", "Array");
i = 0;
while(i < myArr.length){
    console.log(myArr[i]);
    i++;
}
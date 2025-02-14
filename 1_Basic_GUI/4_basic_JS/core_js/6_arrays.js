// Few ways to create Array in javascript 

// First with []
const arr = [31, "Navneet", 8.97]

// Second with Constructor
const arr2 = new Array();

// Third - Array from set of elements
const arr3 = Array.of(1,"nk");

// Fourth - Array from array like elements 
const arr4 = Array.from("Navneet");

// -> internlly, Arrays are stored as object with index as key 
// operations with array 
// -> As array is mutable Object, majority of the properites will modify calling Array object it self 

// 1. push 
// to add element at the end of array 
arr.push("nk");
console.log(arr); // result => [31, "Navneet", 8.97, "nk"]

// 2. pop
// to remove element from end 
arr.pop() // it returns poped element 
console.log(arr); // result => [31, "Navneet", 8.97]

// 3. unshift 
// to add element at the begining 
arr.unshift("unshift");
console.log(arr) // result => ["unshift", 31, "Navneet", 8.97]
    // -> generally, developer avoids it becuase it causes, shift entire array by one position to right 
    // which is overhead 

// 4. shift 
arr.shift() // returns first shifted element
console.log(arr) // result => [31, "Navneet", 8.97]

// 5. join 
// join elemets and returns in string format 
// by default seprator is comma, but for customization pass it as paramter 
console.log(arr.join('-')) // result => '31-Navneet-8.97'

// 6. slice 
// returns part of array based on given params 
const sliceExmp = arr.slice(1,3);
console.log(sliceExmp); // result => ["Navneet", 8.97]
    // -> ending index is optional
    // -> ending indexed element will not be included 
    // -> it creates new Array, so any further modification in any of them will not be reflect in other one

// 7. splice 
// it ommits specified number of elements from specified index 
// optionally we can add elements from start index of splice.
const spliceExmp = arr.splice(1,1,12,13,14); // (startindex, deleteCount, itemsToAdd)
console.log(spliceExmp) // result =>  ["Navneet"] (deleted iteam)
console.log(arr) // result => [31,12,13,14,8.97]

// 8. includes 
// returns true if element exist in array, otherwise false 
// params : (value, startingIndex)
console.log(arr.includes(12,0)) // result => True

// 9. indexOf
// return index of specified element 
// params : (value, startingIndex)
console.log(arr.indexOf(31, 0)) // result => 0
    // -> element not exist then it will return '-1' as result 

// 10. map 
// used to create a new array by applying a specific function to each element of the current array
const mapExmp = arr.map((val, key, arr) => {
    return "map : " + val;
})
console.log(mapExmp); // result => [ 'map : 31', 'map : 12', 'map : 13', 'map : 14', 'map : 8.97' ]
console.log(arr); // result => [ 31, 12, 13, 14, 8.97 ]
    // -> return statement returns value that will be placed at the index in new array 
    // -> if return statement is missing then value => 'undefined'

// 11. filter 
// use to create a new array with elements that pass a test defined by the callback function.
const filterExmp = sliceExmp.filter((val,key,arr) => {
    return (typeof val) === 'number'
})
console.log(filterExmp); // result => [ 8.97 ]
console.log(sliceExmp); // result => [ 'Navneet', 8.97 ]
    // -> here if return value is true then, that value will be added in resulting array 
    // -> if we doesn't return anything then it will be considered as 'undefined' which implice false, so value won't be taken
    // -> if we return non-boolean value then it will be converted to boolean value and then appropriate decision will be taken 
            // --> sample conversions
                // 1 => true; 0 => false
                // undefined => false; null => false
                // "" => false
                // "navneet" => true

// 12. reduce 
// used to reduce entire array to single value 
// params : (callback, initial_val_of_acc)
const reduceExmp = arr.reduce((acc, val, key, arr)=>{
    return acc + val;
},0)
console.log(reduceExmp); // result 78.97

// 13. foreach 
// used to iterate over each element of the array once in order 
arr.forEach((val,key,arr)=>{
    console.log([key,val]);
})
    // -> given callback will be applied to each element once 
    // -> if it encounters return statement in callback then, it will exit just for current Element, and go to the next one

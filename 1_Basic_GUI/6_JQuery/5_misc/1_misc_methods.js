// below are methods which i am not able to classify in any of above section 

// 1) toArray()
// -> returns array of selected elments 
// Example: 
    const divArr = $('div').toArray()

// 2) each()
// -> this method is equivalant of 'forEach' available for js arrays 
// -> do not return anything 
// Syntax: 
    // 1) for DOM elements 
    $(selector).each(function(index,element){});
        // -> index: position of current element in selected elements 
        // -> element: current element 

    // 2) for array and DOM ele 
    $.each(arr, function(index, value){});
// -> key difference: js forEach()
    // -> Supports breaking with return false, which is not possible in forEach
    // -> 'this' points to the current ele 

// 3) map()
// -> applies function to each element of collection and returns new JQuery object 
// -> returns jquery object 
    // 1) for DOM elements     
    $(selector).map(function(index,element){});
        // -> index: position of current element in selected elements 
        // -> element: current element 
    
    // 2) for array and DOM ele 
    $.map(arr,function(value,index){})
// -> key difference: js map()
    // -> If the callback returns null or undefined, those elements are excluded from the result.
    // -> 'this' points to the current ele 

// 4) grep()
// -> it works like filter 
// -> only for javascript arrays 
// -> returns js array 
// Syntax: 
    $.grep(array, function(value, index) {}, invert); 
    // -> if return is true or equivalant true -> element will be selected else ommited 
    // -> invert : boolean -> is set to true the behaviour will be altered 
// -> Key difference form : js filter()
    // -> it supports invert functionality 

// 5) merge()
// -> it takes two arrays, and modifies first array 
// Example: 
const arr1 = [1, 2, 3];
const arr2 = [4, 5, 6];
$.merge(arr1, arr2);
console.log(arr1); //result: [1, 2, 3, 4, 5, 6]

// -> key Differences : js concat()
    // -> it modifies first array instead of returning new array 
    // -> takes only two array as input 


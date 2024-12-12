// following methods helps to selecte element from group of elements 

// 1) first()
// -> returns the first element 
    $('div').first();

// 2) last()
// -> returns last element 
    $('div').last();

// 3) eq(index)
// -> this returns element with specified index 
// -> index starts with 0
    $('div').eq(3); // this will return 4th element (which have index 3)

// 4) filter(criteria)
// -> elements which matches criteria will be returned 
// Example:
    $('div').filter(".hello"); // div elements which have 'hello' class

// 5) not(criterai)
// -> elements which not matches criteria will be returned 
// Example: 
    $('div').not('.hello'); // div elements which not have 'hello' class
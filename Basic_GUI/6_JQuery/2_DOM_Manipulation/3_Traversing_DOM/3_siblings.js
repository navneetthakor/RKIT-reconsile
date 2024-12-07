// 1) siblings()
// -> this method returns all the siblings of the selected element
// -> optionally we can pass filter to filterout choices  
// Example: 
    // i) $(selector).siblings()
    $('div').siblings();

    // ii) $(selector).siblings(filter)
    $('div').siblings('span'); // all siblings which are 'span'

// 2) next()
// -> returns only first next sibling element only
// Example:
    // i) $(selector).next()
    $('div').next();

// 3) nextAll()
// -> returns all the next sibling elements 
// Examle: 
    // i) $(selector).nextAll();
    $('div').nextAll();

// 4) nextUntil()
// -> returns all the next sibling elements between selected and specified element
// Example:
    // i) $(selector).nextUntil(filter)
    $('div').nextUntil('span'); // all next siblings until reaches 'span'

// 5) prev 
// -> returns previous sibling element 
// example:
    // i) $(selector).prev()
    $('div').prev();

// 6) prevAll()
// -> reutrns all the previous sibling elements
// Example: 
    // i) $(selector).prevAll()
    $('div').prevAll();

// 7) prevUntil()
// -> returns all the previous sibling elements between selected and specified element 
// Example: 
    // i) $(selector).prevUntil()
    $('div').prevUntil();
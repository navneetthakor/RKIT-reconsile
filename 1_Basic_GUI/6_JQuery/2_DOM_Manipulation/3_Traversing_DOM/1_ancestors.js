// following are the methods to find ancestors strting from current element 

// 1) parent()
// -> it returns only direct parent of current element 
// Syntax: 
    // $(selector).parent();
// Example: 
    $('div').parent();

// 2) parents()
// -> it returns all the ancestor elements of the selected element, upto the document's root element 
// Syntax:
    //- $(selector).parents();
    // - $(selector).parents(filter);
// Example:
    $('div').parents();
        // return all the ancestors 
    $('div').parents('div') 
        // will return only those ancestors which are 'div'

// 3) parentsUntil()
// -> it returns all the element until specified element reached
// Syntax:
    // $(selector).parentsUntil(filter);
// Example:
    $('div').parentsUntil('main');
        // return all the ancestors of div upto 'main' ('main' not included)
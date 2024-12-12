// Following are the methods to modify the CSS classes attached with element 

// 1) addClass()
// -> add classes to selected element if not present 
// -> Space seprated for multiple classes at time 
// Example:
    $('div').addClass('bgColors primaryHeading')

// 2) removeClass()
// -> removes classes from the selected elements if present
// -> Space seprated for multiple classes at a time 
// Example:
    $('div').removeClass('bgColors hello');

// 3) toggleClass()
// -> to toggle classes for selected elements 
// Example: 
    $('div').toggleClass('bgColors hello')
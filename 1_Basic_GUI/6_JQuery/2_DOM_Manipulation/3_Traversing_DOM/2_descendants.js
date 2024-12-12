// below methods will help us to traverse all the descedants of the selected elements

// 1) children()
// -> it returns direct childrens of selected element 
// Syntax with Examples:
    // i) $(selector).children()
        // all direct childrens returned 
    $('div').children()

    // ii) $(selector).children(filter)
        // returns direct childs which matches filter passed
    $('div').children('div.hello')
        // all direct child of div which are div and have class hello

// 2) find()
// -> returns the descendants upto the last element 
// -> if we not pass any selector/filter in find() then resultant JQuery object will not have any DOM element reference 
// examples:
    // i) return all the descendants 
    $('div').find('*');

    // ii) return all the descendants which are 'span'
    $('div').find('span');
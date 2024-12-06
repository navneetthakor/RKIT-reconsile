// JQuery provides two main methods to remove content/element

// 1) Remove() 
// -> It removes selected element + all its childern elements 
// -> it have two variants 
    // i) simple method
    $('div').remove()

    // ii) method with any valid selector as input 
    $('div').remove('.test')
        // -> it will look for elements from $('div') which qualifys selector criteria and
        //    performs remove() method on them 
        // -> in our case: all 'div' elements with 'class=test'

// 2) empty()
// -> this method removes all the children elements only 
// -> example :
        $('div').empty()
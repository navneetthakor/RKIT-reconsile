// css() method used to get or set css property 

// 1) get property value 
// Syntax: 
    // $(selector).css('property-name');
// Example: 
    $('div').css('color') // result: black

// 2) set property value 
// Syntax: 
    // i) $(selector).css('property-name', 'value') // for single property at a time 
    $('div').css('border', '2px solid red');

    // ii) $(selector).css({'prop1':'value1', 'prop2':'value2', ...}) // multiple a time
    $('div').css({'border':'2px solid red', 'color': 'white'});
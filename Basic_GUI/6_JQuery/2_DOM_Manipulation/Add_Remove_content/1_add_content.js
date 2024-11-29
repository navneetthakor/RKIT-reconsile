// Below are some of the useful method to add content in the element 
// Note: here we are modifying part of the content, instead of chaning entire innerHTML

// Let content is following:
/*
<div>hello</div>
*/

// 1) append()
    // -> insert content at the end of selected element 
    // -> example: 
    $('div').append("<b>added part</b>")
        // -> result: 
            // <div> hello <b>added part</b> </div>

// 2) prepend()
    // -> insert content at the begining of the selected element 
    // -> example:
    $('div').prepend("<b>added part</b>")
        // -> result: 
            // <div> <b>added part</b> hello </div>

// 3) after()
    // -> inster content after the selected element 
    // -> example:
    $('div').after("<b>added part</b>")
        // -> result: 
            // <div>hello</div>
            // <b>added part</b> 

// 4) before()
    // -> inster content before the selected element 
    // -> example:
    $('div').before("<b>added part</b>")
        // -> result: 
        // <b>added part</b> 
        // <div>hello</div>


// -> Following are the ways to create elements in HTML
    // 1) using JQuery
    let ele1 = $('<div></div>').text("my name is navneet")

    // 2) using DOM methods 
    let ele2 = document.createElement('div')
    ele2.innerHTML = "my name is navneet"

    // 3) using string 
    let ele3 = "<div>my name is navneet</div>"

// -> Here, we can pass several elements to getter in any function to add multiple elements at a time 
    // -> example:

    $('div').append(ele1, ele2, ele3)
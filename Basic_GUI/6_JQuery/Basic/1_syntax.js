// JQuery is built for 'selecting' element and performing 'action' on them 

/*
1) syntax is: 
    $('selector').action()

    -> $        : to access JQuery or it defines JQuery
    -> selector : to locate HTML element. It uses CSS selectors, that's why accessing perticular element is so easy
    -> action   : that will perform on element

*/

/* 

2) JQuery object in brief
    -> When we select any element with JQuery it returns JQuery object which is kind of fixer of
        Array + DOM Collection + JQuery methods (developed with javascript)

    -> see the JQuery object that i consoled in the browser tab.
        "console.log($('div'))"

        output -> 
        ce.fn.init
        0: div.colorPallet.d-flex
        1: div.w-100
        2: div.w-100
        3: div.w-100
        4: div.w-100
        5: div.w-100
        6: div.w-100
        7: div.w-100
        length: 8
        prevObject: ce.fn.init {0: document, length: 1}
        [[Prototype]]: Obj

        -> here we have 2 layer of prototype means
            1. Javascript Base Object
                    |
            2. JQuery hidden Object 
             (provides all the methods in prototype)
                    |
            Visible JQuery Object
            
*/

/* 
3) ready method

    -> JQuery provides 'ready' method on document it self to make sure that,
        - Javascript written in this method will only fires when entire document is loaded.
    -> it have 2 syntaxes
        1. $(document).ready(function(){
            // write code here
        })
        
        2. $(function(){
            //write code here
        })

    -> Here, behind the scene, JQuery attches event listener to 'DOMContentLoaded' event
        - It fires once the initial HTML is loaded but, before the external resources like images were finish the loading.
*/


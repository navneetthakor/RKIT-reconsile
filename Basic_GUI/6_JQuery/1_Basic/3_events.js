
//Brief about Events
/*
-> Events: actions performed by user which a web page can respond is called as action.

    Mouse Events	Keyboard Events	    Form Events	        Document/Window Events
    |               |                   |                   |
    click	        keypress	        submit	            load
    dblclick	    keydown	            change	            resize
    mouseenter	    keyup	            focus	            scroll
    mouseleave	 	                    blur	            unload

*/


//how to place handlers for event
/* 
-> JQuery have followsing syntax
    1) $(selector).action(function(){})
        -> where action is the event in our case.
        -> For an example:
*/
            $('div').click(function(){
                // write code here
            });

/* 
2) $(selector).action()
-> this not attaches any event handler to the elements
instead it programatically fires the event (here action is event)
-> For an example:
*/
            $('div').click(); 



//'on()' method
//-> on method attaches on or more event handlers
//-> It has following ways 

  //  1)
    $("p").on("click", function(){
        // write code here...
    });

 //   2)
    $('div').on({
        click: function(){
            // code here
        },
        

        mouseenter: function() {
            // code here
        }
    })



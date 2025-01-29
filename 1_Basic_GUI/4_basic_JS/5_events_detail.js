// Priority of event-handlers 
// 3. addEventListener
// 2. on (property of js) (it can ovrride inline)
// 1. html attribute (like onclick)

// Execution of event handlers
// ->It has three phases

// 1. Capture phase
        // --> here when any event happens like, when we click on button then, action will be passed down in DOM, until it reaches target element 
        // --> usually it's not visible 
        // --> example: (button click in div tag inside body)
                // html -> body -> div -> button 

// 2. Target phase 
        // --> Actual phase where, event handlers corresponding to target element will be executed 

// 3. Bubbling phase 
        // --> here, evert backpropogate through DOM 
        // --> any handler attached with closing parent for same event will be executed 
        // example: (same as above )
                // button -> div -> body -> html 

        // --> to prevent bubbling we can use following in event handler
            // - to prevent bubbling to parent 
            // event.stopPropagation(); 

            // - to prevent anyother handler to fire in order 
            // event.stopImmediatePropagation();
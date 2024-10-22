// Three ways to create variables in Javascript 

//  1) using "var" keyword 
var name = "Navneet";
    // -> but it's funcitonal scoped so not to used it.

// 2) using "let" 
let village = "Khankuva";
    // -> compare to "var" it gives following 
        // - it's block scoped
        // - we can't define variable with the name already exists in the code. 
        // even following will result in the error
                // - let name = "Navneet"
                // - var village = "k";

const id = "21CP031";
    // -> it's block scoped 
    // -> prevents re-assingments, not mutability.
    // -> redeclaration will result in arror
    
// new type of declatraion 
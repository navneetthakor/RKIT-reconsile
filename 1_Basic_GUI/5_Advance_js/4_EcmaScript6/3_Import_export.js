// used to share code between different files and modules 


// --------Export 
// it have following variants 
// 1) Named export 
        // -> allows us to export multiple items 
        // -> example :
            export const PI = 3.14;

// 2) Default export 
        // -> allows to export single value 
        // -> example:
            const PI2 = 3.14;
            export default PI2;

// ----------Import 
// Bringing the code 
// 1) for named exports
        // -> here exact same name is required as in base file 
        // -> mport { PI } from './sample.js';

// 2) for default exports 
        // -> here we can give it any name and {} not reqired 
        // -> import greet from './greet.js';
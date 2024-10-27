// Mainly two broad classifications of the functions 
    // - Syncronous function
                // --> Executed line by line 
                // --> Blocking in nature (means JS engine can't move further until program completes)
            
    // - Asyncronous function
                // --> Non-blocking in nature 
                // --> web API (in browser) and Node API (in nodejs) helps execute this functions

// Following are the ways to create Asyncrounous functions 

// 1> ------- Using callback -------
//-> we can pass callback to Asyncrounous functions [This functions are provided by JS/NodeJS/Browser by defult], so whenever this functions completes its task callback will be executed.
//-> Execution process: 
            // --> Async function passed on to web/node api to compelete execution
            // --> after it put's callback to the callback queue
            // --> whenenver event loop founds call stack to be empty it passes callback to the callstack
            // --> callback is executed

// -> Examples:

const timestamp = setTimeout(()=>{
    console.log("hello");
}, 3000)


// 2> ------- Using promises -------
// -> Promise is the object in JS which have three states : Pending, Fulfilled, Rejected.
// -> Promise is handled by web/node api
// -> Execution is similar to above but only changes is that, dependent part will be pushed to high priority queue instead of normal callback queue 

// -> Example:
const result =  fetch("https://api.github.com/users/navneetthakor", {
    method: "GET",
})

//this part will be put in High priority queue once promise is resolved
result.then((data)=>{
    return data.json();
}).then((data)=>{
    console.log(data);
})

// 3> ------- Using async/await -------
// -> Async/await is the methodology in javascript to define asyncronous function 
// -> This function always returns promise 
        // --> "async" indicates that function may contain some asyncronous code 
        // --> "await" used to push the execution of async function until perticular Promise resolves 

// -> execution with-in function 
        // --> first this function pushed to call stack 
        // --> until async operation comes, function executed normally 
        // --> once await is encountred, it saves state, removes it from call stack and handover task to web/node api
        // --> meanwhile, JS engine executes further code 
        // --> once promise resolves, it pushes remaining code of that async function with saved state to high priority queue
        // --> Whenever event loop founds call stack is empty, it pushes our function once again on to the call stack 

// -> Example: 

console.log("\n------------- Async/await ---------\n")
async function Hello() {
    await new Promise((res,rej)=>{
        setTimeout(() => {
            console.log("Hello");
            res();  
        },3000)
    })
    
    console.log("Hello2");
    
}

Hello().then(()=>{
    console.log("Async Hello complted")
})
console.log("Outer Hello");

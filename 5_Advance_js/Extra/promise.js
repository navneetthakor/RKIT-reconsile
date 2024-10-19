// Promise is object not function 
// it has 3 states 
    // - pending (initial)
    // - fulfilled (success)
    // - rejected (failure)

const samplePromise = new Promise((resolve, reject)=>{
    setTimeout(()=>{
        let condition = false;
        if(condition){
            resolve("completed");
        }
        else{
            reject("rejected");
        }
    },1000)
})

// ways to consume promise 
// 1. simpy usting then and catch 
// samplePromise.then((outcome)=>{
//     console.log(outcome);
// }).catch((error)=>{
//     console.log(error);
// }).finally(()=>{
//     console.log("task completed");
// })

// 2. using async - await 
async function handlePromise() {
    try{    // always use try-catch as promise may reject

        const res = await samplePromise;
        console.log(res);
    }catch(error){
        console.log(error)
    }
}

handlePromise();
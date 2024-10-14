
// localStorage and sessionStorage are added in html5 
// new and better way to store data in client browser compare to cookie 


// ------------- Local Storage ----------------------------------------
// localStorage stores data with no expire date 
// data will persists until user clears that 
// it stores data in key-value pair 

// 1. store data 
localStorage.setItem("username", "Navneet");
    // - it expects key and value both as string 
    // - for storing object we can use JSON.stringify() method 

// 2. retriving data 
let local_storage_data = localStorage.getItem("username");
    // - this method always returns string if key-value exists, otherwise returns null.
    // - don't forgot to convert extracted data to appropriate form 

// 3. Modify data 
localStorage.setItem("username", "nk");
    //- same way as how we added new data, but since that key already exists so it will modify that one. 

// 4. Remove data 
localStorage.removeItem("username");


// ---------------- Session Storage ----------------
// Session storage is simillar to Local storage but, only difference is this will lost when 'tab' is closed 
// methods are same as local storage 
//- By default when client-browser closes connection with server, then server have no way to recognize user when he/she visit again 
//- Cookies is one of way to store data in client browser, that solves this problem

// ---- (don't run below code it's meant for browser not node js ok) -----
// 1. how to store cookie 
const date = new Date();
date.setTime(date.getTime() + (5*24*60*60*1000)); //miliseconds
document.cookie = `username=nk; expires=${date.toUTCString()}`;
    // - above line will through error, as it's not in brower so no document object is present.
    // - setting expire date is important, otherwise when browser closes cookie will be removed

// 2. Modify cookie
// if any existing cookie have same name and path (if given) as new one then, 
// browser will modify existing one 
    // - here name means any attribute like username, sessionId etc...
document.cookie = `username=Navneet; expires=${date.toUTCString()}`;

// 3. remove cookie 
// it's pretty simple, just modify expiry date to past date 
date.setTime(date.getTime() - (2*24*60*60*1000));
document.cookie = `username=Navneet; expires=${date.toUTCString()}`;

// 4. get specific cookie 
// document.cookie stores all cookie for same website in a key-value pair format in string with ';' seprated
// example: "username=nk; email=nk@nk.com; sessionId=12345";
// so we can split them in array and look for specific value 


// api -> medium for communication between two applications 


// how fetch api works 
// fetch internally creates object DATA which is Promise Object,
// this DATA object is not accesseble externally.
// now, what happen is that if fetch gets response then it will set the state of
// Data boject as fulfilled and put resulting data in response object.
// and if fetch is not able to fetch data then it will set state of DATA object 
// to rejected and throw error.
// remember 404 is not error for DATA object as it's kind of response for it.
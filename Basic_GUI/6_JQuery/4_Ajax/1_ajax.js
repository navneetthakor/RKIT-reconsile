// AJAX
// -> Asynchronous javascript and XML
// -> basically it loads data in backgound and updates part of webpage (instead of loadding entire page again)

// following are some of important methods for AJAX

// 1) load()
// -> this method loads data from server and puts it in selected element
// -> it sends 'get' request to server
// Syntax:
// $(selector).load(url, data? {key:value,}, callback?);
// -> url from where data needs to be fetch
// -> optional data of key, value pair and callback which will execute upon the completion of load method
// Example:
$("div").load("nk.com/getSuccess", { method: "get" }, function(responseTxt, statusTxt, xhr){});
// -> nk.com/getSuccess?method=get

// -> here we can pass 'selector' to the url, seprated by space. Which will work as filter and extract specific element according to selector from loaded content and append it to the element
// Example:
$("div").load("nk.com/getSuccess #main");
// -> only element with id '#main' will be loaded

// 2) $.get()
// -> it sends get request to the server
// Syntax:
// $.get(url, data?, callback(data,status)?);
// -> optional callback will be executed if request successeds
// Example:
$.get("hello.com/hello", function (data, status) {
  console.log(data);
});

// 3) $.post()
// -> it sends post request
// Syntax:
// $.post(url, data?, callback(data, status)?)

// 4) $.ajax()
// -> it is versatile and supports gretter functionalities
// Example:
    $.ajax({
      url: "your_url",
      type: "GET", // or "POST", "PUT", "DELETE", etc.
      data: {
        param1: "value1",
        param2: "value2",
      },
      success: function (response) {
        // Handle the successful response
      },
      error: function (xhr, status, error) {
        // Handle errors
      },
    });

// -> it supports several headers too like 
    // dataType - the data type expected of the server response 
    // contentType etc... 

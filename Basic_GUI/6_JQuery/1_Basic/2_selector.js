/*
For selectors we uses same selectors as CSS
    /-> except it doesn't support pseudo-element selector

few are the below:
1) id selector
$('#mydiv')

2) class selector
$('.mydiv')

3) element selector
$('div')

4) all the elements
$('*')

5) current element
$(this)

6) element with class
$('div.myclass')

7) element under another one
$('div p')
$('div > p')

8) any pseudo-classes
$('div p:first') // select the first p element

9) select element with particular attribute
$("[href]") // all elements with 'href' attribute
$("a[href = '_blank']") // all 'a' elements with href value set as '_blank'

etc..
*/
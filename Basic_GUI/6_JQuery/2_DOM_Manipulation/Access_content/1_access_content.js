// JQuery provides bunch of methods to access and modify content of html element

// Below are the important methods to get & set content
// 1) text() 
    // -> set or get text content of element 
    // -> example:
    //     -> get:
                $('div').text()
    //     -> set:
                $('div').text('My name is Navneet')
                // -> Result 
                    // <div>My name is Navneet</div>
    //     -> set with CallBack:
                $('div').text(function(i, orgText){
                    return orgText + i;
                })
                // -> here, i = index of current element in list of selected elements
                // -> orgText = old value of the text
                // -> This both values will be provided by JQuery it self 
                // -> we need return desired value 

// 2) html()
    // -> get innerHTML (+ markup if present in content) of selected element 
    // -> it sets innerHtml only 
    // -> example: 
            // -> get:
                $('div').html()
            // -> set:
                $('div').html('My name is Navneet')
            // set with CallBack:
                $('div').html(function(i, orgHtml){
                    return orgHtml + " new HTML : " + i;
                })

// 3) val()
    // -> set or get value (for elements which have this property like input elements)
    // -> example:
            // -> get:
                $('#fname').val()
            // -> set:
                $('#fname').val('Navneet')
            // -> set with CallBack: 
                $('fname').val(function(i,orgVal){
                    return orgVal + " Added : " + i;
                })

// 4) attr()
    // -> get & set value of perticular attribute of the element 
    // -> example:
            // -> get: 
                $('input[type="text"').attr('name')
            // -> set (single attribute):
                $('input[type="text"').attr('name', "fname")
            // -> set (Multiple attribute)
                $('input[type="text"').attr({
                    "name" : "fname",
                    "value" : "Navneet"
                })
            // -> set with CallBack: 
                $('input[type="text"').attr('name', function(i, orgAttr){
                    return orgAttr + ' : new ' + i;
                })
                
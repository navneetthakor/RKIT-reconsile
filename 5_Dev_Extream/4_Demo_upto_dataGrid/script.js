
$(() => {
    $('#fname').dxTextBox({
        tabIndex: 1,
        placeholder: 'Navneet Kumar',
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'trainer\'s name is required'
        }]
    });


    $('#num_of_record').dxTextBox({
        tabIndex: 5,
        placeholder: 'xxx',
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'EID is required'
        }, {
            type: 'numeric',
            message: "EID must be numeric"
        }]
    });

    $('#you_agree_checkBox').dxCheckBox({
        text: 'You are agree that your feedback is unbiased.'
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'you have to agree'
        }]
    })

    $('#submit_button').dxButton({
        width: '60%',
        text: 'submit',
        type: 'default',
        stylingMode: 'contained',
        useSubmitBehavior: true,
    });

    $('#myForm').submit((e) => {
        e.preventDefault();
        $('#myForm')[0].reset();
        $('#mainContainer1').addClass('d-none');
        $('#mainContainer2').removeClass('d-none');

        // load store and set value of username 
        store.load()
            .done((d) => $("#grid_demo").dxDataGrid("instance").refresh());
        let username = $('#fname').dxTextBox('instance').option('text');
        let username_text = `Hello ${username}!`

        $('#name_text_box').text(username_text);
    })


    //    -------  main2 -------
    let username = $('#fname').dxTextBox('instance').option('text');
    let username_text = `Hello ${username}!`

    $('#name_text_box').text(username_text);

    $('#back_button').dxButton({
        text: 'Back to Home',
        type: 'default',
        stylingMode: 'contained',
        onClick: (e) => {
            $('#mainContainer1').removeClass('d-none');
            $('#mainContainer2').addClass('d-none');
            initial_lenth = -1;
        }
    })

    //url to maker request to mockapi
    const url = 'https://67bd886c321b883e790cd96f.mockapi.io/api/dataGrid';
    let initial_lenth = -1;
    // custom store to load data from mockapi 
    let store = new DevExpress.data.CustomStore({
        key: 'id',
        loadMode: 'processed', // default: 'processed', other: 'raw'

        // to load data from source 
        load: (options) => {
            let result = $.Deferred();

            // load data
            $.ajax({
                url: `${url}/student_data`,
                method: "GET",
                success: function (response) {
                    console.log('data loaded')

                    // see initial length of dataset 
                    if(initial_lenth === -1) initial_lenth = response.length;

                    // how much seed data user wants
                    let num_of_record = Number($('#num_of_record').dxTextBox('instance').option('text'));
                    
                    // logic to display seed data + newly added data 
                    let finalArray = response.slice(0, num_of_record)
                    let temp = response.slice(initial_lenth);
                    temp.forEach(element => {
                        finalArray.push(element)
                    });
                    
                    // resolve it
                    result.resolve(finalArray);
                },
                error: function (xhr, status, error) {
                    // Handle errors
                    alert('some error occured');
                    console.error(error);
                    $('#mainContainer1').removeClass('d-none');
                    $('#mainContainer2').addClass('d-none');
                    result.reject(value);
                },
            })


            // return promise 
            return result.promise();
        },

        // to insert data in (client + server)
        insert: (value) => {
            let result = $.Deferred();

            // insert_dat
            $.ajax({
                url: `${url}/student_data`,
                method: "POST",
                contentType: 'application/json',
                data: JSON.stringify(value),
                success: function (response) {
                    console.log('inserted data')
                    result.resolve(value);
                },
                error: function (xhr, status, error) {
                    // Handle errors
                    alert('some error occured');
                    console.error(error);
                    result.reject(value);
                },
            })

            // return promise
            return result.promise();
        },

        // to update data in (client + server)
        update: (key, value) => {
            let result = $.Deferred();
            console.log("update : " + value)

            // update_data
            $.ajax({
                url: `${url}/student_data/${key}`,
                method: "PUT",
                contentType: 'application/json',
                data: JSON.stringify(value),
                success: function (response) {
                    console.log('updated data')
                    result.resolve(value);
                },
                error: function (xhr, status, error) {
                    // Handle errors
                    alert('some error occured');
                    console.error(error);
                    result.reject(value);
                },
            })

            // return promise
            return result.promise();
        },

        // remove data
        remove: (key) => {
            let result = $.Deferred();

            // remove_data
            $.ajax({
                url: `${url}/student_data/${key}`,
                method: "DELETE",
                contentType: 'application/json',
                success: function (response) {
                    console.log('deleted data')
                    result.resolve(key);
                },
                error: function (xhr, status, error) {
                    // Handle errors
                    alert('some error occured');
                    console.error(error);
                    result.reject(key);
                },
            })

            // return promise
            return result.promise();
        },

        byKey: (key) => {
            let result = $.Deferred();

            // get_recored
            $.ajax({
                url: `${url}/student_data/${key}`,
                method: "GET",
                contentType: 'application/json',
                success: function (response) {
                    console.log('byKey data')
                    result.resolve(response);
                },
                error: function (xhr, status, error) {
                    // Handle errors
                    alert('some error occured');
                    console.error(error);
                    result.reject(error);
                },
            })

            // return promise
            return result.promise();
        },


    });



    $('#grid_demo').dxDataGrid({
        dataSource: store,
        showBorders: true,
        showRowLines: true,
        columns: [
            { dataField: 'id', caption: 'ID' },
            { dataField: 'fname', caption: 'First Name' },
            { dataField: 'lname', caption: 'Last Name' },
            { dataField: 'fantcy_ponits', caption: 'Fantcy Points' },
        ],

        paging: {
            pageSize: 10,
            pageIndex: 0, // default : 0
        },

        pager: {
            showNavigationButtons: 'true',
            showPageSizeSelector: true, // default: false
            allowedPageSizes: [1, 3, 5, 10]
        },

        editing: {
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true,
        },

        searchPanel: {
            visible: true
        }
    })

})

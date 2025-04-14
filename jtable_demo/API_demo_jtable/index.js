
$(() => {
    const myUrl = 'http://localhost:5276/api/Author';

    // for edit popup
    window.openEditPopup = (rowData) => {
        $('#custom_user_form').removeClass('d-none');
        $('#custom_user_form').addClass('d-flex');

        $('#bname').val(rowData.a03F02);
        $('#bdesc').val(rowData.a03F03);

        $('#save').click(() => {
            $('#jtable_demo').jtable('updateRecord', {
                record: {
                    a03F01: rowData.a03F01,
                    a03F02: $('#bname').val(),
                    a03F03: $('#bdesc').val(),
                }
            });
            $('#cancel').click();
        })
    };

    window.openAddPopup = () => {
        $('#custom_user_form').removeClass('d-none');
        $('#custom_user_form').addClass('d-flex');

        $('#save').click(() => {
            $('#jtable_demo').jtable('addRecord', {
                record: {
                    a03F02: $('#bname').val(),
                    a03F03: $('#bdesc').val(),
                }
            });
            $('#cancel').click();
        })
    }

    $('#cancel').click(() => {
        $('#custom_user_form').addClass('d-none');
        $('#custom_user_form').removeClass('d-flex');
        $('#jtable_demo').jtable('load');
    })

    $('#jtable_demo').jtable({
        //#region general options (covere previously)
        title: 'The Student List',


        //#region  paging related settings 
        paging: true,
        pageSize: 2,
        pageSizes: [1, 2, 3, 5, 10],
        //#endregion

        //#region  sorting not working properly 
        sorting: true,
        defaultSorting: "a03F01 ASC",
        multiSorting: false,
        //#endregion

        //#region  column related settings
        columnResizable: true,
        columnSelectable: true,

        //#endregion

        //#region  selection related settings
        selectingCheckboxes: true,
        selecting: true,
        multiselect: false,
        selectOnRowClick: false,
        //#endregion

        //#region  miselenious

        //delete confirmation : open when we try to delete any row
        // default: true
        deleteConfirmation: true,

        // to select themes
        // other themes : jqueryui, lightcolor, basic
        theme: 'metro',

        // shows close button to close the table
        // default : false
        showCloseButton: true,

        //#endregion
        //#endregion

        // toolbar: {
        //     items: [
        //         {
        //             text: "Add/Update Book",
        //             click: function () {
        //                 var $selectedRows = $('#jtable_demo').jtable('selectedRows');
        //                 if ($selectedRows.length > 0) {
        //                     var rowData = $selectedRows.data('record');
        //                     window.openEditPopup(rowData);
        //                 }
        //                 else {
        //                     window.openAddPopup()
        //                 }
        //             },
        //         },
        //     ],
        // },
        //#region action
        actions: {
            // necessory to view records in the table
            listAction: (postData, jtableParams) => {
                console.log(jtableParams);
                let skip = -1, take = "", sortFeild = "a03F01", sortType = 1;
                skip = jtableParams.jtStartIndex;
                take = jtableParams.jtPageSize;
                let sortingData = jtableParams.jtSorting;

                if (sortingData) {
                    sortFeild = sortingData.split(" ")[0] ? sortingData.split(" ")[0] : "";
                    sortType = sortingData.split(" ")[1] === "DESC" ? 0 : 1;
                }

                // Simulate pagination logic
                const defferdObj = $.Deferred();

                $.ajax({
                    url: `${myUrl}/GetAllBooks2?skip=${skip}&take=${take}&sortFeild=${sortFeild}&sortType=${sortType}`,
                    type: "GET",
                    dataType: "json",
                    success: function (data) {
                        let pageData = data.data.items;
                        defferdObj.resolve({
                            Result: "OK",
                            Records: pageData,
                            TotalRecordCount: data.data.totalCount,
                        });
                    },
                    error: function () {
                        defferdObj.reject();
                    },
                });
                return defferdObj;
            },

            // for add button
            createAction: (data) => {
                const defferdObj = $.Deferred();
                $.ajax({
                    url: `${myUrl}/AddBook2?${data}`,
                    type: "POST",
                    dataType: "json",
                    contentType: 'application/json',
                    success: function (data) {
                        defferdObj.resolve({
                            Result: "OK",
                            Record: data
                        });
                    },
                    error: function (error) {
                        console.log(error);
                        defferdObj.reject();
                    },
                });
                return defferdObj;
            },

            // for delete button infront of any row
            deleteAction: (data) => {
                const defferdObj = $.Deferred();
                console.log(data);

                $.ajax({
                    url: `${myUrl}/DeleteBook2?a03F01=${data.a03F01}`,
                    type: "Delete",
                    dataType: "json",
                    success: function (data) {
                        $dfd.resolve({
                            Result: "OK",
                        });
                    },
                    error: function () {
                        $dfd.reject();
                    },
                });
                return defferdObj;
            },

            // for update button infront of any row
            updateAction: (data) => {
                const defferdObj = $.Deferred();

                $.ajax({
                    url: `${myUrl}/UpdateBook2?${data}`,
                    type: "PUT",
                    dataType: "json",
                    success: function (data) {
                        $dfd.resolve({
                            Result: "OK",
                        });
                    },
                    error: function () {
                        $dfd.reject();
                    },
                });
                return defferdObj;
            }
        },

        //#endregion

        fields: {
            a03F01: {
                key: true,
                list: true,
                title: "Book id"
            },
            a03F02: {
                title: 'Book Title',
                inputClass: 'validate[required]'
            },
            a03F03: {
                title: "Book Description",
                inputClass: 'validate[required]',
                sorting: false
            },
        },

        // for close button 
        closeRequested: () => {
            console.log('Closing Main table');
            $('#jtable_demo').hide();
        },

        // recordAdded: function (event, data) {
        //     // This runs after a record is added
        //     console.log("Record added", data);
        //     $('#jtable_demo').jtable('closeDialog'); // <- Closes the add
        // },

        //Initialize validation logic when a form is created
        formCreated: function (event, data) {
            data.form.validationEngine();
            data.form.validationEngine("attach", {
                promptPosition: "inline",
                scroll: false,
                autoPositionUpdate: true,
                showArrow: false,
                prettySelect: true,
            });
        },
        //Validate form when it is being submitted
        formSubmitting: function (event, data) {
            return data.form.validationEngine('validate');
        },
        //Dispose validation logic when form is closed
        formClosed: function (event, data) {
            data.form.validationEngine('hide');
            data.form.validationEngine('detach');
        }

    })
    // Without this, table will stay empty
    $('#jtable_demo').jtable('load');
})

$(() => {

    // loadPanel configuration
    const loadPanel = $('#loadPanel').dxLoadPanel({
        visible: false,
        shadingColor: "rgba(0, 0, 0, 0.5)",
        indicatorSrc: "https://js.devexpress.com/Content/data/loadingIcons/default.svg",
    })

    // menu list
    let menuList = [
        {
            id: 1,
            text: 'Login',
            items: [
                {
                    id: 1,
                    text: "Student Login",
                    reference: 'S'
                }, {
                    id: 2,
                    text: "Professor Login",
                    reference: 'P'
                }
            ]
        }

    ]

    // variable to control data displayed in form
    let isStudent = true;
    // ading submit button
    const submit_button = {
        itemType: "button",
        buttonOptions: {
            text: "Submit",
            type: "success",
            onClick: function () {
                let formInstance = $('#form_container').dxForm('instance');
                let formData = formInstance.option('formData');
                $('#loadPanel').dxLoadPanel('show')
                setTimeout((e) => {
                    $('#loadPanel').dxLoadPanel('hide');
                    $('#popup').dxPopup('instance').hide();
                    DevExpress.ui.notify(
                        "Form Submitted",
                        'Success',
                        3000
                    )
                }, 3000)
            }
        }
    };

    let form_data = {
        student: {
            title: "Login as Student",
            fields: ['name', 'sid', 'branch', 'semester', submit_button]
        },
        professor: {
            title: "Login as Professor",
            fields: ['name', 'pid', 'branch', submit_button]
        }
    };



    $('#myMenu').dxMenu({
        dataSource: menuList,
        displayExpr: 'text', // default: 'text'
        onItemClick: (e) => {
            console.log(e)
            e = e.itemData;

            // if clicked on internal items then only
            if (e.reference) {

                if (e.reference === 'S') {
                    isStudent = true;
                }
                else if (e.reference === 'P') {
                    isStudent = false;
                }
                ;
                $('#popup').dxPopup('instance').option('title', isStudent ? form_data.student.title : form_data.professor.title);

                // need to call it first before change fields of form as form related div is not present in DOM as this moment
                $('#popup').dxPopup('instance').show();
                $('#form_container').dxForm('instance').option('items', isStudent ? form_data.student.fields : form_data.professor.fields);
            }
        }
    });

    $('#popup').dxPopup({
        visible: false,
        height: '40vh',

        contentTemplate: () => {
            const content = $('<div />');
            let currentData = isStudent ? form_data.student : form_data.professor;

            content.dxForm({
                items: currentData.fields, // Properly pass the fields
            });

            content.attr('id', 'form_container');

            return content;
        },

        title: isStudent ? form_data.student.title : form_data.professor.title,
        showTitle: true,
        closeOnOutsideClick: true,

        onShown: function () {
            // Attach submit event after popup content is rendered
            $('#form_container').submit((e) => {
                console.log("submit form : ", e);
                e.preventDefault();
            });
        }
    })
})

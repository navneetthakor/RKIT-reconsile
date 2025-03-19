

$(() => {
    // TextBox for Trainer's Name
    $('#tname').dxTextBox({
        tabIndex: 1,
        placeholder: 'Keyur Adyaru',
        showClearButton: true,
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'trainer\'s name is required'
        }]
    });

     // TextBox for EID
    $('#teid').dxTextBox({
        tabIndex: 2,
        placeholder: 'xxx'
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'EID name is required'
        }, {
            type: 'numeric',
            message: "EID must be numeric"
        }]
    });

    // RadioGroup for Feedback Level
    let tdccOptions = ['poor', 'average', 'thik-thak', 'nice', 'master'];
    $('#tdcc').dxRadioGroup({
        tabIndex: 3,
        items: tdccOptions,
        layout: 'horizontal'
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'select one'
        }]
    });

    // TextArea for Suggestions
    $('#suggestions').dxTextArea({
        tabIndex: 4,
        placeholder: 'Provide your valuable suggestions to make reconsilation proccess better for future telents',
        height: '5rem'
    })

    // TextBox for users EID
    $('#yeid').dxTextBox({
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

    // CheckBox for Agreement
    $('#you_agree_checkBox').dxCheckBox({
        text: 'You are agree that your feedback is unbiased.'
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'you have to agree'
        }]
    })

     // Submit Button
    $('#submit_button').dxButton({
        width: '60%',
        text: 'submit',
        type: 'default',
        stylingMode: 'contained',
        useSubmitBehavior: true,
    });

    // Form Submission
    $('#myForm').submit((e) => {
        e.preventDefault();
        alert("form submited");

        $('#myForm')[0].reset();
    })
})
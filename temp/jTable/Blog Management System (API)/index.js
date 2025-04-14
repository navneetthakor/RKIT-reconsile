$(function () {
  var apiURL = "http://localhost:5095/api/CLBlog";

  $("#BlogTableContainer").jtable({
    title: "Blog List",
    paging: true,
    pageSize: 5,
    sorting: true,
    defaultSorting: "g01F02 DESC",
    selecting: true,
    multiselect: true,
    selectingCheckboxes: true,
    selectOnRowClick: true,
    animationsEnabled: true,
    columnResizable: true,
    columnSelectable: true,

    toolbar: {
      items: [
        {
          icon: "https://img.icons8.com/ios-glyphs/30/add--v1.png",
          text: "Add Blog",
          click: function () {
            $("#BlogTableContainer").jtable("openAddRecordDialog");
          },
          cssClass: "jtable-toolbar-item-addRecord",
        },
      ],
    },
    actions: {
      listAction: function (postData, jtParams) {
        console.log(jtParams);
        return $.Deferred(function ($dfd) {
          $.ajax({
            url: apiURL + "/get-all-blogs",
            type: "GET",
            dataType: "json",
            data: {
              pageSize: jtParams.jtPageSize,
              pageNumber: jtParams.jtStartIndex / jtParams.jtPageSize + 1,
              sorting: jtParams.jtSorting,
            },
            success: function (data) {
              console.log(data);
              $dfd.resolve({
                Result: "OK",
                Records: data.data,
                TotalRecordCount: data.length,
              });
            },
            error: function () {
              $dfd.reject();
            },
          });
        });
      },
      createAction: function (postData) {
        const data = $.deparam(postData); // Convert form-encoded string to object
        objData = {};
        objData.g01102 = data.g01F02;
        objData.g01103 = data.g01F03;
        return $.ajax({
          url: apiURL + "/add-blog",
          type: "POST",
          contentType: "application/json",
          data: JSON.stringify(objData),
          dataType: "json",
        });
      },
      updateAction: function (postData) {
        var data = $.deparam(postData);
        objData = {};
        objData.g01101 = data.g01F01;
        objData.g01102 = data.g01F02;
        objData.g01103 = data.g01F03;
        console.log(data);
        return $.ajax({
          url: `${apiURL}/update-blog`,
          type: "PUT",
          contentType: "application/json",
          data: JSON.stringify(objData),
          dataType: "json",
        });
      },
      deleteAction: function (data) {
        console.log(data);
        return $.ajax({
          url: `${apiURL}/delete-blog/+${data.g01F01}`,
          type: "DELETE",
          contentType: "application/json",
          dataType: "json",
        });
      },
    },
    fields: {
      g01F01: {
        key: true,
        title: "ID",
        width: "10%",
        create: false,
        edit: false,
        list: false,
      },
      g01F02: {
        title: "Blog Title",
        type: "text",
        width: "40%",
        inputClass: "validate[required]",
      },
      g01F03: {
        title: "Blog Description",
        type: "text",
        width: "40%",
        inputClass: "validate[required]",
      },
    },
    formClosed: function () {
      $(data.form).validationEngine("hide");
      $(data.form).validationEngine("detach");
      console.log("Form closed");
    },
    formCreated: function (event, data) {
      $(data.form).validationEngine();
      $(data.form).validationEngine("attach", {
        promptPosition: "inline", // <- Show message under field
        scroll: false,
        autoPositionUpdate: true,
        showArrow: false,
        prettySelect: true,
      });
      console.log("Form created:", data);
    },
    formSubmitting: function (event, data) {
      console.log("Form submitting:", data);
      return $(data.form).validationEngine("validate");
    },
  });

  // Load the data when ready
  $("#BlogTableContainer").jtable("load");
});

/*
    ==============================
    jQuery Validation Rules List
    ==============================

    Basic Validation
    ------------------------------
    - required               → Field must not be empty
    - optional               → Field is optional (can be used with custom rules)

    Custom Format Validation
    ------------------------------
    - custom[email]          → Validates email format
    - custom[phone]          → Validates phone number
    - custom[onlyLetter]     → Only alphabetic characters allowed
    - custom[onlyNumber]     → Only numeric digits allowed
    - custom[integer]        → Integer numbers only (no decimal)
    - custom[date]           → Valid date (e.g. mm/dd/yyyy or dd/mm/yyyy)
    - custom[ipv4]           → Valid IPv4 address
    - custom[url]            → Valid web URL
    - custom[creditCard]     → Valid credit card number

    Length & Numeric Rules
    ------------------------------
    - minSize[N]             → Minimum N characters (e.g. minSize[5])
    - maxSize[N]             → Maximum N characters (e.g. maxSize[10])
    - min[N]                 → Minimum numeric value (e.g. min[1])
    - max[N]                 → Maximum numeric value (e.g. max[100])

    Field Comparison
    ------------------------------
    - equals[fieldID]        → Must match the value of another field (e.g. confirm password)

    Checkbox/Radio Rules
    ------------------------------
    - groupRequired          → At least one option from the group must be selected

    AJAX Validation
    ------------------------------
    - ajax[ajaxName]         → AJAX-based validation (e.g. check if username already exists)
                            → Requires corresponding AJAX rule config in JS

    Notes
    ------------------------------
    - You can chain multiple rules: e.g.
    class="validate[required,custom[email],maxSize[50]]"

*/

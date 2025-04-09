$(function () {
  var apiURL = "https://67b2fe86bc0165def8cf777b.mockapi.io/employee/employees";

  $("#EmployeeTableContainer").jtable({
    title: "Employee List",
    paging: true,
    pageSize: 5,
    sorting: true,
    defaultSorting: "Name ASC",
    selecting: true,
    multiselect: true,
    selectingCheckboxes: true,
    selectOnRowClick: true,
    animationsEnabled: true,
    columnResizable: true,
    columnSelectable: true,
    dialogShowEffect: "fade",
    dialogHideEffect: "fade",
    deleteConfirmation: function (data) {
      data.cancel = !confirm("Are you sure you want to delete this employee?");
    },
    toolbar: {
      items: [
        {
          icon: "https://img.icons8.com/ios-glyphs/30/add--v1.png",
          text: "Add Employee",
          click: function () {
            $("#EmployeeTableContainer").jtable("openAddRecordDialog");
          },
          cssClass: "jtable-toolbar-item-addRecord",
        },
      ],
    },
    actions: {
      listAction: function (postData, jtParams) {
        return $.Deferred(function ($dfd) {
          $.ajax({
            url: apiURL,
            type: "GET",
            dataType: "json",
            success: function (data) {
              $dfd.resolve({
                Result: "OK",
                Records: data,
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
        return $.ajax({
          url: apiURL,
          type: "POST",
          contentType: "application/json",
          data: JSON.stringify(data),
          dataType: "json",
        });
      },
      updateAction: function (postData) {
        const data = $.deparam(postData);
        return $.ajax({
          url: `${apiURL}/${data.id}`,
          type: "PUT",
          contentType: "application/json",
          data: JSON.stringify(data),
          dataType: "json",
        });
      },
      deleteAction: function (postData) {
        const data = $.deparam(postData);
        return $.ajax({
          url: `${apiURL}/${data.id}`,
          type: "DELETE",
          contentType: "application/json",
          dataType: "json",
        });
      },
    },
    fields: {
      id: {
        key: true,
        title: "ID",
        width: "10%",
        create: false,
        edit: false,
        list: false,
      },
      name: {
        title: "Employee Name",
        type: "text",
        width: "40%",
      },
      salary: {
        title: "Salary",
        type: "number",
        width: "20%",
      },
    },
  });

  // Load the data when ready
  $("#EmployeeTableContainer").jtable("load");
});

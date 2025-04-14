var students = [
  { StudentId: 1, Name: "Alice", Age: 20 },
  { StudentId: 2, Name: "Bob", Age: 21 },
  { StudentId: 3, Name: "Charlie", Age: 22 },
  { StudentId: 4, Name: "David", Age: 23 },
  { StudentId: 5, Name: "Eve", Age: 24 },
  { StudentId: 6, Name: "Frank", Age: 25 },
  { StudentId: 7, Name: "Grace", Age: 26 },
  { StudentId: 8, Name: "Heidi", Age: 27 },
  { StudentId: 9, Name: "Ivan", Age: 28 },
  { StudentId: 10, Name: "Judy", Age: 29 },
];

$(document).ready(function () {
  $("#StudentTableContainer").jtable({
    title: "Student List",
    tableId: "StudentJTable",
    paging: true,
    pageSize: 5,
    pageSizes: [2, 5, 10],
    pageList: "normal", // could be 'minimal', 'normal'
    pageSizeChangeArea: true,
    gotoPageArea: "combobox",
    sorting: true,
    // multiSorting: true,
    jtSorting: "Name DESC",
    selecting: true,
    multiselect: true,
    selectingCheckboxes: false,
    selectOnRowClick: true,
    animationsEnabled: true,
    columnResizable: true,
    columnSelectable: true,
    // defaultDateFormat: "yy-mm-dd",
    dialogShowEffect: "fade",
    dialogHideEffect: "fade",
    deleteConfirmation: function (data) {
      data.cancel = !confirm("Are you sure you want to delete this student?");
      data.deleteConfirm = false;
    },
    toolbar: {
      items: [
        {
          icon: "https://img.icons8.com/ios-glyphs/30/add--v1.png",
          text: "Add Student",
          click: function () {
            alert("Add Student button clicked!");
          },
          cssClass: "jtable-toolbar-item-addRecord",
        },
      ],
    },
    showCloseButton: false,
    jqueryuiTheme: true,

    saveUserPreferences: true,
    openChildAsAccordion: true,
    unAuthorizedRequestRedirectUrl: "/login.html",
    loadingAnimationDelay: 500,
    ajaxSettings: {
      type: "POST",
      contentType: "application/json",
    },
    serializeSubmitData: function (data) {
      return JSON.stringify(data);
    },
    messages: {
      serverCommunicationError:
        "An error occurred while communicating with the server.",
      loadingMessage: "Loading students...",
      noDataAvailable: "No students found.",
      addNewRecord: "Add New Student",
      editRecord: "Edit Student",
      areYouSure: "Are you sure?",
      deleteConfirmation: "This student will be deleted. Are you sure?",
      save: "Save",
      saving: "Saving",
      cancel: "Cancel",
      deleteText: "Delete",
      deleting: "Deleting",
      error: "Error",
      close: "Close",
      pagingInfo: "Showing {0} to {1} of {2} students",
      pageSizeChangeLabel: "Rows:",
      gotoPageLabel: "Go to page",
      canNotDeletedRecords: "Could not delete {0} of {1} students!",
      deleteProggress: "Deleting {0} of {1} students...",
      loadingRecords: "Loading students...",
      refresh: "Refresh",
    },
    actions: {
      listAction: function (postData, jtParams) {
        console.log(jtParams);
        var startIndex = jtParams.jtStartIndex;
        var pageSize = jtParams.jtPageSize;

        // Simulate pagination logic
        var pageData = students.slice(startIndex, startIndex + pageSize);

        return {
          Result: "OK",
          Records: pageData,
          TotalRecordCount: students.length,
        };
      },
      createAction: function (postData) {
        console.log(postData);
        var params = new URLSearchParams(postData);
        var newStudent = {
          Name: params.get("Name"),
          Age: parseInt(params.get("Age"), 10),
        };

        newStudent.StudentId = students.length
          ? Math.max(...students.map((s) => s.StudentId)) + 1
          : 1;

        students.push(newStudent);
        console.log(students);

        return {
          Result: "OK",
          Record: newStudent,
        };
      },
      updateAction: function (postData) {
        console.log("Update Data:", postData);
        var params = new URLSearchParams(postData);
        var studentId = parseInt(params.get("StudentId"), 10);
        var student = students.find((s) => s.StudentId === studentId);

        if (student) {
          student.Name = params.get("Name");
          student.Age = parseInt(params.get("Age"), 10);
          console.log("Updated Student:", student);
          return { Result: "OK" };
        } else {
          return { Result: "ERROR", Message: "Student not found" };
        }
      },
      deleteAction: function (postData) {
        console.log("Delete Data:", postData);
        var params = new URLSearchParams(postData);
        var studentId = parseInt(params.get("StudentId"), 10);

        var index = students.findIndex((s) => s.StudentId === studentId);
        if (index !== -1) {
          students.splice(index, 1);
          console.log("Remaining Students:", students);
          return { Result: "OK" };
        } else {
          return { Result: "ERROR", Message: "Student not found" };
        }
      },
    },
    fields: {
      StudentId: {
        key: true,
        title: "ID",
        type: "number",
        width: "10%",
        list: false,
        create: false,
        edit: false,
        sorting: true,
        columnResizable: true,
        visibility: "fixed", // or 'hidden', 'visible'
        inputClass: "student-id-input",
        inputTitle: "Student ID",
        listClass: "student-id-list",
      },
      Name: {
        title: "Student Name",
        inputClass: "validate[required]",
        // type: "text",
        // width: "40%",
        // list: true,
        // create: true,
        // edit: true,
        // sorting: true,
        // columnResizable: true,
        // // defaultValue: "John Doe",
        // input: function (data) {
        //   return (
        //     '<input type="text" name="Name" value="' +
        //     (data.value || "") +
        //     '" class="custom-name-input"/>'
        //   );
        // },
        //
        // inputTitle: "Enter student name",
        // // listClass: "name-list",
        // visibility: "visible",
      },
      Age: {
        title: "Age",
        type: "number",

        width: "20%",
        list: true,
        create: true,
        edit: true,
        sorting: true,
        columnResizable: true,
        defaultValue: 18,
        inputClass: "age-input",
        inputTitle: "Enter student age",
        listClass: "age-list",
        visibility: "visible",
        options: function () {
          var opts = {};
          for (let i = 18; i <= 30; i++) {
            opts[i] = i;
          }
          return opts;
        },
        optionsSorting: "text", // or "value"
      },
    },
    // Event Handlers
    closeRequested: function () {
      console.log("Close requested");
    },
    formClosed: function () {
      $(data.form).validationEngine("hide");
      $(data.form).validationEngine("detach");
      console.log("Form closed");
    },
    formCreated: function (event, data) {
      console.log(typeof $.fn.validationEngine);
      $(data.form).validationEngine();
      console.log("Form created:", data);
    },
    formSubmitting: function (event, data) {
      console.log("Form submitting:", data);
      return $(data.form).validationEngine("validate");
    },
    loadingRecords: function (event, data) {
      console.log("Loading records:", data);
    },
    recordAdded: function (event, data) {
      console.log("Record added:", data.record);
    },
    recordDeleted: function (event, data) {
      console.log("Record deleted:", data.record);
    },
    recordsLoaded: function (event, data) {
      console.log("Records loaded:", data.records);
    },
    recordUpdated: function (event, data) {
      console.log("Record updated:", data.record);
    },
    rowInserted: function (event, data) {
      console.log("Row inserted:", data.row, data.record);
    },
    rowsRemoved: function (event, data) {
      console.log("Rows removed:", data.rows);
    },
    rowUpdated: function (event, data) {
      console.log("Row updated:", data.row, data.record);
    },
    selectionChanged: function () {
      console.log("Selection changed");
    },
  });

  $("#StudentTableContainer").jtable("load");

  var jtable = $("#StudentTableContainer").jtable("instance");
  console.log(jtable);

  // Add a demo record using showCreateForm
  // $("#StudentTableContainer").jtable("showCreateForm");

  // Get a row by key (ID = 1)
  var $row1 = $("#StudentTableContainer").jtable("getRowByKey", 1);
  console.log("Row with ID 1:", $row1);

  // Check if child row is open
  var isChildOpen = $("#StudentTableContainer").jtable("isChildRowOpen", $row1);
  console.log("Is child row open for ID 1:", isChildOpen);

  // Open a child row
  $("#StudentTableContainer").jtable("openChildRow", $row1, function (child) {
    child.append("<div>Child Row Content for ID 1</div>");
  });

  // Get child row of ID 1
  var $childRow = $("#StudentTableContainer").jtable("getChildRow", $row1);
  console.log("Child row for ID 1:", $childRow);

  // Close child row
  $("#StudentTableContainer").jtable("closeChildRow", $row1);

  // Open a child table
  $("#StudentTableContainer").jtable(
    "openChildTable",
    $row1,
    {
      title: "Child Table of Student " + $row1.data("record").Name,
      actions: {
        listAction: function () {
          return {
            Result: "OK",
            Records: [{ SubjectId: 1, SubjectName: "Math" }],
            TotalRecordCount: 1,
          };
        },
      },
      fields: {
        SubjectId: {
          key: true,
          title: "Subject ID",
          width: "30%",
        },
        SubjectName: {
          title: "Subject Name",
          width: "70%",
        },
      },
    },
    function (data) {
      data.childTable.jtable("load");
    }
  );

  // // Close the child table
  // $("#StudentTableContainer").jtable("closeChildTable", $row1);

  // // Select specific rows (e.g., IDs 2 and 3)
  // $("#StudentTableContainer").jtable(
  //   "selectRows",
  //   $("#StudentTableContainer").jtable("getRowByKey", 2)
  // );
  // $("#StudentTableContainer").jtable(
  //   "selectRows",
  //   $("#StudentTableContainer").jtable("getRowByKey", 3)
  // );

  // // Get selected rows
  // var selected = $("#StudentTableContainer").jtable("selectedRows");
  // console.log("Selected rows:", selected);

  // // Change column visibility (hide Age column)
  // $("#StudentTableContainer").jtable("changeColumnVisibility", "Age", "hidden");

  // // Delete a specific row
  // var rowToDelete = $("#StudentTableContainer").jtable("getRowByKey", 4);
  // $("#StudentTableContainer").jtable("deleteRecord", {
  //   key: 4,
  //   clientOnly: true,
  //   animationsEnabled: false,
  // });

  // // Delete multiple selected rows
  // $("#StudentTableContainer").jtable("deleteRows", selected);

  // // Reload the table
  // setTimeout(() => {
  //   $("#StudentTableContainer").jtable("reload");
  // }, 1000);

  // // Update a record manually
  // var rowToUpdate = $("#StudentTableContainer").jtable("getRowByKey", 5);
  // $("#StudentTableContainer").jtable("updateRecord", {
  //   record: {
  //     StudentId: 5,
  //     Name: "Updated Name",
  //     Age: 30,
  //   },
  //   clientOnly: true,
  // });

  // Destroy the table
  // $("#StudentTableContainer").jtable("destroy");s
});

$(function () {
    // FileUploader for the first container
    $("#fileUploaderContainer1").dxFileUploader({
        multiple: true, // Allow multiple files to be uploaded at once
        uploadUrl: "https://js.devexpress.com/Demos/NetCore/FileUploader/Upload", // URL to which files are uploaded
        abortUpload: function (file, uploadInfo) {
            console.log("Upload aborted for file:", file);
            console.log("Upload Info:", uploadInfo);
        },
        accept: "image/*", // MIME type filter (e.g., "image/*", "video/*", or specific file extensions like "application/pdf")
        accessKey: 'x', // API key or authorization token (string, optional)
        activeStateEnabled: false, // Enable/disable active state of the button (true/false)
        allowCanceling: true, // Allow file upload cancellation (true/false)
    });

    // FileUploader for the second container with additional configurations
    let fileUploader = $("#fileUploaderContainer2").dxFileUploader({
        multiple: true, // Allow multiple file uploads
        uploadUrl: "https://js.devexpress.com/Demos/NetCore/FileUploader/Upload", // URL to which files are uploaded
        abortUpload: function (file, uploadInfo) {
            console.log("Upload aborted for file:", file);
            console.log("Upload Info:", uploadInfo);
        },
        accessKey: 'x', // API key or authorization token (string, optional)
        activeStateEnabled: true, // Enable/disable active state of the button (true/false)
        allowCanceling: true, // Allow canceling file uploads (true/false)
        allowedFileExtensions: ['.jpg', '.jpeg', '.gif', '.png', '.pdf'], // Allowed file extensions (array of strings)
        chunkSize: 1024, // Set the chunk size in bytes (e.g., 1024 for 1KB chunks, default is 1MB)
        dialogTrigger: '#dropzone-external', // Trigger element for file dialog (string, can be a selector)
        dropZone: '#dropzone-external', // Define the drop zone for files (string, can be a selector)
        elementAttr: {
            id: "elementId",
            class: "class-name" // Custom ID and class for styling (string)
        },
        focusStateEnabled: true, // Enable/disable focus state for the uploader (true/false)
        hint: 'Upload a file', // Hint text displayed in the uploader (string)
        invalidFileExtensionMessage: "Enter a valid file type", // Error message for invalid file type (string)
        invalidMaxFileSizeMessage: "File size is too large", // Error message for exceeding file size (string)
        invalidMinFileSizeMessage: "File size is too small", // Error message for file being too small (string)
        labelText: "Upload a file", // Label text for the file input (string)
        maxFileSize: 100000, // Maximum file size in bytes (number, e.g., 100000 for 100KB)
        minFileSize: 4000, // Minimum file size in bytes (number, e.g., 4000 for 4KB)
        name: "files[]", // Name attribute for the form input (string)

        onBeforeSend: function (e) {
            console.log("Preparing to upload:", e.file);
            console.log("Upload Info:", e.uploadInfo);
        },

        onDropZoneEnter: function (e) {
            $("#fileUploaderContainer2").css("background-color", "#f0f0f0");
            console.log("A file is being dragged into the drop zone.");
        },

        onDropZoneLeave: function (e) {
            $("#fileUploaderContainer2").css("background-color", "");
            console.log("The file was dragged out of the drop zone.");
        },

        onFilesUploaded: function (e) {
            console.log("Files uploaded:", e.files);
        },

        onOptionChanged: function (e) {
            console.log("Uploader options changed:", e);
        },

        onProgress: function (e) {
            let percentage = Math.round((e.bytesLoaded / e.bytesTotal) * 100);
            console.log("Upload Progress:", percentage + "%");
            $("#progress").text("File progress is " + percentage + "%"); // Updating the progress display element
        },

        onUploadAborted: function (e) {
            console.log("Upload aborted:", e);
        },

        onUploaded: function (e) {
            console.log("Upload completed successfully:", e);
        },

        onUploadError: function (e) {
            console.log("Error during upload:", e);
        },

        onUploadStarted: function (e) {
            console.log("Upload started:", e);
        },

        onValueChanged: function (e) {
            console.log("Value changed:", e.value);
        },

        readyToUploadMessage: "File is ready to upload",
        showFileList: true,
        uploadAbortedMessage: "Upload canceled",
        uploadButtonText: "Upload File",

        uploadChunk: function (file, uploadInfo) {
            console.log("Uploading chunk:", uploadInfo);
        },

        uploadCustomData: {},

        uploadedMessage: 'File is uploaded successfully',
        uploadFailedMessage: 'File upload failed',

        uploadFile: function (file, progressCallback) {
            console.log("Uploading file:", file);
            progressCallback(50);
        },

        uploadHeaders: {},
        uploadMethod: 'POST',
        uploadMode: 'useButtons',
    }).dxFileUploader("instance");

    // Submit Button to handle form submission
    $('#submitButton').dxButton({
        text: "Submit",
        onClick: function () {
            console.log(fileUploader, fileUploader.option('isDirty'));
            if (fileUploader.option('isDirty')) {
                DevExpress.ui.notify("Do not forget to save changes", "warning", 500);
            }
        }
    });

    // Simulating file progress display
    setTimeout(() => {
        let fileProgress = `File progress is ${fileUploader.option("progress")}%`;
        $("#progress").text(fileProgress);
    });

    // Buttons for actions
    $('#abortUploadButton').on('click', function () {
        fileUploader.abortUpload();
        console.log("Upload aborted.");
    });

    $('#clearUploaderButton').on('click', function () {
        fileUploader.clear();
        console.log("Uploader cleared.");
    });

    $('#resetUploaderButton').on('click', function () {
        fileUploader.reset();
        console.log("Uploader reset.");
    });
});
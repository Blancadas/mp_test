// jqXHRData needed for grabbing by data object of fileupload scope
var jqXHRData;

$(function () {
    $('.serviceCathegorySelect').select2();
    $('.serviceTypeSelect').select2();

    if ($('#orderDateTime').length > 0 && $('#orderDueDateTime').length > 0) {

        $('#orderDateTime').datetimepicker({ format: 'DD.MM.YYYY HH:mm' });
        $('#orderDateTime > input').val(moment().format('DD.MM.YYYY hh:mm'));

        $('#orderDueDateTime').datetimepicker();
        $('#orderDueDateTime > input').val(moment().add('days', 1).format('DD.MM.YYYY hh:mm'));
    }

    //Initialization of fileupload
    //initSimpleFileUpload();

    //Handler for "Start upload" button 
    //$("#hl-start-upload").on('click', function () {
    //    if (jqXHRData) {
    //        jqXHRData.submit();
    //    }
    //    return false;
    //});

    //$('#hl-start-upload').on('click', function () {

    //    var data = new FormData();

    //    var files = $("#fu-my-simple-upload").get(0).files;

    //    // Add the uploaded image content to the form data collection
    //    if (files.length > 0) {
    //        data.append("UploadedImage", files[0]);
    //    }

    //    // Make Ajax request with the contentType = false, and procesDate = false
    //    var ajaxRequest = $.ajax({
    //        type: "POST",
    //        url: "/api/fileupload/uploadfile",
    //        contentType: false,
    //        processData: false,
    //        data: data
    //    });

    //    ajaxRequest.done(function (xhr, textStatus) {
    //        // Do other operation
    //    });
    //});

    $('#hl-start-upload').on('click', function (e) {
        var files = $('#fu-my-simple-upload')[0].files;
        var myID = 3; //uncomment this to make sure the ajax URL works
        if (files.length > 0) {
            if (window.FormData !== undefined) {
                var data = new FormData();
                for (var x = 0; x < files.length; x++) {
                    data.append("file" + x, files[x]);
                }

                $.ajax({
                    type: "POST",
                    url: '/Upload/Upload?id=' + myID,
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (result) {
                        console.log(result);
                    },
                    error: function (xhr, status, p3, p4) {
                        var err = "Error " + " " + status + " " + p3 + " " + p4;
                        if (xhr.responseText && xhr.responseText[0] == "{")
                            err = JSON.parse(xhr.responseText).Message;
                        console.log(err);
                    }
                });
            } else {
                alert("This browser doesn't support HTML5 file uploads!");
            }
        }
    });
});

//$(document).on("click", "#btnid", function (event) {
//    event.preventDefault();
//    var fileOptions = {
//        success: uploadSuccess,
//        dataType: "json"
//    };
//    $("#formid").ajaxSubmit(fileOptions);
//});

function uploadSuccess() {
    console.log("file has been uploaded");
}


function formatDate(date) {
    var monthNames = [
        "01", "02", "03",
        "04", "05", "06", "07",
        "08", "09", "10", "11", "12"
    ];

    var day = date.getDate();
    var monthIndex = date.getMonth();
    var year = date.getFullYear();

    return day + '/' + monthNames[monthIndex] + '/' + year;
}

function initSimpleFileUpload() {
    'use strict';

    $('#fu-my-simple-upload').fileupload({
        url: '/Home/Upload',
        dataType: 'json',
        add: function (e, data) {
            jqXHRData = data;
        },
        done: function (event, data) {
            if (data.result.isUploaded) {

            }
            else {

            }
            alert(data.result.message);
        },
        fail: function (event, data) {
            if (data.files[0].error) {
                alert(data.files[0].error);
            }
        }
    });
}
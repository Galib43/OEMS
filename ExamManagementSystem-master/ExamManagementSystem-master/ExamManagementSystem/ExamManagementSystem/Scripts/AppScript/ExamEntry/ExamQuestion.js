﻿/// <reference path="Exam.js" />
/// <reference path="Exam.js" />

//function makeid() {
//    var text = "";
//    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

//    for (var i = 0; i < 4; i++)
//        text += possible.charAt(Math.floor(Math.random() * possible.length));

//    return text;
//}





$("#OrganizationId").change(function () {

    var crsId = $(this).val();

    if (crsId != "") {
        var params = { id: crsId }

        $.ajax({
            type: "POST",
            url: "../../Exam/GetCourseByOrganizationId",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),

            success: function (rData) {
                if (rData != undefined && rData != "") {
                    $("#courseListDD").empty();
                    $("#courseListDD").append("<option value=''>Select Course</option>");

                    $.each(rData,
                        function (k, v) {
                            var option = "<option value='" + v.Id + "'>" + v.Name + "</option>";
                            $("#courseListDD").append(option);
                        });
                } else {
                    $("#courseListDD").empty();
                    $("#courseListDD").append("<option value=''>Select Course</option>");
                }
            }
        });
    }

});


$("#courseListDD").change(function () {

    var crsId = $(this).val();

    if (crsId != "") {
        var params = { id: crsId }

        $.ajax({
            type: "POST",
            url: "../../Exam/GetExamByCourse",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),

            success: function (rData) {
                if (rData != undefined && rData != "") {
                    $("#examListDD").empty();
                    $("#examListDD").append("<option value=''>Select Course</option>");

                    $.each(rData,
                        function (k, v) {
                            var option = "<option value='" + v.Id + "'>" + v.Name + "</option>";
                            $("#examListDD").append(option);
                        });
                } else {
                    $("#examListDD").empty();
                    $("#examListDD").append("<option value=''>Select Course</option>");
                }
            }
        });
    }

});





$("#examListDD").change(function () {

    var crsId = $(this).val();

    if (crsId != "") {
        var params = { id: crsId }

        $.ajax({
            type: "POST",
            url: "../../Exam/MakeQuestionOrder",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),

            success: function (rData) {
                if (rData > 0) {


                    $("#QOrder").empty();
                    $("#QOrder").val(rData + 1);
                }
                else {
                    $("#QOrder").val(rData + 1);
                }
            }
        });
    }

});








$("#AddButton").click(function () {
    createRowForOption();

});


var index = 0;
function createRowForOption() {

    //Get Selected Item from UI
    var selectedItem = getSelectedOption();

    //Check Last Row Index
    var index = $("#OptionListTable").children("tr").length;
    var sl = index;

    //For Model List<Property> Binding For MVC
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='QuestionOptionses.Index' value='" + index + "' /> </td>";

    //For Serial No For UI
    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

    var itemTd = "<td> <input type='hidden' id='QOption" + index + "'  name='QuestionOptionses[" + index + "].Name' value='" + selectedItem.Qoptions + "' /> " + selectedItem.Qoptions + " </td>";
    var qtyTd = "<td> <input type='hidden' id='CorrectAns" + index + "'  name='QuestionOptionses[" + index + "].IsAnswer' value='" + selectedItem.Ans + "' /> " + selectedItem.Ans + " </td>";
    //var rmvId = "<td></td>";

    var newRow = "<tr>" + indexTd + slTd + itemTd + qtyTd + " </tr>";

    $("#OptionListTable").append(newRow);
    $("#QOption").val("");
    $("#CorrectAns").val("");

}


function getSelectedOption() {
    var qoption = $("#QOption").val();
    var cans = getVal();

    var item = {
        "Qoptions": qoption,
        "Ans": cans
    }

    return item;
}


function getVal() {
    if (document.getElementById('CorrectAns').checked) {
        return 'True';
    } else {
        return 'False';
    }
}















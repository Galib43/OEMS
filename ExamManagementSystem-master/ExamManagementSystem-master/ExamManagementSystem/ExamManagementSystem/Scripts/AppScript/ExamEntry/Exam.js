/// <reference path="Exam.js" />
/// <reference path="Exam.js" />

function makeid() {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    for (var i = 0; i < 4; i++)
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;
}


$("#examTypeID").change(function () {

    var crsId = $(this).val();

    if (crsId != "") {
        var params = { id: crsId }

        $.ajax({
            type: "POST",
            url: "../../Exam/MakeExamCode",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),

            success: function (rData) {
                if (rData > 0) {


                    $("#ExamId").empty();
                    $("#ExamId").val('CRS' + makeid() + (rData + 1));
                } else {
                    $("#ExamId").val('CRS' + makeid() + (rData + 1));
                }
            }
        });
    }

});



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













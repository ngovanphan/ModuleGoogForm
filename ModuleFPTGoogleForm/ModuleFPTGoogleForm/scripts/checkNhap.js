$(function () {
    function checkName() {
        if($("#QuestionName").val().length==0)
        {
            $("#fe_QuestionName").html("*Required");
            return false;
        }
        else
        {
            $("#fe_QuestionName").html("");
            return true;
        }
    };
    $("#QuestionName").on("blur", checkName);
});
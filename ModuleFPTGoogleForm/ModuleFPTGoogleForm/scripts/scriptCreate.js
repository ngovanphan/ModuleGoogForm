$(function () {
    var counterText = 1;
    var counterCheckbox = 0;
    $("#typeOption").change(function () {
        var textOption = $("#typeOption option:selected").text();

        var newdiv = document.createElement('div');
        counterText = 0;
        counterCheckbox = 0;
        $("#addAppend").html("");
        $(".fieldsAdd").html("");
        $(".fieldsAdd").remove();
        switch (textOption) {

            case 'Text':
                counterText = counterText + 1;
                newdiv.innerHTML = "<div class='col-md-2 '></div>"
                    + "<div class='col-md-10'> <input type='text' id='textAnwser" + counterText + "' placeholder='Anwser " + (counterText) + "' class='text-danger'/>"
                    + "<input type='button' class='btn-success addFiel' value='Add' id='addFields' /> </div>";


                break;
            case 'CheckBox':
                counterCheckbox++;
                newdiv.innerHTML = "<div class='col-md-2'> <input type='image' src='~/Icon/CheckBoxIcon.jpeg' alt='Icon Khong Load'/> </div>"
                    + "<div class='col-md-10'><input type='text' placeholder='Text Checkbox" + (counterCheckbox) + "' id='checkBoxAnwser" + (counterCheckbox) + "' class='text-danger' />"
                    + "<input type='button' class='btn-success addFiel' value='Add'/> </div>";

                break;

        }
        $('#addAppend').append(newdiv);
        $(".addFiel").click(function (e) {
            e.preventDefault();
            var textOpt = $("#typeOption").val();

            switch (textOpt) {
                case 'Text':
                    counterText = counterText + 1;
                    var newFiel = document.createElement('div');
                    newFiel.innerHTML = "<div class='form-group fieldsAdd' id='fieldAddT" + (counterText) + "'><div class='col-md-2' ></div>"
                              + "<div class='col-md-10'> <input type='text' id='textAnwser" + (counterText) + "' placeholder='Anwser " + (counterText) + "' class='text-danger' />"
                              + "<input type='button' class='btn-danger removeFiel' value='Remove' /> </div> </div>";

                    break;
                case 'CheckBox':
                    counterCheckbox++;
                    var newFiel = document.createElement('div');
                    newFiel.innerHTML = "<div class='form-group fieldsAdd' id='fieldAddC" + (counterCheckbox) + "'><div class='col-md-2'></div>"
                              + "<div class='col-md-10'> <input type='text' id='checkBoxAnwser" + (counterCheckbox) + "' placeholder='Text CheckBox " + (counterCheckbox) + "' class='text-danger' />"
                              + "<input type='button' class='btn-danger removeFiel' value='Remove' /> </div> </div>";

                    break;

            }
            $(newFiel).appendTo('#addAppendField');
            $(".removeFiel").click(function () {


                $(this).parents('.fieldsAdd').remove();

            });

        });

    });
    $(".addFiel").click(function (e) {
        e.preventDefault();
        var textOpt = $("#typeOption").val();

        switch (textOpt) {
            case 'Text':
                counterText = counterText + 1;
                var newFiel = document.createElement('div');
                newFiel.innerHTML = "<div class='form-group fieldsAdd' id='fieldAddT" + (counterText) + "'><div class='col-md-2' ></div>"
                          + "<div class='col-md-10'> <input type='text' id='textAnwser" + (counterText) + "' placeholder='Anwser " + (counterText) + "' class='text-danger' />"
                          + "<input type='button' class='btn-danger removeFiel' value='Remove' /> </div> </div>";

                break;
            case 'CheckBox':
                counterCheckbox++;
                var newFiel = document.createElement('div');
                newFiel.innerHTML = "<div class='form-group fieldsAdd' id='fieldAddC" + (counterCheckbox) + "'><div class='col-md-2'></div>"
                          + "<div class='col-md-10'> <input type='text' id='checkBoxAnwser" + (counterCheckbox) + "' placeholder='Text CheckBox " + (counterCheckbox) + "' class='text-danger' />"
                          + "<input type='button' class='btn-danger removeFiel' value='Remove' /> </div> </div>";

                break;

        }
        $(newFiel).appendTo('#addAppendField');
        $(".removeFiel").click(function () {


            $(this).parents('.fieldsAdd').remove();

        });

    });

    $("#createQuestion").click(function () {

        var typeText = $("#typeOption option:selected").text();
        var typeInt;
        var anwser = "";
        switch (typeText) {
            case 'Text':
                typeInt = 1;

                for (var i = 1; i <= counterText; i++) {
                    anwser = anwser + $("#textAnwser" + i).val() + "; ";
                    alert(anwser);
                }
                break;
            case 'CheckBox':
                typeInt = 2;

                for (var i = 1; i <= counterCheckbox; i++) {
                    anwser = anwser + $("#checkBoxAnwser" + i).val() + "; ";

                }

                break;

        }

        $.ajax({
            type: 'post',
            url: '@Url.Action("AddNewQuestions", "Questions", null)',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({
                QuestionName: $("#QuestionName").val(),
                Answer: anwser,
                Type: typeInt,
                FormId: parseInt($(".FormId option:selected").text())
            })

        });
        window.location.replace("/Questions/Index/");
    });
});
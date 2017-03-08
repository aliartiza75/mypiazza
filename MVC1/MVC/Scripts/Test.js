$(document).ready(function () {


    $('#Button1').click(function () {
        var name1 = $('#email').val();
        var pass1 = $('#pass').val();
        alert(name1 + pass1);
        var choice1;
        $('[name="choice"]').each(function () {
            if ($(this).prop('checked') == true) {
                choice1 = $(this).val();

            }
        });

        $.ajax({
            type: 'POST',
            url: "/Login/validate_user",
            contentType: 'application/json',
            data: JSON.stringify({
                email   : name1,
                pass    : pass1,
                choice  : choice1
            }),
            dataType:'json',
            success: function (msg) {
                if (msg == 1) {
                    alert("User match");
                    window.location.href = '/DashBoard/Index';
                }
                else if (msg == 2) {
                    alert("User match");
                    window.location.href = '/DashBoard2/Index';
                }
                else
                    alert("not found");

            },
            error: function (error) {
                alert("error");
            }
        });
    });
});
//////////////// Code for the Course Registration /////////////////////////////////

$(document).ready(function () {


    $('#Button').click(function () {
        var _Student_id = $('#Student_Id').val();
        var _Course_id = $('#Course_Id').val();
        alert(_Student_id+_Course_id);

        $.ajax({
            type: 'POST',
            url: "/Dashboard/Db_Insert_Course",
            contentType: 'application/json',
            data: JSON.stringify({
                Student_id : _Student_id,
                Course_id   : _Course_id,
            }),
            dataType: 'json',
            success: function (msg) {
                if (msg == 1) {
                    alert("Course Registered");
                    window.location.reload();
                }
                else if (msg == 2) {
                    alert("Registration exist");
                    
                }
                else
                    alert("Exception");

            },
            error: function (error) {
                alert("error");
            }
        });
    });
});
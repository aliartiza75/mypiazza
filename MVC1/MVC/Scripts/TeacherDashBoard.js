$(document).ready(function () {

    $('#Button12').click(function () {
        var class_id1 = $('#class_id').val();
        var class_name1 = $('#class_name').val();
        var instruct_name1 = $('#instruct_name').val();
        var class_type1 = $('#class_type').val();
        var class_description1 = $('#class_description').val();
        
        alert(class_id1 + class_name1);



        $.ajax({
            type: 'POST',
            url: "/DashBoard2/Add_class_db",
            contentType: 'application/json',
            data: JSON.stringify({
                class_id                : class_id1,
                class_name              : class_name1,
                instruct_name: instruct_name1,
                class_type              : class_type1,
                class_description       : class_description1,
            }),
            ////
            dataType: 'json',
            success: function (msg) {
                if (msg == 0) {
                    alert("Success");
                    window.location.reload();
                }
                else if (msg == 2)
                    alert("Invalid Data")
                else if (msg == 3)
                    alert("User Exist");

            },
            error: function (error) {
                alert("error");
            }

        });

    });

});
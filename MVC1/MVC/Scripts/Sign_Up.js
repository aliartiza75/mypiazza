$(document).ready(function () {

    $('#ButtonSS').click(function () {
        var cniccc = $('#cnic').val();
        var name1 = $('#name').val();
        var password1 = $('#password').val();
        var address1 = $('#address').val();
        var contact1 = $('#contact').val();
        var emailll = $('#email').val();
        var choice1;
        $('[name="choice"]').each(function () {
            if ($(this).prop('checked') == true) {
                choice1 = $(this).val();
                
            }
        });



        $.ajax({
            type: 'POST',
            url: "/SignUp/sign_up",
            contentType: 'application/json',
            data: JSON.stringify({
                cnicc       : cniccc,
                name        : name1,
                password    : password1,
                address     : address1,
                contact     : contact1,
                emaill      : emailll,
                choice      : choice1,
            }),
            ////
            dataType: 'json',
            success: function (msg) {
                if (msg == 0) {
                    alert("Success");
                    window.location.reload();
                }
                else if (msg == 1)
                    alert("Unsuccessful");
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
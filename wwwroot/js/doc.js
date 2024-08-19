$(document).ready(function () {

});


$('#btn1').click(function () {
    $('#exampleModal').modal('show');
});

$('#close').click(function () {
    $('#exampleModal').modal('hide');
});


$('#savebtn').click(function () {

    //var obj = {
    //    name=$('#name').val(),
    //    email=$('#email').val(),
    //    salary=$('#salary').val()

    //}//without using serialization getting data from individual elements of form

    var obj = $('#myform').serialize();// using serialization to get data from form ,here on ui side we use name tag for elements instead of id



    $.ajax({
        url: '/Ajax/AddEmp ',
        type: 'POST',
        dataType: 'json',
        contentType:'Application/x-www-form-urlencoded;charset=utf8;',
        data: obj,
        success: function () {
            alert("Success");
        },
        error: function () {
            alert("Failure");
        }
    });
});// using ajax to perform insert operation




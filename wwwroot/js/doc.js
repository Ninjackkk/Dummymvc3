$(document).ready(function () {
    getEmpData();
});

$('#btn1').click(function () {
    clear();
    $('#exampleModalLabel').text("Add Emp");
    $('#exampleModal').modal('show');
    $('#updbtn').hide();
    $('#savebtn').show();

    

});

$('#close').click(function () {
    $('#exampleModal').modal('hide');
});

function clear() {
    $('#name').val('');
    $('#email').val('');
    $('#salary').val('');
}

$('#savebtn').click(function () {

    //var obj = {
    //    name=$('#name').val(),
    //    email=$('#email').val(),
    //    salary=$('#salary').val()

    //}             //without using serialization getting data from individual elements of form

    var obj = $('#myform').serialize(); // using serialization to get data from form ,here on ui side we use name tag for elements instead of id

    $.ajax({
        url: '/Ajax/AddEmp ',
        type: 'POST',
        dataType: 'json',
        contentType: 'Application/x-www-form-urlencoded;charset=utf8;',
        data: obj,
        success: function () {
            alert("Success");
            $('#exampleModal').modal('hide');
            clear();
            getEmpData()

        },
        error: function () {
            alert("Failure");
        }
    });

});     // using ajax to perform insert operation

function getEmpData() {
    $.ajax({

        url: '/Ajax/GetEmp',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json/charset=utf8;',
        success: function (result, status, xhr) {

            obj = '';
            $.each(result, function (index, item) {
                obj += "<tr>";

                obj += "<td>" + item.id + "</td>";
                obj += "<td>" + item.name + "</td>";
                obj += "<td>" + item.email + "</td>";
                obj += "<td>" + item.salary + "</td>";
                obj += "<td> <input type='button' value='Delete' onclick='delEmp("+item.id+")' class='btn btn-info'/> </td>";
                obj += "<td> <input type='button' value='Update' onclick='UpdEmp(" + item.id + ")' class='btn btn-info'/> </td>";


                obj += "</tr>";
            });
            $("#tabledata").html(obj);//here we will convert the json format data to html format and send

        },
        error: function () {
            alert('Data Not Found');
        }

    });
} // using ajax to perform fetching operation




function SearchEmpdata() {

    var sdata = $('#search').val();
    $.ajax({

        url: '/Ajax/SearchEmp?sdata=' + sdata,
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json/charset=utf8;',
        success: function (result, status, xhr) {

            obj = '';
            $.each(result, function (index, item) {
                obj += "<tr>";

                obj += "<td>" + item.id + "</td>";
                obj += "<td>" + item.name + "</td>";
                obj += "<td>" + item.email + "</td>";
                obj += "<td>" + item.salary + "</td>";
                obj += "<td> <input type='button' value='Delete' onclick='delEmp(" + item.id + ")' class='btn btn-info'/> </td>";
                obj += "<td> <input type='button' value='Update' onclick='UpdEmp(" + item.id + ")' class='btn btn-info'/> </td>";


                obj += "</tr>";
            });
            $("#tabledata").html(obj);              //here we will convert the json format data to html format and send

        },
        error: function () {
            alert('Data Not Found');
        }

    });
}                   // Using Search Function in ajax 


function delEmp(id) {
    if (confirm("Are you sure")) {
        $.ajax({
            url: '/Ajax/DeleteEmp?eid=' + id,
            success: function () {
                alert("Emp Deleted Successfully");
                getEmpData();
            },
            error: function () {
                alert("Emp Deletion Failed");

            }
        });
    }
} // using ajax to perform deletion

function UpdEmp(id) {
    $.ajax({
        url: '/Ajax/UpdateEmp?eid=' + id,
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json/charset=utf8;',
        success: function (response) {
            $('#exampleModal').modal('show');
            $('#empId').val(response.id);
            $('#name').val(response.name);
            $('#email').val(response.email);
            $('#salary').val(response.salary);
            $('#savebtn').hide();
            $('#updbtn').show();
            $('#exampleModalLabel').text("Update Emp");
        },
        error: function () {
            alert('Update Failed');
        }
    });
}  // using ajax to perform Updating operation      

$('#updbtn').click(function () {
    var obj = $('#myform').serialize();
    $.ajax({
        url: '/Ajax/UpdateCommit',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/x-www-form-urlencoded;charset=UTF-8',
        data: obj,
        success: function () {
            alert("Employee Details Updated");
            $('#exampleModal').modal('hide');
            clear();
            getEmpData();
        },
        error: function () {
            alert("Failure");
        }
    });
});     // using ajax to perform Update operation




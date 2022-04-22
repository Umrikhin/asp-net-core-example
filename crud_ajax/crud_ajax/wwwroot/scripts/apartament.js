$(document).ready(function () {
    loadData();
});

//Load Data function
function loadData() {
    $.ajax({
        url: "/Home/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = ''; var i = 1;
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + (i++).toString() + '</td>';
                html += '<td>' + item.numberOfRooms + '</td>';
                html += '<td>' + item.space.toFixed(2) + '</td>';
                html += '<td>' + item.level + '</td>';
                html += '<td>' + item.numberOfStoreys + '</td>';
                html += '<td>' + item.adres + '</td>';
                html += '<td>' + (new Intl.NumberFormat('ru-RU', { style: 'currency', currency: 'RUB' })).format(item.price) + '</td>';
                html += '<td><a href="#" onclick="return getbyID(\'' + item.id + '\')">Edit</a> | <a href="#" onclick="Delete(\'' + item.id + '\')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
            $('.total').html((--i).toString());
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for clearing the textboxes
function clearTextBox() {
    $('#ID').val("");
    $('#NumberOfRooms').val("1");
    $('#Space').val("40");
    $('#Level').val("3");
    $('#NumberOfStoreys').val("5");
    $('#Adres').val("Test Stret, 45");
    $('#Price').val("2000000");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#NumberOfRooms').css('border-color', 'lightgrey');
    $('#Space').css('border-color', 'lightgrey');
    $('#Level').css('border-color', 'lightgrey');
    $('#NumberOfStoreys').css('border-color', 'lightgrey');
    $('#Adres').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
    $('.msg-error').html('');
    $('.msg-error').hide();
}

//Add Data Function 
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var aObj = {
        ID: $('#ID').val(),
        NumberOfRooms: $('#NumberOfRooms').val(),
        Space: $('#Space').val(),
        Level: $('#Level').val(),
        NumberOfStoreys: $('#NumberOfStoreys').val(),
        Adres: $('#Adres').val(),
        Price: $('#Price').val()
    };
    $.ajax({
        url: "/Home/Add",
        data: JSON.stringify(aObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#NumberOfRooms').val().trim() == "-1") {
        $('#NumberOfRooms').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberOfRooms').css('border-color', 'lightgrey');
    }
    if ($('#Space').val().trim() == "") {
        $('#Space').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Space').css('border-color', 'lightgrey');
    }
    if ($('#Level').val().trim() == "") {
        $('#Level').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Level').css('border-color', 'lightgrey');
    }
    if ($('#NumberOfStoreys').val().trim() == "") {
        $('#NumberOfStoreys').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#NumberOfStoreys').css('border-color', 'lightgrey');
    }
    if ($('#Adres').val().trim() == "") {
        $('#Adres').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Adres').css('border-color', 'lightgrey');
    }
    if ($('#Price').val().trim() == "") {
        $('#Price').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Price').css('border-color', 'lightgrey');
    }

    return isValid;
}

//function for deleting record
function Delete(id) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/Delete/" + id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for getting the Data Based upon Apartment ID
function getbyID(aID) {
    $('#NumberOfRooms').css('border-color', 'lightgrey');
    $('#Space').css('border-color', 'lightgrey');
    $('#Level').css('border-color', 'lightgrey');
    $('#NumberOfStoreys').css('border-color', 'lightgrey');
    $('#Adres').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/getbyID/" + aID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.id);
            $('#NumberOfRooms').val(result.numberOfRooms);
            $('#Space').val(result.space.toFixed(2));
            $('#Level').val(result.level);
            $('#NumberOfStoreys').val(result.numberOfStoreys);
            $('#Adres').val(result.adres);
            $('#Price').val(result.price.toFixed(0));
            $('.msg-error').html('');
            $('.msg-error').hide();

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating Apartment's record
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var aObj = {
        ID: $('#ID').val(),
        NumberOfRooms: $('#NumberOfRooms').val(),
        Space: $('#Space').val(),
        Level: $('#Level').val(),
        NumberOfStoreys: $('#NumberOfStoreys').val(),
        Adres: $('#Adres').val(),
        Price: $('#Price').val(),
    };
    $.ajax({
        url: "/Home/Update",
        data: JSON.stringify(aObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ID').val("");
            $('#NumberOfRooms').val("-1");
            $('#Space').val("");
            $('#Level').val("");
            $('#NumberOfStoreys').val("");
            $('#Adres').val("");
            $('#Price').val("");
            $('.msg-error').html('');
            $('.msg-error').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
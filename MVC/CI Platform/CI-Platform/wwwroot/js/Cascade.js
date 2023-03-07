$(document).ready(function () {
    //alert('ok');
    GetCountry();
    $('#countrylist').change(function (){
        var countryId = $(this).val();
        $('#citylist').empty();
        $('#citylist').append('<option>Select city</option>');
        $.ajax({
            url: '/User/City?countryId=' + countryId,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#citylist').append('<option value=' + data.cityId + '>' + data.name + '</option>');
                });
            }
        });
    });
    GetTheme();
    GetSkills();

});



function GetCountry() {
    $.ajax({
        url:'/User/Country',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#countrylist').append('<option value=' + data.countryId + '>' + data.name + '</option>');
            });
        }
    });
}


function GetTheme() {
    $.ajax({
        url: '/User/Themes',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#themelist').append('<option value=' + data.missionthemeId + '>' + data.name + '</option>');
            });
        }
    });
}


function GetSkills() {
    $.ajax({
        url: '/User/Skills',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#skilllist').append('<option value=' + data.skillId + '>' + data.skillName + '</option>');
            });
        }
    });
}




var kaarsearch = document.getElementById('#search');
var missionlist = document.getElementsByClass('.mission-list');
var missiontitle = document.createElementByClass('.card-title');


kaarsearch.addEventListener('keyup', SearchMission);


function SearchMission() {
    var low = kaarsearch.to.LowerCase();

}





//var select1 = document.getElementById('countrylist');
//var select2 = document.getElementById('citylist');
//var input = document.getElementById('displayselectedvalue');
//select1.onchange = function ()
//{
//    input.text = select1.name;
//}
//select2.onchange = function ()
//{
//    input.text = select2.name;
//}



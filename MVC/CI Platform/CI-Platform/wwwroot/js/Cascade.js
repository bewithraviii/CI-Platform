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






var kaarsearch = document.querySelector("#search");
var missionlist = document.querySelectorAll(".mission-list");
var missiontitle = document.querySelectorAll(".card-title");
kaarsearch.addEventListener('keyup',SearchMission);


function SearchMission(event)
{
    

    var str = kaarsearch.value.toLowerCase();
    var visibleMissions = 0;

    for (var i = 0; i < missionlist.length; i++)
    {
        if (missiontitle[i].innerHTML.toLowerCase().include(str))
        {
            missionlist[i].classList.remove("d-none")
        }
        else
        {
            missionlist[i].classList.add("d-none");
        }
    }
    console.log(visibleMissions);
    if (visibleMissions === 0)
    {
        document.getElementById("nomissionfound").style.display = "block";
        document.getElementById("mission-list").style.display = "none";
        document.getElementById("total-mission").textContent = "";
    }
    else
    {
        document.getElementById("nomissionfound").style.display = "none";
        document.getElementById("mission-count").textContent = (visibleMissions) + " mission" + (visibleMissions > 1 ? "s" : "");
    }
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



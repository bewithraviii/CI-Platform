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
                    $('#citylist').append('<li class = "dropbtn"><input class="form-check-input me-2" value="data.name" type = "checkbox" id = ""/>'+data.name+'</li>');
                });
            }
        });
    });
    GetTheme();
    GetSkills();

});



function GetCountry() {
    $('#countrylist').append('<option>Select city</option>');
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
                $('#themelist').append('<option value=' + data.missionThemeId + '>' + data.title + '</option>');
            });
        }
    });
}


function GetSkills() {
    $.ajax({
        url: '/User/Skills',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#skilllist').append('<li class = "dropbtn"><input class="form-check-input me-2" value="data.name" type = "checkbox" id = ""/>' + data.name +'</li>');
            });
        }
    });
}






var kaarsearch = document.querySelector("#search");
var missionlist = document.querySelectorAll("#mission-card");
var missiontitle = document.querySelectorAll(".card-title");
var missionorganiser = document.querySelectorAll("#organisationmission");
kaarsearch.addEventListener('keyup',SearchMission);


function SearchMission()
{
    

    var str = kaarsearch.value.toLowerCase();
    var visibleMissions = 0;

    for (var i = 0; i < missionlist.length; i++)
    {
        if ((missiontitle[i].innerHTML.toLowerCase().includes(str)) || (missionorganiser[i].innerHTML.toLowerCase().includes(str)))
        {
            missionlist[i].classList.remove("d-none");
            visibleMissions ++;
        }
        else
        {
            missionlist[i].classList.add("d-none");
        }
    }
    console.log(visibleMissions);
    if (visibleMissions == 0)
    {
        document.getElementById("nomissionfound").style.display = "block";
        //document.getElementById("mission-card").style.display = "none";
        document.getElementById("total-mission").textContent =  "0 missions";
    }
    else
    {
        document.getElementById("nomissionfound").style.display = "none";
        document.getElementById("total-mission").textContent = (visibleMissions) + " mission" + (visibleMissions > 1 ? "s" : "");
    }
}




//pagination



/*....................................................................................Trial-2.......................................................................................*/

    //let thisPage = 1;
    //let limit = 3;
    
    //let list = document.querySelectorAll('.mission-list .card');
    //function loadItem(){
    //    let beginGet = limit * (thisPage - 1);
    //let endGet = limit * thisPage - 1;
    //list.forEach((item, key)=>{
    //    if(key >= beginGet && key <= endGet){
    //    item.style.display = 'grid';
    //    }
    //    else
    //    {
    //    item.style.display = 'none';
    //    }
    //})
    //listPage();
    //}
    //loadItem();
    //function listPage(){
    //    let count = Math.ceil(list.length / limit);
    //document.querySelector('.listPage').innerHTML = '';

    //    let doubleprev = document.createElement('li');
    //    doubleprev.innerText = '<<';
    //    if (thisPage > 2) {
    //        doubleprev.setAttribute('onclick', "changePage(" + (thisPage - 2) + ")");
    //        document.querySelector('.listPage').appendChild(doubleprev);
    //    }
    //    else if (thisPage > 1){
    //        doubleprev.setAttribute('onclick', "changePage(" + (thisPage - 1) + ")");
    //        document.querySelector('.listPage').appendChild(doubleprev);
    //    }
    //    else {
    //        doubleprev.setAttribute('onclick', "changePage(" + (thisPage) + ")");
    //        document.querySelector('.listPage').appendChild(doubleprev);
    //    }

    //let prev = document.createElement('li');
    //    prev.innerText = '<';
    //    if (thisPage > 1) {
    //        prev.setAttribute('onclick', "changePage(" + (thisPage - 1) + ")");
    //        document.querySelector('.listPage').appendChild(prev);
    //    }
    //    else
    //    {
    //        prev.setAttribute('onclick', "changePage(" + (thisPage) + ")");
    //        document.querySelector('.listPage').appendChild(prev);
    //    }

    //for(i = 1; i <= count; i++){
    //    let newPage = document.createElement('li');
    //newPage.innerText = i;
    //if(i == thisPage){
    //    newPage.classList.add('active');
    //        }
    //newPage.setAttribute('onclick', "changePage(" + i + ")");
    //document.querySelector('.listPage').appendChild(newPage);
    //    }


    //    let next = document.createElement('li');
    //    next.innerText = '>';
    //    if (thisPage < count) {
    //        next.setAttribute('onclick', "changePage(" + (thisPage + 1) + ")");
    //        document.querySelector('.listPage').appendChild(next);
    //    }
    //    else {  
    //    next.setAttribute('onclick', "changePage(" + (thisPage) + ")");
    //    document.querySelector('.listPage').appendChild(next);
    //    }

    //    let doublenext = document.createElement('li');
    //    doublenext.innerText = '>>';
    //    if (thisPage < count -1) {
    //        doublenext.setAttribute('onclick', "changePage(" + (thisPage + 2) + ")");
    //        document.querySelector('.listPage').appendChild(doublenext);
    //    }
    //    else if (thisPage < count)
    //        {
    //        doublenext.setAttribute('onclick', "changePage(" + (thisPage + 1) + ")");
    //        document.querySelector('.listPage').appendChild(doublenext);
    //        }
    //    else {
    //        doublenext.setAttribute('onclick', "changePage(" + (thisPage) + ")");
    //        document.querySelector('.listPage').appendChild(doublenext);
    //    }
   
    //}
    //function changePage(i){
    //    thisPage = i;
    //loadItem();
    //}







/*....................................................................................Trial-1.......................................................................................*/


//function getpagelist(totalpages, page, maxlength) {
//    function range(start, end) {
//        return Array.from(Array(end - start + 1), (_, i) => i + start);
//    }

//    var sidewidth = maxlength < 9 ? 1 : 2;
//    var leftwidth = (maxlength - sidewidth * 2 - 3) >> 1;
//    var rightwidth = (maxlength - sidewidth * 2 - 3) >> 1;

//    if (totalpages <= maxlength) {
//        return range(1, totalpages);
//    }

//    if (page <= maxlength - sidewidth - 1 - rightwidth) {
//        return range(1, maxlength - sidewidth - 1).concat(0, range(totalpages - sidewidth + 1, totalpages));
//    }

//    if (page >= totalpages - sidewidth - 1 - rightwidth) {
//        return range(1, sidewidth).concat(0, range(totalpages - sidewidth - 1 - rightwidth - leftwidth, totalpages));
//    }

//    return range(1, sidewidth).concat(0, range(page - leftwidth, page + rightwidth), 0, range(totalpages - sidewidth + 1, totalpages));


//}

//$(function ()
//{
//    var numberofitem = $(".mission-list .mission").length;
//    var limitperpage = 9; //how many card should be visible per page
//    var totalpages = Math.ceil(numberofitem / limitperpage);
//    var paginationsize = 5;
//    var currentpage;


//    function showpage(whichpage)
//    {
//        if (whichpage < 1 || whichpage > totalpages) return false;

//        currentpage = whichpage;

//        $(".mission-list .mission").hide().slice((currentpage - 1) * limitperpage, currentpage * limitperpage).show();

//        $(".pagination li").slice(1, -1).remove();

//        getpagelist(totalpages, currentpage, paginationsize).forEach(item => {
//            $("<li>").addClass("page-item").addClass(item ? "current-page" : "dots")
//                .toggleclass("active", item == currentpage).append($("<a>").addClass("page-link")
//                    .attr({ href: "javascript.void(0)" }).text(item || "2")).insertBefore(".next-page");
//        });

//        $(".previous-page").toggleClass("disable", currentpage === 1);
//        $(".next-page").toggleClass("disable", currentpage === totalpages);
//        return true;

//    }

//    $(".pagination").append(
//        $("<li>").addClass("page-item").addClass("previous-page").append($("<a>").addClass("page-link").attr({ href: "javascript:void(0)" }).text("<")),
//        $("<li>").addClass("page-item").addClass("next-page").append($("<a>").addClass("page-link").attr({ href: "javascript:void(0)" }).text(">"))
//    );

//    $(".mission-list").show();
//    showpage(1);

//    $(document).on("click", ".pagination li.current-page:not(.active)", function () {
//        return showpage(+$(this).text());
//    });


//    $(".next-page").on("click", function () {
//        return showpage(currentpage + 1);
//    });
//    $(".previous-page").on("click", function () {
//        return showpage(currentpage - 1);
//    });

//});










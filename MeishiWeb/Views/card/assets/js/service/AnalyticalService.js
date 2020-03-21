$(document).ready(function() {

    var analyticalService = new AnalyticalService();

    // tigger on service links
    $(".contact-details-link").on("click", function (event) {

        var pLink = jQuery(this).attr("id");
        var model = new DataModel(pLink, $('a[name ="email"]')[0].innerText, "Profile");
        //alert(model.label);
        //alert(model.email);
        
        //alert(pLink);
        //alert(model.names);
        analyticalService.saveStatistics(model);
    });

    $(".fancybox").on("click",function (event) {
        // console.log(event.target.href);
        //alert(event.target);
        var cLink = jQuery(this).attr("id");
        var model = new DataModel(cLink, $('a[name ="email"]')[0].innerText, "Services");
        //alert(cLink);
        analyticalService.saveStatistics(model);
    });
});


class DataModel{
    names = "";
    email = "";
    area = "";
    constructor(names, email, area){
        this.names = names;       
        this.email = email;       
        this.area = area;       
    }
}



class AnalyticalService{
    constructor(){
    }

    saveStatistics(model){
        
         //$.post({
         //    type: "POST",
         //    url: "https://localhost:44348/Views/card/Analytics",
         //    headers: {
         //        Accept: "application/json",
         //        "Content-Type": "application/json"
         //    },
         //    data: model,
         //    success: function (output) {
         //        console.log('saved' + output);
         //    }
         //});

        $.ajax({
            url: "/card/Analytics",
            method: 'POST',
            dataType: 'json',
            data: JSON.stringify (model),
            contentType: 'application/json',
            mimeType: 'application/json',
            success: function (data) {
                //alert("success");
                //commit(true);
            },
            error:function(data,status,er) {
                console.log("error: "+data+" status: "+status+" er:"+er);
            }
        });

    }

}

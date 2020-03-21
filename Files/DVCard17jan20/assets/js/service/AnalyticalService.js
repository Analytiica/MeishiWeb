$(document).ready(function() {

    var analyticalService = new AnalyticalService();

    // tigger on service links
    $(".contact-details-link").on("click",function (event) {
        var model = new DataModel(event.target.name, event.target.href,($('a[name ="email"]')[0].innerText));
        analyticalService.saveStatistics(model);
    });

    $(".fancybox").on("click",function (event) {
        // console.log(event.target.href);
        analyticalService.saveStatistics(event.target.href);
        var model = new DataModel(event.target.name, event.target.href,($('a[name ="email"]')[0].innerText));
        analyticalService.saveStatistics(model);
    });
});


class  DataModel{
    label = "";
    link = "";
    email = "";
    constructor(label,link, email){
    this.label = label;
    this.link = link;
    this.email = email;
    }
}



class AnalyticalService{
    constructor(){
    }

    saveStatistics(model){
        console.log(model);

        // $.post({
        //     type: "POST",
        //     url: "http://localhost:8080/save",
        //     headers: {
        //         Accept: "application/json",
        //         "Content-Type": "application/json"
        //     },
        //     data: model,
        //     success: function (output) {
        //         console.log('saved' + output);
        //     }
        // });

        $.ajax({
            url: "http://localhost:8080/save",
            method: 'POST',
            dataType: 'json',
            body: model,
            data: model,
            contentType: 'application/json',
            mimeType: 'application/json',
            success: function(data) {
                //commit(true);
            },
            error:function(data,status,er) {
                console.log("error: "+data+" status: "+status+" er:"+er);
            }
        });

    }

}

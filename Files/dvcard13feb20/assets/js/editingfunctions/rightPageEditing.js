$(document).ready(function() {

    function getFiles() {
        var directory="http://wordpress2.com/uploads/serviceicons";
        // $.ajax({
        //     type: "GET",
        //     url: directory,
        //     async:true,
        //     dataType : 'html',   //you may use jsonp for cross origin request
        //     crossDomain:true,
        //     success: function(data, status, xhr) {
        //         alert(data);
        //     }
        // });


        var xmlHttp = new XMLHttpRequest();
        xmlHttp.open( "GET", directory, false ); // false for synchronous request
        xmlHttp.send();
        var ret=xmlHttp.responseText;

        console.log("ret",ret);
        var fileList=ret.split('\n');

        let str = "";
        let fileNames = [];

        for(let i=0;i<fileList.length;i++){
            var fileinfo = fileList[i].split(' ');
            if ( i > 6 && i !== 20) {
                str += fileList[i];
                if(fileinfo.length > 4){
                    if(fileinfo[4].indexOf('.png')  > -1){
                        let subs = fileinfo[4];
                        subs = fileinfo[4].substr(fileinfo[4].indexOf('"')+1);
                        subs = subs.substr(0,subs.indexOf('"'));
                        fileNames.push(subs);
                    }
                }

            }
        }
        console.log(fileNames);
        return fileNames;
    }



    // when action triggered on color changed
    // $("#FNColorChange").on("change",function(){
    // });

    // $("#landingHeaderSubmitChange").on("click",function(){
    $(".effect-apollo").on("click",function(event){
        $('#exampleModal').modal('show');
        let currentIcon = event.currentTarget.children[0].getAttribute("src");
        let currentId = event.currentTarget.children[0].getAttribute("id");

        let files = getFiles();

        if(files.length > 0){
            let html = "";
            for(let i=0; i < files.length;i++) {
                if(currentIcon.indexOf(files[i]) < 0){
                    html += '<div class="col-md-3 icon-gallery-item" style="background: url(uploads/serviceicons/'+ files[i] +') no-repeat center center;height: 121px"></div>'
                }
            }
            $("#icon-gallery").html(html);


            $(".icon-gallery-item").on("click",function (event){
                let location = window.location.href;

                let files = getFiles();
                let string = event.currentTarget.getAttribute("style");
                if (location.indexOf('#') >  0 ) {

                    location = location.substring(location.indexOf('#')+1);

                    console.log("location",location);
                    console.log("event",event.currentTarget.getAttribute("style"));
                    for(let i = 0;i<files.length;i++)
                    {
                        if(string.indexOf(files[i])>0){
                            console.log("=",files[i]);
                            let model = new EditIcon();
                            model.gridName = location;
                            model.email = ($('a[name ="email"]')[0].innerText);
                            model.iconName = files[i];

                            saveIconChange(model);

                            $('#exampleModal').modal('hide');
                        }
                    }

                }

            });
        }
    });

    class  EditorCommon{
        email = ""; // identifier
        text = "";
        textColor = "";
        fontSize = "";
        fontStyle = "";
        tag = "";
        before = "";
        constructor(){
        }
    }
    class EditIcon{
        email = ""; // identifier
        iconName = "";
        gridName = "";

        constructor(){
        }
    }

    // send updates
    function  saveIconChange(model){

        $.ajax({
            url: "http://localhost:8080/save",
            method: 'POST',
            dataType: 'json',
            body: model,
            data: model,
            contentType: 'application/json',
            mimeType: 'application/json',
            success: function(data) {
                $('#exampleModal').modal('hide');
            },
            error:function(data,status,er) {
                console.log("error: "+data+" status: "+status+" er:"+er);
            }
        });
    }





});

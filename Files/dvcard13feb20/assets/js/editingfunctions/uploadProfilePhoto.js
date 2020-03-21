$(document).ready(function() {

    $(':file').on('change', function () {
        var file = this.files[0];

        console.log("file", file);

        if (file.size > (1000*1000*5)) {
            $("#uploadProfilePicButton").attr("disabled",true);
            alert('max upload size is 5mb');
        }else{
            $("#uploadProfilePicButton").attr("disabled",false);
        }

        // Also see .name, .type
    });
    $("#uploadProfilePicButton").on("click",function(){
        //uploadProfilePic can give the model this tag for a name
        console.log("model", $('.uploadProfilePic input[type=file]')[0].files[0]);
        // let model =
        //
        upload();
    });


    function upload(){
        console.log("uploading");
        let photo = $('.uploadProfilePic input[type=file]').val();  // file from input
        // let photo = document.getElementById('.uploadProfilePic input[type=file]').files[0];  // file from input

        let req = new XMLHttpRequest();
        let formData = new FormData();

        formData.append("photo", photo);
        req.open("POST", '/uploads');
        req.send(photo);

    }
});
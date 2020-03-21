$(document).ready(function() {


    // when action triggered on color changed
    // $("#FNColorChange").on("change",function(){
    // });

    // $("#landingHeaderSubmitChange").on("click",function(){
    $(".editorSubmitButton").on("click",function(event){
        let editorTag = event.target.parentNode;
        let editorId = "#"+editorTag.id;
        let inputList = $(editorId).find("input");
        let selectList = $(editorId).find("select");

        let model = new EditorCommon();
        model.email = ($('a[name ="email"]')[0].innerText);
        model.text = inputList[0].value;
        model.textColor = inputList[1].value;
        model.fontSize = inputList[2].value;
        model.fontStyle = selectList[0].value;
        model.tag = editorTag.id;
        saveStyleChange(model);
        $(editorId).css("display", 'none');
    });
    $(".specialLastNameEditorSubmitButton").on("click",function(event){
        let editorTag = event.target.parentNode;
        let editorId = "#"+editorTag.id;
        let inputList = $(editorId).find("input");
        let selectList = $(editorId).find("select");

        let model = new EditorCommon();
        model.email = ($('a[name ="email"]')[0].innerText);
        model.text = inputList[0].value;
        model.textColor = inputList[1].value;
        model.fontSize = inputList[2].value;
        model.before = inputList[3].value;
        model.fontStyle = selectList[0].value;
        model.tag = editorTag.id;
        saveStyleChange(model);
        $(editorId).css("display", 'none');
    });

    $(".editorCancelButton").on("click",function(event){
        let editorTag = event.target.parentNode;
        let editorId = "#"+editorTag.id;

        $(editorId).css("display", 'none');
    });

    $(".editorbgColorSubmitButton").on("click",function(event){
        let editorTag = event.target.parentNode;
        let editorId = "#"+editorTag.id;
        let inputList = $(editorId).find("input");

        let model = new EditorCommon();
        model.email = ($('a[name ="email"]')[0].innerText);
        model.textColor = inputList[0].value;
        model.tag = editorTag.id;

        saveStyleChange(model);
        $(editorId).css("display", 'none');
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
    // prevent more than 2 digits
    $(".editorCard_item input[type=number]").on("keyup",function (evt) {
        let value = evt.currentTarget.value;
        if(value.length  > 2){
            evt.currentTarget.value = value.substring(0,2);
        }
    });
    // prevent non numbers
    $(".editorCard_item input[type=number]").on("keypress",function (evt) {
        // console.log(evt.currentTarget.value);
        var theEvent = evt || window.event;

        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
        var regex = /[0-9]|\./;
        if( !regex.test(key) ) {
            theEvent.returnValue = false;
            if(theEvent.preventDefault) theEvent.preventDefault();
        }
    })

    // send updates

    function  saveStyleChange(model){

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


});

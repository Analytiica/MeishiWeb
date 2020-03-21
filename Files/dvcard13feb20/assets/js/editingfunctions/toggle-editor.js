$(document).ready(function() {

    function openCloseEditor(element){
        let elementDisplay =  element.css("display");
        checkIfAnyEditorIsOpen();
        if(elementDisplay === "none"){
            element.css("display",'inline-block');
        }else{
            element.css("display", 'none');
        }
    }

    function checkIfAnyEditorIsOpen(){
        let editors = $(".editors");
        // console.log(editors.style.display);
        // for(let i=0;i<editors.length;i++){
        //     if(editors[i].css("display") === "inline-block"){
        //         editors[i].css("display","none");
        //     }
        // }
        $('.editors').each(function(item,object){
            if(object.style.display){
                if(object.style.display === "inline-block"){
                    object.style.display = "none";
                }
            }
        });
    }

    // triggers
    //landing
    $("#firstNameTrigger").on("click",function(){
        openCloseEditor($(".firstNameTrigger").next("span"));
    });

    $("#landingHeadingTrigger").on("click",function(){
        openCloseEditor($(".landingHeadingTrigger").next("span"));
    });

    $("#jobTitleTrigger").on("click",function(){
        openCloseEditor($(".jobTitleTrigger").next("span"));
    });

    // left side
    $("#leftSideHeadingTrigger").on("click",function(){
        openCloseEditor($(".leftSideHeadingTrigger").next("span"));
    });
    $("#leftSideDescriptionTrigger").on("click",function(){
        openCloseEditor($(".leftSideDescriptionTrigger").next("span"));
    });

    $("#leftSideContactHeadingTrigger").on("click",function(){
        openCloseEditor($(".leftSideContactHeadingTrigger").next("span"));
    });
    $("#leftSideContactDescriptionTrigger").on("click",function(){
        openCloseEditor($(".leftSideContactDescriptionTrigger").next("span"));
    });
    $("#leftSideContactEmailTrigger").on("click",function(){
        openCloseEditor($(".leftSideContactEmailTrigger").next("span"));
    });
    $("#leftSideContactMobileTrigger").on("click",function(){
        openCloseEditor($(".leftSideContactMobileTrigger").next("span"));
    });
    $("#leftSideContactlandlineTrigger").on("click",function(){
        openCloseEditor($(".leftSideContactlandlineTrigger").next("span"));
    });


    // ------- SPECIAL CASES -----------------
    $("#landingBackgroundTrigger").on("click",function(){
        openCloseEditor($(".landingBackgroundTrigger").next("span"));
    });

    $("#lastNameTrigger").on("click",function(){
        openCloseEditor($(".lastNameTrigger").next("span"));
    });

    $("#leftSideRequestCallTrigger").on("click",function(){ // left side
        openCloseEditor($(".leftSideRequestCallTrigger").next("span"));
    });

    $("#leftSidesaveContactTrigger").on("click",function(){ // left side
        openCloseEditor($(".leftSidesaveContactTrigger").next("span"));
    });

    $("#leftSidewhatsappShareTrigger").on("click",function(){ // left side
        openCloseEditor($(".leftSidewhatsappShareTrigger").next("span"));
    });
    $("#leftSideSendButtonTrigger").on("click",function(){ // left side
        openCloseEditor($(".leftSideSendButtonTrigger").next("span"));
    });
    $("#leftSideProfilePicTrigger").on("click",function(){ // left side
        openCloseEditor($(".leftSideProfilePicTrigger").next("span"));
    });
    $("#rightlandingBackgroundTrigger").on("click",function(){ // left side
        openCloseEditor($(".rightlandingBackgroundTrigger").next("span"));
    });$("#landingBotTrigger").on("click",function(){ // left side
        openCloseEditor($(".landingBotTrigger").next("span"));
    });
    $("#landingAboutMeTrigger").on("click",function(){ // left side
        openCloseEditor($(".landingAboutMeTrigger").next("span"));
    });$("#landingServiceTrigger").on("click",function(){ // left side
        openCloseEditor($(".landingServiceTrigger").next("span"));
    });



});
//<!---
$("#saveData").on("click", function(){
    // get form
    var form = document.forms["detailsForm"].getElementsByTagName("input");
    // check if form has input elements
    if(form && form.length){
        saveDetails(buildModel(form));
    }
});

class FormDetails{
    email = "";
    firstName = "";
    lastName = "";
    website = "";
    jobTitle = "";

    detailId = "";
    CompanyId = "";
    StreetName = "";
    addressLing = "";
    province = "";
    postalCode = "";
    country = "";
    displayName = "";
    companyLogo = "";
    company_moto = "";
    agentName = "";
    introduction = "";
    middleName = "";
    alias = "";
    bio = "";
    location = "";
    profilePic = "";

    constructor(){
    }
}

function buildModel(form){
    // add all the names of the input to retrieve their data
    var allDetails = new FormDetails();
    allDetails.email = validate(form.namedItem("email"));
    allDetails.firstName = validate(form.namedItem("firstName"));
    allDetails.jobTitle = validate(form.namedItem("jobTitle"));
    allDetails.lastName = validate(form.namedItem("lastName"));
    allDetails.website = validate(form.namedItem("website"));
    return allDetails;
}
function validate(input){
    // just to check that the element isnt null
    if(input){
        return input.value
    }else{
        return "";
    }
}

function saveDetails(model){
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

//--->
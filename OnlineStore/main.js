var ready = (callback) => {
    if (document.readyState != "loading") callback();
    else document.addEventListener("DOMContentLoaded", callback);
}

function clearResults() {
    document.getElementById("VCResult").innerHTML = "<div class='modal-body' id='VCResult'><p><center><i class='fa fa-spinner fa-spin' style='font-size:48px'></i></center></p></div>"
}

function notCertified() {
    document.getElementById("VCResult").innerHTML = "<div class='modal-body' id='VCResult'><p>This product has not yet been certified. </br> Please check back again soon.</p></div>"
}


var counter = 0

function poll() {
    // var verifierURL = 'https://didofthings.azurewebsites.net/ingredients'
    var verifierURL = 'https://didofthings.azurewebsites.net/ing'

    const options = {
        method: 'GET',
        cache: 'no-store',
        "Content-TYpe": 'application/json',
        "Access-Control-Allow-Origin": 'https://didofthings.azurewebsites.net'
    };

    fetch(verifierURL, options)
        .then((response) => {
            return response.json()
        }).then((data) => {
            // alert(data)
            try {
                vcDetails = JSON.parse(data)
                document.getElementById("VCResult").innerHTML = "<b><i><h5><center>" + vcDetails.productName + "</center></h5></i></b></br><b>Allergens:</b> " + vcDetails.allergenName + "</br></br><b>Ingredients: </b>" + vcDetails.ingredientName + "</br>"
                console.log(data)
                clearTimeout(timeoutId);
            } catch {
                // hopefully the data is there on the next interation 
            }
        }).catch((err) => {
            console.log(data)
        })
    counter++
    if (counter >= 80) {
        document.getElementById("VCResult").innerHTML = "<b>Timed out waiting for verification of the product. </br>Please try again shortly or see your Administrator.</b>"
        clearTimeout(timeoutId);
    }
    let timeoutId = setTimeout(poll, 1500)
};

ready(() => {
    document.querySelector(".header").style.height = window.innerHeight + "px";
})


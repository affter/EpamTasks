/*jslint plusplus: true */

    var closeButton = document.querySelector(".close-window"),
        restartButton = document.querySelector(".restart"),
        thisWindow;

closeButton.onclick = function () {
    thisWindow = window.open('','_self');
    console.log(opener);
    thisWindow.close();
}

restartButton.onclick = function () {
    window.location.assign("index.html");
}


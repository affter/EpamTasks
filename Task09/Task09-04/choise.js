/*jslint plusplus: true */

    var closeButton = document.querySelector(".close-window"),
        restartButton = document.querySelector(".restart");

closeButton.onclick = function () {
    var thisWindow = window.open(location,'_self');
}

restartButton.onclick = function () {
    window.history.go(-3);
}
/*jslint plusplus: true */

    var resumeButton = document.querySelector(".resume-timer"),
        stopButton = document.querySelector(".stop-timer"),
        backButton = document.querySelector(".back"),
        closeButton = document.querySelector(".close-window"),
        timer = document.querySelector(".timer"),
        nextPage = document.querySelector(".next-page"),
        interval,
        timeout;
    interval = setInterval(function () {
        timer.innerHTML--;
    }, 1000)
    timeout = setTimeout(function () {
        window.location.assign(nextPage.innerHTML)
    }, timer.innerHTML*1000)


stopButton.onclick = function() {
    resumeButton.disabled = false;
    stopButton.disabled = true;
    clearInterval(interval);
    clearInterval(timeout);
    }

resumeButton.onclick = function () {
    resumeButton.disabled = true;
    stopButton.disabled = false;
    interval = setInterval(function () {
        timer.innerHTML--;
    }, 1000)
    timeout = setTimeout(function () {
        window.location.assign("index2.html")
    }, timer.innerHTML*1000)

}

backButton.onclick = function () {
    window.history.back();
}
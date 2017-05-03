/*jslint plusplus: true */


var buttons,
    i,
    warning = document.createElement("span");
warning.className = "warning";
warning.innerHTML = "No options selected";

function move(from, to) {
    "use strict";
    var options = from && from.options,
        opt,
        movedOptions,
        selectionStatus = false;
    for (i = 0; i < options.length; i++) {
        opt = options[i];
        if (opt.selected) {
            selectionStatus = true;
            to.appendChild(opt);
            i--;
        }
    }
    if (!selectionStatus) {
        to.parentElement.appendChild(warning);
    } else if (to.parentElement.lastChild === warning) {
        to.parentElement.removeChild(warning);
    }
}

function moveAll(from, to) {
    "use strict";
    var options = from && from.options;
    for (i = 0; i < options.length;) {
            to.appendChild(options[i]);
    }
    if (to.parentElement.lastChild === warning) {
        to.parentElement.removeChild(warning);
    }
}

buttons = document.querySelectorAll("button.move-left");
for (i = 0; i < buttons.length; i++) {
    buttons[i].onclick = function () {
        move(this.parentElement.parentElement.children.item(2), this.parentElement.parentElement.children.item(0))
    }
}

buttons = document.querySelectorAll("button.move-right")
for (i = 0; i < buttons.length; i++) {
    buttons[i].onclick = function () {
        move(this.parentElement.parentElement.children.item(0), this.parentElement.parentElement.children.item(2))
    }
}

buttons = document.querySelectorAll("button.move-all-left")
for (i = 0; i < buttons.length; i++) {
    buttons[i].onclick = function () {
        moveAll(this.parentElement.parentElement.children.item(2), this.parentElement.parentElement.children.item(0))
    }
}

buttons = document.querySelectorAll("button.move-all-right")
for (i = 0; i < buttons.length; i++) {
    buttons[i].onclick = function () {
        moveAll(this.parentElement.parentElement.children.item(0), this.parentElement.parentElement.children.item(2))
    }
}
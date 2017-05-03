/*jslint plusplus: true */


var buttons,
    i;

function move(from, to) {
    "use strict";
    var options = from && from.options,
        opt,
        movedOptions;
    for (i = 0; i < options.length; i++) {
        opt = options[i];
        if (opt.selected) {
            to.appendChild(opt);
            i--;
        }
    }
}

function moveAll(from, to) {
    "use strict";
    var options = from && from.options;
    for (i = 0; i < options.length;) {
            to.appendChild(options[i]);
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
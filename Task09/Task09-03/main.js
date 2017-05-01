/*jslint plusplus: true */

function move(from, to) {
    "use strict";
    var options = from && from.options,
        opt,
        movedOptions,
        i;
    for (i=0; i<options.length; i++) {
        opt = options[i];
        if (opt.selected) {
            to.appendChild(opt)
            i--;
        }
    }
}

function moveAll(from, to) {
    "use strict";
    var options = from && from.options,
        i;
    for (i=0; i<options.length;) {
            to.appendChild(options[i])
    }
}
/*jslint plusplus: true */

function findDuplicateSymbols(splittedInputString) {
    "use strict";
    var i,
        duplicatesArray = [],
        duplicates = [],
        separators = " ?!:;,.";
    for (i = 0; i < splittedInputString.length; i++) {
        if (separators.indexOf(splittedInputString[i]) < 0) {
            if (duplicatesArray.indexOf(splittedInputString[i]) >= 0) {
                duplicates.push(splittedInputString[i]);
            } else if (duplicates.indexOf(splittedInputString[i]) < 0) {
                duplicatesArray.push(splittedInputString[i]);
            }
        } else {
            duplicatesArray = [];
        }
    }
    return duplicates;
}

function removeDuplicates() {
    "use strict";
    var inputString,
        splittedInputString,
        duplicates,
        i;
    inputString = window.data.value;
    splittedInputString = inputString.split("");
    duplicates = findDuplicateSymbols(splittedInputString);
    for (i = 0; i < duplicates.length; i++) {
        while (splittedInputString.indexOf(duplicates[i]) >= 0) {
            splittedInputString.splice(splittedInputString.indexOf(duplicates[i]), 1);
        }
    }
    window.output.value = splittedInputString.join("");
}


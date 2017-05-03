/*jslint plusplus: true */

document.querySelector(".calculate-button").onclick = function () {
    calculate();
}

function calculateEqPart(eqPart) {
    "use strict";
    var eqPartValue,
        signs,
        numbers;
    numbers = eqPart.toString().match(/-?\d+(?:\.\d+)?/g);
    signs = eqPart.toString().match(/[+*\-\/]/g);
    if (signs.length === 1 && numbers[1] < 0) {
        signs[0] = '+';
    }
    if (signs.length === 2 && numbers[1] < 0) {
        signs[1] = signs[0];
    }
    if (signs.length === 2 && numbers[1] < 0 && numbers[0] < 0) {
        signs[1] = '+'
    }
    switch (signs[parseInt(signs.length / 2, 10)]) {
        case '+': {
            return parseFloat(numbers[0]) + parseFloat(numbers[1]);
        }
        case '-': {
            return numbers[0] - numbers[1];
        }
        case '*': {
            return numbers[0] * numbers[1];
        }
        case '/': {
            return numbers[0] / numbers[1];
        }
        default: {
            break;
        }
    }
}

function calculate() {
    "use strict";
    var eq,
        eqPart,
        eqPartValue;
    eq = document.querySelector(".equation").value;
    if (!eq.match(/^-?\d+(?:\.\d+)?(?: ?[+*\/\-] ?-?\d+(?:\.\d+)?)* ?=$/)) {
        document.querySelector(".result").value = "Calculation error";
    } else {
        while (eq.match(/^-?\d+(?:\.\d+)? ?[+*\/\-] ?-?\d+(?:\.\d+)?/)) {
            eqPart = eq.match(/^-?\d+(?:\.\d+)? ?[+*\/\-] ?-?\d+(?:\.\d+)?/);
            eqPartValue = calculateEqPart(eqPart);
            eq = eq.replace(eqPart, eqPartValue);
        }
        document.querySelector(".result").value = parseFloat(eq.match(/-?\d+(?:\.\d+)?/)).toLocaleString("ru-RU",{minimumFractionDigits:0, maximumFractionDigits:3});
    }
}


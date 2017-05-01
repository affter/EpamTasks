/*jslint plusplus: true */

function calculateEqPart(eqPart) {
    "use strict";
    var eqPartValue,
        signs,
        numbers;
    numbers = eqPart.toString().match(/-?\d+(?:\.\d+)?/g);
    signs = eqPart.toString().match(/[+*\-\/]/g);
    console.log(signs);
    console.log(numbers);
    if (signs.length === 1 && numbers[1] < 0) {
        signs[0] = '+';
    }
    if (signs.length === 2 && numbers[1] < 0) {
        signs[1] = signs[0];
    }
    if (signs.length === 2 && numbers[1] < 0 && numbers[0] < 0) {
        signs[1] = '+'
    }
    console.log(signs[parseInt(signs.length / 2, 10)]);
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
    eq = window.equation.value;
    if (!eq.match(/^-?\d+(?:\.\d+)?(?: ?[+*\/\-] ?-?\d+(?:\.\d+)?)* ?=$/)) {
        window.result.value = "Calculation error";
    } else {
        while (eq.match(/^-?\d+(?:\.\d+)? ?[+*\/\-] ?-?\d+(?:\.\d+)?/)) {
            eqPart = eq.match(/^-?\d+(?:\.\d+)? ?[+*\/\-] ?-?\d+(?:\.\d+)?/);
            eqPartValue = calculateEqPart(eqPart);
            eq = eq.replace(eqPart, eqPartValue);
            console.log(eqPart);
        }
        window.result.value = parseFloat(eq.match(/-?\d+(?:\.\d+)?/)).toLocaleString("ru-RU",{minimumFractionDigits:0, maximumFractionDigits:3});
    }
}


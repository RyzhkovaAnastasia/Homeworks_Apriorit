function validNumber(n) {
    return isFinite(n);
}

function addDays(days) {
    var currentDate = new Date(this.valueOf());
    currentDate.setDate(currentDate.getDate() + days);
    return currentDate;
}

function evenFilter(source) {
    return source.filter(number => number % 2 === 0);
}

function cutStrings(source, length) {
    if (typeof (source) === typeof ('')) {
        return source.substr(0, length);
    } else {
        return 'Source is not string';
    }
}

function getFibonachi(length) {
    if (!isFinite(length)) {
        return 'Length is not a number';
    }
    if (length === 1) {
        return [0, 1];
    }
    else {
        var s = getFibonachi(length - 1);
        s.push(s[s.length - 1] + s[s.length - 2]);
        return s;
    }
}

function myDeepCopy(source) {
    var destinationObject;
    for (key in source) {
        if (typeof source[key] != "object") {
            destinationObject[key] = source[key];
        } else {
            destinationObject[key] = {};
            myDeepCopy(source[key], destinationObject[key]);
        }
    }
    return destinationObject;
}

function extend(source, bonus) {
    for (variable in bonus) {
        if (!source[variable]) {
            source[variable] = bonus[variable];
        }
    }
    return source;
}

function powBuilder(pow) {
    return (n) => {
        return isFinite(n) && isFinite(pow) ? n ** pow : 'Parameter is not number';
    }
}

String.prototype.firstToUppercase = function firstToUppercase(s) {
    return s.charAt(0).toUpperCase() + s.substr(1);
}

function countIntegerArguments(args) {
    var counter = 0;
    for (let i = 0; i < arguments.length; i++)
        if (typeof (arguments[i]) === "number") {
            counter++;
        }
    return counter;
}

function countIntegerArguments_SecondWay(args) {
    var agrs = Array.prototype.slice.call(arguments, 0);
    return agrs.filter(arg => typeof (arg) === "number").length;
}

function executeWithDelay(func, delay) {
    setTimeout(func, delay);
}



function getComment(id) {

    let promise = new Promise((resolve, reject) => {
        fetch('https://jsonplaceholder.typicode.com/todos/' + id)
            .then(response => response.json())
            .then(json => {
                if (json.id != null) {
                    resolve(json.id);
                } else {
                    reject('Cannot find id');
                }
            }
            );
    });
    
    return promise
        .then(
            result => {
                return "Id " + result + " was found!";
            },
            error => {
                return error;
            }
        );
}


function getUserAge(user) {
    let { personalInfo } = user;
    let { dob } = personalInfo;
    let diff = (new Date() - new Date(dob));
    let ageDate = new Date(diff);
    return Math.abs(ageDate.getUTCFullYear() - 1970);
}
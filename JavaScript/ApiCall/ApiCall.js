var firstNameEle = document.getElementById("firstname");
var lastNameEle = document.getElementById("lastname");
var EstablishedYearEle = document.getElementById("establishedyear");
var ceoEle = document.getElementById("ceo");
var optionEle = document.getElementById("option");
var sendButtonEle = document.getElementById("sendData");
var dataEle = document.getElementById("data");

var details = function (firstName, lastName, EstablishedYear, ceo) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.EstablishedYear = EstablishedYear;
    this.ceo = ceo;
}

details.prototype = {
    Api1Obj: function () {
        var retVal = {
            Company: {
                FirstName: this.firstName,
                LastName: this.lastName,
                Details: {
                    EstablishedYear: this.EstablishedYear,
                    CEO: this.ceo
                }
            }
        };
        return retVal;
    },
    Api2Obj: function () {
        var retVal = {
            Company: {
                Name: {
                    FirstName: this.firstName,
                    LastName: this.lastName,
                }
            },
            EstablishedYear: this.EstablishedYear,
            CEO: this.ceo
        }
        return retVal;
    }
}

sendButtonEle.onclick = function () {
    var defaultObj = new details(firstNameEle.value, lastNameEle.value, EstablishedYearEle.value, ceoEle.value);

    if (optionEle.value == 1) {
        dataEle.textContent = JSON.stringify(defaultObj.Api1Obj());
    }
    else {
        dataEle.textContent = JSON.stringify(defaultObj.Api2Obj());
    }
}

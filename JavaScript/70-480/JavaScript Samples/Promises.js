var isMomHappy = true;

// Promise
var willIGetNewPhone = new Promise(
    function (resolve, reject) {
        if (isMomHappy) {
            var phone = {
                brand: 'Samsung',
                color: 'black'
            };
            resolve(phone); // fulfilled
        } else {
            var reason = new Error('mom is not happy');
            reject(reason); // reject
        }

    }
);

var seePhone = function(phone){
    return new Promise(
        function (resolve, reject) {
            var message = 'I got a new ' +
                phone.color + ' ' + phone.brand + ' phone';

            resolve(phone, message);
        }
    );
}

var showOff = function (phone) {
    return new Promise(
        function (resolve, reject) {
            var message = 'Hey friend, I have a new ' +
                phone.color + ' ' + phone.brand + ' phone';

            resolve(message);
        }
    );
};

willIGetNewPhone
.then(seePhone)
.then((phone, message)=>{
    console.log(message);
    resolve(phone);
})
.then(showOff)
.then((message)=>{
    console.log(message);
})
.catch((error)=>{
    console.log(error);
})
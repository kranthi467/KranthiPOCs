/// <reference path="jquery-3.2.1.min.js" />

(function () {
    var Subject = function () {
        var observers = [];

        return {
            subscribeObserver: function (observer) {
                observers.push(observer);
            },
            unsubscribeObserver: function (observer) {
                var index = observers.indexOf(observer);
                if (index > -1) {
                    observers.splice(index, 1);
                }
            },
            notifyObserver: function (observer, message) {
                var index = observers.indexOf(observer);
                if (index > -1) {
                    observers[index].notify(message);
                }
            },
            notifyAllObservers: function (message) {
                for (var i = 0; i < observers.length; i++) {
                    observers[i].notify(message);
                };
            }
        };
    }

    var Observer = function (element) {
        var _selected = false;
        var _messageBox = element;
        return {
            notify: function (message) {
                var msg = document.createElement('span');
                msg.textContent = message;
                _messageBox.appendChild(msg);
                _messageBox.appendChild(document.createElement('br'));
            },
            selected: _selected
        }
    }

    var subject = new Subject();

    $("#addButton").click(function (e) {
        var messageBox = document.createElement("div");
        var subscribe = document.createElement("button");
        subscribe.textContent = '+';
        messageBox.appendChild(subscribe);
        var observer = new Observer(messageBox);
        $("#messageBoxes").append(messageBox);

        subscribe.onclick = function (e) {
            if (!observer.selected) {
                e.target.textContent = '-';
                observer.selected = true;
                subject.subscribeObserver(observer);
            }
            else {
                e.target.textContent = '+';
                observer.selected = false;
                subject.unsubscribeObserver(observer);
            }
        };
    });

    $("#send").click(function (e) {
        subject.notifyAllObservers($('#message').val());
        $('#message').val('');
    });
})()
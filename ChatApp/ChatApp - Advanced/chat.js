(function(){
  var socket = (function () {
    var _instance;
    return {
      getInstance: function () {
        if (!_instance) {
          _instance = io();
        }
        return _instance;
      },
      sendMsg: 'sent to server',
      listenMsg: 'listening from server',
      sendUser: 'register at server',
      listenUsers: 'update users',
      removeUser: 'remove from server',
      sender: function (emitTo, message) {
        return function () {
          socket.getInstance().emit(emitTo, message.value);
          message.value = '';
          console.log('Message Sent');
        }
      },
      reciever: function (messages) {
        return function (msg) {
          var msgEle = document.createElement('li');
          msgEle.textContent = msg;
          messages.appendChild(msgEle);
        }
      },
      sendUserToServer: function (emitTo, user1) {
        return function () {
          socket.getInstance().emit(emitTo, user1);
          console.log('user Sent'+ user1);
        }
      },
      updateUsers: function (usersEle) {
        return function (usrs) {
          var _users = [];
          _users = usrs.split(',');
          usersEle.innerHTML = '';
          _users.forEach(usr => {
            var usrEle = document.createElement('li');
            usrEle.textContent = usr;
            usersEle.appendChild(usrEle);
          });
        }
      }
    }
  })();

  var messages = document.getElementById('messages');
  var message = document.getElementById('message');
  var send = document.getElementById('send');
  var usersEle = document.getElementById('users');

  send.onclick = socket.sender(socket.sendMsg, message);
  socket.getInstance().addEventListener(socket.listenMsg, socket.reciever(messages));

  var user1 = prompt('Please enter user name:', 'name');

  window.onload = socket.sendUserToServer(socket.sendUser, user1);
  window.onbeforeunload = socket.sendUserToServer(socket.removeUser, user1);

  socket.getInstance().addEventListener(socket.listenUsers, socket.updateUsers(usersEle));
})();
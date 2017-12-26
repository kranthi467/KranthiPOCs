(function(){
  var socket = io();
  var form = document.getElementById('messageForm');
  var messages = document.getElementById('messages');
  var message = document.getElementById('message');
  var send = document.getElementById('send');
  send.onclick = function(){
    console.log('Hey')
    socket.emit('chat message', message.value);
    message.value = '';
    return false;
  }
  socket.addEventListener('chat message', function(msg){
    var msgEle = document.createElement('li');
    msgEle.textContent = msg;
    messages.appendChild(msgEle);
  });
});
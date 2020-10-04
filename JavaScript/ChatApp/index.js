var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var port = 3000;

app.get('/', function(req, res){
  res.sendFile(__dirname + '/index.html');
});

io.on('connection', function(socket){
  console.log('Connect with socket');
  // reseving message from one app
  socket.on('sent to server', function(msg){
    // sending message to apps (broadcasting)
    io.emit('listening from server', msg);
  });
});

http.listen(port, function(){
  console.log('listening on ' + port);
});

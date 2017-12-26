var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var port = 3000;

app.get('/', function (req, res) {
  res.sendFile(__dirname + '/index.html');
});

// // to fetch other required files
// app.get('/js', function (req, res) {
//   res.sendFile(__dirname + '/chat.js');
// });

io.on('connection', function (socket) {
  console.log('Connect with socket');
  // reseving message from one app
  socket.on('sent to server', function (msg) {
    // sending message to apps (broadcasting)
    io.emit('listening from server', msg);
  });

  var _users = [];
  // registering user from one app
  socket.on('register at server', function (user) {
    _users.push(user);
    // sending users to apps (broadcasting)
    io.emit('update users', _users.join(','));
  });

  // removing user from server
  socket.on('remove from server', function (user) {
    var index = _users.indexOf(user);
    if (index > -1) {
      _users.splice(index, 1);
      // sending users to apps (broadcasting)
      io.emit('update users', _users.join(','));
    }
  });
});

http.listen(port, function () {
  console.log('listening on ' + port);
});

var dba = require('./MyMongo.js');
var secure = require('./secure.js');
var co = require('co');
var app = secure.Express;
// var express = require('express');
// var app = express();

//app.use(express.static('public'));
// var bodyParser = require('body-parser');
// app.use(bodyParser.json());       // to support JSON-encoded bodies
// app.use(bodyParser.urlencoded({     // to support URL-encoded bodies
//   extended: true
// })); 

dba.mongoDB.findAllDocuments();

// co(function* () {
//   console.log(dba.mongoDB.findAllDocuments())
// }).catch(err => console.log(err));

// Redirect to login page
app.get('/', function (req, res) {
  res.render('login', { message: "Please Login", type: "login" });
});

app.get('/ToDo', secure.IsUserLoggedIn, function (req, res) {
  res.sendFile(__dirname + '/ToDo.html');
});

app.get('/tasks', secure.IsUserLoggedIn, function (req, res) {
  // using callback, can use for all requests also
  dba.mongoDB.findAllDocuments(function (err, results) {
    if (err)
      res.sendStatus(404);
    else
      res.send(results);
  });
  // co(function* () {
  //   var results = yield dba.mongoDB.findAllDocuments();
  //   return results;
  // })
  //   .then(results => res.send(results))
  //   .catch(err => console.log(err));
});

app.post('/tasks', secure.IsUserLoggedIn, function (req, res) {
  console.log(req.body);
  co(function* () {
    var results = yield dba.mongoDB.insertDocuments(req.body);
    return results;
  })
    .then(results => {
      console.log(results);
      res.send(results.ops[0]);
    })
    .catch(err => console.log(err));
});

app.delete('/tasks/:_id', secure.IsUserLoggedIn, function (req, res) {
  console.log(req.params._id);
  co(function* () {
    var results = dba.mongoDB.DeleteOneByID(req.params._id);
    return results;
  })
    .then(results => {
      console.log(results);
      res.json({ delete: "Success" });
    })
    .catch(err => console.log(err));
});

app.put('/tasks/:_id', secure.IsUserLoggedIn, function (req, res) {
  console.log(req.params._id);
  co(function* () {
    var results = yield dba.mongoDB.EditDocuments(req.params._id, req.body);
    return results;
  })
    .then(results => {
      console.log(results);
      res.json({ edit: "Success" });
    })
    .catch(err => console.log(err));
});

app.listen(3000, () => {
  console.log('Server is running')
});

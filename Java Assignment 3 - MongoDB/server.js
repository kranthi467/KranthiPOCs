var dba = require('./MyMongo.js');
var secure = require('./secure.js');
var co = require('co');
var app = secure.Express;

dba.mongoDB.findAllDocuments();

// Redirect to login page
app.get('/', function (req, res) {
  res.render('login', { message: "Please Login", type: "login" });
});

app.use(secure.IsUserLoggedIn);

app.get('/ToDo', function (req, res) {
  res.sendFile(__dirname + '/ToDo.html');
});

app.get('/tasks', function (req, res) {
  console.log('==>' + JSON.stringify(req.session.userid));
  // using callback, can use for all requests also
  dba.mongoDB.findAllDocuments(req.session.userid, function (err, results) {
    if (err)
      res.sendStatus(404);
    else
      res.send(results);
  });
});

app.post('/tasks', function (req, res, userid) {
  console.log(req.body);
  co(function* () {
    var results = yield dba.mongoDB.insertDocuments(req.session.userid, req.body);
    return results;
  })
    .then(results => {
      console.log(results);
      res.send(results.ops[0]);
    })
    .catch(err => console.log(err));
});

app.delete('/tasks/:_id', function (req, res, userid) {
  console.log(req.params._id);
  co(function* () {
    var results = dba.mongoDB.DeleteOneByID(req.session.userid, req.params._id);
    return results;
  })
    .then(results => {
      console.log(results);
      res.json({ delete: "Success" });
    })
    .catch(err => console.log(err));
});

app.put('/tasks/:_id', function (req, res, userid) {
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
  console.log('Server is running');
});

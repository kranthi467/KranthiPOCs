var express = require('express');
var app = express();
var session = require('express-session');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');
var Users = require('./mongooseDB.js').Users;

app.use(cookieParser());
app.use(session(
    {
        secret: "Nenu chepp@ r@ neeku",
        resave: false,
        saveUninitialized: false
    }
));
app.set('view engine', 'pug');
app.set('views', './views');
app.use(express.static('public'));   // setting static folder(exposed to net)
app.use(bodyParser.json());          // to support JSON-encoded bodies
app.use(bodyParser.urlencoded({      // to support URL-encoded bodies
    extended: true
}));

var _loggedinUsers = [];

app.get('/signup', function (req, res) {
    res.render('login', { message: "Please Sign Up", type: "signup" });
});

app.post('/signup', function (req, res) {
    if (!req.body.id || !req.body.password) {
        res.status = 400;
        res.send("Invalid details!");
    } else {
        Users.findOne({ 'username': req.body.id })
            .then(result => {
                if (result == null && req.body.password == req.body.confirmPassword) {
                    var newUser = { username: req.body.id, password: req.body.password, email: req.body.email };
                    Users.create(newUser)
                        .then(result => {
                            console.log(result);
                            res.redirect('/');
                        })
                        .catch(err => res.render('login', {
                            message: "Got Error while signing up, Try again",
                            type: "signup"
                        }));
                }
                else {
                    res.render('login', {
                        message: "User Already Exists! Login or choose another user id",
                        type: "signup"
                    });
                }
            })
            .catch(err => {
                res.render('login', {
                    message: "Got Error while signing up, Try again",
                    type: "signup"
                });
            })
    }
});

app.get('/login', function (req, res) {
    res.render('login', { message: "Please Log In", type: "login" });
});

app.post('/login', function (req, res) {

    if (!req.body.id || !req.body.password) {
        res.render('login', { message: "Please enter both id and password", type: "login" });
    } else {
        Users.findOne({ 'username': req.body.id })
            .then(result => {
                if (result != null && result.password == req.body.password) {
                    req.session.userid = result._id;
                    if (_loggedinUsers.filter(function (user) {
                        if (user.username === req.body.id) {
                            return user;
                        }
                    }).length == 0) {
                        _loggedinUsers.push(result);
                    }
                    res.redirect('/ToDo');
                }
                else {
                    res.render('login', { message: "Invalid credentials!", type: "login" });
                }
            })
            .catch(err => res.render('login', { message: "Something went wrong", type: "login" }));
    }
});

app.get('/logout', function (req, res) {
    req.session.destroy(function () {
        console.log("User logged out.")
    });
    res.redirect('/login');
});

function checkSignIn(req, res, next) {
    if (req.session.userid) {
        var userIn = _loggedinUsers.filter(function (user) {
            if (user._id == req.session.userid) {
                return user;
            }
        });
        if (userIn.length != 0) {
            next();     //If session exists, proceed to page
        }
        else {
            req.session.destroy();
            res.render('login', { message: "Please Log In", type: "login" });
        }
    } else {
        console.log("LogIn check error:" + JSON.stringify(req.session.user));
        res.redirect('/');
    }
}

module.exports.IsUserLoggedIn = checkSignIn;
module.exports.Express = app;

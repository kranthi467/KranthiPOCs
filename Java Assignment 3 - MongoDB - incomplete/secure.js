var express = require('express');
var app = express();
var session = require('express-session');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');
var Users = require('./mongooseDB.js').Users;

app.use(cookieParser());
app.use(session({ secret: "Nenu chepp@ r@ neeku" }));
app.set('view engine', 'pug');
app.set('views', './public');
app.use(express.static('public'));
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
                if (result == null) {
                    var newUser = { username: req.body.id, password: req.body.password, email: req.body.email };
                    Users.create(newUser)
                        .then(result => {
                            console.log(result);
                            req.session.userid = result._id;
                        })
                        .catch(err => console.log(err));
                    res.redirect('/');
                }
                else {
                    res.render('login', {
                        message: "User Already Exists! Login or choose another user id",
                        type: "signup"
                    });
                }
            })
            .catch(err => res.render('login', {
                message: "Got Error while signing up, Try again",
                type: "signup"
            }))
        // if (_loggedinUsers.filter(function (user) {
        //     if (user.id === req.body.id) {
        //         res.render('login', {
        //             message: "User Already Exists! Login or choose another user id",
        //             type: "signup"
        //         });
        //         return user;
        //     }
        // }).length == 0) {
        //     var newUser = { id: req.body.id, password: req.body.password };
        //     console.log(_loggedinUsers);
        //     _loggedinUsers.push(newUser);
        //     req.session.user = newUser;
        //     res.redirect('/');
        // }
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
                    req.session.user = result;
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
        // if (_loggedinUsers.filter(function (user) {
        //     if (user.id === req.body.id && user.password === req.body.password) {
        //         req.session.user = user;
        //         res.redirect('/ToDo');
        //         return user;
        //     }
        // }).length == 0) {
        //     res.render('login', { message: "Invalid credentials!", type: "login" });
        // }
    }
});

app.get('/logout', function (req, res) {
    req.session.destroy(function () {
        console.log("User logged out.")
    });
    res.redirect('/login');
});

function checkSignIn(req, res, next) {
    if (req.session.user) {
        var userIn = _loggedinUsers.filter(function (user) {
            if (user._id == req.session.user._id) {
                return user;
            }
        });
        if (userIn.length != 0 && userIn[0].username == req.session.user.username) {
            next();     //If session exists, proceed to page
        }
        else {
            res.render('login', { message: "Please Log In", type: "login" });
        }
    } else {
        var err = new Error("Not logged in!");
        console.log(req.session.user);
        res.redirect('/');
    }
}

module.exports.IsUserLoggedIn = checkSignIn;
module.exports.Express = app;

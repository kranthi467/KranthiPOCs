var express = require('express');
var app = express();
var session = require('express-session');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');

app.use(cookieParser());
app.use(session({ secret: "Nenu chepp@ r@ neeku" }));
app.set('view engine', 'pug');
app.set('views', './public');
app.use(express.static('public'));
app.use(bodyParser.json());          // to support JSON-encoded bodies
app.use(bodyParser.urlencoded({      // to support URL-encoded bodies
    extended: true
}));

var _users = [];

app.get('/signup', function (req, res) {
    res.render('login', { message: "Please Sign Up", type: "signup" });
});

app.post('/signup', function (req, res) {
    console.log(req.body);
    if (!req.body.id || !req.body.password) {
        res.status("400");
        res.send("Invalid details!");
    } else {
        _users.filter(function (user) {
            if (user.id === req.body.id) {
                res.render('signup', {
                    message: "User Already Exists! Login or choose another user id"
                });
            }
        });
        var newUser = { id: req.body.id, password: req.body.password };
        _users.push(newUser);
        req.session.user = newUser;
        res.redirect('/');
    }
});

app.get('/login', function (req, res) {
    res.render('login', { message: "Please Log In", type: "login" });
});

app.post('/login', function (req, res) {
    console.log(_users);
    if (!req.body.id || !req.body.password) {
        res.render('login', { message: "Please enter both id and password", type: "login" });
    } else {
        _users.filter(function (user) {
            if (user.id === req.body.id && user.password === req.body.password) {
                req.session.user = user;
                res.redirect('/ToDo');
            }
        });
        res.render('login', { message: "Invalid credentials!", type: "login" });
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
        next();     //If session exists, proceed to page
    } else {
        var err = new Error("Not logged in!");
        console.log(req.session.user);
        res.redirect('/');
    }
}

module.exports.IsUserLoggedIn = checkSignIn;
module.exports.Express = app;

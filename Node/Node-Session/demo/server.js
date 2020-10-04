const fs = require('fs');
const http = require('http');
const path = require('path');
const url = require('url');
var express = require('express');
var app = express();

app.use("/public", express.static(path.join(__dirname + '/public')));

app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname + '/index.html'));
});
app.listen(3002);
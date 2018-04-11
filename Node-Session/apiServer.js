const fs = require('fs');
var http = require('http');
const server = http.createServer();
http.request()
server.on('request', (req, res) => {
    switch (req.url) {
        case '/listUsers':
            res.writeHead(200, { 'content-type': 'text/json' });
            fs.readFile("./users.json", 'utf8', function (err, data) {
                res.end(data);
            });
            break;
        case '/addUsers':
            req.on('data', (dataFromRes) => {
                let user = JSON.parse(dataFromRes.toString());
                let users;
                fs.readFile("./users.json", 'utf8', function (err, dataFromRF) {
                    users = JSON.parse(dataFromRF);
                    users["user4"] = user["user4"];
                    res.writeHead(200, { 'content-type': 'text/json' });
                    res.end(JSON.stringify(user));
                    fs.writeFile("./users.json", JSON.stringify(users), 'utf8', function (err, data) {
                        if (err) throw err;
                        console.log('The file has been saved!');
                    });
                });
            });
            break;
        case '/':
            res.writeHead(301, { 'Location': '/listUsers' });
            res.end();
            break;
        default:
            res.writeHead(404, { 'content-type': 'text/html' });
            res.end(fs.readFileSync('PageNotFound.html'));
    }

});

// server.timeout = 10000;
server.listen(8000);
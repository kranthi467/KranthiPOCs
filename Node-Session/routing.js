const fs = require('fs');
const server = require('http').createServer();

server.on('request', (req, res) => {
    switch(req.url){
        case '/home':
        case '/about':
            res.writeHead(200, {'content-type': 'text/html'});
            res.end(fs.readFileSync(`.${req.url}.html`));
            break;
        case '/':
            res.writeHead(301, { 'Location':'/home'});
            res.end();
            break;
        default: 
            res.writeHead(404, {'content-type': 'text/html'});
            res.end(fs.readFileSync('PageNotFound.html'));
    }
   
});

server.timeout = 10000;
server.listen(8000);
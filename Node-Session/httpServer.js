const server = require('http').createServer();

server.on('request', (req, res) => {
    res.writeHead(200, {'content-type': 'text/plain'});
    res.write('Writing');
    setTimeout(()=>{
        res.write('some msgsome other msgsome other msgsome other msgsome other msgsome other msgsome msgsome other msgsome other msgsome other msgsome other msgsome other msgsome msgsome other msgsome other msgsome other msgsome other msgsome other msgsome msgsome other msgsome other msgsome other msgsome other msgsome other msgsome msgsome other msgsome other msgsome other msgsome other msgsome other msgsome msgsome other msgsome other msgsome other msgsome other msgsome other msgsome msgsome other msgsome other msgsome other msgsome other msgsome other msgsome msgsome other msgsome other msgsome other msgsome other msgsome other msgsome msgsome other msgsome other msgsome other msgsome other msgsome other msgsome msgsome other msgsome other msgsome other msgsome other msgsome other msgsome msgsome other msgsome other msgsome other msgsome other msgsome other msg');
    }, 500);

    setTimeout(()=>{
        res.write('some other msg');
    }, 1000);

    setTimeout(function() {        
        res.end('end');
    }, 1500);
});

// server.timeout = 10000;
server.listen(8000);
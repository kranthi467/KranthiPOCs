const http = require('http');

const req = http.request({ hostname: 'localhost',
        port: 8000
    },
    (res)=>{
        console.log(res.statusCode);
        res.on('data', (data)=>{
            console.log(data.toString());
        });
    }
);

req.on('error', (err)=>{
    console.log(err);
});
req.end();
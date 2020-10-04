const http = require('http');
const user = {
    "user4" : {
        "name" : "mohit",
        "password" : "password4",
        "profession" : "teacher",
        "id": 4
    }
}
const options = {
  hostname: 'localhost',
  port: 8000,
  path: '/addUsers',
  method: 'POST',
  headers: {
    'Content-Type': 'application/json'
  }
};

const req = http.request(options, (res)=>{
                console.log(res.statusCode);
                res.on('data', (data)=>{
                    console.log(data.toString());
                });
            });

req.on('error', (err)=>{
    console.log(err);
});
req.end(JSON.stringify(user));


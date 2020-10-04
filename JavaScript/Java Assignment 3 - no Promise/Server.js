const jsonServer = require('json-server');
const server = jsonServer.create();
const router = jsonServer.router('db.json');
const middlewares = jsonServer.defaults();

server.use(jsonServer.bodyParser)
server.use(middlewares);
server.use((req, res, next) => {
  console.log(req.method); 
  if (isValid(req)) { 
    next() 
  } else {
    res.sendStatus(401)
  }
});
server.use(router);
server.listen(3000, () => {
  console.log('JSON Server is running')
});

var isValid = (req) => {
    if(req.method == 'GET' || req.method == 'DELETE'){
      return true;
    }
    if(req.body.detail.length > 100){
      return false;
    }
    else{
      return true;
    }
}
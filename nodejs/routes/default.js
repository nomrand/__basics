var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(request, response) {
  response.send('Hello World!')
});

/**
 * http://localhost:3000/get/(任意の文字列) にGETメソッドのリクエストを投げると、
 * JSON形式で(任意の文字列)を返す。
 */
router.get('/get/:place', function (req, res, next) {
  var param = {"result":"Hello "+ req.params.place + " !","shop name":req.query.shop};
  res.header('Content-Type', 'application/json; charset=utf-8');
  res.send(param);
});

/**
 * http://localhost:3000/post にPOSTメソッドのリクエストを投げると、
 * JSON形式で文字列を返す。
 */
router.post('/post', function(req, res, next) {
  var param = {"値":"POSTメソッドのリクエストを受け付けました","bodyの値":req.body.card};
  res.header('Content-Type', 'application/json; charset=utf-8')
  res.send(param);
});

module.exports = router;

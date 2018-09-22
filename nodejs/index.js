require('./global_env.js');
var express = require('express');
var app = express();
var bodyParser = require('body-parser');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));

// 
app.set('port', (process.env.PORT || 5000));
app.use(express.static(__dirname + '/public'));

// ROUTE SETTING
var defaultRouter = require('./routes/default');
app.use('/', defaultRouter);


app.listen(app.get('port'), function() {
  console.log("Node app is running at localhost:" + app.get('port'))
});

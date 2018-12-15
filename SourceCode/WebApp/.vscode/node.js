var express = require("express");

var app = express();
var pathRoot = __dirname + "/../wwwroot";
var port = 8900;

app.use(express.static(pathRoot, {
    maxAge: 3600000
}));
app.listen(port);
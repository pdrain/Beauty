var http = require('http');

var pageUrl = 'http://shixi.info/';
http.get(pageUrl, function(res) {
	var html = '';
	res.on('data', function(data) {
		html += data;
	});
	res.on('end', function() {
		//数据获取完，执行回调函数
		console.log(html);
	});
});

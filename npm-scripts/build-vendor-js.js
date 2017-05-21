var uglify = require('uglifyjs');
var fs = require('fs');

var files = [
    'node_modules/jquery/dist/jquery.js',
    'node_modules/angular/angular.js'
];

var result = uglify.minify(files, {
    beautify: false
});

fs.writeFile('build/assets/vendor.min.js', result.code, function(error) {
    if (!error) {
        console.log("---- vendor.min.js generated and saved");
    } else {
        console.log(error);
    }
});

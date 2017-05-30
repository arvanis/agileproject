var uglify = require('uglifyjs');
var fs = require('fs');

var files = [
    'src/assets/js/start.js'
];

var result = uglify.minify(files, {
    beautify: false
});

fs.writeFile('build/assets/build.js', result.code, function(error) {
    if (!error) {
        console.log("---- build.js generated and saved");
    } else {
        console.log(error);
    }
});

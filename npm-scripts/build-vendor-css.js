var fs = require('fs');

var files = [
    
];

var buffer = '';

if (files.length) {
    files.forEach(function(fileUrl) {
        buffer += fs.readFileSync(fileUrl, "utf-8");
    });
}

fs.writeFile('src/assets/scss/_vendors.scss', buffer, function(error) {
    if (!error) {
        console.log("---- vendor.scss generated");
    } else {
        console.log(error);
    }
});

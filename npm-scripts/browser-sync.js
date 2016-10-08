var historyApiFallback = require('connect-history-api-fallback')
var bs = require('browser-sync').create();

bs.init({
    server: {
        baseDir: "./build",
        middleware: [ historyApiFallback() ]
    },
    files: [
        "build/index.html",
        "build/assets/*.css",
        "build/assets/*.js"
    ]
});

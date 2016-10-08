'use strict'

const cpx = require("cpx");
const fs = require('fs');

function deleteDirectory(path) {
    if( fs.existsSync(path) ) {
        fs.readdirSync(path).forEach(function(file,index){
            var curPath = path + "/" + file;
            if(fs.lstatSync(curPath).isDirectory()) {
                deleteDirectory(curPath);
            } else {
                fs.unlinkSync(curPath);
            }
        });
        fs.rmdirSync(path);
    }
}

function buildStructure() {
    deleteDirectory("build");
    fs.mkdirSync("build");
    cpx.copy("src/**/*.html", "build");

    fs.mkdirSync("build/assets");
    cpx.copy("src/assets/fonts/**/*", "build/assets/fonts");
    cpx.copy("src/assets/images/**/*", "build/assets/images");
    cpx.copy("src/assets/video/**/*", "build/assets/video");
    cpx.copy(".htaccess", "build/");
}

buildStructure();

const { series, src, dest, watch, parallel } = require("gulp");
const inlinesource = require("gulp-inline-source");
const path = require("path");
const concat = require("gulp-concat");
const babel = require("gulp-babel");
const clean = require("gulp-clean");
var less = require("gulp-less");

const EXPORT_DIST_DIR = path.join(__dirname, "dist");

const watchPaths = [
    "./ui/scripts/**/*.js",
    "./ui/*.js",
    "./ui/scripts/**/*.jsx",
    "./ui/**/*.html",
    "./ui/**/*.css",
    "./ui/**/*.less",
];

function generateJs() {
    return src([
        "./ui/app.config.js",
        "./ui/app.core-fns.js",
        "./ui/scripts/**/*.js",
        "./ui/scripts/**/*.jsx",
        "./ui/app.bootstrap.js",
    ])
        .pipe(concat("ui.js"))
        .pipe(
            babel({
                presets: ["@babel/env"],
                plugins: ["transform-react-jsx"],
                sourceType: "module",
            })
        )
        .pipe(dest("./dist"));
}

function processLess() {
    return src("./ui/styles/**/*.less")
        .pipe(
            less({
                paths: [path.join(__dirname, "less", "includes")],
            })
        )
        .pipe(concat("less.css"))
        .pipe(dest("./dist"));
}

function generateCss() {
    return src(["./ui/styles/**/*.css", "./dist/less.css"])
        .pipe(concat("ui.css"))
        .pipe(dest("./dist"));
}

function generateHtml() {
    return src("./ui/*.html")
        .pipe(inlinesource({ compress: true }))
        .pipe(dest("./dist"));
}

function cleanup() {
    return src(["./dist/ui.js", "./dist/ui.css", "./dist/less.css"]).pipe(
        clean()
    );
}

const buildProcess = series(
    processLess,
    parallel(generateJs, generateCss),
    generateHtml,
    cleanup,
);

function doWatch() {
    return watch(watchPaths, { ignoreInitial: false }, buildProcess);
}

exports.default = buildProcess;
exports.watch = doWatch;
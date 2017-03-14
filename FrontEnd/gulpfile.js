var gulp = require('gulp');
var concat = require('gulp-concat');  
var rename = require('gulp-rename');  
var uglify = require('gulp-uglify');  
var minify = require('gulp-minify-css');
var clean = require('gulp-clean');
 

var jsFiles = 'js/vendor/*.js',  
    jsDest = 'dist/scripts',
    htmlFiles = 'preindex.html',
    cssFiles = 'css/*.css',
    cssDest = 'dist/styles',
    fontsFiles = 'fonts/**',
    fontsDest = 'dist/fonts',
    imagesFiles = 'images/**',
    imagesDest = 'dist/images';

gulp.task('js', function() {  
     gulp.src(jsFiles)
        .pipe(concat('scripts.js'))
       // .pipe(gulp.dest(jsDest))
        .pipe(rename('scripts.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(jsDest));
    gulp.src('js/src/*.js')
    .pipe(concat('bundle.js'))
       // .pipe(gulp.dest(jsDest))
        .pipe(rename('bundle.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(jsDest));
        gulp.src('js/jquery*.js')
        .pipe(gulp.dest(jsDest));
});

gulp.task('css', function(){
   gulp.src(cssFiles)
   .pipe(concat('style.css'))
   .pipe(minify())
   .pipe(gulp.dest(cssDest));
});

var htmlmin = require('gulp-htmlmin');
 
gulp.task('html', ['clean'], function() {
 return gulp.src(htmlFiles)
    .pipe(htmlmin({
        collapseWhitespace: true, 
        removeComments: true, 
        minifyJS: true
    }))    
    .pipe(rename('index.html'))
    .pipe(gulp.dest(''));
});

gulp.task('addHeader', ['html'], function(){
        return gulp.src(['header.rafa','index.html'])
    .pipe(concat('index.html'))
    .pipe(gulp.dest(''));
})

gulp.task('fonts', function(){
    return gulp.src(fontsFiles)
    .pipe(gulp.dest(fontsDest));
});
gulp.task('images', function(){
    return gulp.src(imagesFiles)
    .pipe(gulp.dest(imagesDest));
});
gulp.task('clean',function () {
    return gulp.src('index.html', {read: false})
        .pipe(clean());
});

gulp.task('resources', ['fonts', 'images']);
gulp.task('default',['addHeader']);
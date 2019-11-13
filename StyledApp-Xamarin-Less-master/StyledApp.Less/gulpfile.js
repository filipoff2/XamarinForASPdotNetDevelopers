var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less");


gulp.task("Build Less File", function () {
    return gulp.src('MainPage.less')
        .pipe(less())
        .pipe(gulp.dest('../StyledApp/Styles'));
});



gulp.task('default', ['Build Less File']); 
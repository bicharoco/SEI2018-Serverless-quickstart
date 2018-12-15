// Sass configuration
var gulp = require('gulp');
var sass = require('gulp-sass');

const sassPath = 'wwwroot/content/**/*.scss';

gulp.task('sass', function() {
    return gulp.src(sassPath)
        .pipe(sass())
        .pipe(gulp.dest(function(f) {
            return f.base;
        }));
});

gulp.task('default', ['sass'], function() {
    gulp.watch(sassPath, ['sass']);
});

// gulp.task('default', function() {
//     gulp.watch(sassPath, gulp.series('sass'));
// });

// gulp.task('default', gulp.series('sass', function() {
//     return gulp.watch(sassPath, ['sass']);
// }));

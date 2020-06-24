//npm install --save gulp gulp-postcss gulp-uglify gulp-plumber gulp-rename autoprefixer gulp-notify gulp-sass gulp-concat lost
var gulp         = require('gulp'),
	postcss 	 = require('gulp-postcss'),
	uglify       = require('gulp-uglify'),
	plumber      = require('gulp-plumber'),
	rename       = require('gulp-rename'),
	autoprefixer = require('autoprefixer'),
	notify       = require('gulp-notify'),
	sass         = require('gulp-sass'),
	concat       = require('gulp-concat'),
	lost         = require('lost');

var watch_paths = {
	scripts: ['assets/js/modules/*.js'],
	styles:  ['assets/scss/**/*.scss']
};

// Scripts Task
//'./assets_src/js/libs/*.js',
//'./assets_src/js/uncompress-libs/*.js',
gulp.task('scripts', async function() {
	return gulp.src([
	'./assets/js/modernizr.min.js',
	'./assets/js/jquery.js',
    './assets/js/bootstrap.js',
    './assets/js/jscookie.js',
	'./assets/js/modules/*.js'
	])
	.pipe(concat('main.js'))
	//.pipe(uglify())
	.pipe(uglify().on('error', function(e){
            console.log(e);
         }))
	/*.pipe(uglify({
		options: {
          mangle: false,
          compress: true
        }})) // Uncomment to minify js*/
	.pipe(gulp.dest('./scripts/'))
	.pipe(notify({ message: 'Scripts task complete' }))
});

// Styles Task
gulp.task('styles', async function() {
	var processors = [
		lost,
		autoprefixer({browsers:['last 6 version', 'ie >= 9']})
	];

	gulp.src(watch_paths.styles)
		.pipe(plumber())
		.pipe(sass({
			outputStyle: 'compressed' // Uncomment to minify css
		}))
		.pipe(postcss(processors))
		.pipe(gulp.dest('css'))
		.pipe(notify({ message: 'Styles task complete' }));
});

// Watch Task
gulp.task('watch', async function() {
	gulp.watch(watch_paths.scripts, gulp.series('scripts'));
	gulp.watch(watch_paths.styles, gulp.series('styles'));
});

gulp.task('default', gulp.series('watch'));

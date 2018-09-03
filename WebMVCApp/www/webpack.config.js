var path = require('path')
var webpack = require('webpack')
var fs = require('fs')

var appBasePath = './vueapp'

var jsEntries = {}
// We search for index.js files inside basePath folder and make those as entries
/*fs.readdirSync(appBasePath).forEach(function (name) {
    var indexFile = appBasePath + name + '/index.js'
    if (fs.existsSync(indexFile)) {
        jsEntries[name] = indexFile
    }
})*/

// Recorriendo todas las subcarpetas dentro de vueapp
var walkSync = function (dir, filelist) {
    var files = fs.readdirSync(dir);
    filelist = filelist || [];
    files.forEach(function (file) {
        // file es dir or file
        if (fs.statSync(dir + '/' + file).isDirectory()) {
            filelist = walkSync(dir + '/' + file, filelist);
        }
        else {
            filelist.push(dir + '/' + file);
        }
    });
    return filelist;
};

// Seteando jsEntries
var res = walkSync(appBasePath);
res.forEach(function (pathFile, i) {
    var aName = pathFile.split('/');
    aName.splice(0, 2); // Eliminando: ['.', 'vueapp']
    // Quitando la extension al ultimo Item (fileName.extension)
    aName[aName.length - 1] = aName[aName.length - 1].split('.')[0];
    var sName = aName.join('_');
    // Guardando files y quitando al key el substring: ".js"
    jsEntries[sName/*.substring(0, sName.length-3)*/] = pathFile;
});


module.exports = {
    entry: jsEntries,
    output: {
        path: path.resolve(__dirname, './bundle/'), // './Scripts/bundle/'
        publicPath: '/bundle/', // '/Scripts/bundle/'
        filename: '[name].js'
    },
    resolve: {
        extensions: ['.js', '.vue', '.json'],
        alias: {
            'vue$': 'vue/dist/vue.esm.js',
            '@': path.join(__dirname, appBasePath)
        }
    },
    module: {
        loaders: [
            {
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    loaders: {
                        scss: 'vue-style-loader!css-loader!sass-loader', // <style lang="scss">
                        sass: 'vue-style-loader!css-loader!sass-loader?indentedSyntax' // <style lang="sass">
                    }
                }
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                exclude: /node_modules/
            },
            {
                test: /\.scss$/,
                loader: 'style-loader!css-loader!sass-loader'
            },
            {
                test: /\.css$/,
                loader: 'style-loader!css-loader'
            },
            {
                test: /\.(eot|svg|ttf|woff|woff2)(\?\S*)?$/,
                loader: 'file-loader'
            },
            {
                test: /\.(png|jpe?g|gif|svg)(\?\S*)?$/,
                loader: 'file-loader',
                query: {
                    name: '[name].[ext]?[hash]'
                }
            }
        ]
    },
    devServer: {
        proxy: {
            '*': {
                target: 'http://localhost:5001',
                changeOrigin: true
            }
        }
    },
    devtool: '#eval-source-map'
}
//console.log("process.env.NODE_ENV:", process.env.NODE_ENV);
if (process.env.NODE_ENV === 'production') {
    module.exports.devtool = '#source-map'
    // http://vue-loader.vuejs.org/en/workflow/production.html

    const UglifyJSPlugin = require('uglifyjs-webpack-plugin');

    module.exports.plugins = (module.exports.plugins || []).concat([
        new webpack.DefinePlugin({
            'process.env': {
                NODE_ENV: '"production"'
            }
        }),
        new UglifyJSPlugin({
            uglifyOptions:{
                compress: {
                    warnings: false
                },
            }
            , sourceMap: true
        })
        /*
        new webpack.optimize.UglifyJsPlugin({
            compress: {
                warnings: false
            },
            sourceMap: true
        })*/
    ])
}
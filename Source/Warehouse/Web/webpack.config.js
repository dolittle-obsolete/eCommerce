const config = require('dolittle.javascript.build.aurelia/webpack.config.js');
config.entry = {
    app: ['babel-polyfill', 'aurelia-bootstrapper'],
    vendor: ['bluebird']
};
module.exports = config;
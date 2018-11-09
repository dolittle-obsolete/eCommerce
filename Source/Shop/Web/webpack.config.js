const path = require('path');
require('dotenv').config();

process.env.DOLITTLE_WEBPACK_ROOT = path.resolve('../Core');
process.env.DOLITTLE_WEBPACK_OUT = path.resolve('../Core/wwwroot');
process.env.DOLITTLE_FEATURES_DIR = path.resolve('./Features');
process.env.DOLITTLE_COMPONENT_DIR = path.resolve('./Components');

const config = require('dolittle.javascript.build.aurelia/webpack.config.js');

config.entry = {
    app: ['babel-polyfill', 'aurelia-bootstrapper'],
    vendor: ['bluebird']
};
module.exports = config;

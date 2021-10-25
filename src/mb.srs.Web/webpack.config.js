const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const TerserPlugin = require("terser-webpack-plugin");
const CopyPlugin = require("copy-webpack-plugin");

const config = {
    entry: path.resolve(__dirname, 'assets') + '/bundle.js',
    output: {
        filename: 'main.js',
        path: path.resolve(__dirname, './wwwroot'),
        clean: false,
    },
    plugins: [
      new CopyPlugin({
        patterns: [
          { from: "./assets/images/favicon.ico", to: "./" },
          { from: "./assets/images", to: "./",
            globOptions: {ignore: ["**/*.ico"] },
          },
        ],
      }),
    ],
    module: {
        rules: [
          {
            test: /\.s[ac]ss$/i,
            use: [
              MiniCssExtractPlugin.loader,
              "css-loader",
              "sass-loader"
            ],
          },
        ],
    },
};

module.exports = (env, argv) => {
    
    if (argv.mode === "development") {
        config.devtool = "cheap-module-source-map";
        config.mode = "development";
        config.plugins.push(
          new MiniCssExtractPlugin({
            filename: "main.css"
          })
        );
    }
    if (argv.mode === "production") {
        config.mode = "production";
        config.optimization = {
            minimize: true,
            minimizer: [
                new TerserPlugin()
            ]
        };
        config.output.filename = 'main.min.js';
        config.plugins.push(
          new MiniCssExtractPlugin({
            filename: "main.min.css"
          })
        );
    }
    return config;
}
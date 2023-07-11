const path = require('path');

module.exports = {
    entry: {
        barbecueValidation: './Scripts/BarbecueValidation.ts',
        validationBoot: './Scripts/ValidationBoot.ts'
    },
    output: {
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, 'wwwroot/dist/js'),
        devtoolModuleFilenameTemplate: '[resource-path]'
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: 'ts-loader',
                exclude: /node_modules/
            }
        ]
    },
    resolve: {
        extensions: ['.ts', '.js']
    },
    devtool: 'source-map',
    mode: 'development'
};

module.exports = {
    env: {
        browser: true,
        es2021: true
    },
    root: true,
    parser: '@typescript-eslint/parser',
    plugins: [
        '@typescript-eslint'
    ],
    extends: ['standard', 'eslint:recommended', 'plugin:@typescript-eslint/eslint-recommended', 'plugin:@typescript-eslint/recommended'],
    overrides: [
    ],
    parserOptions: {
        ecmaVersion: 'latest',
        sourceType: 'module'
    },
    rules: {
        indent: ['error', 4],
        'space-before-function-paren': ['error', {
            anonymous: 'always',
            named: 'always',
            asyncArrow: 'always'
        }],
        semi: [0, 'never']
    }
}
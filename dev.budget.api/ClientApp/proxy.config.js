const proxy = [
    {
      context: '/api',
      target: 'http://localhost:61616',
      pathRewrite: {'^/api' : '^/api'}
    }
  ];
  module.exports = proxy;
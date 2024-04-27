const http = require('http');

const server = http.createServer((req, res) => {
  res.writeHead(200, { 'Content-Type': 'application/json' });

  const responseData = {
    message: 'Wiadomosc!',
    timestamp: new Date().toISOString(),
  };

  res.end(JSON.stringify(responseData));
});

const PORT = 3000;
server.listen(PORT, () => {
  console.log(` ${PORT} nasluchiwanie`);
});

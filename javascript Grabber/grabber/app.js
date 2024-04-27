const express = require('express');
const mongoose = require('mongoose');
const axios = require('axios');
const cheerio = require('cheerio');

const connectionString = 'mongodb://localhost:27017/bazaImplementacja';

mongoose.connect(connectionString, { useNewUrlParser: true, useUnifiedTopology: true });

const db = mongoose.connection;

db.on('error', console.error.bind(console, 'Błąd połączenia z MongoDB:'));
db.once('open', () => {
  console.log('Połączono z bazą danych MongoDB');
});

const app = express();
const PORT = 3000;

// Model danych do zapisu w bazie dla pogody
const WeatherData = mongoose.model('WeatherData', {
  city: String,
  conditions: String,
});

// Model danych do zapisu w bazie dla pokemonów
const PokemonData = mongoose.model('PokemonData', {
  name: String,
  dex: String,
});

// Lista 10 miast z Ameryki
const cities = ['New York City', 'Los Angeles', 'Chicago', 'Houston', 'Phoenix', 'Philadelphia', 'San Antonio', 'San Diego', 'Dallas', 'San Jose'];

// Endpoint do wyświetlenia informacji o pogodzie dla 10 miast
app.get('/pogoda', async (req, res) => {
  try {
    const weatherDataList = [];

    for (const city of cities) {
      const apiUrl = `https://wttr.in/${city}?format=%t+%C+%w+%m`;

      const response = await axios.get(apiUrl);
      const weatherData = response.data;

      // Zapisz dane pogodowe do bazy danych
      const newWeatherData = new WeatherData({
        city,
        conditions: weatherData,
      });

      await newWeatherData.save();

      // Dodaj dane pogodowe do listy
      weatherDataList.push({ city, conditions: weatherData });
    }

    // Wyślij odpowiedź z informacjami o pogodzie w formie HTML
    res.send(`
      <html>
        <head>
          <title>Informacje o pogodzie</title>
        </head>
        <body>
          <h1>Informacje o pogodzie dla 10 miast z Ameryki</h1>
          <ul>
            ${weatherDataList.map(data => `<li>${data.city}: ${data.conditions}</li>`).join('')}
          </ul>
        </body>
      </html>
    `);
  } catch (error) {
    console.error('ERROR:', error.message);

    // Wysyłamy odpowiedź z informacją o błędzie w formie HTML
    res.status(500).send(`
      <html>
        <head>
          <title>Błąd</title>
        </head>
        <body>
          <h1>Wystąpił błąd podczas pobierania informacji o pogodzie</h1>
          <p>${error.message}</p>
        </body>
      </html>
    `);
  }
});

// Endpoint do pobierania informacji o pokemonach i zapisywania ich do bazy danych
app.get('/pokemon', async (req, res) => {
  try {
    const apiUrl = 'https://pokeapi.co/api/v2/pokemon?limit=10'; //zmiana limitu ile pokemonów pobrać

    const response = await axios.get(apiUrl);
    const pokemonDataList = response.data.results;

    // Zapisz dane pokemonów do bazy danych
    for (const pokemon of pokemonDataList) {
      const dexNumber = pokemon.url.split('/').slice(-2, -1)[0];
      const newPokemonData = new PokemonData({
        name: pokemon.name,
        dex: dexNumber,
      });
      await newPokemonData.save();
    }

    // Wyślij odpowiedź z informacjami o pokemonach w formie HTML
    res.send(`
      <html>
        <head>
          <title>Informacje o Pokemonach</title>
        </head>
        <body>
          <h1>Informacje o Pokemonach</h1>
          <ul>
            ${pokemonDataList.map(pokemon => `<li>${pokemon.name} - Dex: ${pokemon.url.split('/').slice(-2, -1)}</li>`).join('')}
          </ul>
        </body>
      </html>
    `);
  } catch (error) {
    console.error('ERROR:', error.message);

    // Wysyłamy odpowiedź z informacją o błędzie w formie HTML
    res.status(500).send(`
      <html>
        <head>
          <title>Błąd</title>
        </head>
        <body>
          <h1>Wystąpił błąd podczas pobierania informacji o Pokemonach</h1>
          <p>${error.message}</p>
        </body>
      </html>
    `);
  }
});

// Start serwera
app.listen(PORT, () => {
  console.log(`Serwer nasłuchuje na porcie ${PORT}`);
});

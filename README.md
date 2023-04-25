# Dynamic Weather

This repository contains the source code for Dynamic Weather, a simple Unity app that displays weather and astronomy information for various cities around the world.

## Getting Started

To use this app, you'll need to sign up for API keys for two different APIs: [OpenWeatherMap](https://openweathermap.org/) and [IPGeolocation](https://ipgeolocation.io/). These APIs provide the weather and astronomy information that the app uses to display data.

Once you have API keys for both services, you'll need to create a JSON configuration file that the app will use to access the APIs. The structure of the JSON file should look like this:

~~~json
{
  "api": [
    {
      "name": "weather",
      "url": "api.openweathermap.org",
      "key": "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
    },
    {
      "name": "astronomy",
      "url": "api.ipgeolocation.io",
      "key": "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
    }
  ],
  "cities": [
    {
      "country": "us",
      "name": "new york",
      "gmt": -4
    },
    {
      "country": "jp",
      "name": "tokyo",
      "gmt": 9
    }
  ]
}
~~~

Replace the "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" placeholders with your actual API keys. You should also update the list of cities to include the ones you want to display information for.

Once you've created the JSON file, you'll need to upload it to a mock API service. We recommend using [Mocky](https://www.mocky.io/) for this purpose. Create a new mock and upload the JSON file. Copy the URL of the mock, which should look something like this:

~~~
https://run.mocky.io/v3/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
~~~
Make sure to use only the last part of the URL (`xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx`).

## Running the App

To run the app, open the Unity project and navigate to the "Scenes" folder. Open the "Main" scene, which should contain the main UI canvas for the app.

Click the "Play" button to start the app. Paste the URL of the Mocky mock that you created.

The app should display weather and astronomy information for the cities specified in the JSON file.

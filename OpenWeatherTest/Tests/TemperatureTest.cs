using NUnit.Framework;
using OpenWeatherTest.Models;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Globalization;
using System.Net;

namespace OpenWeatherTest.Tests
{
    [TestFixture]
    public class TemperatureTest
    {
        CommonPropertiesAPI commonProps;
        public TemperatureTest()
        {
            commonProps = new CommonPropertiesAPI();
        }

        /// <summary>
        /// Check the id for Mountain View is 5375480 
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="APIKey"></param>
        [TestCase("Mountain View", "9d50450a48809637b4862bdcb125927d", TestName = "Check the id for Mountain View is 5375480")]
        public void CityNameResponseCheck(string cityName, string APIKey)
        {
            // arrange
            RestClient client = new RestClient(commonProps.RequestURL);
            RestRequest request = new RestRequest($"?q={cityName}&appid={APIKey}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            //check the value of the status
            WeatherResponse weatherResponse = new WeatherResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                weatherResponse = new JsonDeserializer().Deserialize<WeatherResponse>(response);
            }

            // assert
            Assert.That(weatherResponse.Id, Is.EqualTo("5375480"));
        }

        /// <summary>
        /// Temperature is not null
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="APIKey"></param>
        [TestCase("Mountain View", "9d50450a48809637b4862bdcb125927d", TestName = "Temperature is not null")]
        public void TemperatureNullCheck(string cityName, string APIKey)
        {
            // arrange
            RestClient client = new RestClient(commonProps.RequestURL);
            RestRequest request = new RestRequest($"?q={cityName}&appid={APIKey}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            //check the value of the status
            WeatherResponse weatherResponse = new WeatherResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                weatherResponse = new JsonDeserializer().Deserialize<WeatherResponse>(response);
            }

            // assert
            Assert.IsNotNull(weatherResponse.Main);
            Assert.That(weatherResponse.Main.Temp, Is.Not.Null);
            string cTemp = ConvertToCelsius(weatherResponse.Main.Temp);
            TestContext.Out.WriteLine("Temperature in {0} is {1} celsius", cityName, cTemp);
        }

        /// <summary>
        /// Minimum temperature is not null
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="APIKey"></param>
        [TestCase("Mountain View", "9d50450a48809637b4862bdcb125927d", TestName = "Minimum temperature is not null")]
        public void TemperatureMinimumNullCheck(string cityName, string APIKey)
        {
            // arrange
            RestClient client = new RestClient(commonProps.RequestURL);
            RestRequest request = new RestRequest($"?q={cityName}&appid={APIKey}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            //check the value of the status
            WeatherResponse weatherResponse = new WeatherResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                weatherResponse = new JsonDeserializer().Deserialize<WeatherResponse>(response);
            }

            // assert
            Assert.IsNotNull(weatherResponse.Main);
            Assert.That(weatherResponse.Main.Temp_Min, Is.Not.Null);
            string cTemp_Min = ConvertToCelsius(weatherResponse.Main.Temp_Min);
            TestContext.Out.WriteLine("Minimum Temperature in {0} is {1} celsius", cityName, cTemp_Min);
        }

        /// <summary>
        /// Maximum temperature is not null
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="APIKey"></param>
        [TestCase("Mountain View", "9d50450a48809637b4862bdcb125927d", TestName = "Maximum temperature is not null")]
        public void TemperatureMaximumNullCheck(string cityName, string APIKey)
        {
            // arrange
            RestClient client = new RestClient(commonProps.RequestURL);
            RestRequest request = new RestRequest($"?q={cityName}&appid={APIKey}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            //check the value of the status
            WeatherResponse weatherResponse = new WeatherResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                weatherResponse = new JsonDeserializer().Deserialize<WeatherResponse>(response);
            }

            // assert
            Assert.IsNotNull(weatherResponse.Main);
            Assert.That(weatherResponse.Main.Temp_Max, Is.Not.Null);
            string cTemp_Max = ConvertToCelsius(weatherResponse.Main.Temp_Max);
            TestContext.Out.WriteLine("Maximum Temperature in {0} is {1} celsius", cityName, cTemp_Max);
        }

        /// <summary>
        /// Check for Min and Max temperature range
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="APIKey"></param>
        [TestCase("Mountain View", "9d50450a48809637b4862bdcb125927d", TestName = "Check for Min and Max temperature range")]
        public void TemperatureRangeCheck(string cityName, string APIKey)
        {
            // arrange
            RestClient client = new RestClient(commonProps.RequestURL);
            RestRequest request = new RestRequest($"?q={cityName}&appid={APIKey}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            //check the value of the status
            WeatherResponse weatherResponse = new WeatherResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                weatherResponse = new JsonDeserializer().Deserialize<WeatherResponse>(response);
            }

            // assert
            Assert.IsNotNull(weatherResponse.Main);
            Assert.That(weatherResponse.Main.Temp_Min, Is.Not.Null);
            string cTemp_Min = ConvertToCelsius(weatherResponse.Main.Temp_Min);
            Assert.That(cTemp_Min, Is.Not.Null);
            TestContext.Out.WriteLine("Minimum Temperature in {0} :- {1} celsius", cityName, cTemp_Min);
            Assert.That(weatherResponse.Main.Temp, Is.Not.Null);
            string cTemp = ConvertToCelsius(weatherResponse.Main.Temp);
            Assert.That(cTemp, Is.Not.Null);
            TestContext.Out.WriteLine("Temperature in {0} :- {1} celsius", cityName, cTemp);
            Assert.That(weatherResponse.Main.Temp_Max, Is.Not.Null);
            string cTemp_Max = ConvertToCelsius(weatherResponse.Main.Temp_Max);
            Assert.That(cTemp_Max, Is.Not.Null);
            TestContext.Out.WriteLine("Maximum Temperature in {0} :- {1} celsius", cityName, cTemp_Max);

            float cT = float.Parse(cTemp, CultureInfo.InvariantCulture.NumberFormat);
            float cTMin = float.Parse(cTemp_Min, CultureInfo.InvariantCulture.NumberFormat);
            float cTMax = float.Parse(cTemp_Max, CultureInfo.InvariantCulture.NumberFormat);
            bool rangeCheck = false;
            if (cTMin <= cT)
                rangeCheck = true;
            else
                rangeCheck = false;
            if (cTMin < cTMax)
                rangeCheck = true;
            else
                rangeCheck = false;
            if (cT <= cTMax)
                rangeCheck = true;
            else
                rangeCheck = false;
            Assert.That(rangeCheck, Is.EqualTo(true));
            TestContext.Out.WriteLine("Temperature falls between minimum and maximum temperature range");
        }

        /// <summary>
        /// Humidity is not null
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="APIKey"></param>
        [TestCase("Mountain View", "9d50450a48809637b4862bdcb125927d", TestName = "Humidity is not null")]
        public void HumidityNullCheck(string cityName, string APIKey)
        {
            // arrange
            RestClient client = new RestClient(commonProps.RequestURL);
            RestRequest request = new RestRequest($"?q={cityName}&appid={APIKey}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            //check the value of the status
            WeatherResponse weatherResponse = new WeatherResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                weatherResponse = new JsonDeserializer().Deserialize<WeatherResponse>(response);
            }

            // assert
            Assert.IsNotNull(weatherResponse.Main);
            Assert.That(weatherResponse.Main.Humidity, Is.Not.Null);
            TestContext.Out.WriteLine("Humidity in {0} :- {1}%", cityName, weatherResponse.Main.Humidity);
        }
        /// <summary>
        /// Description is not null
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="APIKey"></param>
        [TestCase("Mountain View", "9d50450a48809637b4862bdcb125927d", TestName = "Description is not null")]
        public void DescriptionNullCheck(string cityName, string APIKey)
        {
            // arrange
            RestClient client = new RestClient(commonProps.RequestURL);
            RestRequest request = new RestRequest($"?q={cityName}&appid={APIKey}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            //check the value of the status
            WeatherResponse weatherResponse = new WeatherResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                weatherResponse = new JsonDeserializer().Deserialize<WeatherResponse>(response);
            }

            // assert
            Assert.IsNotNull(weatherResponse.Weather);
            Assert.That(weatherResponse.Weather[0].Description, Is.Not.Null);
            TestContext.Out.WriteLine("Weather description for {0} :- {1}%", cityName, weatherResponse.Weather[0].Description);
        }

        public string ConvertToCelsius(string Temp)
        {
            float kTemp = float.Parse(Temp, CultureInfo.InvariantCulture.NumberFormat);
            string ctemp = (kTemp - 273).ToString();
            return ctemp;
        }
    }
}

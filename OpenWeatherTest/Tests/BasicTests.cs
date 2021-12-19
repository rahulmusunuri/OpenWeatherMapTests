using NUnit.Framework;
using OpenWeatherTest.Models;
using RestSharp;
using System.Net;

namespace OpenWeatherTest
{
    [TestFixture]
    public class BasicTests
    {
        CommonPropertiesAPI commonProps;
        public BasicTests()
        {
            commonProps = new CommonPropertiesAPI();
        }
        [TestCase("London", "9d50450a48809637b4862bdcb125927d", HttpStatusCode.OK, TestName = "Check status code for right city name and right API Key")]
        [TestCase("London", "9d50450a48809637b4862bdcb125927", HttpStatusCode.Unauthorized, TestName = "Check status code for right city name and wrong API Key")]
        [TestCase("fersared", "9d50450a48809637b4862bdcb125927d", HttpStatusCode.NotFound, TestName = "Check status code for wrong city name and right API Key")]
        public void StatusCodeCheck_CityName(string cityName, string APIKey, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            RestClient client = new RestClient(commonProps.RequestURL);
            RestRequest request = new RestRequest($"?q={cityName}&appid={APIKey}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }

        [TestCase("5128581", "en", "9d50450a48809637b4862bdcb125927d", HttpStatusCode.OK, TestName = "Check status code for right city id and right API Key")]
        [TestCase("2650225", "hi", "9d50450a48809637b4862bdcb125927", HttpStatusCode.Unauthorized, TestName = "Check status code for right city id and wrong API Key")]
        [TestCase("18501s47", "ja", "9d50450a48809637b4862bdcb125927d", HttpStatusCode.BadRequest, TestName = "Check status code for wrong city id and right API Key")]
        public void StatusCodeCheck_CityId_LangCode(string cityId, string langCode, string APIKey, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            RestClient client = new RestClient(commonProps.RequestURL);
            RestRequest request = new RestRequest($"?id={cityId}&lang={langCode}&appid={APIKey}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }
    }
}
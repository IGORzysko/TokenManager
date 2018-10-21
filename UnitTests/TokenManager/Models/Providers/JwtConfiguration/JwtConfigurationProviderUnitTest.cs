using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TokenManager.Interfaces.Models.Providers.JwtConfiguration;
using TokenManager.Interfaces.Models.Providers.SettingConfigurationProvider;
using TokenManager.Models.Providers.ConfigurationBuilderProvider;
using TokenManager.Models.Providers.SettingConfiguration;

namespace UnitTests.TokenManager.Models.Providers.JwtConfiguration
{
    [TestClass]
    public class JwtConfigurationProviderUnitTest
    {
        private IAppSettingsConfigurationProvider _appSettingsConfigurationProvider;
        private IJwtConfigurationProvider _jwtConfigurationProvider;

        [TestInitialize]
        public void Initialize()
        {
            _appSettingsConfigurationProvider = new AppSettingsConfigurationProvider();
            _appSettingsConfigurationProvider.CreateConfigurationBuilder();

            _jwtConfigurationProvider = new JwtConfigurationProvider(_appSettingsConfigurationProvider);
        }

        [TestMethod]
        public void SettingConfigurationProviderShoulBeNotNull()
        {
            NUnit.Framework.Assert.IsNotNull(_appSettingsConfigurationProvider);
        }

        [TestMethod]
        public void JwtConfigurationProviderShoulBeNotNull()
        {
            NUnit.Framework.Assert.IsNotNull(_jwtConfigurationProvider);
        }

        [TestMethod]
        public void ConfigSectionShoulNotBeNull()
        {
            var result = _appSettingsConfigurationProvider.ConfigSection;

            Assert.IsNotNull(result);

            Console.WriteLine(result);
        }

        [TestMethod]
        public void GetSecretKeyShouldReturnSecretKey()
        {
            var result = _jwtConfigurationProvider.GetSecretKey();

            Assert.IsTrue(result == "secretKeyValue");

        }

        [TestMethod]
        public void GetExpirationTimeInMinutesShouldReturnExpirationTimeInMinutes()
        {
            var result = _jwtConfigurationProvider.GetExpirationTimeInMinutes();

            Assert.IsTrue(result == "10");
        }
    }
}
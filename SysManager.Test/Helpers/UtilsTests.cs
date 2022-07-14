using SysManager.Application.Helpers;
using Xunit;

namespace SysManager.Test.Utils
{
    public class UtilsTests
    {
        [Fact(DisplayName = "Teste de conversão para base64")]
        public void Base64_Conversion_Sucess()
        {
            //Arrange
            var text = "texto de test";
            var textBase64 = "dGV4dG8gZGUgdGVzdA==";

            //Act
            var result = text.ToBase64Encode();

            //Assert
            Assert.Equal(textBase64, result);
        }
    }
}
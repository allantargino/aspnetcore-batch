using Batch.Processor.Utils;
using System.Net.Http;
using Xunit;

namespace Batch.Processor.Tests
{
    public class HttpUtilsTests
    {
        [Theory]
        [InlineData("get")]
        [InlineData("geT")]
        [InlineData("gEt")]
        [InlineData("gET")]
        [InlineData("Get")]
        [InlineData("GeT")]
        [InlineData("GEt")]
        [InlineData("GET")]
        public void GetGETMethod(string method)
        {
            var httpMethod = HttpUtils.GetHttpMethod(method);
            Assert.Equal(HttpMethod.Get, httpMethod);
        }

        [Theory]
        [InlineData("put")]
        [InlineData("puT")]
        [InlineData("pUt")]
        [InlineData("pUT")]
        [InlineData("Put")]
        [InlineData("PuT")]
        [InlineData("PUt")]
        [InlineData("PUT")]
        public void GetPUTMethod(string method)
        {
            var httpMethod = HttpUtils.GetHttpMethod(method);
            Assert.Equal(HttpMethod.Put, httpMethod);
        }

        [Theory]
        [InlineData("post")]
        [InlineData("posT")]
        [InlineData("poSt")]
        [InlineData("poST")]
        [InlineData("pOst")]
        [InlineData("pOsT")]
        [InlineData("pOSt")]
        [InlineData("pOST")]
        [InlineData("Post")]
        [InlineData("PosT")]
        [InlineData("PoSt")]
        [InlineData("PoST")]
        [InlineData("POst")]
        [InlineData("POsT")]
        [InlineData("POSt")]
        [InlineData("POST")]
        public void GetPostMethod(string method)
        {
            var httpMethod = HttpUtils.GetHttpMethod(method);
            Assert.Equal(HttpMethod.Post, httpMethod);
        }

        [Theory]
        [InlineData("delete")]
        [InlineData("deletE")]
        [InlineData("deleTe")]
        [InlineData("deleTE")]
        [InlineData("delEte")]
        [InlineData("delEtE")]
        [InlineData("delETe")]
        [InlineData("delETE")]
        [InlineData("deLete")]
        [InlineData("deLetE")]
        [InlineData("deLeTe")]
        [InlineData("deLeTE")]
        [InlineData("deLEte")]
        [InlineData("deLEtE")]
        [InlineData("deLETe")]
        [InlineData("deLETE")]
        [InlineData("dElete")]
        [InlineData("dEletE")]
        [InlineData("dEleTe")]
        [InlineData("dEleTE")]
        [InlineData("dElEte")]
        [InlineData("dElEtE")]
        [InlineData("dElETe")]
        [InlineData("dElETE")]
        [InlineData("dELete")]
        [InlineData("dELetE")]
        [InlineData("dELeTe")]
        [InlineData("dELeTE")]
        [InlineData("dELEte")]
        [InlineData("dELEtE")]
        [InlineData("dELETe")]
        [InlineData("dELETE")]
        [InlineData("Delete")]
        [InlineData("DeletE")]
        [InlineData("DeleTe")]
        [InlineData("DeleTE")]
        [InlineData("DelEte")]
        [InlineData("DelEtE")]
        [InlineData("DelETe")]
        [InlineData("DelETE")]
        [InlineData("DeLete")]
        [InlineData("DeLetE")]
        [InlineData("DeLeTe")]
        [InlineData("DeLeTE")]
        [InlineData("DeLEte")]
        [InlineData("DeLEtE")]
        [InlineData("DeLETe")]
        [InlineData("DeLETE")]
        [InlineData("DElete")]
        [InlineData("DEletE")]
        [InlineData("DEleTe")]
        [InlineData("DEleTE")]
        [InlineData("DElEte")]
        [InlineData("DElEtE")]
        [InlineData("DElETe")]
        [InlineData("DElETE")]
        [InlineData("DELete")]
        [InlineData("DELetE")]
        [InlineData("DELeTe")]
        [InlineData("DELeTE")]
        [InlineData("DELEte")]
        [InlineData("DELEtE")]
        [InlineData("DELETe")]
        [InlineData("DELETE")]
        public void GetDeleteMethod(string method)
        {
            var httpMethod = HttpUtils.GetHttpMethod(method);
            Assert.Equal(HttpMethod.Delete, httpMethod);
        }

        [Theory]
        [InlineData("other")]
        [InlineData("otheR")]
        [InlineData("othEr")]
        [InlineData("othER")]
        [InlineData("otHer")]
        [InlineData("otHeR")]
        [InlineData("otHEr")]
        [InlineData("otHER")]
        [InlineData("oTher")]
        [InlineData("oTheR")]
        [InlineData("oThEr")]
        [InlineData("oThER")]
        [InlineData("oTHer")]
        [InlineData("oTHeR")]
        [InlineData("oTHEr")]
        [InlineData("oTHER")]
        [InlineData("Other")]
        [InlineData("OtheR")]
        [InlineData("OthEr")]
        [InlineData("OthER")]
        [InlineData("OtHer")]
        [InlineData("OtHeR")]
        [InlineData("OtHEr")]
        [InlineData("OtHER")]
        [InlineData("OTher")]
        [InlineData("OTheR")]
        [InlineData("OThEr")]
        [InlineData("OThER")]
        [InlineData("OTHer")]
        [InlineData("OTHeR")]
        [InlineData("OTHEr")]
        [InlineData("OTHER")]
        public void GetOtherMethod(string method)
        {
            var httpMethod = HttpUtils.GetHttpMethod(method);
            var httpExpected = new HttpMethod("OTHER");
            Assert.Equal(httpExpected, httpMethod);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CodeBase.Algorithm
{
    public class DateAndTime
    {
        string dtjson = "{ \"Date\": \"\\/Date(1659364858000+0000)\\/\" }";

        public void Convert()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
            };

            var dateTime = JsonConvert.DeserializeObject<DtObject>(this.dtjson, settings).Date;
        }

        public class DtObject
        {
            public DateTime Date { get; set; }
        }
    }
}

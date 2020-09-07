using System;
using System.Collections.Generic;
using System.Text;

namespace SampleXamarinJuly.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

    public class Duration
    {
        public double value { get; set; }
        public string text { get; set; }
    }

    public class RfidDriver
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class Idle
    {
        public double lon { get; set; }
        public double lat { get; set; }
        public string addr { get; set; }
        public int geo_location_id { get; set; }
        public int geo_area_id { get; set; }
        public string geo_location_nm { get; set; }
        public string geo_area_nm { get; set; }
        public string geo_location_code { get; set; }
        public string geo_area_code { get; set; }
        public double fuel_consumption { get; set; }
    }
    public class MyData
    {
        public string gps_sn { get; set; }
        public string nopol { get; set; }
        public string company_nm { get; set; }
        public int company_id { get; set; }
        public int tipe { get; set; }
        public string status { get; set; }
        public DateTime start_time { get; set; }
        public DateTime stop_time { get; set; }
        public Duration duration { get; set; }
        public RfidDriver rfid_driver { get; set; }
        public object driving { get; set; }
        public object parking { get; set; }
        public Idle idle { get; set; }
        public double fuel_consumption { get; set; }
    }

    public class MyResult
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<MyData> Data { get; set; }
    }
}

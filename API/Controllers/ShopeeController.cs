using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/shopee")]
    public class ShopeeController : ControllerBase
    {

        [HttpGet]
        [Route("get_voucher")]
        public List<Product> get_voucher()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://data.polyxgo.com/api/v1/datax/shopee_vouchers");
            request.Method = "GET";
            String responseJson = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseJson = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var result = JsonConvert.DeserializeObject<Part1>(responseJson);
            var str = result.value.ToString();
            str = str.Substring(1, str.Length-2);
            var voucher = JsonConvert.DeserializeObject<Part2>(str);
            return voucher.vouchers;
        }
        public class Part1
        {
            public string key { get; set; }
            public object value { get; set; }
        }
        public class Part2
        {
            public string category { get; set; }
            public List<Product> vouchers { get; set; }
        }
        public class Product
        {
            public string voucher_market_type { get; set; }
            public string product_message { get; set; }
            public string logistic { get; set; }
            public string devices { get; set; }
            public string payments { get; set; }
            public string reward_percentage { get; set; }
            public string product_limit { get; set; }
            public int shop_id { get; set; }
            public string shop_name { get; set; }
            public string use_type { get; set; }
            public string max_value { get; set; }
            public long promotionid { get; set; }
            public string signature { get; set; }
            public string icon_text { get; set; }
            public string usage_terms { get; set; }
            public long min_spend { get; set; }
            public string discount_percentage { get; set; }
            public string discount_value { get; set; }
            public string coin_percentage { get; set; }
            public string coin_cap { get; set; }
            public string voucher_code { get; set; }
            public string usage_limit_per_user { get; set; }
            public string shop_logo { get; set; }
            public string start_time { get; set; }
            public string end_time { get; set; }
            public bool is_shop_official { get; set; }
        }
    }
}

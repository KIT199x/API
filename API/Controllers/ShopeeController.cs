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
        public List<Data> get_voucher()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://api.accesstrade.vn/v1/offers_informations/coupon?page=2&limit=10&merchant=4742147753565840242,4348611690224153209,&category=E-COMMERCE,&campaign=4751584435713464237,4348614231480407268,&keyword=&url=&utm_source=&utm_medium=&utm_campaign=&utm_content=&data_sub1=&data_sub2=&data_sub3=&data_sub4=&data_sub5=&sort=0");
            request.Method = "GET";
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("Authorization", " Token 5857904480039377044");
            request.Headers.Add("Content-Type", "application/json");
            String responseJson = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseJson = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var voucher = JsonConvert.DeserializeObject<Part1>(responseJson);
            return voucher.data;
        }
        public class Part1
        {
            public int count { get; set; }
            public List<Data> data { get; set; }
        }
        public class Data
        {
            public string aff_link { get; set; }
            public string aff_link_campaign_tag { get; set; }
            public object banner { get; set; }
            public string campaign { get; set; }
            public string campaignid { get; set; }
            public string campaign_name { get; set; }
            public object categories { get; set; }
            public long coin_cap { get; set; }
            public long coin_percentage { get; set; }
            public string content { get; set; }
            public object counpons { get; set; }
            public long discount_percentage { get; set; }
            public string discount_value { get; set; }
            public string domain { get; set; }
            public string end_time { get; set; }
            public string id { get; set; }
            public string images { get; set; }
            public bool is_hot { get; set; }
            public object keywword { get; set; }
            public string link { get; set; }
            public long max_value { get; set; }
            public string merchant { get; set; }
            public long min_spend { get; set; }
            public string name { get; set; }
            public string prior_type { get; set; }
            public int remain { get; set; }
            public bool remain_true { get; set; }
            public string shop_id { get; set; }
            public string start_time { get; set; }
            public string status { get; set; }
            public string time_left { get; set; }
        }
    }
}

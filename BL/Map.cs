using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace BL
{
    class Map
    {
        private static Thread gMapsThread;
        private static bool isRun;
        public  double distance(BE.Address address1, BE.Address address2)//distance in km
        {
            // isRun = true;           
            // in the format: @"bergman 5 st. Jerusalem, ISRAEL";
            string origin = address1.Street + " " + address1.Building_number + " st. " + address1.City + ", ISRAEL";
            string destination = address2.Street + " " + address2.Building_number + " st. " + address2.City + ", ISRAEL";
            string KEY = @"AyK5ohHf7hbnc8VSnPkdcABB5IgYGmvC";

            string url = @"https://www.mapquestapi.com/directions/v2/route" +
              @"?key=" + KEY +
              @"&from=" + origin +
              @"&to=" + destination +
              @"&outFormat=xml" +
              @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
              @"&enhancedNarrative=false&avoidTimedConditions=false";
            gMapsThread = new Thread(GetDrivingDistanceInKM);
            gMapsThread.Start(url);
            return Convert.ToDouble(url);
        }
        private static void GetDrivingDistanceInKM(object url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create((string)url);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(responsereader);
                Console.WriteLine(xmldoc.GetElementsByTagName("distance")[0].ChildNodes[0].InnerText);

                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double dist = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                url = dist.ToString();


                //if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK") //we have answer 
                //{
                //    isRun = false; //stop the thread

                //    //Console.WriteLine(xmldoc.GetElementsByTagName("status")[1].ChildNodes[0].InnerText);
                //    if (xmldoc.GetElementsByTagName("status")[1].ChildNodes[0].InnerText == "NOT_FOUND")//one of the addresses is not found
                //        Console.WriteLine("one of the adrresses is not found");
                //    else
                //    {
                //        XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                //        double dist = Convert.ToDouble(distance[0].ChildNodes[1].InnerText.Replace(" mi", ""));
                //        Console.WriteLine(dist * 1.609344);

                //        XmlNodeList duration = xmldoc.GetElementsByTagName("duration");
                //        string dur = duration[0].ChildNodes[1].InnerText;
                //        Console.WriteLine(dur);
                //    }
                //}
                //else //QUERY_OVER_LIMIT

            }
            catch
            {
                throw;
            }
        }



    }
}


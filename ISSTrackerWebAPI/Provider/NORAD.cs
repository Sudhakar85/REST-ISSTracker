using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using ISSTrackerWebAPI.Models;


namespace ISSTrackerWebAPI.Provider
{
    public class NORAD : Interface.INord
    {
        private string URL = "http://www.southernstars.com/updates/skysafari4pro/satellites.txt";

        private string baseNORDURL = "http://celestrak.com/NORAD/elements/";

        public List<Satellite> GetAllSatellite()
        {
            // Base Http URL to get the client:
            //http://www.southernstars.com/updates/skysafari4pro/satellites.txt

            List<Satellite> allSystems = new List<Satellite>();

            HttpClient baseServer = new HttpClient();
            var response = baseServer.GetStringAsync(this.URL);

            response.Wait();

            List<string> satelliteURL = response.Result.ToString().SplitBy("\n");
            

            foreach (var url in satelliteURL)
            {
                Satellite system = new Satellite();
                system.Purpose = url.Replace(this.baseNORDURL,string.Empty).Replace(".txt", string.Empty).ToUpper();
                system.Name = new List<string>();

                HttpClient client = new HttpClient();
                var dataResponse = client.GetStringAsync(url);
                dataResponse.Wait();

                system.Name.AddRange(GetSatelliteName(dataResponse.Result.ToString()));
                allSystems.Add(system);
            }

            return allSystems;
        }

        public List<string> GetAllSatellite(string purpose)
        {
            List<string> satelliteList = new List<string>();

            HttpClient baseServer = new HttpClient();
            var response = baseServer.GetStringAsync(this.baseNORDURL + purpose+".txt");
            response.Wait();
            satelliteList.AddRange(GetSatelliteName(response.Result.ToString()));
            
            return satelliteList;

        }

        private List<string> GetSatelliteName(string strContent)
        {
            List<string> nameList = new List<string>();

            var allLines = strContent.SplitBy(Environment.NewLine.ToString());

            for (int i = 0; i < allLines.Count(); i++)
            {
                nameList.Add(allLines[i]);
                i = i + 2;                  // Skipp Two Satellite Date and Get Only Name
            }

            return nameList;

        }

        
    }


    public static class Extension
    {
        public static List<string> SplitBy(this string splitString, string splitby)
        {
            return splitString.Split(new string[] { splitby }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
   
}
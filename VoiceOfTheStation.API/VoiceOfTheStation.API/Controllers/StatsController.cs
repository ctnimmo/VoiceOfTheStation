using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



using System.Text;





namespace VoiceOfTheStation.API.Controllers
{
    /// <summary>
    /// Controller for handling Transfer interaction
    /// Endpoints provided are:
    /// - [HttpGet]
    /// - [HttpGet("{transferKey}")]
    /// - [HttpGet("{transferKey}/item")]
    /// - [HttpGet("{transferKey}/item/{itemID}")]
    /// - [HttpPost]
    /// - [HttpPost("{transferKey}")]
    /// - [HttpPost("{transferKey}/item/")]
    /// - [HttpPost("{transferKey}/item/{itemID}")]
    /// - [HttpDelete("{transferKey}/item/{itemID}")]
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        /// <summary>
        /// Create Controller
        /// </summary>
        public StatsController(){}



        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }





        //public ActionResult<Models.LongLatFruin> GetLongLatFruin([FromQuery] string? date = null)
        //{






        //    return Ok();
        //}

        



        //public ActionResult<string> SomeData()
        //{


        //    IList<string> result = new List<string>();

        //    foreach (string month in monthFiles)
        //    {
        //        IEnumerable<string> dataInFile = System.IO.File.ReadLines(month + ".csv");

        //        foreach (string dataRow in dataInFile)
        //        {
        //            foreach (string day in days)
        //            {
        //                if (dataRow.Contains(day))
        //                {
        //                    // 1. Format commas found in quotes (convert comma to _)

        //                    string[] quoteSections = dataRow.Split('"');
        //                    int j = 1;
        //                    while (j < quoteSections.Length - 1)
        //                    {
        //                        quoteSections[j] = quoteSections[j].Replace(',', '_');
        //                        j += 2;
        //                    }

        //                    // 2. Reformat data into string

        //                    string dataRowFormatted = String.Join("\"", quoteSections);

        //                    // 3. Split data into columns (using commas)

        //                    string[] dataColumns = dataRowFormatted.Split(','); // note: be wary due to commas in a column

        //                    // 4. check
        //                    if (dataColumns.Length > 26)
        //                    {
        //                        throw new Exception("found too many columns in csv");
        //                    }

        //                    // grab columns for new data file

        //                    /* grab columns:
        //                    timestamp - 2
        //                    userid - 3
        //                    Latitude - 10 --- actually 7
        //                    Longitude - 11 --- actually 8
        //                    connectiontype -16
        //                    devicelanguage - 25
        //                    */

        //                    string[] selectedDataColumns = { dataColumns[2 - 1], dataColumns[3 - 1], dataColumns[7 - 1], dataColumns[8 - 1], dataColumns[16 - 1], dataColumns[25 - 1] };

        //                    // 5. Reformat data into string
        //                    string newDataRow = String.Join(",", selectedDataColumns);

        //                    result.Add(newDataRow); // the contains should be duped due to uniqueness of data
        //                }
        //            }
        //        }
        //    }
        //    System.IO.File.WriteAllLines("DailyDataForHackTrain6.csv", result);
        //}
        
    }
}
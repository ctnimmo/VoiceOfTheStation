using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationDataCoreLibrary
{
    public class DataFormatter
    {

        // default value for acceptable neighbourhood (effectively a measure to use like FRUIN)
        // a feedback loop/control could adjust this accordingly
        // although may be better in another class
        public double AcceptableNeighbourhoodSize = 0.01;


        public string[] SplitCommaSeperatedRow(string dataRow)
        {
            // 1. Determine quotation marks (where comma are not seperators)

            string[] quoteSections = dataRow.Split('"');

            // 2. Replace commas by underscores in "quoted" sections (to prevent unwanted splits).

            int j = 1;
            while (j < quoteSections.Length - 1)
            {
                quoteSections[j] = quoteSections[j].Replace(',', '_');
                j += 2;
            }

            // 3. Reformat data into string

            string dataRowFormatted = String.Join("\"", quoteSections);

            // 4. Split data into columns (using commas)

            string[] dataColumns = dataRowFormatted.Split(','); // note: be wary due to commas in a column

            return dataColumns;
        }

        
        public string[] GetRequiredColumns(string[] dataColumns, IEnumerable<LocationDataType> columnsToInclude)
        {

            IList<string> selectedDataColumnsList = new List<string>();

            foreach (LocationDataType col in columnsToInclude)
            {
                selectedDataColumnsList.Add(dataColumns[(int)col - 1]);
            }

            string[] selectedDataColumns = selectedDataColumnsList.ToArray();

            return selectedDataColumns;

            // string newDataRow = String.Join(",", selectedDataColumns);

            // return newDataRow;
        }
        
        public bool ToInclude(string[] dataColumns, params IDataFilter[] filters)
        {
            if (filters == null || filters.Length == 0)
            {
                return true; // need to change this
            }

            //default output
            bool output = false;

            // else go through each filter and if you find one then true it
            foreach (DataFilter filter in filters)
            {
                int columnToCheck = (int)filter.FilterType - 1;
                string descriptionToCheck = filter.Filter;

                if (dataColumns[columnToCheck] == descriptionToCheck)
                {
                    output = true;
                    break;
                }
            }

            return output;
        }

        public IList<string> ProcessFileToList(IEnumerable<string> monthFiles, IEnumerable<string> days, IEnumerable<LocationDataType> requiredLocationColumns, params IDataFilter[] filters)
        {
            IList<string> result = new List<string>();

            foreach (string month in monthFiles)
            {
                IEnumerable<string> dataInFile = System.IO.File.ReadLines(month + ".csv");

                foreach (string dataRow in dataInFile)
                {
                    foreach (string day in days)
                    {
                        if (dataRow.Contains(day))
                        {
                            // DataFormatter df = new DataFormatter();

                            string[] dataColumns = SplitCommaSeperatedRow(dataRow);

                            // Check number of expected rows:
                            int numExpectedRows = 26; // ideally set as part of some (expected) metadata input for a file

                            if (dataColumns.Length != numExpectedRows)
                            {
                                throw new Exception("More columns than expected in csv");
                            }

                            // test passed; therefore, filter row (if a filter exists)

                            // filter this before removing columns as the number order will change -- potential bug point (change if time)
                            if (!ToInclude(dataColumns, filters))
                            {
                                continue;
                            }

                            string[] selectedDataColumns = GetRequiredColumns(dataColumns, requiredLocationColumns);

                            string newDataRow = String.Join(",", selectedDataColumns);

                            result.Add(newDataRow); // the contains should be duped due to uniqueness of data
                        }
                    }
                }
            }
            return result;
        }

        public void ProcessFileToDebugFolder(IEnumerable<string> monthFiles, IEnumerable<string> days, IEnumerable<LocationDataType> requiredLocationColumns, string fileOutputName, params IDataFilter[] filters)
        {
            IList<string> result = ProcessFileToList(monthFiles, days, requiredLocationColumns, filters);
            System.IO.File.WriteAllLines(fileOutputName, result);
        }


        //// assumes format input is the reduced data format
        //// therefore first
        //public IList<string> ReduceToHourData(IList<string> processedFile, string wantedHour)
        //{
        //    IList<string> newOutput = new List<string>();
        //    foreach (string row in processedFile)
        //    {
        //        string[] colData = row.Split(',');


        //        var dateTimeData = colData[0];
        //        var dateTimeSplit = dateTimeData.Split('T');
        //        var date = dateTimeSplit[0].Split('-');
        //        var year = date[0];
        //        var month = date[1];
        //        var day = date[2];

        //        var time = dateTimeSplit[1].Split(':');

        //        var hour = time[0];
        //        var minute = time[1];
        //        var secondAndMillisecond = time[2].Split('.');
        //        var second = secondAndMillisecond[0];
        //        var milliSecond = secondAndMillisecond[1];


        //        if (hour == wantedHour) //this is not very "tight" i.e. logical needs tightening
        //        {
        //            newOutput.Add(row);
        //        }
        //    }
        //    return newOutput;
        //}


        // assumes format input is the reduced data format
        // therefore first
        public IList<string[]> ReduceToHourData(IList<string> processedFile, string wantedHour) // could overload but want to keep seperate for the moment as may diverge functionality *** comments no longer relevant
        {
            // just return lat long and date time - but as a split
            IList<string[]> newOutput = new List<string[]>();
            foreach (string row in processedFile)
            {
                string[] colData = row.Split(',');


                var dateTimeData = colData[0];
                var dateTimeSplit = dateTimeData.Split('T');
                var date = dateTimeSplit[0].Split('-');
                var year = date[0];
                var month = date[1];
                var day = date[2];

                var time = dateTimeSplit[1].Split(':');

                var hour = time[0];
                var minute = time[1];
                var secondAndMillisecond = time[2].Split('.');
                var second = secondAndMillisecond[0];
                var milliSecond = secondAndMillisecond[1];


                var userId = colData[1];
                var latitude = colData[2];
                var longitude = colData[3];
                
                if (hour == wantedHour) //this is not very "tight" i.e. logical needs tightening
                {
                    string[] newRowVersion = { year, month, day, hour, minute, second, milliSecond, userId, latitude, longitude, "" }; // empty is reserved for data to return. 
                    newOutput.Add(newRowVersion);
                }
            }
            return newOutput;
        }



        // assumes format input is the reduced data format
        // therefore first
        public IList<CalculatedDataOutput> ReduceToHourData_v2C(IList<string> processedFile, string wantedHour) // could overload but want to keep seperate for the moment as may diverge functionality *** comments no longer relevant
        {
            IList<CalculatedDataOutput> newOutputC = new List<CalculatedDataOutput>();
            foreach (string row in processedFile)
            {
                string[] colData = row.Split(',');


                var dateTimeData = colData[0];
                var dateTimeSplit = dateTimeData.Split('T');
                var date = dateTimeSplit[0].Split('-');
                var year = date[0];
                var month = date[1];
                var day = date[2];

                var time = dateTimeSplit[1].Split(':');

                var hour = time[0];
                var minute = time[1];
                var secondAndMillisecond = time[2].Split('.');
                var second = secondAndMillisecond[0];
                var milliSecond = secondAndMillisecond[1];


                var userId = colData[1];
                var latitude = colData[2];
                var longitude = colData[3];

                if (hour == wantedHour) //this is not very "tight" i.e. logical needs tightening
                {
                    CalculatedDataOutput newOutput = new CalculatedDataOutput
                    {
                        Year = year,
                        Month = month,
                        Day = day,
                        Hour = hour,
                        Minute = minute,
                        Second = second,
                        MilliSecond = milliSecond,
                        UserId = userId,
                        Latitude = latitude,
                        Longitude = longitude,
                        NeigbourhoodSize = "",
                        AcceptableNeighbourhoodSize = AcceptableNeighbourhoodSize.ToString(),
                        IsAcceptable = "",
                        IsHappyFace = ""
                    };
                    newOutputC.Add(newOutput);
                }
            }
            return newOutputC;
        }

        
        public double CalculateDist(LatLongPoint point1, LatLongPoint point2)
        {
            double LatDist = Math.Abs(point1.Latitude - point2.Latitude);
            double LongDist = Math.Abs(point1.Longitude - point2.Longitude);

            double aSq = Math.Pow(LatDist, 2);
            double bSq = Math.Pow(LongDist, 2);
            double cSq = aSq + bSq;

            double c = Math.Sqrt(cSq);

            return c;
        }

        public double CalculateAvgDistancesForAToAll(IList<string[]> data, LatLongPoint pointA) //ideally the reduced data
        {
            double cumDistanceAToB = 0;
            foreach (string[] row in data)
            {
                var latitude = row[8];
                var logitude = row[9];

                LatLongPoint pointB = new LatLongPoint
                {
                    Latitude = Convert.ToDouble(latitude),
                    Longitude = Convert.ToDouble(logitude)
                };

                double distanceAToB = CalculateDist(pointA, pointB);
                cumDistanceAToB += distanceAToB;
            }

            if (data.Count() == 0) // zero error
            {
                return 0; // not technically true but ok for here
            }

            double avgDistanceForAToAll = cumDistanceAToB / data.Count(); // this forms the index measure for the last hour
            return avgDistanceForAToAll;
        }
        
        public IList<string[]> CalculateAvgDistancesForAllToAll(IList<string[]> data) //the data in the finally element of array should be empty string - see ReduceToHourData_v2 ... note this is bug prone due to it being called from anthine
        {
            foreach (string[] dataRow in data)
            {
                LatLongPoint pointB = new LatLongPoint
                {
                    Latitude = Convert.ToDouble(dataRow[8]),
                    Longitude = Convert.ToDouble(dataRow[9])
                };
                double avgDist = CalculateAvgDistancesForAToAll(data, pointB);
                dataRow[dataRow.Length - 1] = avgDist.ToString(); // this end element should be "", but could do with a sanity check/validation. Even better, use a proper class!
            }
            return data;
        }






        public double CalculateAvgDistancesForAToAll_v2C(IList<CalculatedDataOutput> data, LatLongPoint pointA) //ideally the reduced data
        {
            double cumDistanceAToB = 0;
            foreach (CalculatedDataOutput row in data)
            {
                var latitude = row.Latitude;
                var logitude = row.Longitude;

                LatLongPoint pointB = new LatLongPoint
                {
                    Latitude = Convert.ToDouble(latitude),
                    Longitude = Convert.ToDouble(logitude)
                };

                double distanceAToB = CalculateDist(pointA, pointB);
                cumDistanceAToB += distanceAToB;
            }

            if (data.Count() == 0) // zero error
            {
                return 0; // not technically true but ok for here
            }

            double avgDistanceForAToAll = cumDistanceAToB / data.Count(); // this forms the index measure for the last hour
            return avgDistanceForAToAll;
        }

        public IList<CalculatedDataOutput> CalculateAvgDistancesForAllToAll_v2C(IList<CalculatedDataOutput> data) //the data in the finally element of array should be empty string - see ReduceToHourData_v2 ... note this is bug prone due to it being called from anthine
        {
            foreach (CalculatedDataOutput dataRow in data)
            {
                LatLongPoint pointB = new LatLongPoint
                {
                    Latitude = Convert.ToDouble(dataRow.Latitude),
                    Longitude = Convert.ToDouble(dataRow.Longitude)
                };
                double avgDist = CalculateAvgDistancesForAToAll_v2C(data, pointB);
                // dataRow[dataRow.Length - 1] = avgDist.ToString(); // this end element should be "", but could do with a sanity check/validation. Even better, use a proper class!
                dataRow.NeigbourhoodSize = avgDist.ToString();
                double analyse = avgDist-AcceptableNeighbourhoodSize;
                if (analyse > 0)
                {
                    dataRow.IsAcceptable = true.ToString();
                    dataRow.IsHappyFace = " :-) ";
                }
                else
                {
                    dataRow.IsAcceptable = true.ToString();
                    dataRow.IsHappyFace = " :-( ";
                }
            }
            return data;
        }

    }
}

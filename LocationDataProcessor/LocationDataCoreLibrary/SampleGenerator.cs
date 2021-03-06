﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LocationDataCoreLibrary
{
    public class SampleGenerator
    {
        public SampleGenerator() { }

        public void Generate(string[] args)
        {
            // ProcessADailyFile_SampleTEST();
            // ProcessADailyFile_Sample1();
            // ProcessFlowFile_SampleTEST();
            // ProcessFlowFile_Sample1();
            // ProcessFlowFile_Sample2();
            // ProcessFlowFile_Sample3();
        }

        // SAMPLE 1
        public void ProcessADailyFile_SampleTEST()
        {
            // Data to pull:
            string fileOutputName = "DailyDataForHackTrain6_1Month_1Day_TEST.csv";
            IList<LocationDataType> requiredLocationColumns =   new List<LocationDataType>
                                                                {
                                                                    LocationDataType.Timestamp,
                                                                    LocationDataType.User_ID,
                                                                    LocationDataType.Latitude,
                                                                    LocationDataType.Longitude,
                                                                    LocationDataType.Connection_Type,
                                                                    LocationDataType.Device_Language
                                                                };
            string[] monthFiles = { "month=2018-12" };
            string[] days = { ",2018-12-03T" };
            DataFormatter df = new DataFormatter();
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName);
        }

        // SAMPLE 2
        public void ProcessADailyFile_Sample1()
        {
            // Data to pull:

            string fileOutputName = "DailyDataForHackTrain6_3Months.csv";

            IList<LocationDataType> requiredLocationColumns = new List<LocationDataType>
                                                                {
                                                                    LocationDataType.Timestamp,
                                                                    LocationDataType.User_ID,
                                                                    LocationDataType.Latitude,
                                                                    LocationDataType.Longitude,
                                                                    LocationDataType.Connection_Type,
                                                                    LocationDataType.Device_Language
                                                                };

            string[] monthFiles =   {
                                        "month=2018-12",
                                        "month=2019-06",
                                        "month=2019-10"
                                    };

            string[] days = {
                                ",2018-12-03T",
                                ",2018-12-04T",
                                ",2018-12-05T",
                                ",2018-12-06T",
                                ",2018-12-07T",

                                ",2019-06-03T",
                                ",2019-06-04T",
                                ",2019-06-05T",
                                ",2019-06-06T",
                                ",2019-06-07T",

                                ",2019-10-03T",
                                ",2019-10-04T",
                                ",2019-10-05T",
                                ",2019-10-06T",
                                ",2019-10-07T"
                            };

            DataFormatter df = new DataFormatter();
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName);
        }

        // SAMPLE 3
        public void ProcessFlowFile_SampleTEST()
        {
            string fileOutputName = "FlowDataForHackTrain6_TEST.csv";

            IDataFilter dataFilter = new DataFilter
            {
                FilterType = LocationDataType.User_ID,
                Filter = "728da454-a3b6-42e1-b919-91bbf8e05ac7"
            };

            IList<LocationDataType> requiredLocationColumns = new List<LocationDataType>
                                                                {
                                                                    LocationDataType.Timestamp,
                                                                    LocationDataType.User_ID,
                                                                    LocationDataType.Latitude,
                                                                    LocationDataType.Longitude,
                                                                    LocationDataType.Connection_Type,
                                                                    LocationDataType.Device_Language
                                                                };

            string[] monthFiles = { "month=2018-12" }; // override to test

            string[] days = { ",2018-12-03T" };

            DataFormatter df = new DataFormatter();
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName, dataFilter);
        }

        // SAMPLE 4
        public void ProcessFlowFile_Sample1()
        {
            string fileOutputName = "FlowDataForHackTrain6_Dec5Days_User_1.csv";

            IDataFilter dataFilter = new DataFilter
            {
                FilterType = LocationDataType.User_ID,
                Filter = "c5960d83-d29d-48a2-aa40-974ba76c7513"
            };

            IList<LocationDataType> requiredLocationColumns = new List<LocationDataType>
                                                                {
                                                                    LocationDataType.Timestamp,
                                                                    LocationDataType.User_ID,
                                                                    LocationDataType.Latitude,
                                                                    LocationDataType.Longitude,
                                                                    LocationDataType.Connection_Type,
                                                                    LocationDataType.Device_Language
                                                                };
            string[] monthFiles = { "month=2018-12" };
            string[] days = {
                                ",2018-12-03T",
                                ",2018-12-04T",
                                ",2018-12-05T",
                                ",2018-12-06T",
                                ",2018-12-07T"
                            };

            DataFormatter df = new DataFormatter();
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName, dataFilter);

            // additional
            fileOutputName = "FlowDataForHackTrain6_Dec5Days_User_2.csv";
            dataFilter.Filter = "64a2036f-0e6f-4bd2-95c2-c747e7c2cec8";
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName, dataFilter);

            fileOutputName = "FlowDataForHackTrain6_Dec5Days_User_3.csv";
            dataFilter.Filter = "ba7dc04c-4209-440f-82ce-3e710baa217d";
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName, dataFilter);

            fileOutputName = "FlowDataForHackTrain6_Dec5Days_User_4.csv";
            dataFilter.Filter = "5343052a-c492-44e6-af60-a76af7875e07";
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName, dataFilter);

            fileOutputName = "FlowDataForHackTrain6_Dec5Days_User_5.csv";
            dataFilter.Filter = "47dcf0fa-4fad-4ba3-a692-f62cc7bb0852";
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName, dataFilter);
        }

        // SAMPLE 5
        public void ProcessFlowFile_Sample2()
        {
            string fileOutputName = "FlowDataForHackTrain6_3Months_User_CHECK.csv";

            IDataFilter dataFilter = new DataFilter
            {
                FilterType = LocationDataType.User_ID,
                Filter = "5343052a-c492-44e6-af60-a76af7875e07"
            };

            IList<LocationDataType> requiredLocationColumns = new List<LocationDataType>
                                                                {
                                                                    LocationDataType.Timestamp,
                                                                    LocationDataType.User_ID,
                                                                    LocationDataType.Latitude,
                                                                    LocationDataType.Longitude,
                                                                    LocationDataType.Connection_Type,
                                                                    LocationDataType.Device_Language
                                                                };
            string[] monthFiles =   {
                                        "month=2018-12",
                                        "month=2019-06",
                                        "month=2019-10"
                                    };

            string[] days = {
                                ",2018-12-03T",
                                ",2018-12-04T",
                                ",2018-12-05T",
                                ",2018-12-06T",
                                ",2018-12-07T",

                                ",2019-06-03T",
                                ",2019-06-04T",
                                ",2019-06-05T",
                                ",2019-06-06T",
                                ",2019-06-07T",

                                ",2019-10-03T",
                                ",2019-10-04T",
                                ",2019-10-05T",
                                ",2019-10-06T",
                                ",2019-10-07T"
                            };

            DataFormatter df = new DataFormatter();
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName, dataFilter);
        }




        // SAMPLE 6 (Flow Sample 3)
        public void ProcessFlowFile_Sample3()
        {
            string fileOutputName = "";

            IDataFilter dataFilter = new DataFilter
            {
                FilterType = LocationDataType.User_ID
            };

            IList<LocationDataType> requiredLocationColumns = new List<LocationDataType>
                                                                {
                                                                    LocationDataType.Timestamp,
                                                                    LocationDataType.User_ID,
                                                                    LocationDataType.Latitude,
                                                                    LocationDataType.Longitude,
                                                                    LocationDataType.Connection_Type,
                                                                    LocationDataType.Device_Language
                                                                };
            string[] monthFiles = { "month=2018-12" };
            string[] days = {
                                ",2018-12-03T",
                                ",2018-12-04T",
                                ",2018-12-05T",
                                ",2018-12-06T",
                                ",2018-12-07T"
                            };

            DataFormatter df = new DataFormatter();

            /*
            a8b170c7-8b5b-494c-9fdb-ff453d36f577
            b5dfa510-14d0-4c88-b064-dc53ceea290c    
            87b7dc48-58b9-43a8-8f4b-2d2e44a1a994
            */

            fileOutputName = "FlowDataForHackTrain6_Dec5Days_User_6.csv";
            dataFilter.Filter = "a8b170c7-8b5b-494c-9fdb-ff453d36f577";
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName, dataFilter);

            // additional
            fileOutputName = "FlowDataForHackTrain6_Dec5Days_User_7.csv";
            dataFilter.Filter = "b5dfa510-14d0-4c88-b064-dc53ceea290c";
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName, dataFilter);

            fileOutputName = "FlowDataForHackTrain6_Dec5Days_User_8.csv";
            dataFilter.Filter = "87b7dc48-58b9-43a8-8f4b-2d2e44a1a994";
            df.ProcessFileToDebugFolder(monthFiles, days, requiredLocationColumns, fileOutputName, dataFilter);
        }


        // SAMPLE 7 to use for API output - mimick real-time scenario ()
        // Stick to one day, 3rd dec
        public IList<CalculatedDataOutput> GenerateAPISample(string wantedHour, double? acceptableDistance)
        {
            IDataFilter dataFilter = new DataFilter
            {
                FilterType = LocationDataType.User_ID
            };

            IList<LocationDataType> requiredLocationColumns = new List<LocationDataType>
                                                                {
                                                                    LocationDataType.Timestamp,
                                                                    LocationDataType.User_ID,
                                                                    LocationDataType.Latitude,
                                                                    LocationDataType.Longitude,
                                                                    LocationDataType.Connection_Type,
                                                                    LocationDataType.Device_Language
                                                                };
            string[] monthFiles = { "month=2018-12" };
            string[] days = {
                                ",2018-12-03T",
                            };

            DataFormatter df = new DataFormatter();
            
            // reduces data (could have just used subset, but this will do)
            IList<string> processedFile = df.ProcessFileToList(monthFiles, days, requiredLocationColumns);
            IList<string[]> processedFileToHourDetails = df.ReduceToHourData(processedFile, wantedHour);
            IList<string[]> detailsWithAvgs = df.CalculateAvgDistancesForAllToAll(processedFileToHourDetails); // if time refactor to a class
            
            IList<CalculatedDataOutput> processedFileToHourDetails_v2C = df.ReduceToHourData_v2C(processedFile, wantedHour);
            IList<CalculatedDataOutput> detailsWithAvgs_v2C = df.CalculateAvgDistancesForAllToAll_v2C(processedFileToHourDetails_v2C);

            return detailsWithAvgs_v2C;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationDataProcessor
{
    public class DataFormatter
    {

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

        public void ProcessFileToDebugFolder(IEnumerable<string> monthFiles, IEnumerable<string> days, IEnumerable<LocationDataType> requiredLocationColumns, string fileOutputName, params IDataFilter[] filters)
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

            System.IO.File.WriteAllLines(fileOutputName, result);
        }
    }
}

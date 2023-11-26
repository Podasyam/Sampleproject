using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;


namespace Tests.TestData
{
    public class ExcelOperations
    {

        private static DataTable ExcelToDataTable(string filename)
        {

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);//An encoding provider that allows access to encodings not supported on the current .NET Framework platform.
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read); // This line opens the Excel file specified by fileName in read mode and creates a FileStream named stream.
            IExcelDataReader excelreader = ExcelReaderFactory.CreateOpenXmlReader(stream); // this line creates an instance of IExcelDataReader using ExcelReaderFactory.CreateOpenXmlReader. The IExcelDataReader interface provides methods to read data from Excel files.
            DataSet resultSet = excelreader.AsDataSet(new ExcelDataSetConfiguration() // this line is redundant and should be removed, as result was already assigned in the previous step.
            {

                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true // Can also skip rows before the header, with UseHeaderRow = true, and the ReadHeaderRow callback:

                }   

            }) ;
            DataTableCollection table = resultSet.Tables; // The Tables property of the DataSet result provides access to the collection of DataTable objects contained in the DataSet. The DataTableCollection is assigned to the variable table.
            DataTable resulttable = table["Sheet1"];// This line retrieves the specific DataTable from the table collection based on the sheetName provided as an argument.
            return resulttable; // The method returns the DataTable containing the data from the specified sheet in the Excel file.
        }
        public class DataCollection
        {
            public int rowNumber { get; set; }
            public int colNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }

        }
            static List<DataCollection> datacol = new List<DataCollection>(); // Here, a new List of DataCollection objects is created and named dataCol. This list will store the data read from the Excel file.

        public static void PopulateInCollection(string filename) // this method takes two parameters: fileName (the path to the Excel file) and sheetName (the name of the sheet from which the data should be read).
        {
                DataTable table = ExcelToDataTable(filename); // This line calls the method ExcelToDataTable to read the data from the Excel file specified by fileName and sheetName into a DataTable object named table.
            for (int row = 1; row <= table.Rows.Count; row++) //This for loop iterates over each row in the DataTable table.
            {
                    for (int col = 0; col < table.Columns.Count; col++) //This nested for loop iterates over each column in the DataTable table.
                {
                        DataCollection dtTable = new DataCollection() // Inside the nested loop, a new Datacollection object is created and initialized with the row number, column name, and column value for each cell in the DataTable.
                        {
                            rowNumber = row,// get rownumber                            
                            colName = table.Columns[col].ColumnName,//get column name
                            colValue = table.Rows[row - 1][col].ToString()
                        };
                        datacol.Add(dtTable);
                    }
                    
                }
            }
            public static string ReadData (int rowNumber, string columnname) //  This method takes the same parameters as before, fileName and sheetName, and is responsible for reading the data from the Excel file.
        {
                try
            {   // Retriving data using LINQ to reduce much of iterations
                string data = (from colData in datacol where colData.colName == columnname && colData.rowNumber == rowNumber select colData.colValue).SingleOrDefault();                
                return data.ToString();

                }
                catch (Exception ex)
                {
                    return ex.Message;                
                
                }          
                        
            }
         }
    }


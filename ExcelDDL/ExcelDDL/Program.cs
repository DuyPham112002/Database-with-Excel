namespace ExcelDDL
{
    class Program
    {

        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }
        static async Task MainAsync()
        {
            var templateFile = Directory.GetCurrentDirectory() + "\\template\\template.xlsx";

            var outputFile = new FileInfo(Directory.GetCurrentDirectory() + "\\template\\output.xlsx");
            if (!File.Exists(outputFile.FullName))
            {
                File.Copy(templateFile, outputFile.FullName);
            }
            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(outputFile))
            {
                List<MyObject> objectList = new List<MyObject>();

                for (int rowNumber = 1; rowNumber <= 10; rowNumber++)
                {
                    MyObject myObject = new MyObject
                    {
                        StringColumn1 = "String " + rowNumber.ToString(),
                        IntegerColumn2 = rowNumber,
                        DoubleColumn3 = 1.5 * rowNumber,
                        ObjectColumn4 = DateTime.Now.ToString()
                    };

                    objectList.Add(myObject);
                }

                fastExcel.Write(objectList, "Sheet1", true);
            }
        }

        public class MyObject
        {
            public string StringColumn1 { get; set; }
            public int IntegerColumn2 { get; set; }
            public double DoubleColumn3 { get; set; }
            public string ObjectColumn4 { get; set; }
        }
    }
}

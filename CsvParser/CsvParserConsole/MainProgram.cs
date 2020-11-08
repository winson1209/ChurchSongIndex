using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CsvParserConsole
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            IEnumerable<Song> records;

            using (var reader = new StreamReader("songs.csv", Encoding.Default, true))
            using (var csv = new CsvReader(reader, new CultureInfo("zh-HK")))
            {
                records = csv.GetRecords<Song>().ToList();
            }

            var outputFile = @"songs.txt";
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            foreach (var record in records)
            {
                var stroke = record.Code.Split(new char[] { '-' })[0];
                try
                {
                    stroke = "" + int.Parse(stroke);
                }
                catch
                {
                    stroke = "''";
                }


                var correctedName = record.Name.Replace('?', '祢');
                var correctedFirstLine = record.FirstLine.Replace('?', '祢');
                var array = new[] { "			{", $"				code: '{record.Code}',", $"				name: '{correctedName}',", $"				firstLine: '{correctedFirstLine}',", $"				remark: '{record.Remarks}',", $"				stroke: {stroke},", $"				key: '{record.Key}',", $"				link: '',", $"				lyrics: ''", "			}," };

                File.AppendAllLines(outputFile, array, Encoding.Unicode);
            }
        }
    }
}

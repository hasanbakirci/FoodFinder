using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Helpers
{
    public class FileHelper
    {
        public static Task<string> Add(IFormFile file){
            var sourcepath = Path.GetTempFileName();

            Console.WriteLine(sourcepath);

            if(file.Length > 0){
                using(var stream = new FileStream(sourcepath, FileMode.Create)){
                    Console.WriteLine(stream);
                    file.CopyTo(stream);
                }
            }
            var result = newPath(file);
            Console.WriteLine(result);
            File.Move(sourcepath, result);
            return Task.FromResult(result);
        }


        private static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            string path = Environment.CurrentDirectory + @"\Images";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
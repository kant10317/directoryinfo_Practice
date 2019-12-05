using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace directoryinfo_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\temp";
            DirectoryInfo di = new DirectoryInfo(path);
            Console.WriteLine("=====GetFile=====");

            if (!di.Exists)
            {
                Console.WriteLine("Not Exists");
            }

            // 從目前的目錄傳回檔案清單。
            foreach (var fi in di.GetFiles())
            {
                Console.WriteLine(fi.Name);
            }

            Console.WriteLine("=====FileInfo GetFile=====");
            foreach (FileInfo item in di.GetFiles())
            {
                Console.WriteLine(item.FullName);
            }

            Console.WriteLine("=====GetDirectories=====");
            DirectoryInfo di2 = new DirectoryInfo(path);
            DirectoryInfo[] diArr = di2.GetDirectories();
            foreach (DirectoryInfo dri in diArr)
            {
                Console.WriteLine(dri.Name);
            }

            // 擷取強型別 FileSystemInfo 物件的陣列，表示目前目錄的檔案和子目錄。
            Console.WriteLine("=====GetFileSystemInfos=====");
            foreach (var fi in di.GetFileSystemInfos())
            {
                Console.WriteLine(fi.FullName);
            }

            Console.WriteLine("=====DirectoryInfo Create=====");
            // 使用Create的方法來建立，若是該目錄已經存在則不會有所動作
            string strFolderPath = @"C:\temp\test1";
            DirectoryInfo DIFO = new DirectoryInfo(strFolderPath);
            DIFO.Create();

            Console.WriteLine("=====DirectoryInfo CreateSubdirectory=====");
            // 若是我們要在該目錄下，不斷建立該目錄的子目錄，不需要重複寫上面那一段Code然後把路徑置換，只需要使用CreateSubdirectory方法就可以
            DirectoryInfo DIFO2 = new DirectoryInfo(strFolderPath);
            DirectoryInfo ss = DIFO2.CreateSubdirectory("GG");
            DirectoryInfo sq = ss.CreateSubdirectory("FF");

            Console.WriteLine("=====DirectoryInfo Delete=====");
            // 不過，這邊有一個重點，若是該目錄不是空的，執行這樣語法會出現錯誤，現在已經不需要這樣麻煩，只需要在Delete中傳入，
            // 是否要一併刪除該資料內所有檔案或是目錄就可以，True是表示要刪除該資料夾下所有資料，False則反之。
            //DirectoryInfo DIFO3 = new DirectoryInfo(strFolderPath);
            //DIFO3.Delete(true);      
            
            Console.ReadLine();
        }
    }
}

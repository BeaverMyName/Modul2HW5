using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger.Helpers
{
    public class FileCreationTimeComparer : IComparer
    {
        public int Compare(object obj1, object obj2)
        {
            var file1 = obj1 as FileInfo;
            var file2 = obj2 as FileInfo;

            return file1.CreationTime.CompareTo(file2.CreationTime);
        }
    }
}

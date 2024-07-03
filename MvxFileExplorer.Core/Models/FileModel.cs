using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvxFileExplorer.Core.Models
{
    public class FileModel
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public long Size { get; set; }

        public DateTime DateModified { get; set; }
    }
}

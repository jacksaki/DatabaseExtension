using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseExtension.SampleApp.Models {
    public class CompileFailedException:ApplicationException {
        public CompileFailedException(IEnumerable<string> lines) {
            this.Lines = lines;
        }
        public IEnumerable<string> Lines {
            get;
        }
    }
}

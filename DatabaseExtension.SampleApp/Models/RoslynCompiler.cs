using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace DatabaseExtension.SampleApp.Models {
    public class RoslynCompiler {
        public Task<object> Evaluate(string source) {
            return CSharpScript.EvaluateAsync(source,
                Microsoft.CodeAnalysis.Scripting.ScriptOptions.Default.
                    AddReferences("System").
                    AddReferences("System.Linq").
                    AddReferences("System.IO").
                    AddReferences("System.Collections.Generic").
                    AddReferences("System.Text.Json").
                    AddReferences("DatabaseExtension.SQLite").
                    AddReferences("DatabaseExtension").
                    AddReferences("System.Text.Json.Serialization").
                    AddReferences("System.Reflection").
                    AddReferences("System.Runtime.Serialization")
                );
        }
    }
}

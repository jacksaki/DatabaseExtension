using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DatabaseExtension.SampleApp.Models;
using ICSharpCode.AvalonEdit.Document;
using Livet;
using Livet.Commands;
using Livet.EventListeners;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using DatabaseExtension;
using DatabaseExtension.SQLite;
using System.Text.Json.Serialization;

namespace DatabaseExtension.SampleApp.ViewModels {
    public enum DatabaseType {
        [EnumText("Oracle")]
        ManagedOracle,
        [EnumText("MySQL")]
        MySQL,
        [EnumText("SQLite")]
        SQLite,
        [EnumText("PostgreSQL")]
        PostgreSQL,
        [EnumText("SQL Server")]
        SqlServer,
    }
    public class MainWindowViewModel : ViewModel {
        // Some useful code snippets for ViewModel are defined as l*(llcom, llcomn, lvcomm, lsprop, etc...).
        public void Initialize() {
        }
        public MainWindowViewModel() : base() {
            this.Source = new TextDocument();
            this.Source.TextChanged += (sender, e) => {
                RaisePropertyChanged(nameof(Source));
            };
            this.Result = new TextDocument();
            this.Result.TextChanged += (sender, e) => RaisePropertyChanged(nameof(Result));
            this.Source.Text = GetText("Source.txt");
        }
        private static string GetText(string path) {
            if (System.IO.File.Exists(path)) {
                return System.IO.File.ReadAllText(path);
            } else {
                return "";
            }
        }
        public TextDocument Source {
            get;
        }
        public TextDocument Result {
            get;
        }


        private ViewModelCommand _ExecuteCommand;

        public ViewModelCommand ExecuteCommand {
            get {
                if (_ExecuteCommand == null) {
                    _ExecuteCommand = new ViewModelCommand(Execute, CanExecute);
                }
                return _ExecuteCommand;
            }
        }

        public bool CanExecute() {
            if (this.Source.TextLength == 0) {
                return false;
            }
            return true;
        }

        public void Execute() {
            try {
                this.Result.Text = (new RoslynCompiler().Evaluate(this.Source.Text)).Result.ToString();
            } catch(CompileFailedException ex) {
                this.Result.Text = string.Join("\r\n", ex.Lines);
            }catch(Exception ex) {
                this.Result.Text = ex.Message;
            }
        }

    }
}

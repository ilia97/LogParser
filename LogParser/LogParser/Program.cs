using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using LogParser.Core.Services.Interfaces;

namespace LogParser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var container = LogParserAutofac.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var parserService = scope.Resolve<IParserService>();
                Application.Run(new Form1(parserService));
             }
        }
    }
}

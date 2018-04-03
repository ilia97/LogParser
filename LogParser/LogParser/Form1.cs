using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogParser.Core.Services.Interfaces;

namespace LogParser
{
    public partial class Form1 : Form
    {
        private readonly IParserService _parserService;

        public Form1(IParserService parserService)
        {
            _parserService = parserService;

            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var filePaths = Directory.GetFiles("LOGS");

            foreach (var filePath in filePaths)
            {
                var fileText = File.ReadAllText(filePath);

                await _parserService.ParseLogs(fileText);
            }

            MessageBox.Show("Logs were successfully parsed.");
        }
    }
}

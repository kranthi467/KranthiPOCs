using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace SampleService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        //C:\Windows\Microsoft.NET\Framework\v4.0.30319\installUtil /i SampleService.exe
        // sc delete SampleService
        //cd C:\Users\kranthi.ramasayam\Documents\Visual Studio 2015\Projects\SampleService\SampleService\bin\Debug
        //C:\Windows\System32
        //GGKTECH\kranthi.ramasayam
    }
}

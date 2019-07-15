using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net.FtpClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace mantis_tests
{
    public  class AccountData
    {

        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
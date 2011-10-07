using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DotToPngGenerator
{
    class GlobalSettings
    {
        private static GlobalSettings m_globalSettings;

        private string iniFileName = "DotToPNG.ini";
        private Configs ConfigTokens;

        struct Configs
        {
            public string m_dotToPNGConverterPath;
            public bool m_showInExternalViewer;
        }

        private string[] ConfigStrings =
        {
            "DotToPNGConverterPath",
            "ShowInExternalViewer"
        };
        
        private enum GlobalEnums
        {
            dotToPNGConverterPath,
            showInNativeViewer
        };

        public static GlobalSettings GetInstance()
        {
            if (m_globalSettings == null)
            {
                m_globalSettings = new GlobalSettings();                
            }
            return m_globalSettings;
        }

        //private void ReadConfigToken(TypeCode t,int e,ref Object o)
        //{
        //    switch (t)
        //    {
        //        case TypeCode.String: 

        //            break;
        //        case TypeCode.Boolean:

        //            break;
        //    }
        //    StreamReader sr = new StreamReader(iniFileName);
        //    while (!sr.EndOfStream)
        //    {
        //        string[] s = sr.ReadLine().Split(new char[] { '=' });
        //        if (s[0] == ConfigStrings[e])
        //        {
        //            o = s[1];
        //        }
        //    }
        //    sr.Close();
        //}

        private void ReadStringConfigToken(int e, ref string o)
        {            
            StreamReader sr = new StreamReader(iniFileName);
            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(new char[] { '=' });
                if (s[0] == ConfigStrings[e])
                {
                    o = s[1];
                }
            }
            sr.Close();
        }

        private void ReadBoolConfigToken(int e, ref bool o)
        {
            StreamReader sr = new StreamReader(iniFileName);
            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(new char[] { '=' });
                if (s[0] == ConfigStrings[e])
                {
                    o = bool.Parse(s[1]);
                }
            }
            sr.Close();
        }

        private void ReadGlobalSettings()
        {
            //Do some optimization wrt file access
            ReadStringConfigToken(/*GlobalEnums.dotToPNGConverterPath*/ 0, ref ConfigTokens.m_dotToPNGConverterPath);
            ReadBoolConfigToken(/*GlobalEnums.showInNativeViewer*/ 1, ref ConfigTokens.m_showInExternalViewer);
        }

        public void WriteGlobalSettings()
        {
            StreamWriter sw = new StreamWriter(iniFileName);
            sw.WriteLine(ConfigStrings[0]+"="+ConfigTokens.m_dotToPNGConverterPath);
            sw.WriteLine(ConfigStrings[1]+"="+ConfigTokens.m_showInExternalViewer);
            sw.Close();
        }

        private GlobalSettings()
        {
            try
            {
                ConfigTokens = new Configs();
                ReadGlobalSettings();         
            }
            catch
            {
                SetDefaultSettings();
            }            
        }

        private void SetDefaultSettings()
        {
            ConfigTokens.m_dotToPNGConverterPath = "C:\\Program Files\\Graphviz2.24\\bin\\dot.exe";
            ConfigTokens.m_showInExternalViewer = true;
        }

        public string DotToPNGConverterPath
        {
            get
            {
                return ConfigTokens.m_dotToPNGConverterPath;
            }
            set
            {
                ConfigTokens.m_dotToPNGConverterPath = value;
            }
        }

        public bool ShowInExternalViewer
        {
            get
            {
                return ConfigTokens.m_showInExternalViewer;
            }
            set
            {
                ConfigTokens.m_showInExternalViewer = value;
            }
        }

        ~GlobalSettings()
        {
            //flush everything to file
            WriteGlobalSettings();
        }
        
    }
}

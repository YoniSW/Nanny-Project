﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
//using DAL;
namespace DS
{
    public static class XML_Source
    {
        private static string solutionDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
        
        private static string filePath = System.IO.Path.Combine(solutionDirectory, "DS", @"c:\NannyProject\dataSourceXML");

        private static XElement passwordRoot = null;
        static string passwordPath = Path.Combine(filePath, @"c:\NannyProject\KookieXML.xml");

        private static XElement motherRoot = null;
        static string motherPath = Path.Combine(filePath, @"c:\NannyProject\MothersXML.xml");

        private static XElement contractRoot = null;
        static string contractPath = Path.Combine(filePath, @"c:\NannyProject\ContractsXML.xml");

        private static XElement childRoot = null;
        static string childPath = Path.Combine(filePath, @"c:\NannyProject\ChildrenXML.xml");

        private static XElement nannyRoot = null;
        static string nannyPath = Path.Combine(filePath, @"c:\NannyProject\NannysXML.xml");

        static XML_Source()
        {
            bool exists = Directory.Exists(filePath);

            if (!exists)
            {
                Directory.CreateDirectory(filePath);
            }

            if (!File.Exists(motherPath))
            {
                CreateFile("Mothers", motherPath);

            }
            else
            {
                motherRoot = LoadData(motherPath);
            }

            if (!File.Exists(contractPath))
            {
                CreateFile("Contracts", contractPath);
            }
            else
            {
                contractRoot = LoadData(contractPath);
            }

            if (!File.Exists(childPath))
            {
                CreateFile("Children", childPath);
            }
            else
            {
                childRoot = LoadData(childPath);
            }

            if (!File.Exists(nannyPath))
            {
                CreateFile("Nannys", nannyPath);
            }
            else
            {
                nannyRoot = LoadData(nannyPath);
            }
            if (!File.Exists(passwordPath))
            {
                CreateFile("Kookies", passwordPath);                
            }
            else
            {
                nannyRoot = LoadData(nannyPath);
            }
        }

        public static void Save(XElement root, string path)
        {
            root.Save(path);
        }

        public static void SaveMothers()
        {
            motherRoot.Save(motherPath);
        }

        public static void SaveContracts()
        {
            contractRoot.Save(contractPath);
        }

        public static void SaveChildren()
        {
            childRoot.Save(childPath);
        }

        public static void SaveNannys()
        {
             nannyRoot.Save(nannyPath);
        }

        public static void SavePasswords()
        {
            passwordRoot.Save(passwordPath);
        }
        

        public static XElement Nannys
        {
            get
            {
                nannyRoot = LoadData(nannyPath);
                return nannyRoot;
            }
        }
        public static XElement Passwords
        {
            get
            {
                passwordRoot = LoadData(passwordPath);
                return passwordRoot;
            }
        }


        public static XElement Mothers
        {
            get
            {
                motherRoot = LoadData(motherPath);
                return motherRoot;
            }
        }

        public static XElement Children
        {
            get
            {
                childRoot = LoadData(childPath);
                return childRoot;
            }
        }

        public static XElement Contracts
        {
            get
            {
                contractRoot = LoadData(contractPath);
                return contractRoot;
            }
        }

        private static void CreateFile(string typename, string path)
        {
            XElement root = new XElement(typename);
            root.Save(path);
        }

        private static XElement LoadData(string path)
        {
            XElement root;
            try
            {
                root = XElement.Load(path);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
            return root;
        }
    }
}
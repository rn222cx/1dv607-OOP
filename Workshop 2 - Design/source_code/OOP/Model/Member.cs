﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Workshop_2.Model
{
    class Member
    {
        public string Name { get; set; }
        public string PersonalNumber { get; set; }

        public Member(string name, string personalNumber)
        {
            Name = name;
            PersonalNumber = personalNumber;
        }

        public void add()
        {
            if (File.Exists("Members.xml") == false)
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create("Members.xml", xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Members");

                    xmlWriter.WriteStartElement("Member");
                    xmlWriter.WriteElementString("id", "1");
                    xmlWriter.WriteElementString("Name", Name);
                    xmlWriter.WriteElementString("PersonalNumber", PersonalNumber);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
            else
            {
                //XDocument xDocument = XDocument.Load("Members.xml");
                //XElement Members = xDocument.Element("Members");
                //IEnumerable<XElement> rows = Members.Descendants("Member");
                //// get the last id value
                //int id = int.Parse((string)Members.Descendants("id").FirstOrDefault());
                //id++;
                //XElement firstRow = rows.First();
                //firstRow.AddBeforeSelf(
                //   new XElement("Member",
                //   new XElement("id", id),
                //   new XElement("Name", Name),
                //   new XElement("PersonalNumber", PersonalNumber)));
                //xDocument.Save("Members.xml");

                XElement xEle = XElement.Load("Members.xml");
                int id = int.Parse((string)xEle.Descendants("id").FirstOrDefault());
                id++;
                xEle.AddFirst(new XElement("Member",
                   new XElement("id", id),
                   new XElement("Name", Name),
                   new XElement("PersonalNumber", PersonalNumber)));
                xEle.Save("Members.xml");
            }
        }


    }
}
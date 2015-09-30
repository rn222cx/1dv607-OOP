﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Workshop_2.Model
{
    class MemberDAL
    {
        public bool saveMember(Member member)
        {
            if (member.MemberID == 0)
            {
                return updateMember(member);
            }
            else
            {
                try
                {
                    if (File.Exists(XMLFileInfo.Path) == false)
                    {
                        XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                        xmlWriterSettings.Indent = true;
                        xmlWriterSettings.NewLineOnAttributes = true;
                        using (XmlWriter xmlWriter = XmlWriter.Create(XMLFileInfo.Path, xmlWriterSettings))
                        {
                            xmlWriter.WriteStartDocument();
                            xmlWriter.WriteStartElement(XMLFileInfo.Members);

                            xmlWriter.WriteStartElement(XMLFileInfo.Member);
                            xmlWriter.WriteElementString(XMLFileInfo.ID, XMLFileInfo.FirstID);
                            xmlWriter.WriteElementString(XMLFileInfo.Name, member.Name);
                            xmlWriter.WriteElementString(XMLFileInfo.SocialSecurityNumber, member.SocialSecurityNumber);
                            xmlWriter.WriteEndElement();

                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteEndDocument();
                            xmlWriter.Flush();
                            xmlWriter.Close();
                        }
                    }
                    else
                    {
                        XElement xElement = XElement.Load(XMLFileInfo.Path);
                        int id = int.Parse((string)xElement.Descendants(XMLFileInfo.ID).FirstOrDefault());
                        id++;
                        xElement.AddFirst(new XElement(XMLFileInfo.Member,
                           new XElement(XMLFileInfo.ID, id),
                           new XElement(XMLFileInfo.Name, member.Name),
                           new XElement(XMLFileInfo.SocialSecurityNumber, member.SocialSecurityNumber)));
                        xElement.Save(XMLFileInfo.Path);
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private bool updateMember(Member memberToBeUpdated)
        {
            try
            {
                var oldMember = getMemberByID(memberToBeUpdated.MemberID);
                if (String.IsNullOrWhiteSpace(memberToBeUpdated.Name))
                    memberToBeUpdated.Name = oldMember.Name;
                if (String.IsNullOrWhiteSpace(memberToBeUpdated.SocialSecurityNumber))
                    memberToBeUpdated.SocialSecurityNumber = oldMember.SocialSecurityNumber;

                XElement xElement = XElement.Load(XMLFileInfo.Path);

                // TODO: OSKAR -> Implement function for updating the xml-file

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool validateMemberID(int IdToValidate)
        {
            try
            {
                XElement xElement = XElement.Load(XMLFileInfo.Path);
                IEnumerable<XElement> members = xElement.Elements();
                foreach (var member in members)
                {
                    if (member.Element(XMLFileInfo.ID).Value == IdToValidate.ToString())
                        return true;
                }
            }
            catch (Exception)
            {
                
            }

            return false;
        }

        public Member getMemberByID(int memberID)
        {
            XElement xElement = XElement.Load(XMLFileInfo.Path);

            var memberInfo = from Member in xElement.Elements(XMLFileInfo.Member)
                                where (string)Member.Element(XMLFileInfo.ID) == memberID.ToString()
                                select Member;

            var memberNames = memberInfo.Elements(XMLFileInfo.Name);
            XElement memberName = memberNames.First();

            var memberSSNs = memberInfo.Elements(XMLFileInfo.SocialSecurityNumber);
            XElement memberSSN = memberSSNs.First();
            
            var member = new Member(memberName.Value, memberSSN.Value);

            return member;
        }

        public void removeMember()
        {
            XElement xElement = XElement.Load(XMLFileInfo.Path);

            xElement.Descendants("Member")
                .Where(aa => aa.Element("ID").Value == "1")
                .Remove();

            Console.WriteLine(xElement);
            Console.ReadLine();
        }


        /// <summary>
        /// Creates list of all members. 
        /// </summary>
        /// <returns>List of members.</returns>
        public List<Member> getMembers()
        {
            var memberList = new List<Member>();

            try
            {
                XElement xElement = XElement.Load(XMLFileInfo.Path);

                IEnumerable<XElement> members = xElement.Elements();

                foreach (var member in members)
                {
                    memberList.Add(new Member((string)member.Element(XMLFileInfo.Name), 
                        (string)member.Element(XMLFileInfo.SocialSecurityNumber), 
                        (int)member.Element(XMLFileInfo.ID)));      
                }

                memberList.TrimExcess();

                
            }
            catch (Exception)
            {

            }

            return memberList;
        }
    }
}

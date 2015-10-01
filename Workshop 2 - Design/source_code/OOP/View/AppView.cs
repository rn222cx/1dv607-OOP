﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Model;

namespace Workshop_2.View
{
    class AppView
    {
        public void fail()
        {
            Console.WriteLine(AppStrings.failGeneral);
        }
        public void exit()
        {
            Console.Write(AppStrings.menuGoodBye);
            Console.ReadKey();
        }
        public void waitForUserToRead()
        {
            Console.WriteLine(AppStrings.pressAnyKey);
            Console.ReadLine();
        }

        public void renderCompactListElement(Member member, int numberOfBoats)
        {
            Console.WriteLine(AppStrings.renderCompactList, member.Name, member.MemberID, numberOfBoats);
        }

        public void renderListTitle(string title)
        {
            Console.WriteLine(title);
            Console.WriteLine(AppStrings.divider);
        }

        public void renderGoBackQuestion()
        {
            Console.WriteLine(AppStrings.back, AppStrings.backKey);
        }

        public bool getGoBack()
        {
            return char.ToUpper(Console.ReadKey().KeyChar) == char.Parse(AppStrings.backKey);
        }

        public void renderDivider()
        {
            Console.WriteLine(AppStrings.divider);
        }

        public void renderVerboseListElement(Member member)
        {
            Console.WriteLine(AppStrings.renderVerboseList, member.Name, member.SocialSecurityNumber, member.MemberID);
        }

        public void consoleClear()
        {
            Console.Clear();
        }
    }
}

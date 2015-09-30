﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Model;
using Workshop_2.View;

namespace Workshop_2.Controller
{
    class AppController
    {
        private AppView appView;
        private MemberDAL memberDAL;
        private BoatDAL boatDAL;
        public AppController(AppView appView)
        {
            this.appView = appView;
            memberDAL = new MemberDAL();
            boatDAL = new BoatDAL();
        }

        public void doControll()
        {
            Dictionary<ListOption, Action> Menu = new Dictionary<ListOption, Action>();
            ListOption menuChoice = new ListOption();
            Menu.Add(ListOption.addMember, doAddMember);
            Menu.Add(ListOption.addBoat, doAddBoat);
            Menu.Add(ListOption.showCompactListOfMembers, appView.displayCompactListOfMembers);
            Menu.Add(ListOption.removeMember, doRemoveMember);
            Menu.Add(ListOption.quit, appView.exit);

            while (menuChoice != ListOption.quit)
            {
                appView.welcomeMessage();
                menuChoice = appView.listMenu();

                Menu[menuChoice]();

                //switch (menuChoice)
                //{
                //    case ListOption.addMember:
                //        doAddMember();
                //        break;
                //    case ListOption.addBoat:
                //        doAddBoat();
                //        break;
                //    case ListOption.showCompactListOfMembers:
                //        appView.displayCompactListOfMembers();
                //        break;
                //    case ListOption.quit:
                //        return;
                //    default:
                //        break;
                //} 
            }
        }

        private void doAddMember()
        {
            var newMember = appView.addMember();
            
            if (memberDAL.saveMember(newMember))
            {
                appView.addMemberSuccess();
            }
        }

        private void doAddBoat()
        {
            appView.addBoat();
            var memberID = appView.getNewBoatMemberID();
            var newBoat = appView.getNewBoat();
            if (boatDAL.add(memberID, newBoat))
            {
                appView.addBoatSuccess();
            }
        }

        public void doRemoveMember()
        {
            memberDAL.removeMember(appView.getMemberID());
        }

    }
}

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
            MenuEnum.ListOptions menuChoice;
            appView.welcomMessage();
            menuChoice = appView.listMenu();

            switch (menuChoice)
            {
                case MenuEnum.ListOptions.addMember:
                    var newMember = appView.addMember();
                    if (memberDAL.add(newMember))
                    {
                        appView.addMemberSuccess();
                    }
                    break;
                case MenuEnum.ListOptions.addBoat:
                    var newBoat = appView.addBoat();
                    if (boatDAL.add(newBoat))
                    {
                        appView.addBoatSuccess();
                    }
                    break;
                case MenuEnum.ListOptions.quit:
                    break;
                default:
                    break;
            }
        }

    }
}

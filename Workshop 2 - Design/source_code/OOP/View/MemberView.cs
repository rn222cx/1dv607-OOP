﻿using System;
using Workshop_2.Model;

namespace Workshop_2.View
{
    class MemberView
    {
        private MemberDAL memberDAL;
        public MemberView()
        {
            memberDAL = new MemberDAL();
        }
        #region Add
        public Member addMember()
        {
            Console.WriteLine(AppStrings.menuAddNewMember);
            return getMemberInfo();
        }
        #endregion
        #region Get
        public int getMemberID()
        {
            Console.Write(AppStrings.getMemberId);
            while (true)
            {
                int ID;
                if (int.TryParse(Console.ReadLine(), out ID))
                {
                    if (memberDAL.validateMemberID(ID))
                    {
                        return ID;
                    }
                    else
                    {
                        Console.Write(AppStrings.getMemberIDFail);
                    }
                }
            }
        }
        public Member getMemberInfo()
        {
            return getMemberInfo(0);
        }
        public Member getMemberInfo(int ID)
        {
            Console.Write(AppStrings.addMemberName);
            string name = Console.ReadLine();

            Console.Write(AppStrings.addMemberSSN);
            string ssn = Console.ReadLine();

            var member = new Member(name, ssn, ID);

            return member;
        }
        #endregion
        #region Render
        public void renderMemberByID(int ID)
        {
            var member = memberDAL.getMemberByID(ID);
            Console.WriteLine(AppStrings.renderMembersName, member.Name);
            Console.WriteLine(AppStrings.renderMembersSSN, member.SocialSecurityNumber);
        }
        public void renderAddMemberSuccess()
        {
            Console.WriteLine(AppStrings.addMemberSuccess);
        }
        public void renderEditMemberSuccess()
        {
            Console.WriteLine(AppStrings.editMemberSuccess);
        }
        public void renderRemoveMemberSuccess()
        {
            Console.WriteLine(AppStrings.removeMemberSuccess);
        }
        #endregion
    }
}

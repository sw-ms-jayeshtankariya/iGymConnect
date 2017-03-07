﻿using BusinessLogic.ObjectModel;
using DataLogic.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.UserMag
{
    public class BMember
    {
        public static List<OMMember> GetAllByMember()
        {
            var MemberList = new List<OMMember>();
            using (var context = new iGymConnectEntities())
            {
                MemberList = context.MemberMasters
                    .Where(x => !x.Deleted)
                    .Select(x => new OMMember
                    {
                        MemberId = x.MemberId,
                        MemberImage=x.MemberImage,
                        MemberName = x.MemberName,
                        Gender = x.Gender,
                        Address = x.Address,
                        Address2 = x.Address2,
                        City = x.City,
                        State = x.State,
                        Zip = x.Zip.HasValue ? x.Zip.Value : 0,
                        PhoneHome1 = x.PhoneHome1.HasValue ? x.PhoneHome1.Value : 0,
                        PhoneWork1 = x.PhoneWork1.HasValue ? x.PhoneWork1.Value : 0,
                        Email = x.Email,
                        Note = x.Note,
                        Membershiptypeid = x.Membershiptypeid.HasValue ? x.Membershiptypeid.Value:0,
                    }).ToList();
            }
            return MemberList;
        }

        public static List<OMMember> Save(OMMember mem)
        {
            var memberlist = new List <OMMember>();
            MemberMaster member = new MemberMaster();
            if (mem.MemberId > 0)
            {
                using (var m = new iGymConnectEntities())
                {
                    member = m.MemberMasters.FirstOrDefault(x => x.MemberId == mem.MemberId);
                    member.MemberName = mem.MemberName;
                    member.MemberImage = mem.MemberImage;
                    member.Gender = mem.Gender;
                    member.Address = mem.Address;
                    member.Address2 = mem.Address2;
                    member.City = mem.City;
                    member.State = mem.State;
                    member.Zip = mem.Zip;
                    member.PhoneHome1 = mem.PhoneHome1;
                    member.PhoneWork1 = mem.PhoneWork1;
                    member.Email = mem.Email;
                    member.Note = mem.Note;
                    member.Updated = 1;
                    member.DateUpdated = DateTime.Now;
                    member.Membershiptypeid = mem.Membershiptypeid;
                    member.Deleted = false;
                    
                    m.SaveChanges();
                }
            }
            else
            {
                member.MemberName = mem.MemberName;
                member.MemberImage = mem.MemberImage;
                member.Gender = mem.Gender;
                member.Address = mem.Address;
                member.Address2 = mem.Address2;
                member.City = mem.City;
                member.State = mem.State;
                member.Zip = mem.Zip;
                member.PhoneHome1 = mem.PhoneHome1;
                member.PhoneWork1 = mem.PhoneWork1;
                member.Email = mem.Email;
                member.Note = mem.Note;
                member.Membershiptypeid = mem.Membershiptypeid;
                member.Deleted = false;
                member.CreatedBy = 1;
                member.DateCreated = DateTime.Now;
                using (var m = new iGymConnectEntities())
                {
                    m.MemberMasters.Add(member);
                    m.SaveChanges();
                    memberlist = GetAllByMember();
                }
            }
            return memberlist;
        }
        public static List<OMMember> Deletemem(int MemberId)
        {
            var memberlist = new List<OMMember>();
            using (var m = new iGymConnectEntities())
            {
                var dlMember = m.MemberMasters.FirstOrDefault(x => x.MemberId == MemberId);
                dlMember.Deleted = true;
                m.SaveChanges();
                memberlist = GetAllByMember();
            }
            return memberlist;
        }
    }
}

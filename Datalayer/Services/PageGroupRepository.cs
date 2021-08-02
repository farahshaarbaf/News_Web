﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class PageGroupRepository:IPageGroupRepository
    {
        private MyCmsContext db;

        public PageGroupRepository(MyCmsContext context)
        {
            this.db = context;
        }
        public IEnumerable<PageGroup> GetAllGroups()
        {
            return db.PageGroups;
        }

        public PageGroup GetGroupById(int groupId)
        {
            return db.PageGroups.Find(groupId);
        }

        public bool InsertGroup(PageGroup pageGroup)
        {
            try
            {
                db.PageGroups.Add(pageGroup);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGroup(int groupId)
        {
            try
            {
                var group = GetGroupById(groupId);
                DeleteGroup(group);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public void save()
        {
            db.SaveChanges();
        }

        public IEnumerable<ShowGroupViewModel> GetGroupsForView()
        {
            return db.PageGroups.Select(g => new ShowGroupViewModel()
            {
                GroupID = g.GroupID,
                GroupTitle = g.GroupTitle,
                PageCount = g.Pages.Count
            });
        }


        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<PageGroup> GetFavorite(int take = 4)
        {
            db.Pages.OrderByDescending(p => p.CreateDate);
            return db.PageGroups.OrderByDescending(p=> p.GroupID).Take(take);
        }
    }
}

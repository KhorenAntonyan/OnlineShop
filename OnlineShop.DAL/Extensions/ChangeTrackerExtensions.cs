﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Entities;

namespace OnlineShop.DAL.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static void SetAuditProperties(this ChangeTracker changeTracker)
        {
            var entities = changeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity
                        && (e.State == EntityState.Added
                         || e.State == EntityState.Modified
                         || e.State == EntityState.Deleted));

            foreach (var entity in entities)
            {
                ((BaseEntity)entity.Entity).ModifiedDate = DateTime.UtcNow;

                switch (entity.State)
                {
                    case EntityState.Added:
                        {
                            ((BaseEntity)entity.Entity).CreatedDate = DateTime.UtcNow;
                            break;
                        }
                    case EntityState.Deleted:
                        {
                            entity.State = EntityState.Modified;
                            ((BaseEntity)entity.Entity).IsDeleted = DateTime.UtcNow;
                            break;
                        }
                }
            }
        }
    }
}

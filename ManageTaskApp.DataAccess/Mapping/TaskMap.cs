using ManageTaskApp.DataAccess.DBEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageTaskApp.DataAccess.Mapping
{
    public class TaskMap
    {
        public TaskMap(EntityTypeBuilder<ManageTask> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Priority).IsRequired();
            entityBuilder.Property(t => t.Date).IsRequired();
            entityBuilder.Property(t => t.EstimatedCost).IsRequired();
            entityBuilder.Property(t => t.Description).IsRequired();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;

namespace SocialHeroes.Infra.Data.Configurations
{
    public static class ConventionsRemoveConfiguration
    {
        public static void ConventionsRemove(IEnumerable<IMutableEntityType> entityTypes)
        {
            foreach (var entityType in entityTypes)
            {
                entityType.Relational().TableName = entityType.DisplayName();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }
        }
    }
}

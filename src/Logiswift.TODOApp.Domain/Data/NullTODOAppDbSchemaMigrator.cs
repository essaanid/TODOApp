using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Logiswift.TODOApp.Data;

/* This is used if database provider does't define
 * ITODOAppDbSchemaMigrator implementation.
 */
public class NullTODOAppDbSchemaMigrator : ITODOAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

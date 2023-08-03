using System.Threading.Tasks;

namespace Logiswift.TODOApp.Data;

public interface ITODOAppDbSchemaMigrator
{
    Task MigrateAsync();
}

using whs.api.entities.management;
using whs.api.repository.abstractions.management;
using whs.api.repository.context;

namespace whs.api.repository.management;

internal class UserRepository(WHSDbContext context) : Repository<User>(context), IUsersRepository
{
}

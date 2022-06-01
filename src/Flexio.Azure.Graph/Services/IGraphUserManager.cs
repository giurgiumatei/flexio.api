using Flexio.Data.Models.Users;

namespace Flexio.Azure.Graph.Services;

public interface IGraphUserManager
{
    public void AddUser(User email, string password);
}
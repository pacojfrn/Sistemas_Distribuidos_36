using SoapApi.Models;

namespace SoapApi.Repositories;

public interface IUserRepository {
    Task<IList<UserModel>> GetAll(CancellationToken cancellationToken);
    Task<IList<UserModel>> GetAllByEmail(string email, CancellationToken cancellationToken);
    public Task<UserModel> GetByIdAsync(Guid id, CancellationToken cancellationToken) ;

<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> main
    public Task DeleteByIdAsync(UserModel user, CancellationToken cancellationToken);

    public Task<UserModel> CreateAsync(UserModel user, CancellationToken cancellationToken);

    public Task<bool> UpdateUser(UserModel user, CancellationToken cancellationToken);

<<<<<<< HEAD
=======
=======
>>>>>>> f687bda72c2c50207500665b583f0bc2963e378f
>>>>>>> main
}



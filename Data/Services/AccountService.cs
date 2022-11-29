// using onlyassets.Data.ViewModels;
// using OnlyAssetsFinal.Models;
// using ustaTickets.Data.Base;
// using ustaTickets.Data.Services;

// namespace OnlyAssetsFinal.Data.Services
// {
//     public class AccountService : EntityBaseRepository<Account>, IAccountService
//     {
//         private readonly ApplicationDbContext _context;
//         public AccountService(ApplicationDbContext context) : base(context)
//         {
//             _context = context;
//         }

//         public async Task AddNewAccountAsync(NewAccountVM data)
//         {
//             var newAccount = new Account()
//             {
//                 Email = data.Email,
//                 Password = data.Password,
//                 NickName = data.NickName,
//                 CreationDate = data.CreationDate,
//                 CountryCreation = data.CountryCreation,
//                 ProfilePictureURL = data.ProfilePictureURL,
//                 PersonId = data.PersonId,
//                 RoleId = data.RoleId
//             };
//             await _context.Account.AddAsync(newAccount);
//             await _context.SaveChangesAsync();

//             // Add Movie Actors
//             foreach (var actorId in data.ActorIds)
//             {
//                 var newActorMovie = new Actor_Movie() 
//                 { 
//                     MovieId = newMovie.Id,
//                     ActorId = actorId 
//                 };
//                 await _context.Actor_Movie.AddAsync(newActorMovie);
//             }
//             await _context.SaveChangesAsync();
//         }

//         public Task DeleteAccountAsync(NewAccountVM data)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<Account> GetAccountByIdAsync(int id)
//         {
//             throw new NotImplementedException();
//         }

//         public Task<NewAccountDropdownsVM> GetNewAccountDropdownsValues()
//         {
//             throw new NotImplementedException();
//         }

//         public Task UpdateAccountAsync(NewAccountVM data)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }
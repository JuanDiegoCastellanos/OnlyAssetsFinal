using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlyAssetsFinal.Models;

namespace OnlyAssetsFinal.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // if (!context.Person.Any())
                // {
                //     context.Person.AddRange(new List<Person>()
                //     {
                //         new Person()
                //         {
                //             Name = "Tom",
                //             SurName = "Stiven",
                //             FullName = "Tom Stiven Holland",
                //             BirthDate = new DateTime(2002,09,22),
                //             Gender = false,
                //             PhoneNumber = "31244772828"
                //         },
                //         new Person(){
                //             Name = "Michael",
                //             SurName = "Wichever",
                //             FullName = "Michael Wichever Santos",
                //             BirthDate = new DateTime(1997, 05,21),
                //             Gender = false,
                //             PhoneNumber = "4538939349"
                //         },
                //         new Person()
                //         {
                //             Name = "Trevor",
                //             SurName = "Daniel",
                //             FullName = "Trevor Daniel Rodriguez",
                //             BirthDate = new DateTime(1987, 03, 13),
                //             Gender = false,
                //             PhoneNumber = "0598372882"
                //         }
                //     });
                //     context.SaveChanges();
                // }
                // if (!context.Role.Any())
                // {
                //     context.Role.AddRange(new List<Role>()
                //     {
                //         new Role()
                //         {
                //             RoleType = Enums.RoleType.ADMIN
                //         },
                //         new Role()
                //         {
                //             RoleType = Enums.RoleType.USER
                //         }
                //     });
                //     context.SaveChanges();
                // }
                // if (!context.Account.Any())
                // {
                //     context.Account.AddRange(new List<Account>()
                //     {
                //         new Account()
                //         {
                //             Id = 1,
                //             Email = "tomstiven23@gmail.com",
                //             Password = "miclave123",
                //             NickName = "KillerTom",
                //             CreationDate = new DateTime(2022,10,2),
                //             CountryCreation = "Hong Kong",
                //             ProfilePictureURL = "http://localhost/img/Accounts/Frankin.jpg",
                //             PersonId = 1,
                //             RoleId = 2
                //         },
                //         new Account(){
                //             Id = 2,
                //             Email = "michael.ws@outlook.com",
                //             Password = "lamegaclave2",
                //             NickName = "Michael_Master",
                //             CreationDate = new DateTime(2019,04,20),
                //             CountryCreation = "New York",
                //             ProfilePictureURL = "http://localhost/img/Accounts/michael.jpg",
                //             PersonId = 2,
                //             RoleId = 1
                //         },
                //         new Account()
                //         {
                //             Id = 3,
                //             Email = "trevor.danini02@hotmail.com",
                //             Password = "124494983",
                //             NickName = "TheGreenBaby",
                //             CreationDate = new DateTime(2021,09,15),
                //             CountryCreation = "Dinamarca",
                //             ProfilePictureURL = "http://localhost/img/Accounts/trevor.jpg",
                //             PersonId = 3,
                //             RoleId = 2
                //         }
                //     });
                //     context.SaveChanges();
                // }
                // if (!context.Creator.Any())
                // {
                //     context.Creator.AddRange(new List<Creator>(){

                //         new Creator()
                //         {
                //             CompanyName = "Revolution THR S.A.S",
                //             ContactNumber = "000949282",
                //             ProfilePictureURL = "http://localhost/img/Creators/creatorThree.jpg"
                //         },
                //         new Creator()
                //         {
                //             CompanyName = "ROCKET BRUSH STUDIO",
                //             ContactNumber = "+2342948484",
                //             ProfilePictureURL = "http://localhost/img/Creators/creatorOne.jpeg"
                //         },
                //         new Creator()
                //         {
                //             CompanyName = "REAL.DIMENSION. 5D",
                //             ContactNumber = "21234211",
                //             ProfilePictureURL = "http://localhost/img/Creators/creatorTwo.jpg"
                //         }
                //     });
                //     context.SaveChanges();
                // }
                // if (!context.Asset.Any())
                // {
                //     context.Asset.AddRange(new List<Asset>(){

                //         new Asset()
                //         {
                //             Name = "Pequeño Terreno",
                //             AssetType = Enums.AssetType.CUBE_TEXTURE,
                //             AssetImageUrl = "http://localhost/img/Assets/cubetexture/polygon3d.jpeg",
                //             Price = 99.35,
                //             Rating = 4.6,
                //             CreatorId = 1
                //         },
                //         new Asset()
                //         {
                //             Name = "Pirate Boat",
                //             AssetType = Enums.AssetType.CUBE_TEXTURE,
                //             AssetImageUrl = "http://localhost/img/Assets/cubetexture/ship3d.jpg",
                //             Price = 200.2,
                //             Rating = 4.9,
                //             CreatorId = 2
                //         },
                //         new Asset()
                //         {
                //             Name = "Girl Model Humanoid",
                //             AssetType = Enums.AssetType.HUMANOID_RIGGING,
                //             AssetImageUrl = "http://localhost/img/Assets/humanoidrigging/humanoid3d.jpg",
                //             Price = 250.90,
                //             Rating = 4.5,
                //             CreatorId = 3
                //         },
                //         new Asset()
                //         {
                //             Name = "Girl Full Body",
                //             AssetType = Enums.AssetType.HUMANOID_RIGGING,
                //             AssetImageUrl = "http://localhost/img/Assets/humanoidrigging/humanoideMujer3d.jpg",
                //             Price = 450.98,
                //             Rating = 5.0,
                //             CreatorId = 2
                //         },
                //         new Asset()
                //         {
                //             Name = "Riggin for Humanoid-Girl-Model",
                //             AssetType = Enums.AssetType.HUMANOID_RIGGING,
                //             AssetImageUrl = "http://localhost/img/Assets/humanoidrigging/riggin3d.jpg",
                //             Price = 350.85,
                //             Rating = 4.6,
                //             CreatorId = 2
                //         },
                //         new Asset()
                //         {
                //             Name = "Cat mob Model",
                //             AssetType = Enums.AssetType.MESH_3D,
                //             AssetImageUrl = "http://localhost/img/Assets/mesh3d/cat3d.jpg",
                //             Price = 250.00,
                //             Rating = 4.5,
                //             CreatorId = 1
                //         },
                //         new Asset()
                //         {
                //             Name = "Gun Full Model",
                //             AssetType = Enums.AssetType.MESH_3D,
                //             AssetImageUrl = "http://localhost/img/Assets/mesh3d/gun3d.jpeg",
                //             Price = 250.0,
                //             Rating = 4.5,
                //             CreatorId = 3
                //         },
                //         new Asset()
                //         {
                //             Name = "Guns Package",
                //             AssetType = Enums.AssetType.MESH_3D,
                //             AssetImageUrl = "http://localhost/img/Assets/mesh3d/guns3d.jpeg",
                //             Price = 89.99,
                //             Rating = 3.9,
                //             CreatorId = 3
                //         },
                //         new Asset()
                //         {
                //             Name = "Platformer Full Set 2D",
                //             AssetType = Enums.AssetType.SPRITE_2D,
                //             AssetImageUrl = "http://localhost/img/Assets/sprite2d/platformer2d.png",
                //             Price = 550.90,
                //             Rating = 5.0,
                //             CreatorId = 1
                //         }
                //     });
                //     context.SaveChanges();
                // }
                // if (!context.Purchase.Any())
                // {
                //     context.Purchase.AddRange(new List<Purchase>(){

                //         new Purchase()
                //         {
                //             AccountId = 2,
                //             Description = "Compra uno ---x descripcion de compra uno",
                //             TotalAmount = 24.55
                //         },
                //         new Purchase()
                //         {
                //             AccountId = 1,
                //             Description = "Compra dos ---x descripcion de compra dos",
                //             TotalAmount = 56.55
                //         },
                //         new Purchase()
                //         {
                //             AccountId = 3,
                //             Description = "Compra tres ---x descripcion de compra tres",
                //             TotalAmount = 89.88
                //         },
                //         new Purchase()
                //         {
                //             AccountId = 3,
                //             Description = "Compra cuatro ----x descripcion de compra cuatro",
                //             TotalAmount = 24.55
                //         }
                //     });
                //     context.SaveChanges();
                // }
                // if (!context.Asset_Purchase.Any())
                // {
                //     context.Asset_Purchase.AddRange(new List<Asset_Purchase>(){

                //         new Asset_Purchase()
                //         {
                //             AssetId = 1,
                //             PurchaseId = 2
                //         },
                //         new Asset_Purchase()
                //         {
                //             AssetId = 9,
                //             PurchaseId = 3
                //         },
                //         new Asset_Purchase()
                //         {
                //             AssetId = 5,
                //             PurchaseId = 2
                //         },
                //         new Asset_Purchase()
                //         {
                //             AssetId = 2,
                //             PurchaseId = 1
                //         },
                //         new Asset_Purchase()
                //         {
                //             AssetId = 3,
                //             PurchaseId = 4
                //         },
                //         new Asset_Purchase()
                //         {
                //             AssetId = 8,
                //             PurchaseId = 1
                //         },
                //         new Asset_Purchase()
                //         {
                //             AssetId = 7,
                //             PurchaseId = 3
                //         },
                //         new Asset_Purchase()
                //         {
                //             AssetId = 6,
                //             PurchaseId = 2
                //         },
                //         new Asset_Purchase()
                //         {
                //             AssetId = 4,
                //             PurchaseId = 4
                //         },
                //         new Asset_Purchase()
                //         {
                //             AssetId = 7,
                //             PurchaseId = 4
                //         },
                //         new Asset_Purchase()
                //         {
                //             AssetId = 9,
                //             PurchaseId = 4
                //         }

                //     });
                //     context.SaveChanges();
                // }               
            
            }
        }

    }
}
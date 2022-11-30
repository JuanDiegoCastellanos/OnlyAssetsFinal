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
                //             ProfilePictureURL = "https://assets.reedpopcdn.com/eurogamer-nv8krx.jpg/BROK/resize/1200x1200%3E/format/jpg/quality/70/eurogamer-nv8krx.jpg",
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
                //             ProfilePictureURL = "https://i.pinimg.com/550x/95/98/0c/95980ce3fdc1793a3f25c51c501e7e3c.jpg",
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
                //             ProfilePictureURL = "https://i.pinimg.com/originals/11/6e/06/116e06ee2d9af1c838b44897df1084f5.jpg",
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
                //             ProfilePictureURL = "https://s1.eestatic.com/2021/01/18/cultura/552207380_170722409_1024x576.jpg"
                //         },
                //         new Creator()
                //         {
                //             CompanyName = "ROCKET BRUSH STUDIO",
                //             ContactNumber = "+2342948484",
                //             ProfilePictureURL = "http://clipart-library.com/images/pT5rEbdac.jpg"
                //         },
                //         new Creator()
                //         {
                //             CompanyName = "REAL.DIMENSION. 5D",
                //             ContactNumber = "21234211",
                //             ProfilePictureURL = "https://i1.wp.com/animationvisarts.com/wp-content/uploads/2016/11/cool-logo-backgrounds-6.jpg?fit=1920%2C1080&ssl=1"
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
                //             AssetImageUrl = "https://assets.website-files.com/5f6c71314a8db82b6218d0ea/6266964105976634a4129097_13.jpg",
                //             Price = 99.35,
                //             Rating = 4.6,
                //             CreatorId = 1
                //         },
                //         new Asset()
                //         {
                //             Name = "Pirate Boat",
                //             AssetType = Enums.AssetType.CUBE_TEXTURE,
                //             AssetImageUrl = "https://media.sketchfab.com/models/4dcd5c2e0d5049ae8803d9015db61d5f/thumbnails/a8ed5a264c1c4e449fced8247374ca97/cfaf0946ae8b4855880fdb776f8e6b72.jpeg",
                //             Price = 200.2,
                //             Rating = 4.9,
                //             CreatorId = 2
                //         },
                //         new Asset()
                //         {
                //             Name = "Girl Model Humanoid",
                //             AssetType = Enums.AssetType.HUMANOID_RIGGING,
                //             AssetImageUrl = "https://i.pinimg.com/originals/24/22/70/242270bd39f5b23ea5269612637883a1.png",
                //             Price = 250.90,
                //             Rating = 4.5,
                //             CreatorId = 3
                //         },
                //         new Asset()
                //         {
                //             Name = "Girl Full Body",
                //             AssetType = Enums.AssetType.HUMANOID_RIGGING,
                //             AssetImageUrl = "https://img2.cgtrader.com/items/3195212/3dd9174c90/female-base-mesh-full-rig-woman-girl-character-3d-model-low-poly-rigged-obj-fbx-stl-blend-dae.jpg",
                //             Price = 450.98,
                //             Rating = 5.0,
                //             CreatorId = 2
                //         },
                //         new Asset()
                //         {
                //             Name = "Riggin for Humanoid-Girl-Model",
                //             AssetType = Enums.AssetType.HUMANOID_RIGGING,
                //             AssetImageUrl = "https://img2.cgtrader.com/items/2285087/d9bc2ceff5/large/female-full-body-rig-3d-model-low-poly-rigged-obj-fbx-ma-blend.jpg",
                //             Price = 350.85,
                //             Rating = 4.6,
                //             CreatorId = 2
                //         },
                //         new Asset()
                //         {
                //             Name = "Cat mob Model",
                //             AssetType = Enums.AssetType.MESH_3D,
                //             AssetImageUrl = "https://i.pinimg.com/originals/b5/d1/ca/b5d1cab02f44477855890e0c45e562cc.jpg",
                //             Price = 250.00,
                //             Rating = 4.5,
                //             CreatorId = 1
                //         },
                //         new Asset()
                //         {
                //             Name = "Gun Full Model",
                //             AssetType = Enums.AssetType.MESH_3D,
                //             AssetImageUrl = "https://i.pinimg.com/originals/ea/53/5a/ea535a8f32a8af5f9ce8d88f9d9ad42b.jpg",
                //             Price = 250.0,
                //             Rating = 4.5,
                //             CreatorId = 3
                //         },
                //         new Asset()
                //         {
                //             Name = "Guns Package",
                //             AssetType = Enums.AssetType.MESH_3D,
                //             AssetImageUrl = "https://i.pinimg.com/originals/40/e3/a7/40e3a7652fa10687982515e908729665.jpg",
                //             Price = 89.99,
                //             Rating = 3.9,
                //             CreatorId = 3
                //         },
                //         new Asset()
                //         {
                //             Name = "Platformer Full Set 2D",
                //             AssetType = Enums.AssetType.SPRITE_2D,
                //             AssetImageUrl = "https://e7.pngegg.com/pngimages/464/738/png-clipart-tile-based-video-game-sprite-platform-game-pc-game-sprite-game-text.png",
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
                //             AssetId = 1
                //         },
                //         new Purchase()
                //         {
                //             AccountId = 1,
                //             AssetId = 2
                //         },
                //         new Purchase()
                //         {
                //             AccountId = 3,
                //             AssetId = 4
                //         },
                //         new Purchase()
                //         {
                //             AccountId = 3,
                //             AssetId = 2
                //         }
                //     });
                //     context.SaveChanges();
                // }   
            
            }
        }

    }
}
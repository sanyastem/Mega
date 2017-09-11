namespace MEGA.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DB;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MEGA.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MEGA.Models.ApplicationDbContext context)
        {
            //var types = new List<GoodsType>() {new GoodsType() { Id = 1, Name = "Фотографии стандартных форматов(фотохимическая печать)" },
            //    new GoodsType() { Id = 2, Name = "Фото больших форматов(струйная печать)" },
            //    new GoodsType() { Id = 3, Name = "Полиграфия(лазерная печать)" },
            //    new GoodsType() { Id = 4, Name = "Фотокниги" },
            //    new GoodsType() { Id = 5, Name = "Выпускные альбомы" },
            //    new GoodsType() { Id = 6, Name = "Майки" },
            //    new GoodsType() { Id = 7, Name = "Кружки" },
            //    new GoodsType() { Id = 8, Name = "Тарелки" },
            //    new GoodsType() { Id = 9, Name = "Копилки" },
            //    new GoodsType() { Id = 10, Name = "Фартуки" },
            //    new GoodsType() { Id = 11, Name = "Флажки" },
            //    new GoodsType() { Id = 12, Name = "Подушки" },
            //    new GoodsType() { Id = 13, Name = "Вымпелы" },
            //    new GoodsType() { Id = 14, Name = "Часы" },
            //    new GoodsType() { Id = 15, Name = "Чехлы для смартфонов" },
            //    new GoodsType() { Id = 16, Name = "Сумки" },
            //    new GoodsType() { Id = 17, Name = "Брелки" },
            //    new GoodsType() { Id = 18, Name = "Магниты" },
            //    new GoodsType() { Id = 19, Name = "Пазлы" },
            //    new GoodsType() { Id = 20, Name = "Термос" },
            //    new GoodsType() { Id = 21, Name = "Фляга" },
            //    new GoodsType() { Id = 22, Name = "Коврик для мыши" },
            //    new GoodsType() { Id = 23, Name = "Холст с натяжкой на подрамник" }};
            //context.GoodsTypes.AddRange(types);
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "somemail@mail.ru", UserName = "somemail@mail.ru" };
            string password = "ad46D_ewr3";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
        }
    }
}

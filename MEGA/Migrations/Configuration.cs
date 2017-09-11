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
            //var types = new List<GoodsType>() {new GoodsType() { Id = 1, Name = "���������� ����������� ��������(�������������� ������)" },
            //    new GoodsType() { Id = 2, Name = "���� ������� ��������(�������� ������)" },
            //    new GoodsType() { Id = 3, Name = "����������(�������� ������)" },
            //    new GoodsType() { Id = 4, Name = "���������" },
            //    new GoodsType() { Id = 5, Name = "��������� �������" },
            //    new GoodsType() { Id = 6, Name = "�����" },
            //    new GoodsType() { Id = 7, Name = "������" },
            //    new GoodsType() { Id = 8, Name = "�������" },
            //    new GoodsType() { Id = 9, Name = "�������" },
            //    new GoodsType() { Id = 10, Name = "�������" },
            //    new GoodsType() { Id = 11, Name = "������" },
            //    new GoodsType() { Id = 12, Name = "�������" },
            //    new GoodsType() { Id = 13, Name = "�������" },
            //    new GoodsType() { Id = 14, Name = "����" },
            //    new GoodsType() { Id = 15, Name = "����� ��� ����������" },
            //    new GoodsType() { Id = 16, Name = "�����" },
            //    new GoodsType() { Id = 17, Name = "������" },
            //    new GoodsType() { Id = 18, Name = "�������" },
            //    new GoodsType() { Id = 19, Name = "�����" },
            //    new GoodsType() { Id = 20, Name = "������" },
            //    new GoodsType() { Id = 21, Name = "�����" },
            //    new GoodsType() { Id = 22, Name = "������ ��� ����" },
            //    new GoodsType() { Id = 23, Name = "����� � �������� �� ���������" }};
            //context.GoodsTypes.AddRange(types);
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // ������� ��� ����
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // ��������� ���� � ��
            roleManager.Create(role1);
            roleManager.Create(role2);

            // ������� �������������
            var admin = new ApplicationUser { Email = "somemail@mail.ru", UserName = "somemail@mail.ru" };
            string password = "ad46D_ewr3";
            var result = userManager.Create(admin, password);

            // ���� �������� ������������ ������ �������
            if (result.Succeeded)
            {
                // ��������� ��� ������������ ����
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
        }
    }
}

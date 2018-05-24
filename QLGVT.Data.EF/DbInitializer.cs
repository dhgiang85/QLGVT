﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QLGVT.Data.Entities;
using QLGVT.Data.Enums;

namespace QLGVT.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Customer"
                });
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "mcst@gmail.com",
                    Balance = 0,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Status = Status.Active
                }, "Abcd1234");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            if (_context.Functions.Count() == 0)
            {
                _context.Functions.AddRange(new List<Function>()
                {
                    new Function() {Id = "SYSTEM", Name = "System",ParentId = null,SortOrder = 1,Status = Status.Active,URL = "/",IconCss = "fa-desktop"  },
                    new Function() {Id = "ROLE", Name = "Role",ParentId = "SYSTEM",SortOrder = 1,Status = Status.Active,URL = "/admin/role/index",IconCss = "fa-home"  },
                    new Function() {Id = "FUNCTION", Name = "Function",ParentId = "SYSTEM",SortOrder = 2,Status = Status.Active,URL = "/admin/function/index",IconCss = "fa-home"  },
                    new Function() {Id = "USER", Name = "User",ParentId = "SYSTEM",SortOrder =3,Status = Status.Active,URL = "/admin/user/index",IconCss = "fa-home"  },
                    new Function() {Id = "ACTIVITY", Name = "Activity",ParentId = "SYSTEM",SortOrder = 4,Status = Status.Active,URL = "/admin/activity/index",IconCss = "fa-home"  },
                    new Function() {Id = "ERROR", Name = "Error",ParentId = "SYSTEM",SortOrder = 5,Status = Status.Active,URL = "/admin/error/index",IconCss = "fa-home"  },
                    new Function() {Id = "SETTING", Name = "Configuration",ParentId = "SYSTEM",SortOrder = 6,Status = Status.Active,URL = "/admin/setting/index",IconCss = "fa-home"  },
                    new Function() {Id = "PRODUCT",Name = "Product Management",ParentId = null,SortOrder = 2,Status = Status.Active,URL = "/",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_CATEGORY",Name = "Category",ParentId = "PRODUCT",SortOrder =1,Status = Status.Active,URL = "/admin/productcategory/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_LIST",Name = "Product",ParentId = "PRODUCT",SortOrder = 2,Status = Status.Active,URL = "/admin/product/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "BILL",Name = "Bill",ParentId = "PRODUCT",SortOrder = 3,Status = Status.Active,URL = "/admin/bill/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "CONTENT",Name = "Content",ParentId = null,SortOrder = 3,Status = Status.Active,URL = "/",IconCss = "fa-table"  },
                    new Function() {Id = "BLOG",Name = "Blog",ParentId = "CONTENT",SortOrder = 1,Status = Status.Active,URL = "/admin/blog/index",IconCss = "fa-table"  },
                    new Function() {Id = "UTILITY",Name = "Utilities",ParentId = null,SortOrder = 4,Status = Status.Active,URL = "/",IconCss = "fa-clone"  },
                    new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",SortOrder = 1,Status = Status.Active,URL = "/admin/footer/index",IconCss = "fa-clone"  },
                    new Function() {Id = "FEEDBACK",Name = "Feedback",ParentId = "UTILITY",SortOrder = 2,Status = Status.Active,URL = "/admin/feedback/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ANNOUNCEMENT",Name = "Announcement",ParentId = "UTILITY",SortOrder = 3,Status = Status.Active,URL = "/admin/announcement/index",IconCss = "fa-clone"  },
                    new Function() {Id = "CONTACT",Name = "Contact",ParentId = "UTILITY",SortOrder = 4,Status = Status.Active,URL = "/admin/contact/index",IconCss = "fa-clone"  },
                    new Function() {Id = "SLIDE",Name = "Slide",ParentId = "UTILITY",SortOrder = 5,Status = Status.Active,URL = "/admin/slide/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ADVERTISMENT",Name = "Advertisment",ParentId = "UTILITY",SortOrder = 6,Status = Status.Active,URL = "/admin/advertistment/index",IconCss = "fa-clone"  },

                    new Function() {Id = "REPORT",Name = "Report",ParentId = null,SortOrder = 5,Status = Status.Active,URL = "/",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "REVENUES",Name = "Revenue report",ParentId = "REPORT",SortOrder = 1,Status = Status.Active,URL = "/admin/report/revenues",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "ACCESS",Name = "Visitor Report",ParentId = "REPORT",SortOrder = 2,Status = Status.Active,URL = "/admin/report/visitor",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "READER",Name = "Reader Report",ParentId = "REPORT",SortOrder = 3,Status = Status.Active,URL = "/admin/report/reader",IconCss = "fa-bar-chart-o"  },
                });
            }
            if (_context.Slides.Count() == 0)
            {
                List<Slide> slides = new List<Slide>()
                {
                    new Slide() {Name="Slide 1",Image="/client-side/images/slider/slide-1.jpg",Url="#",DisplayOrder = 0,GroupAlias = "top",Status = true },
                    new Slide() {Name="Slide 2",Image="/client-side/images/slider/slide-2.jpg",Url="#",DisplayOrder = 1,GroupAlias = "top",Status = true },
                    new Slide() {Name="Slide 3",Image="/client-side/images/slider/slide-3.jpg",Url="#",DisplayOrder = 2,GroupAlias = "top",Status = true },

                    new Slide() {Name="Slide 1",Image="/client-side/images/brand1.png",Url="#",DisplayOrder = 1,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 2",Image="/client-side/images/brand2.png",Url="#",DisplayOrder = 2,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 3",Image="/client-side/images/brand3.png",Url="#",DisplayOrder = 3,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 4",Image="/client-side/images/brand4.png",Url="#",DisplayOrder = 4,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 5",Image="/client-side/images/brand5.png",Url="#",DisplayOrder = 5,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 6",Image="/client-side/images/brand6.png",Url="#",DisplayOrder = 6,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 7",Image="/client-side/images/brand7.png",Url="#",DisplayOrder = 7,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 8",Image="/client-side/images/brand8.png",Url="#",DisplayOrder = 8,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 9",Image="/client-side/images/brand9.png",Url="#",DisplayOrder = 9,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 10",Image="/client-side/images/brand10.png",Url="#",DisplayOrder = 10,GroupAlias = "brand",Status = true },
                    new Slide() {Name="Slide 11",Image="/client-side/images/brand11.png",Url="#",DisplayOrder = 11,GroupAlias = "brand",Status = true },
                };
                _context.Slides.AddRange(slides);
            }
            if (_context.DonviVantais.Count() == 0)
            {
                _context.DonviVantais.AddRange(new List<DonviVantai>()
                {
                    new DonviVantai() { Ten = "don vi 1",Diachi = "1",GPKinhdoanh = "1",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},
                    new DonviVantai() { Ten = "don vi 2",Diachi = "2",GPKinhdoanh = "2",LHKinhdoanh = LHKinhDoanh.TuyenCodinh,Status = Status.Active},

                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeTitle"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeTitle",
                    Name = "Home's title",
                    Value1 = "Tedu Shop home",
                    Status = Status.Active
                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaKeyword"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaKeyword",
                    Name = "Home Keyword",
                    Value1 = "shopping, sales",
                    Status = Status.Active
                });
            }
            if (!_context.SystemConfigs.Any(x => x.Id == "HomeMetaDescription"))
            {
                _context.SystemConfigs.Add(new SystemConfig()
                {
                    Id = "HomeMetaDescription",
                    Name = "Home Description",
                    Value1 = "Home tedu",
                    Status = Status.Active
                });
            }
            await _context.SaveChangesAsync();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QLGVT.Application.Interfaces;
using QLGVT.Application.ViewModels.Common;
using QLGVT.Application.ViewModels.QuanLyDonVi;
using QLGVT.Data.Enums;
using QLGVT.Extensions;
using QLGVT.Utilities.Extensions;

namespace QLGVT.Areas.Admin.Controllers
{
    public class DonviVantaiController : BaseController
    {
        IDonviVantaiService _donviVantaiService;

        private readonly IAuthorizationService _authorizationService;

        private readonly IHostingEnvironment _hostingEnvironment;


        public DonviVantaiController(IDonviVantaiService donviVantaiService,
            IAuthorizationService authorizationService,
            IHostingEnvironment hostingEnvironment)
        {
            _donviVantaiService = donviVantaiService;
            
            _authorizationService = authorizationService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            //var email = User.GetSpecificClaim("Email");
            return View();
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _donviVantaiService.GetAllPaging(keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetLHKinhdoanh()
        {
            List<EnumModel> enums = ((LHKinhDoanh[])Enum.GetValues(typeof(LHKinhDoanh)))
                .Select(c => new EnumModel()
                {
                    Value = (int)c,
                    Name = c.GetDescription()
                }).ToList();
            return new OkObjectResult(enums);
        }

        [HttpPost]
        public IActionResult SaveEntity(DonviVantaiViewModel donviVantaiVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                //productVm.SeoAlias = TextHelper.ToUnsignString(productVm.Name);
                if (donviVantaiVm.Id == 0)
                {
                    _donviVantaiService.Add(donviVantaiVm);
                }
                else
                {
                    _donviVantaiService.Update(donviVantaiVm);
                }
                _donviVantaiService.Save();
                return new OkObjectResult(donviVantaiVm);
            }
        }
        [HttpPost]
        public IActionResult SaveTuyens(int donvivantaiId, List<DangkyTuyenViewModel> tuyens)
        {
            _donviVantaiService.AddTuyen(donvivantaiId, tuyens);
            _donviVantaiService.Save();
            return new OkObjectResult(tuyens);
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _donviVantaiService.GetById(id);

            return new OkObjectResult(model);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                _donviVantaiService.Delete(id);
                _donviVantaiService.Save();

                return new OkObjectResult(id);
            }
        }

        [HttpGet]
        public IActionResult GetTuyens(int donvivantaiId)
        {
            var model = _donviVantaiService.GetTuyens(donvivantaiId);

            return new OkObjectResult(model);
        }
    }
}

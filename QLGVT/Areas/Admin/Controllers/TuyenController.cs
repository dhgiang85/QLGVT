using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLGVT.Application.Interfaces;
using QLGVT.Application.ViewModels.Common;
using QLGVT.Application.ViewModels.QuanLyDonVi;
using QLGVT.Data.Enums;
using QLGVT.Utilities.Extensions;

namespace QLGVT.Areas.Admin.Controllers
{
    public class TuyenController : BaseController
    {
        private ITuyenService _tuyenService;
        private IBenxeService _benxeService;

        public TuyenController(ITuyenService tuyenService,
            IBenxeService benxeService)
        {
            _tuyenService = tuyenService;
            _benxeService = benxeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _tuyenService.GetAllPaging(keyword, page, pageSize);
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetDSBenxe()
        {
            var model = _benxeService.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Ten,
                Value = x.Id.ToString()
            }).ToList();
            return new OkObjectResult(model);

        }
        [HttpGet]
        public IActionResult GetTuyens()
        {
            var model = _tuyenService.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Xuatphat.Ten + " - " + x.Diemden.Ten + " (" + x.Khoangcach + " km)",
                Value = x.Id.ToString()
            }).ToList();
            return new OkObjectResult(model);

        }
        [HttpPost]
        public IActionResult SaveEntity(TuyenViewModel tuyenVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                //productVm.SeoAlias = TextHelper.ToUnsignString(productVm.Name);
                if (tuyenVm.Id == 0)
                {
                    _tuyenService.Add(tuyenVm);
                }
                else
                {
                    _tuyenService.Update(tuyenVm);
                }

                _tuyenService.Save();
                return new OkObjectResult(tuyenVm);

            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _tuyenService.GetById(id);

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
                _tuyenService.Delete(id);
                _tuyenService.Save();

                return new OkObjectResult(id);
            }
        }
    }
}
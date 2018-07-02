using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QLGVT.Application.Interfaces;
using QLGVT.Application.ViewModels.Common;
using QLGVT.Application.ViewModels.QuanlyGia;
using QLGVT.Data.Enums;
using QLGVT.Utilities.Extensions;

namespace QLGVT.Areas.Admin.Controllers
{
    public class KekhaiGiaController : BaseController
    {
        private IKekhaiGiaService _kekhaiGiaService;

        public KekhaiGiaController(IKekhaiGiaService kekhaiGiaService)
        {
            _kekhaiGiaService = kekhaiGiaService;
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var model = _kekhaiGiaService.GetAllPaging(keyword, page, pageSize);
            return new OkObjectResult(model);
        }
        [HttpGet]
        public IActionResult GetDongiaStatus()
        {
            List<EnumModel> enums = ((KekhaiGiaStatus[])Enum.GetValues(typeof(KekhaiGiaStatus)))
                .Select(c => new EnumModel()
                {
                    Value = (int)c,
                    Name = c.GetDescription()
                }).ToList();
            return new OkObjectResult(enums);
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _kekhaiGiaService.GetById(id);
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult SaveDongia(KekhaiGiaViewModel KKGVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                //productVm.SeoAlias = TextHelper.ToUnsignString(productVm.Name);
                if (KKGVm.Id == 0)
                {
                    _kekhaiGiaService.Add(KKGVm);
                }
                else
                {
                    _kekhaiGiaService.Update(KKGVm);
                }
                _kekhaiGiaService.Save();
                return new OkObjectResult(KKGVm);
            }
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
                _kekhaiGiaService.Delete(id);
                _kekhaiGiaService.Save();

                return new OkObjectResult(id);
            }
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}

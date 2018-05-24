using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using QLGVT.Application.Interfaces;
using QLGVT.Application.ViewModels.QuanLyDonVi;

namespace QLGVT.Areas.Admin.Controllers
{
    public class BenxeController : BaseController
    {
        private IBenxeService _benxeService;

        public BenxeController(IBenxeService benxeService)
        {
            _benxeService = benxeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _benxeService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpPost]
        public IActionResult SaveEntity(BenxeViewModel benxeVm)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                //productVm.SeoAlias = TextHelper.ToUnsignString(productVm.Name);
                if (benxeVm.Id == 0)
                {
                    _benxeService.Add(benxeVm);
                }
                else
                {
                    _benxeService.Update(benxeVm);
                }
                _benxeService.Save();
                return new OkObjectResult(benxeVm);
            }
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _benxeService.GetById(id);
            return new OkObjectResult(model);
        }
        [HttpPost]
        public IActionResult ReOrder(int sourceId, int targetId)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {
                if (sourceId == targetId)
                {
                    return new BadRequestResult();
                }
                else
                {
                    _benxeService.ReOrder(sourceId, targetId);
                    _benxeService.Save();
                    return new OkResult();
                }
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
                _benxeService.Delete(id);
                _benxeService.Save();

                return new OkObjectResult(id);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HariBySilke_2021.WebApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HBS.HariBySilke_2021.WebApi.Controllers
{
    [Route("api/TreatmentController")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentsService _treatmentsService;

        public TreatmentController(ITreatmentsService treatmentsService)
        {
            _treatmentsService = treatmentsService;
        }

        [HttpGet]
        public ActionResult<TreatmentDto> ReadAll()
        {
            try
            {
                var treatments = _treatmentsService.GetAllTreatments()
                    .Select(t => new TreatmentDto
                    {
                        Price = t.Price,
                        TreatmentName = t.TreatmentName
                    }).ToList();
                return Ok(new TreatmentsDto
                {
                    List = treatments
                });

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
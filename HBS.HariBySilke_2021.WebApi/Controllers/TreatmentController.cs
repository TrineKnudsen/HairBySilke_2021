using System;
using System.IO;
using System.Linq;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HariBySilke_2021.WebApi.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HBS.HariBySilke_2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentsService _treatmentsService;

        public TreatmentController(ITreatmentsService treatmentsService)
        {
            _treatmentsService = treatmentsService ?? throw new InvalidDataException();
        }

        [Authorize]
        [HttpGet]
        public ActionResult<TreatmentDto> ReadAll()
        {
            try
            {
                var treatments = _treatmentsService.GetAllTreatments()
                    .Select(t => new TreatmentDto
                    {
                        Price = t.Price,
                        TreatmentName = t.TreatmentName,
                        Duration = t.Duration
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
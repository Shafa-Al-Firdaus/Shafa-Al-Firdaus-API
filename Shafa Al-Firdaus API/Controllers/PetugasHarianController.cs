﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG4_M7_P1_112.Models;
using Shafa_Al_Firdaus_API.Models;

namespace Shafa_Al_Firdaus_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PetugasHarianController : Controller
    {
        private readonly PetugasHarianRepository _petugasrepository;
        ResponseModel response = new ResponseModel();

        public PetugasHarianController(IConfiguration configuration)
        {
            _petugasrepository = new PetugasHarianRepository(configuration);
        }

        [HttpGet("/GetAllPetugasHarian", Name = "GetAllPetugasHarian")]
        public IActionResult GetAllPetugasHarian()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _petugasrepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }

        [HttpGet("/GetPetugasHarian", Name = "GetPetugasHarian")]
        public IActionResult GetPetugasHarian(string kode)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _petugasrepository.getData(kode);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpGet("/GetIdPetugasHarian", Name = "GetIdPetugasHarian")]
        public IActionResult GetIdPetugasHarian()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _petugasrepository.autoId();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpPost("/InsertPetugasHarian", Name = "InsertPetugasHarian")]
        public IActionResult InsertPetugasHarian([FromBody] PetugasHarianModel petugasHarianModel)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _petugasrepository.insertData(petugasHarianModel);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpPut("/UpdatePetugasHarian", Name = "UpdatePetugasHarian")]
        public IActionResult UpdatePetugasHarian([FromBody] PetugasHarianModel petugasHarianModel)
        {
            PetugasHarianModel petugas = new PetugasHarianModel();

            petugas.kode = petugasHarianModel.kode;
            petugas.nama = petugasHarianModel.nama;
            petugas.nomor_telepon = petugasHarianModel.nomor_telepon;
            petugas.status = petugasHarianModel.status;

            try
            {
                response.status = 200;
                response.message = "Success";
                _petugasrepository.updateData(petugas);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }
        [HttpPatch("/UpdateStatusPetugasHarian", Name = "UpdateStatusPetugasHarian")]
        public IActionResult UpdateStatusPetugasHarian(string kode, int newStatus)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                _petugasrepository.updateStatus(kode, newStatus);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed " + ex.Message.ToString();
            }
            return Ok(response);
        }

    }
}

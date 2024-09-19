using Chatx.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Chatx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HanghoaController : ControllerBase
    {
        public static List<HangHoa> HangHoa = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(HangHoa);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(String id)
        {
            try
            {
                var hanghoa = HangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }
            

        [HttpPost]
        public IActionResult Create(HanghoaVM hanghoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(), 
                TenHangHoa = hanghoaVM.TenHangHoa,
                Dongia = hanghoaVM.Dongia
            };
            HangHoa.Add(hanghoa);
            return Ok(new { Success = true, Data = hanghoa });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(String id, HangHoa hangHoaEdit)
        {
            try
            {
                // LINQ [object] Query
                var hanghoa = HangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // Update 
                hanghoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hanghoa.Dongia = hangHoaEdit.Dongia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(String id)
        {

            try
            {
                // LINQ [object] Query
                var hanghoa = HangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }

                // Update 
                HangHoa.Remove(hanghoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

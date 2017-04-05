﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERP.Web.Models.Database;
using ERP.Web.Models.NewModels;
using System.Threading.Tasks;

namespace ERP.Web.Api.KhachHang
{
    public class Api_TaiKhoanKHController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_TaiKhoanKH
        [Route("api/Api_TaiKhoanKH/{makh}")]
        public List<TaiKhoanKH> GetKH_TK_NGAN_HANG(string makh)
        {
            var vData = (from t1 in db.KH_TK_NGAN_HANG
                         join t2 in db.DM_LOAI_TK_NGAN_HANG on t1.LOAI_TAI_KHOAN equals t2.MA_LOAI
                         where t1.MA_KHACH_HANG == makh
                         select new
                         {
                             t1.MA_KHACH_HANG,t1.SO_TAI_KHOAN,t1.TEN_NGAN_HANG,t1.TEN_TAI_KHOAN,t1.CHI_NHANH,t1.TINH_TP,t1.GHI_CHU,t1.LOAI_TAI_KHOAN,t2.TEN_LOAI                                               
                         });
            var result = vData.ToList().Select(x => new TaiKhoanKH()
            {
                SO_TAI_KHOAN = x.SO_TAI_KHOAN,
                MA_KHACH_HANG = x.MA_KHACH_HANG,
                TEN_TAI_KHOAN = x.TEN_TAI_KHOAN,
                TEN_NGAN_HANG = x.TEN_NGAN_HANG,
                CHI_NHANH = x.CHI_NHANH,
                TINH_TP = x.TINH_TP,
                GHI_CHU = x.GHI_CHU,
                LOAI_TAI_KHOAN = x.LOAI_TAI_KHOAN,
                TEN_LOAI = x.TEN_LOAI
            }).ToList();
            return result;
        }

        // GET: api/Api_TaiKhoanKH/5
        [ResponseType(typeof(KH_TK_NGAN_HANG))]
        public IHttpActionResult GetKH_TK_NGAN_HANG()
        {
            KH_TK_NGAN_HANG kH_TK_NGAN_HANG = db.KH_TK_NGAN_HANG.Find();
            if (kH_TK_NGAN_HANG == null)
            {
                return NotFound();
            }

            return Ok(kH_TK_NGAN_HANG);
        }

        // PUT: api/Api_TaiKhoanKH/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKH_TK_NGAN_HANG(string id, KH_TK_NGAN_HANG kH_TK_NGAN_HANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kH_TK_NGAN_HANG.SO_TAI_KHOAN)
            {
                return BadRequest();
            }

            db.Entry(kH_TK_NGAN_HANG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KH_TK_NGAN_HANGExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Api_TaiKhoanKH
        [ResponseType(typeof(KH_TK_NGAN_HANG))]
        public IHttpActionResult PostKH_TK_NGAN_HANG(KH_TK_NGAN_HANG kH_TK_NGAN_HANG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KH_TK_NGAN_HANG.Add(kH_TK_NGAN_HANG);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KH_TK_NGAN_HANGExists(kH_TK_NGAN_HANG.SO_TAI_KHOAN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kH_TK_NGAN_HANG.SO_TAI_KHOAN }, kH_TK_NGAN_HANG);
        }
        //[HttpPost]
        //[ActionName("Multi")]
        //public async Task<IHttpActionResult> PostMultiKH_TK_NGAN_HANG(String EMAIL,[FromBody] List<KH_TK_NGAN_HANG> taikhoan)
        //{
        //    var data = db.KHs.Where(x => x.EMAIL == EMAIL).FirstOrDefault();

        //    foreach (var item in taikhoan)
        //    {
        //        item.MA_KHACH_HANG = data.MA_KHACH_HANG;
        //        db.KH_TK_NGAN_HANG.Add(item);
        //    }
        //    //for (int i = 0; i < taikhoan.Count(); i++)
        //    //{
        //    //    //nH_NTTKs[i].ID = (index + i + 1).ToString();
        //    //    db.KH_TK_NGAN_HANG.Add(taikhoan[i]);
        //    //}
        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(ex.Message);
        //    }
        //    return Ok(taikhoan);
        //}
        [HttpPost]
        [Route("api/Api_TaiKhoanKH/{makh}")]
        public async Task<IHttpActionResult> PostMultiKH_TK_NGAN_HANG(string makh,[FromBody] List<KH_TK_NGAN_HANG> qUY_CHI_TIET_PHIEU_CHI)
        {
            for (int i = 0; i < qUY_CHI_TIET_PHIEU_CHI.Count(); i++)
            {
                //nH_NTTKs[i].ID = (index + i + 1).ToString();
                db.KH_TK_NGAN_HANG.Add(qUY_CHI_TIET_PHIEU_CHI[i]);
            }
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(qUY_CHI_TIET_PHIEU_CHI);
        }

        // DELETE: api/Api_TaiKhoanKH/5
        [ResponseType(typeof(KH_TK_NGAN_HANG))]
        public IHttpActionResult DeleteKH_TK_NGAN_HANG(string id)
        {
            KH_TK_NGAN_HANG kH_TK_NGAN_HANG = db.KH_TK_NGAN_HANG.Find(id);
            if (kH_TK_NGAN_HANG == null)
            {
                return NotFound();
            }

            db.KH_TK_NGAN_HANG.Remove(kH_TK_NGAN_HANG);
            db.SaveChanges();

            return Ok(kH_TK_NGAN_HANG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KH_TK_NGAN_HANGExists(string id)
        {
            return db.KH_TK_NGAN_HANG.Count(e => e.SO_TAI_KHOAN == id) > 0;
        }
    }
}
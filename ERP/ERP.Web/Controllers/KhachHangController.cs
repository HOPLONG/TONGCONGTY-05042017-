﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP.Web.Models.Database;
using System.IO;
using OfficeOpenXml;
using ERP.Web.Models.BusinessModel;

namespace ERP.Web.Controllers
{
    public class KhachHangController : Controller
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        XuLyNgayThang xulydate = new XuLyNgayThang();
        int so_dong_thanh_cong;
        int dong;
        string makhach, tencongty, phanloaikhach, nhomnganh, diachivpgiaodich, diachixuathoadon, MST, somayban, fax, email, logo, website, tinh, quocgia, dieukhoanthanhtoan, songayduocno, sonotoida, tinhtranghoatdong, tructhuoc, ghichu, phutrachhienthoi, nguoilienhe, chucvu, phongban, ngaysinh, gioitinh, sdt1, sdt2, emailcanhan, emailcongty, skype, facebook, ghichulienhe, salephutrach, sotknganhang, tentaikhoan, tennganhang, chinhanhnganhang, tinhnganhang, loaitaikhoan, ghichutaikhoan;

        // GET: KhachHang
        public ActionResult Index()
        {
            var kHs = db.KHs.Include(k => k.CCTC_CONG_TY);
            return View(kHs.ToList());
        }

        #region "Import KHÁCH HÀNG"

        public ActionResult Import_KhachHang()
        {
           
            return View();
        }





[HttpPost]
        public ActionResult Import_KhachHang(HttpPostedFileBase file)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase filetonkho = Request.Files["UploadedFile"];
                    if ((filetonkho != null) && (filetonkho.ContentLength > 0) && !string.IsNullOrEmpty(filetonkho.FileName))
                    {
                        string fileName = filetonkho.FileName;
                        string fileContentType = filetonkho.ContentType;
                        byte[] fileBytes = new byte[filetonkho.ContentLength];
                        var data = filetonkho.InputStream.Read(fileBytes, 0, Convert.ToInt32(filetonkho.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(filetonkho.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                 makhach = workSheet.Cells[rowIterator, 1].Value.ToString();
                                tencongty = workSheet.Cells[rowIterator, 2].Value.ToString();
                                if (workSheet.Cells[rowIterator, 3].Value != null)
                                    phanloaikhach = workSheet.Cells[rowIterator, 3].Value.ToString();
                                else
                                    phanloaikhach = "";
                                if (workSheet.Cells[rowIterator, 4].Value != null)
                                    nhomnganh = workSheet.Cells[rowIterator, 4].Value.ToString();
                                else
                                    nhomnganh = "";
                                if (workSheet.Cells[rowIterator, 4].Value != null)
                                    nhomnganh = workSheet.Cells[rowIterator, 4].Value.ToString();
                                else
                                    nhomnganh = "";
                                if (workSheet.Cells[rowIterator, 5].Value != null)
                                    diachivpgiaodich = workSheet.Cells[rowIterator, 5].Value.ToString();
                                else
                                    diachivpgiaodich = "";
                                if (workSheet.Cells[rowIterator, 6].Value != null)
                                    diachixuathoadon = workSheet.Cells[rowIterator, 6].Value.ToString();
                                else
                                    diachixuathoadon = "";
                                if (workSheet.Cells[rowIterator, 7].Value != null)
                                    MST = workSheet.Cells[rowIterator, 7].Value.ToString();
                                else
                                    MST = "";



                                if (workSheet.Cells[rowIterator, 8].Value != null)
                                    somayban = workSheet.Cells[rowIterator, 8].Value.ToString();
                                else
                                    somayban = "";
                                if (workSheet.Cells[rowIterator, 9].Value != null)
                                    fax = workSheet.Cells[rowIterator, 9].Value.ToString();
                                else
                                    fax = "";
                                if (workSheet.Cells[rowIterator, 10].Value != null)
                                    email = workSheet.Cells[rowIterator, 10].Value.ToString();
                                else
                                    email = "";
                                if (workSheet.Cells[rowIterator, 11].Value != null)
                                    logo = workSheet.Cells[rowIterator, 11].Value.ToString();
                                else
                                    logo = "";
                                if (workSheet.Cells[rowIterator, 12].Value != null)
                                    website = workSheet.Cells[rowIterator, 12].Value.ToString();
                                else
                                    website = "";
                                if (workSheet.Cells[rowIterator, 13].Value != null)
                                    tinh = workSheet.Cells[rowIterator, 13].Value.ToString();
                                else
                                    tinh = "";
                                if (workSheet.Cells[rowIterator, 14].Value != null)
                                    quocgia = workSheet.Cells[rowIterator, 14].Value.ToString();
                                else
                                    quocgia = "";
                                if (workSheet.Cells[rowIterator, 15].Value != null)
                                    dieukhoanthanhtoan = workSheet.Cells[rowIterator, 15].Value.ToString();
                                else
                                    dieukhoanthanhtoan = "";
                                if (workSheet.Cells[rowIterator, 16].Value != null)
                                    songayduocno = workSheet.Cells[rowIterator, 16].Value.ToString();
                                else
                                    songayduocno = "";
                                if (workSheet.Cells[rowIterator, 17].Value != null)
                                    sonotoida = workSheet.Cells[rowIterator, 17].Value.ToString();
                                else
                                    sonotoida = "";
                                if (workSheet.Cells[rowIterator, 18].Value != null)
                                    tinhtranghoatdong = workSheet.Cells[rowIterator, 18].Value.ToString();
                                else
                                    tinhtranghoatdong = "";
                                if (workSheet.Cells[rowIterator, 19].Value != null)
                                    tructhuoc = workSheet.Cells[rowIterator, 19].Value.ToString();
                                else
                                    tructhuoc = "";
                                if (workSheet.Cells[rowIterator, 20].Value != null)
                                    ghichu = workSheet.Cells[rowIterator, 20].Value.ToString();
                                else
                                    ghichu = "";
                                if (workSheet.Cells[rowIterator, 21].Value != null)
                                    phutrachhienthoi = workSheet.Cells[rowIterator, 21].Value.ToString();
                                else
                                    phutrachhienthoi = "";



                                if (workSheet.Cells[rowIterator, 22].Value != null)
                                    nguoilienhe = workSheet.Cells[rowIterator, 22].Value.ToString();
                                else
                                    nguoilienhe = "";
                                if (workSheet.Cells[rowIterator, 23].Value != null)
                                    chucvu = workSheet.Cells[rowIterator, 23].Value.ToString();
                                else
                                    chucvu = "";
                                if (workSheet.Cells[rowIterator, 24].Value != null)
                                    phongban = workSheet.Cells[rowIterator, 24].Value.ToString();
                                else
                                    phongban = "";
                                if (workSheet.Cells[rowIterator, 25].Value != null)
                                    ngaysinh = workSheet.Cells[rowIterator, 25].Value.ToString();
                                else
                                    ngaysinh = "";
                                if (workSheet.Cells[rowIterator, 26].Value != null)
                                    gioitinh = workSheet.Cells[rowIterator,26].Value.ToString();
                                else
                                    gioitinh = "";
                                if (workSheet.Cells[rowIterator, 27].Value != null)
                                    sdt1 = workSheet.Cells[rowIterator, 27].Value.ToString();
                                else
                                    sdt1 = "";
                                if (workSheet.Cells[rowIterator,28].Value != null)
                                    sdt2 = workSheet.Cells[rowIterator, 28].Value.ToString();
                                else
                                    sdt2 = "";
                                if (workSheet.Cells[rowIterator, 29].Value != null)
                                    emailcanhan = workSheet.Cells[rowIterator, 29].Value.ToString();
                                else
                                    emailcanhan = "";
                                if (workSheet.Cells[rowIterator, 30].Value != null)
                                    emailcongty = workSheet.Cells[rowIterator, 30].Value.ToString();
                                else
                                    emailcongty = "";
                                if (workSheet.Cells[rowIterator,31].Value != null)
                                    skype = workSheet.Cells[rowIterator, 31].Value.ToString();
                                else
                                    skype = "";
                                if (workSheet.Cells[rowIterator, 32].Value != null)
                                    facebook = workSheet.Cells[rowIterator, 32].Value.ToString();
                                else
                                    facebook = "";
                                if (workSheet.Cells[rowIterator, 33].Value != null)
                                    ghichulienhe = workSheet.Cells[rowIterator, 33].Value.ToString();
                                else
                                    ghichulienhe = "";
                                if (workSheet.Cells[rowIterator, 34].Value != null)
                                    salephutrach = workSheet.Cells[rowIterator, 34].Value.ToString();
                                else
                                    salephutrach = "";
                                if (workSheet.Cells[rowIterator, 35].Value != null)
                                    sotknganhang = workSheet.Cells[rowIterator, 36].Value.ToString();
                                else
                                    sotknganhang = "";

                                if (workSheet.Cells[rowIterator, 36].Value != null)
                                    tentaikhoan = workSheet.Cells[rowIterator, 36].Value.ToString();
                                else
                                    tentaikhoan = "";
                                if (workSheet.Cells[rowIterator, 37].Value != null)
                                    tennganhang = workSheet.Cells[rowIterator, 37].Value.ToString();
                                else
                                    tennganhang = "";
                                if (workSheet.Cells[rowIterator, 38].Value != null)
                                    chinhanhnganhang = workSheet.Cells[rowIterator, 38].Value.ToString();
                                else
                                    chinhanhnganhang = "";
                                if (workSheet.Cells[rowIterator, 39].Value != null)
                                    tinhnganhang = workSheet.Cells[rowIterator, 39].Value.ToString();
                                else
                                    tinhnganhang = "";
                                if (workSheet.Cells[rowIterator, 40].Value != null)
                                    loaitaikhoan = workSheet.Cells[rowIterator, 40].Value.ToString();
                                else
                                    loaitaikhoan = "";
                                if (workSheet.Cells[rowIterator, 41].Value != null)
                                    ghichu = workSheet.Cells[rowIterator, 41].Value.ToString();
                                else
                                    ghichu = "";













                                //Thêm khách hàng

                                var query = db.KHs.Where(x => x.MA_KHACH_HANG == makhach).FirstOrDefault();
                                if (query == null)
                                {
                                    KH khachhang = new KH();
                                    khachhang.MA_KHACH_HANG = makhach;
                                    khachhang.TEN_CONG_TY = tencongty;
                                    if (diachivpgiaodich != "")
                                        khachhang.VAN_PHONG_GIAO_DICH = diachivpgiaodich;
                                    if (diachixuathoadon != "")
                                        khachhang.DIA_CHI_XUAT_HOA_DON = diachixuathoadon;
                                    if (MST != "")
                                        khachhang.MST = MST;
                                    if (somayban != "")
                                        khachhang.HOTLINE = somayban;
                                    if (fax != "")
                                        khachhang.FAX = fax;
                                    if (email != "")
                                        khachhang.EMAIL = email;
                                    if (logo != "")
                                        khachhang.LOGO = logo;
                                    if (website != "")
                                        khachhang.WEBSITE = website;
                                    if (tinh != "")
                                        khachhang.TINH = tinh;
                                    if (quocgia != "")
                                        khachhang.QUOC_GIA = quocgia;
                                    if (dieukhoanthanhtoan != "")
                                        khachhang.DIEU_KHOAN_THANH_TOAN = dieukhoanthanhtoan;
                                    if (songayduocno != "")
                                        khachhang.SO_NGAY_DUOC_NO = Convert.ToInt32(songayduocno);
                                    if (sonotoida != "")
                                        khachhang.SO_NO_TOI_DA = Convert.ToInt32(sonotoida);
                                    if (tinhtranghoatdong != "")
                                        khachhang.TINH_TRANG_HOAT_DONG = tinhtranghoatdong;
                                    if (tructhuoc != "")
                                        khachhang.TRUC_THUOC = tructhuoc;
                                    if (ghichu != "")
                                        khachhang.GHI_CHU = ghichu;

                                    db.KHs.Add(khachhang);
                                    db.SaveChanges();

                                    //thêm phụ trách hiện thời
                                    if(phutrachhienthoi != "")
                                    {
                                        KH_CHUYEN_SALES chuyensale = new KH_CHUYEN_SALES();
                                        chuyensale.MA_KHACH_HANG = makhach;
                                        chuyensale.SALE_HIEN_THOI = phutrachhienthoi;
                                        db.KH_CHUYEN_SALES.Add(chuyensale);

                                    }
                                    //Thêm phân loại khách
                                    var DATA = db.KH_PHAN_LOAI_KHACH.Where(x => x.MA_KHACH_HANG == makhach).FirstOrDefault();
                                    if(DATA !=null && phanloaikhach != "")
                                    {
                                       
                                        KH_PHAN_LOAI_KHACH plkhach = new KH_PHAN_LOAI_KHACH();
                                        plkhach.MA_KHACH_HANG = makhach;
                                        plkhach.MA_LOAI_KHACH = phanloaikhach;
                                        if(nhomnganh != "")
                                            plkhach.NHOM_NGANH = nhomnganh;
                                        db.KH_PHAN_LOAI_KHACH.Add(plkhach);
                                        db.SaveChanges();
                                    }
                                   //thêm người liên hệ
                                    if (nguoilienhe != "")
                                    {
                                        KH_LIEN_HE lhkhach = new KH_LIEN_HE();
                                        lhkhach.MA_KHACH_HANG = makhach;
                                        lhkhach.NGUOI_LIEN_HE = nguoilienhe;
                                        if (chucvu!="")
                                            lhkhach.CHUC_VU = chucvu;
                                        if (phongban != "")
                                            lhkhach.PHONG_BAN = phongban;
                                        if (ngaysinh != "")
                                            lhkhach.NGAY_SINH = xulydate.Xulydatetime(ngaysinh);
                                        if (gioitinh != "")
                                            lhkhach.GIOI_TINH = gioitinh;
                                        lhkhach.SDT1 = sdt1;
                                        if (sdt2 != "")
                                            lhkhach.SDT2 = sdt2;
                                        if (emailcanhan != "")
                                            lhkhach.EMAIL_CA_NHAN = emailcanhan;
                                        if (emailcongty != "")
                                            lhkhach.EMAIL_CONG_TY = emailcongty;
                                        if (skype != "")
                                            lhkhach.SKYPE = skype;
                                        if (facebook != "")
                                            lhkhach.FACEBOOK = facebook;
                                        if (ghichulienhe != "")
                                            lhkhach.GHI_CHU = ghichu;
                                        db.KH_LIEN_HE.Add(lhkhach);
                                        db.SaveChanges();
                                        
                                        //thêm sale phụ trách
                                        var datalienhe = db.KH_LIEN_HE.Where(x => x.SDT1 == sdt1).FirstOrDefault();
                                        if (datalienhe != null)
                                        {
                                            KH_SALES_PHU_TRACH salept = new KH_SALES_PHU_TRACH();
                                            salept.ID_LIEN_HE = datalienhe.ID_LIEN_HE;
                                            salept.SALES_PHU_TRACH = salephutrach;
                                            salept.NGAY_BAT_DAU_PHU_TRACH = DateTime.Today.Date;
                                            salept.TRANG_THAI = true;
                                            db.KH_SALES_PHU_TRACH.Add(salept);
                                            db.SaveChanges();
                                        }


                                        //thêm tài khoản ngân hàng
                                        if (sotknganhang!= "")
                                        {
                                            KH_TK_NGAN_HANG tkkhach = new KH_TK_NGAN_HANG();
                                            tkkhach.MA_KHACH_HANG = makhach;
                                            tkkhach.SO_TAI_KHOAN = sotknganhang;
                                            if (tentaikhoan != "")
                                                tkkhach.TEN_TAI_KHOAN = tentaikhoan;
                                            if (tennganhang != "")
                                                tkkhach.TEN_NGAN_HANG = tennganhang;
                                            if (chinhanhnganhang != "")
                                                tkkhach.CHI_NHANH = chinhanhnganhang;
                                            if (tinhnganhang != "")
                                                tkkhach.TINH_TP = tinhnganhang;

                                            if (loaitaikhoan != "")
                                                tkkhach.LOAI_TAI_KHOAN = loaitaikhoan;
                                            if (ghichutaikhoan != "")
                                                tkkhach.GHI_CHU = ghichutaikhoan;

                                            db.KH_TK_NGAN_HANG.Add(tkkhach);
                                            db.SaveChanges();


                                        }

                                    }
                                   
                                }
                                //trường hợp đã có khách hàng, chỉ thêm liên hệ, ...
                                else
                                if (query != null)
                                {

                                    //thêm liên hệ
                                    if (nguoilienhe != "")
                                    {
                                        KH_LIEN_HE lhkhach = new KH_LIEN_HE();
                                        lhkhach.MA_KHACH_HANG = makhach;
                                        lhkhach.NGUOI_LIEN_HE = nguoilienhe;
                                        if (chucvu != "")
                                            lhkhach.CHUC_VU = chucvu;
                                        if (phongban != "")
                                            lhkhach.PHONG_BAN = phongban;
                                        if (ngaysinh != "")
                                            lhkhach.NGAY_SINH = xulydate.Xulydatetime(ngaysinh);
                                        if (gioitinh != "")
                                            lhkhach.GIOI_TINH = gioitinh;
                                        lhkhach.SDT1 = sdt1;
                                        if (sdt2 != "")
                                            lhkhach.SDT2 = sdt2;
                                        if (emailcanhan != "")
                                            lhkhach.EMAIL_CA_NHAN = emailcanhan;
                                        if (emailcongty != "")
                                            lhkhach.EMAIL_CONG_TY = emailcongty;
                                        if (skype != "")
                                            lhkhach.SKYPE = skype;
                                        if (facebook != "")
                                            lhkhach.FACEBOOK = facebook;
                                        if (ghichu != "")
                                            lhkhach.GHI_CHU = ghichu;
                                        db.KH_LIEN_HE.Add(lhkhach);
                                        db.SaveChanges();

                                        //thêm sale phụ trách
                                        var datalienhe = db.KH_LIEN_HE.Where(x => x.SDT1 == sdt1).FirstOrDefault();
                                        if (datalienhe != null)
                                        {
                                            KH_SALES_PHU_TRACH salept = new KH_SALES_PHU_TRACH();
                                            salept.ID_LIEN_HE = datalienhe.ID_LIEN_HE;
                                            salept.SALES_PHU_TRACH = salephutrach;
                                            salept.NGAY_BAT_DAU_PHU_TRACH = DateTime.Today.Date;
                                            salept.TRANG_THAI = true;
                                            db.KH_SALES_PHU_TRACH.Add(salept);
                                            db.SaveChanges();
                                        }

                                        //thêm tài khoản ngân hàng
                                        if (sotknganhang != "")
                                        {
                                            KH_TK_NGAN_HANG tkkhach = new KH_TK_NGAN_HANG();
                                            tkkhach.MA_KHACH_HANG = makhach;
                                            tkkhach.SO_TAI_KHOAN = sotknganhang;
                                            if (tentaikhoan != "")
                                                tkkhach.TEN_TAI_KHOAN = tentaikhoan;
                                            if (tennganhang != "")
                                                tkkhach.TEN_NGAN_HANG = tennganhang;
                                            if (chinhanhnganhang != "")
                                                tkkhach.CHI_NHANH = chinhanhnganhang;
                                            if (tinhnganhang != "")
                                                tkkhach.TINH_TP = tinhnganhang;

                                            if (loaitaikhoan != "")
                                                tkkhach.LOAI_TAI_KHOAN = loaitaikhoan;
                                            if (ghichutaikhoan != "")
                                                tkkhach.GHI_CHU = ghichutaikhoan;

                                            db.KH_TK_NGAN_HANG.Add(tkkhach);
                                            db.SaveChanges();


                                        }

                                    }

                                }


                                so_dong_thanh_cong++;
                                dong = rowIterator;

                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại các dòng: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }

            return View();
        }

        #endregion

        #region "Tìm Kiếm KHÁCH HÀNG"

        public ActionResult TimKiem_KhachHang()
        {

            return View();
        }

        #endregion

        #region "Upload logo khách hàng"

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Index(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Verify that the user selected a file
                    if (file != null && file.ContentLength > 0)
                    {
                        // extract only the fielname
                        var fileName = Path.GetFileName(file.FileName);
                        // TODO: need to define destination
                        var path = Path.Combine(Server.MapPath("~/Content/Images/KhachHang"), fileName);
                        file.SaveAs(path);
                    }
                }
            }
        }
        #endregion

        #region "Khách hàng chưa phát sinh giao dịch"

        public ActionResult KhachChuaGiaoDich()
        {

            return View();
        }

        #endregion

        #region "Thêm mới khách hàng"

        public ActionResult ThemMoiKhach()
        {

            return View();
        }

        #endregion

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KH kH = db.KHs.Find(id);
            if (kH == null)
            {
                return HttpNotFound();
            }
            return View(kH);
        }

    }
}

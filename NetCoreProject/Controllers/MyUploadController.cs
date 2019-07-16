using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreProject.Controllers
{
    public class MyUploadController : Controller
    {
        private IHostingEnvironment _hosting;
        public MyUploadController(IHostingEnvironment hosting)
        {
            this._hosting = hosting;
        }
        #region 文件上传 表单
        /// <summary>
        /// 表单 文件上传
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFile(List<IFormFile> files)
        {
            long size = 0;

            foreach (var formFile in files)
            {
                var fileName = ContentDispositionHeaderValue
                      .Parse(formFile.ContentDisposition)
                      .FileName
                      .Trim('"');
                fileName = _hosting.WebRootPath + $@"\UploadFiles\{fileName}";
                size += fileName.Length;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    formFile.CopyTo(fs);
                    fs.Flush();
                }
            }
            return Ok(new { message = $"{files.Count}个文件 /{size}字节上传成功!" });

        }
        #endregion

        #region 文件上传 Ajax
        public IActionResult AjaxIndex()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult UploadFileByAjax(List<IFormFile> _files)
        {
            //如果使用Request.Form.Files 参数必须有List<IFormFile> _files 否则不行
            long size = 0;
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                //var fileName = file.FileName;
                var fileName = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                fileName = _hosting.WebRootPath + $@"\UploadFiles\{fileName}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return Ok(new { message = $"{files.Count}个文件 /{size}字节上传成功!" });
        }
        #endregion
    }
}
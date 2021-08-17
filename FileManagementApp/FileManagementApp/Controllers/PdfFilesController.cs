using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileManagementApp.Data;
using FileManagementApp.Models;
using FileManagementApp.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Mail;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using TeleSharp.TL;
using TLSharp;
using TLSharp.Core;
using TeleSharp.TL.Messages;
using System.Text;
using TLSharp.Core.Utils;

namespace FileManagementApp.Controllers
{
    public class PdfFilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PdfFilesController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: PdfFiles
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.PdfFiles.Include(p => p.Group).Include(p => p.Item).Include(p => p.SubGroup);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PdfFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var pdfFile = await _context.PdfFiles
                .Select(book => new PdfFileCreateVM()
                {
                    PdfFileID=book.PdfFileID,
                    PdfFileName=book.PdfFileName,
                    PdfFileUrl=book.PdfFileUrl
                })
            //    .Include(p => p.Group)
            //    .Include(p => p.Item)
            //    .Include(p => p.SubGroup)
                .FirstOrDefaultAsync(m => m.PdfFileID == id);
            if (pdfFile == null)
            {
                return NotFound();
            }

            return View(pdfFile);
        }

        // GET: PdfFiles/Create
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName");
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName");
            ViewData["SubGroupID"] = new SelectList(_context.SubGroups, "SubGroupID", "SubGroupName");
            return View();
        }

        // POST: PdfFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PdfFileCreateVM pdfModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (pdfModel.PdfFileStaticFolder != null)
                    {
                        if (pdfModel.PdfFileStaticFolder != null)
                        {
                            string folder = "MyFiles/";
                            pdfModel.PdfFileUrl = await UploadImage(folder, pdfModel.PdfFileStaticFolder);
                        }

                        string[] Parts = pdfModel.PdfFileUrl.Split('/');
                        string UploadFilename = Parts[Parts.Length - 1];
                        var newBook = new PdfFile()
                        {
                            GroupID = pdfModel.GroupID,
                            SubGroupID = pdfModel.SubGroupID,
                            ItemID = pdfModel.ItemID,
                            PdfFileName = pdfModel.PdfFileName,
                            CreateON = DateTime.UtcNow,
                            UpdateON = DateTime.UtcNow,
                            PdfFileUrl = UploadFilename
                        };
                        await _context.PdfFiles.AddAsync(newBook);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                TempData["msg"] = "Added new file success.....";
                ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName", pdfModel.GroupID);
                ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", pdfModel.ItemID);
                ViewData["SubGroupID"] = new SelectList(_context.SubGroups, "SubGroupID", "SubGroupName", pdfModel.SubGroupID);
                return View(pdfModel);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
        //[HttpGet]
        //public PartialViewResult SendToTelegram(int? id)
        //{
        //    //ViewData["Email"] = new SelectList(_context.UserEmail, "Id", "Emailid");
        //    var pdfFile = _context.PdfFiles
        //        .Select(book => new Email()
        //        {
        //            PdfFileID = book.PdfFileID,
        //            PdfFileName = book.PdfFileName,
        //            PdfFileUrl = book.PdfFileUrl
        //        }).FirstOrDefaultAsync(m => m.PdfFileID == id);
        //    return PartialView("_SendToTelegram", pdfFile);
        //}
        //[HttpPost]
        //public async void authAsync()
        //{

        //    int n = 1;
        //    StringBuilder sb = new StringBuilder();
        //    string str = "";
        //    TelegramClient client = new TelegramClient(7061100, "e25b2d0547c978c0473202bed3fbfa18");
        //    var dialogs = await client.GetUserDialogsAsync();
        //    foreach (var element in dialogs.Chats)
        //    {
        //        TLChat chat = element as TLChat;
        //        if (element is TLChannel)
        //        {
        //            var offset = 0;
        //            TLChannel channel = element as TLChannel;
        //            if (channel.Title == "TOPLES")
        //            {
        //                TLChannel ch = element as TLChannel;
        //                TLInputPeerChannel inputPeer = new TLInputPeerChannel() { ChannelId = ch.Id, AccessHash = (long)ch.AccessHash };
        //                while (n != 11)
        //                {
        //                    try
        //                    {
        //                        TLChannelMessages res = await client.SendRequestAsync<TLChannelMessages>
        //                        (new TLRequestGetHistory() { Peer = inputPeer, Limit = 20, AddOffset = offset, OffsetId = 0 });
        //                        var msgs = res.Messages;
        //                        if (res.Count > offset)
        //                        {
        //                            offset += msgs.Count;
        //                            foreach (TLAbsMessage msg in msgs)
        //                            {
        //                                if (msg is TLMessage)
        //                                {
        //                                    TLMessage message = msg as TLMessage;
        //                                    str += n.ToString() + "\t" + message.Id + "\t" + message.FromId + "\t" + message.Message + Environment.NewLine;
        //                                }
        //                                if (msg is TLMessageService)
        //                                    continue;
        //                                n++;
        //                            }
        //                        }
        //                        else
        //                            break;
        //                    }
        //                    catch (Exception ex)
        //                    {

        //                        break;
        //                    }
        //                }
        //            }
        //        }

        //    }
        //}

        public async Task<IActionResult> SendToTelegram()
        {
            try
            {
                string ContactNo = "+919737920098";
                TelegramClient client = new TelegramClient(7061100, "e25b2d0547c978c0473202bed3fbfa18");
                await client.ConnectAsync();

                string hash = await client.SendCodeRequestAsync("+919737920098");
                //string hash = await client.SendCodeRequestAsync("+919106512023");
                string a = "";
                string code = "63365";
                var user = await client.MakeAuthAsync(ContactNo, hash, code);
                var result =await client.GetContactsAsync();
                var userData = result.Users.ToList().Where(x => x.GetType() == typeof(TLUser)).Cast<TLUser>().Where(x=>x.FirstName=="Naresh");
                if (userData.ToList().Count != 0)
                {
                    foreach (var u in userData)
                    {
                        if (u.Phone.Contains("919975778621"))
                        {
                            //send message
                            var fileResult = (TLInputFile)await client.UploadFile($"C:\\Users\\Admin\\Pictures\\Screenshots\\ab.png", new StreamReader("data/ab.png"));
                            await client.SendMessageAsync(new TLInputPeerUser() { UserId = u.Id }, "Hello this is send message by SmartFile Application");
                        }
                    }
                }
                return Json(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Download(int? id)
        {
            var Data = _context.PdfFiles
                 .Select(book => new PdfFileCreateVM()
                 {
                     PdfFileID = book.PdfFileID,
                     PdfFileName = book.PdfFileName,
                     PdfFileUrl = book.PdfFileUrl
                 })
                 .FirstOrDefault(m => m.PdfFileID == id);
            string filename = Data.PdfFileUrl;

            if (filename == null)
                return Content("filename not present");

            string path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot\\MyFiles", filename);

           
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            TempData["msg"] = "Download File Success";
            return File(bytes, "application/octet-stream", filename);
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            //Using Guid
            //folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            //Using Datetime
            folderPath += DateTime.Now.Date.ToShortDateString()+ "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return folderPath;
        }
        public PartialViewResult GetCamera()
        {
            return PartialView("_GetCamera");
        }
        [HttpPost]
        public void SaveImage(string base64image)
        {
            //System.IO.File.WriteAllText(Server.MapPath("~/Content/Images/" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".txt"), base64image);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pdfFile = await _context.PdfFiles.FindAsync(id);
            if (pdfFile == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName", pdfFile.GroupID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", pdfFile.ItemID);
            ViewData["SubGroupID"] = new SelectList(_context.SubGroups, "SubGroupID", "SubGroupName", pdfFile.SubGroupID);
            PdfFileCreateVM Data = new PdfFileCreateVM();
            Data.GroupID = pdfFile.GroupID;
            Data.ItemID = pdfFile.ItemID;
            Data.PdfFileID = pdfFile.PdfFileID;
            Data.PdfFileName = pdfFile.PdfFileName;
            Data.SubGroupID = pdfFile.SubGroupID;
            Data.UpdateON = pdfFile.UpdateON;
            Data.CreateON = pdfFile.CreateON;
            Data.PdfFileUrl = pdfFile.PdfFileUrl;
            return View(Data);
        }
        public ActionResult SendWhatsap()
        {
            const string accountSid = "AC0278f0d0dae0bf41e80353f2e5d9e6e2";
            const string authToken = "30f7aa3167c3bdd1a2b179d80c4949edf";
            TwilioClient.Init(accountSid, authToken);
            var uriList = new List<Uri>() { new Uri("https://www.google.com/images/nav_logo242.png") }; 
            var message = MessageResource.Create(mediaUrl: uriList, from: new Twilio.Types.PhoneNumber("whatsapp:+14088729717"), body: "Profile", to: new Twilio.Types.PhoneNumber("whatsapp:+919737920098"));
            return RedirectToAction("Index");
        }
        // POST: PdfFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PdfFileCreateVM pdfModel,IFormFile PdfFileStaticFolder)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    if (pdfModel.PdfFileStaticFolder == null)
                    {
                        var newBook = new PdfFile()
                        {
                            GroupID = pdfModel.GroupID,
                            SubGroupID = pdfModel.SubGroupID,
                            ItemID = pdfModel.ItemID,
                            PdfFileName = pdfModel.PdfFileName,
                            CreateON = DateTime.UtcNow,
                            UpdateON = DateTime.UtcNow,
                            PdfFileUrl = pdfModel.PdfFileUrl
                        };
                        _context.Update(newBook);

                        await _context.SaveChangesAsync();
                    }
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PdfFileExists(pdfModel.PdfFileID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["msg"] = "Edit file success.....";
            ViewData["GroupID"] = new SelectList(_context.Groups, "GroupID", "GroupName", pdfModel.GroupID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", pdfModel.ItemID);
            ViewData["SubGroupID"] = new SelectList(_context.SubGroups, "SubGroupID", "SubGroupName", pdfModel.SubGroupID);
            return View(pdfModel);
        }

        // GET: PdfFiles/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pdfFile = await _context.PdfFiles
        //        .Include(p => p.Group)
        //        .Include(p => p.Item)
        //        .Include(p => p.SubGroup)
        //        .FirstOrDefaultAsync(m => m.PdfFileID == id);
        //    if (pdfFile == null)
        //    {
        //        return NotFound();
        //    }
        //    TempData["msg"] = "Edit file success.....";
        //    return View(pdfFile);
        //}
        //// POST: PdfFiles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var pdfFile = await _context.PdfFiles.FindAsync(id);
            _context.PdfFiles.Remove(pdfFile);
            await _context.SaveChangesAsync();
            TempData["msg"] = "Delete file success.....";
            return RedirectToAction(nameof(Index));
        }

        private bool PdfFileExists(int id)
        {
            return _context.PdfFiles.Any(e => e.PdfFileID == id);
        }

        [HttpGet]
        public async Task<IActionResult> SendPdfEmail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["Email"] = new SelectList(_context.UserEmail, "Id", "Emailid");
            var pdfFile = await _context.PdfFiles
                .Select(book => new Email()
                {
                    PdfFileID =   book.PdfFileID,
                    PdfFileName = book.PdfFileName,
                    PdfFileUrl =  book.PdfFileUrl
                }).FirstOrDefaultAsync(m => m.PdfFileID == id);
            if (pdfFile == null)
            {
                return NotFound();
            }

            return View(pdfFile);
        }

        [HttpPost]
        public IActionResult SendPdfEmail(Email em)
        {
            try
            {
                string[] email = new string[em.To.Length];
                int cntr = 0;
                foreach (var item in em.To)
                {
                    var data = _context.UserEmail.FirstOrDefault(m => m.Id == Convert.ToInt32(item));
                    email[cntr] = data.Emailid;
                    cntr += 1;
                }
                for (int i = 0; i < em.To.Length; i++)
                {
                    string to = email[i];
                    string subject = em.Subject;
                    string body = em.Body;
                    string file = "wwwroot/MyFiles/" + em.PdfFileUrl;
                    MailMessage mm = new MailMessage();
                    
                    mm.To.Add(to);
                    mm.Subject = subject;
                    mm.Body = body;
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(file);
                    mm.Attachments.Add(attachment);
                    mm.From = new MailAddress("smartfilenb@gmail.com");
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("smartfilenb@gmail.com", "Gurudev@654");
                    smtp.EnableSsl = true;
                    smtp.Send(mm);
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                    SentEmailList sentEmail = new SentEmailList();
                    bool IsAvailable = _context.SentEmailList.Any(x => x.Emailid == to && x.Filename == em.PdfFileUrl);
                    if (!IsAvailable)
                    {
                        sentEmail.Body = body;
                        sentEmail.Emailid = to;
                        sentEmail.Filename = em.PdfFileUrl;
                        sentEmail.SentDateTime = DateTime.Now;
                        sentEmail.Subject = subject;
                        _context.SentEmailList.Add(sentEmail);
                        _context.SaveChanges();
                    }
                }
                TempData["msg"] = "The Mail Send Successfully.....";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Error to sending file";
                return RedirectToAction("Index");
            }
          
        }
        public IActionResult GetOldEmail()
        {
            return View(_context.SentEmailList.ToList());
        }
        public IActionResult SendAgain(int? id)
        {
            SentEmailList sm = _context.SentEmailList.Where(x => x.Id == id).FirstOrDefault();
            string file = "wwwroot/MyFiles/" + sm.Filename;
            MailMessage mm = new MailMessage();
            mm.To.Add(sm.Emailid);
            mm.Subject = sm.Subject;
            mm.Body = sm.Body;
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(file);
            mm.Attachments.Add(attachment);
            mm.From = new MailAddress("smartfilenb@gmail.com");
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("smartfilenb@gmail.com", "Gurudev@654");
            smtp.EnableSsl = true;
            smtp.Send(mm);
            TempData["msg"] = "Mail Re-Send Success On : " + sm.Emailid;
            return RedirectToAction("Index");
        }
       

    }
}

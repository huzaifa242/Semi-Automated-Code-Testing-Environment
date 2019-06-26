using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SupportedLanguage;
using System.IO;
using Client.CodeCoordinationService;
using System.Web.UI.HtmlControls;
using System.Threading.Tasks;

namespace Client
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ButtonClick(object sender,EventArgs e)
        {
            
            var fni = fileupload2.PostedFile;
            var filename1 = System.IO.Path.GetFileName(fileupload2.FileName);
            fni.SaveAs("F:\\codefolder\\"+filename1);
            var filename2 = System.IO.Path.GetFileName(fileupload3.FileName);
            var fnt = fileupload3.PostedFile;
            fnt.SaveAs("F:\\codefolder\\" + filename2);
            foreach (HttpPostedFile uploadedFile in fileupload1.PostedFiles)
            {
                string fno = System.IO.Path.GetFileName(uploadedFile.FileName);
                string SaveLocation = @"F:\codefolder\" + fno;
                try
                {
                    CodeCoordinationService.CoordinationClient cordi = new CoordinationClient();
                    cordi.Endpoint.Binding.SendTimeout = new TimeSpan(0,6,0);
                    uploadedFile.SaveAs(SaveLocation);
                    cordi.setcodep(filename1);
                    cordi.settest(filename2);
                    cordi.setcodes(fno);
                    cordi.setcodepl(language.cpp);
                    cordi.setcodesl(language.cpp);
                    cordi.settestl(language.cpp);
                    cordi.setopp(filename1 + "opp");
                    cordi.setops(fno + "ops");
                    Task t = Task.Run(() => { cordi.execute(); });
                    t.Wait();
                    string line1 = File.ReadAllText(@"F:\codefolder\"+ fno + "opsresult");
                    HtmlGenericControl newLi = new HtmlGenericControl("li");
                    newLi.InnerText = line1;
                    list1.Controls.Add(newLi);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
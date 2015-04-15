using System;
using Entity;
using System.IO;
public partial class Code_Sample_Image : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Response.Buffer = true;
        Response.ContentType = "image/gif";
        System.Data.SqlTypes.SqlBinary bmpBytes = Employee.GetEmployeeByEmployeeId(Int32.Parse(Request["ImageBinary"],System.Globalization.CultureInfo.CurrentCulture.NumberFormat)).Photo;

        if ((!bmpBytes.IsNull))
        {
            byte[] bytearray = (byte[])bmpBytes;
            Response.BinaryWrite(bytearray);
        }
        else
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/image/noimage.gif"));
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.BinaryWrite(ms.ToArray());
        }
    }  
}

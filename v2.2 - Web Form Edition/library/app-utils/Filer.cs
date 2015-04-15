namespace Utilities
{
    using System;
    using System.IO;
    using System.Web;
    using System.Web.UI.HtmlControls;
    /// <summary>
	/// Contains necessary utility methods to facilitate working on file and file paths.
	/// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
	public sealed class Filer
	{
        private Filer() { }

		#region File access related
		
		/// <summary>
		/// Writes the text in a file, named "temp.txt", located into the current directory of the caller web http context.
		/// If the file doesn't exist, the file will be created and the text will be written then.
		/// If the file is already exists, the text will be appended to that file.
		/// </summary>
		/// <param name="text">The text to be written.</param>
		public static void WriteToFile ( string text )
		{
			string path = System.Web.HttpContext.Current.Server.MapPath("temp.txt");
			WriteToFile( path, text);
		}
		
		/// <summary>
		/// Writes the text in the provided file path [ Path + File Name ] located into the current directory.
		/// If the file doesn't exist, the file will be created and the text will be written then.
		/// If the file is already exists, the text will be appended to that file.
		/// </summary>
		/// <param name="strPath">A relative or absolute path for the file that the current method will work.</param>
		/// <param name="text">The text to be written.</param>
		public static void WriteToFile ( string path, string text )
		{
			FileStream fStream = new FileStream(path, FileMode.Append, FileAccess.Write);
			BufferedStream bfs = new BufferedStream(fStream);			
			StreamWriter sWriter = new StreamWriter(bfs);
			sWriter.WriteLine(text);
			sWriter.Close();
		}

        /// <summary>
        /// Writes file to the specified path.
        /// </summary>
        /// <param name="strPath">The physical path of the caller machine, where the file will be saved.
        /// This path includes the file name as well as.
        /// </param>
        /// <param name="buffer">The buffer that contains the file stream.</param>
        public static void WriteToFile(string path, byte[] buffer)
        {
            // Create a file
            FileStream newFile = new FileStream(path, FileMode.Create);

            // Write data to the file
            newFile.Write(buffer, 0, buffer.Length);

            // Close file
            newFile.Close();
        }

		#endregion
		
		#region File path related

		/// <summary>
		/// Adds a character in the end of a string if such character hasn't 
		/// already presented.
		/// </summary>
        /// <param name="text">Text to be formatted</param>
		/// <returns>Formatted string</returns>
		public static string AddBackslashInTheEndIfNotPresent(string text)
		{
			return AddCharInTheEndIfNotPresent(@"\", text);
		}

		/// <summary>
		/// Adds the char in the end if not present.
		/// </summary>
        /// <param name="character">Character to be added</param>
        /// <param name="text">The text to be formatted</param>
		/// <returns>The formatted text</returns>
		public static string AddCharInTheEndIfNotPresent(string character, string text)
		{
			if (text.LastIndexOf(character, StringComparison.CurrentCulture) != (text.Length - 1))
			{
				text = text + character.ToString();
			}
			return text;
		}

		/// <summary>
		/// Adds the slash in the end if not present.
		/// </summary>
        /// <param name="text">the text to be formatted</param>
		/// <returns>The formatted text</returns>
		public static string AddSlashInTheEndIfNotPresent(string text)
		{
			return AddCharInTheEndIfNotPresent("/", text);
		}

		/// <summary>
		/// Formats the size of the file.
		/// </summary>
		/// <param name="FileSize">Size of the file.</param>
		/// <returns>The formateed size as string</returns>
		public static string FormatFileSize(long fileSize)
		{
			int num1 = Convert.ToInt32((double) (((double) fileSize) / 1024));
			if (num1 == 0)
			{
				return ("1 KB");
			}
			return (string.Format(System.Globalization.CultureInfo.CurrentCulture,"{0:###,###,###}", num1) + " KB" );
		}

		/// <summary>
		/// This function works for /main/db/test/ as well as /main/db/test.aspx
		/// </summary>
		/// <param name="RelativePath">The relative path</param>
		/// <returns>Formatted path</returns>
		public static string GetParentDirectory(string relativePath)
		{
			
			if (string.Compare(relativePath, string.Empty, false, System.Globalization.CultureInfo.CurrentCulture) == 0) //can't go higher than root
			{
				return string.Empty;
			}
			else
			{	
				//Remove trailing "/" at end of path
				if (relativePath.LastIndexOf("/", StringComparison.CurrentCulture) == (relativePath.Length - 1))
				{
					relativePath = relativePath.Remove(relativePath.LastIndexOf("/", StringComparison.CurrentCulture), relativePath.Length - relativePath.LastIndexOf("/",StringComparison.CurrentCulture));
				}

                try
                {
                    //Remove the characters after the last occurence of / in the string. => parent directory
                    relativePath = relativePath.Remove(relativePath.LastIndexOf("/", StringComparison.CurrentCulture), relativePath.Length - relativePath.LastIndexOf("/", StringComparison.CurrentCulture));
                    return relativePath;
                }
                catch (IOException ioe)
                {
                    return ioe.Message;
                }
                catch
                {
                    throw;
                }
                finally
                {

                }
			}
			
		}
		
		#endregion

		#region File upload related
		/// <summary>
		/// Uploads a file to the server to the location of the folder of currently requested aspx file.
		/// </summary>
		/// <param name="inpFile">The HtmlInputFile object that contains the client file to be uploaded to the server.</param>
		/// <returns>The uploaded file size. If the size is zero then it can be assumed that the file upload was failed.</returns>
		public static int FileAttach( HtmlInputFile inputFile)
		{
			return FileAttach(System.Web.HttpContext.Current.Request.PhysicalApplicationPath, inputFile, string.Empty);
		}
		
		/// <summary>
		/// Uploads a file to the server.
		/// </summary>
		/// <param name="AttachmentDirectory">The full physical path of the server, where the file should be saved.</param>
		/// <param name="inpFile">The HtmlInputFile object that contains the client file to be uploaded to the server.</param>
		/// <returns>The uploaded file size. If the size is zero then it can be assumed that the file upload was failed.</returns>
		public static int FileAttach( string attachmentDirectory, HtmlInputFile inputFile)
		{
			return FileAttach(attachmentDirectory, inputFile, string.Empty);
		}
		
		/// <summary>
		/// Uploads a file to the server.
		/// </summary>
		/// <param name="AttachmentDirectory">The full physical path of the server, where the file should be saved.</param>
		/// <param name="inpFile">The HtmlInputFile object that contains the client file to be uploaded to the server.</param>
		/// <param name="FileNamePrefix">To avoid the replacement of an existing file with the newly uploaded file, the user can provide own text that will be used as the file name prefix. This is just added  prior to the file name while saving the file into the server.</param>
		/// <returns>The uploaded file size. If the size is zero then it can be assumed that the file upload was failed.</returns>
		public static int FileAttach( string attachmentDirectory, HtmlInputFile inputFile, string fileNamePrefix)
		{
			// Check to see if file was uploaded
			if (inputFile.PostedFile != null)
			{
				// Get a reference to PostedFile object
				HttpPostedFile myFile = inputFile.PostedFile;
				
				// Get size of uploaded file
				int nFileLen = myFile.ContentLength; 
				
				// make sure the size of the file is > 0
				if( nFileLen > 0 )
				{
					// Allocate a buffer for reading of the file
					byte[] myData = new byte[nFileLen];

					// Read uploaded file from the Stream
					myFile.InputStream.Read(myData, 0, nFileLen);

					// Create a name for the file to store
					string strFilename = Path.GetFileName(myFile.FileName);
					strFilename = fileNamePrefix + strFilename;
					
					string ServerUploadFullFilePath = attachmentDirectory + strFilename;
					
					//Write data into a file
                    try
                    {
                        WriteToFile(ServerUploadFullFilePath, myData);
                        return nFileLen;
                    }
                    catch
                    {
                        throw;
                    }
					
				}
			}
			
			return 0;
		}

		#endregion

		#region File download related

		/// <summary>
		/// Using Response.WriteFile method this method can download simple files [ which are not too large ]
		/// </summary>
		/// <param name="filepath">The full file path [Path + File Name].</param>
		/// Added: 07-04-2006
		public static void SimpleDownload(string filePath)
		{
			// Identify the file to download including its path.
			//string filepath = DownloadFileName;

			// Identify the file name.
			string filename = System.IO.Path.GetFileName(filePath);

			System.Web.HttpContext.Current.Response.Clear();

			// Specify the Type of the downloadable file.
			System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";

			// Set the Default file name in the FileDownload dialog box.
			System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);

			System.Web.HttpContext.Current.Response.Flush();

			// Download the file.
			System.Web.HttpContext.Current.Response.WriteFile(filePath);
		}
		
		/// <summary>
		/// This method is able to download large scale files programmaticlly from web server.
		/// </summary>
		/// <param name="filepath"></param>
		/// Added: 07-04-2006
		public static void OptDownloadFile(string filePath)
		{
		
			System.IO.Stream iStream = null;

			// Buffer to read 10K bytes in chunk:
			byte[] buffer = new Byte[10000];

			// Length of the file:
			int length;

			// Total bytes to read:
			long dataToRead;

			// Identify the file to download including its path.
			//string filepath  = "DownloadFileName";

			// Identify the file name.
			string  filename  = System.IO.Path.GetFileName(filePath);

            try
            {
                // Open the file.
                iStream = new System.IO.FileStream(filePath, System.IO.FileMode.Open,
                    System.IO.FileAccess.Read, System.IO.FileShare.Read);


                // Total bytes to read:
                dataToRead = iStream.Length;

                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);

                // Read the bytes.
                while (dataToRead > 0)
                {
                    // Verify that the client is connected.
                    if (System.Web.HttpContext.Current.Response.IsClientConnected)
                    {
                        // Read the data in buffer.
                        length = iStream.Read(buffer, 0, 10000);

                        // Write the data to the current output stream.
                        System.Web.HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);

                        // Flush the data to the HTML output.
                        System.Web.HttpContext.Current.Response.Flush();

                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        //prevent infinite loop if user disconnects
                        dataToRead = -1;
                    }
                }
            }
            catch
            {
                // Trap the error, if any.
                throw;
            }
			finally
			{
				if (iStream != null)
				{
					//Close the file.
					iStream.Close();
				}
			}

		}
		
		#endregion
		
	}
}

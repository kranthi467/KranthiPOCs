<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="WebAPIFileUploadDownload.Start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div><label for="fileUpload">Select File to Upload: </label>
         <input id="fileUpload" type="file" />
    <input id="btnUploadFile" type="button" value="Upload File" /></div>
        </div>
    </div>
    </form>
        <script type="text/javascript">
$(document).ready(function () {

    $('#btnUploadFile').on('click', function () {

      var data = new FormData();

      var files = $("#fileUpload").get(0).files;

      // Add the uploaded image content to the form data collection
      if (files.length > 0) {
           data.append("UploadedImage", files[0]);
      }

      // Make Ajax request with the contentType = false, and procesDate = false
      var ajaxRequest = $.ajax({
           type: "POST",
           url: "/api/image",
           contentType: false,
           processData: false,
           data: data
           });

      ajaxRequest.done(function (xhr, textStatus) {
                    // Do other operation
             });
   });
});
</script>
</body>
</html>

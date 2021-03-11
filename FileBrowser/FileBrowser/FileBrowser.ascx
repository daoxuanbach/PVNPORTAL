<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileBrowser.ascx.cs" Inherits="FileBrowser.FileBrowser.FileBrowser" %>


<%@ Register Assembly="IZ.WebFileManager" Namespace="IZ.WebFileManager" TagPrefix="iz" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>File Browser</title>
    
</head>
<body>
    <form id="form1" runat="server">
        <input id="HF_FileBrowserConfig" type="hidden" runat="server" 
            data-filesfolder="files" 
            data-readonly-hidecommands="true"
         />
        <input id="HF_CustomRoots" type="hidden" runat="server" 
            data-usecustomroots="false"
            data-usedefaultroots="true" 
            data-roots-names="Pippo,Pluto,Paperino" 
            data-roots-smallimages="file-video.png,file-word.png,file-zip-alt.png" 
            data-roots-largeimages="file-video.png,file-word.png,file-zip-alt.png"
            data-roots-folders="" 
            data-roots-imagefolder="/FileBrowser/img/32"
         />
        <div>
            <iz:FileManager ID="FileManager1" runat="server" Height="480" Width="1200" ImagesFolder="~/FileBrowser/img/cmd"
                MainDirectory="~/DataStore" CustomThumbnailHandler="~/FileBrowser/IZWebFileManagerThumbnailHandler.ashx"
                ShowHiddenFilesAndFolders="false" FileViewMode="Details" DefaultAccessMode="Default" DownloadOnDoubleClick="true"> 
                <FileTypes>
                    <iz:FileType Extensions=".jpg, .jpeg,.pmg, .gif" SmallImageUrl="img/16/file-picture.png"
                        LargeImageUrl="img/32/file-picture.png">
                    </iz:FileType>
                    <iz:FileType Extensions=".xls,.xlsx,.ods" SmallImageUrl="img/16/file-excel-alt.png"
                        LargeImageUrl="img/32/file-excel-alt.png">
                    </iz:FileType>
                    <iz:FileType Extensions=".pdf" SmallImageUrl="img/16/file-pdf-alt.png" LargeImageUrl="img/32/file-pdf-alt.png">
                    </iz:FileType>
                    <iz:FileType Extensions=".psd" SmallImageUrl="img/16/file-photoshop.png" LargeImageUrl="img/32/file-photoshop.png">
                    </iz:FileType>
                    <iz:FileType Extensions=".ppt,.pptx,.pptm, .odp" SmallImageUrl="img/16/file-powerpoint-alt.png"
                        LargeImageUrl="img/32/file-powerpoint-alt.png">
                    </iz:FileType>
                    <iz:FileType Extensions=".aiff,.mp3,.ogg,.oga,.wav,.wma" SmallImageUrl="img/16/file-sound.png"
                        LargeImageUrl="img/32/file-sound.png">
                    </iz:FileType>
                    <iz:FileType Extensions=".txt" SmallImageUrl="img/16/file-text.png" LargeImageUrl="img/32/file-text.png">
                    </iz:FileType>
                    <iz:FileType Extensions=".flv,.f4v,.avi,.mov,.qt,.wmv,.mp4,.mpg,.mpeg,.mp2" SmallImageUrl="img/16/file-video.png"
                        LargeImageUrl="img/32/file-video.png">
                    </iz:FileType>
                    <iz:FileType Extensions=".doc,.docx,.odt" SmallImageUrl="img/16/file-word-alt.png"
                        LargeImageUrl="img/32/file-word.png">
                    </iz:FileType>
                    <iz:FileType Extensions=".tar.gz, .7z, .ace, .cab, .rar, .zip, .zipx" SmallImageUrl="img/16/file-zip-alt.png"
                        LargeImageUrl="img/32/file-zip-alt.png">
                    </iz:FileType>
                </FileTypes>
            </iz:FileManager>
              <small id="DND_message" runat="server"></small>
        </div>
    </form>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script>
         var $filemanager, $fileview, $foldertree;  
        // Resizing File Manager
       $(function () {
           $filemanager = $('#FileBrowser_Filemanager1');
            $fileview = $('#FileBrowser_FileManager1_FileView');
            $foldertree = $('#FileBrowser_FileManager1_FolderTree');
            $foldertree.width(150);
            $(window).on('resize load', function (e) {
                var $this = $(this);
                var w = $this.width();
                var h = $this.height();
                var $toolbar = $('#FileBrowser_FileManager1_ToolBar');
                var $paneUpload = $('#Panel_upload');
                var barsHeight = ($toolbar.length ? $toolbar.height() + 55 : 5) ;    
                $filemanager.width(w - 100);
                $fileview.width(w - $foldertree.width() - 100).height(h - barsHeight);
                $foldertree.height(h - barsHeight);
            })
        })
    </script>
</body>
</html>

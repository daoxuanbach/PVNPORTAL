var preloadImg = "/dist/img/preload.gif";
var pathfolderUser = "";
function LoadImages(id, str) {
    document.getElementById(id).src = "/IntraUserControls/GetImage.ashx?File=" + str;
    //alert("GetImage.ashx?File="+str + id);
}
function postData(page, urlPost) {
    PreLoad('data-content');
    $.ajax({
        url: urlPost,
        type: 'post',
        data: { "p": page },
        success: function (data, textStatus, jQxhr) {
            $("#data-content").html(data);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
    return false;
}
function submitData(urlPostAction, form) {
    $.ajax({
        url: urlPostAction,
        type: 'post',
        data: form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(),
        success: function (data, textStatus, jQxhr) {
            if (data.Error) {
                createMessagewarning("Thongbao", data.Message);
            }
            else {
                removeOverlay();
                displayOverlay(data.Message);
                getPage("/UserControls/EBL_Sach/viewSach.aspx?action=view");
                return false;
            }
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
    return false;// Will stop the submission of the form
}
function getPage(urlPost) {
    PreLoad('data-content');
    //$("#data-content").html("");
    $.ajax({
        url: urlPost,
        type: 'post',
        data: $(this).serialize(),
        success: function (data, textStatus, jQxhr) {
            $("#data-content").html(data);
            return false;
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
            location.reload();
        }
    });
    return false;
}

function GetListIDChecked() {
    var arrID = '';
    $(".table input[type='checkbox']:checked").not("#chkCheckAll").each(function () {
        arrID += $(this).val() + ",";
    });
    arrID = (arrID.length > 0) ? arrID.substring(0, arrID.length - 1) : arrID;
    return arrID;
}



function GetListUpdateValue() {
    var ListUpdate = new Array();

    $("#table-updatevalue tr").each(function () {
        var myObj = new Object();
        myObj.UserID = $(this).find('.actions').attr('itemid');
        if (myObj.UserID > 0) {
            myObj.RolePermission = $(this).find('.actions').find('.select2').val();
            ListUpdate.push(myObj);
        }

    });
    return ListUpdate;
}



function PreLoad(dynData) {
    $("#" + dynData).html("<center><img src='" + preloadImg + "' alt='Vui lòng chờ trong giây lát' title='Vui lòng chờ trong giây lát'/></center>");
}
function createMessagewarning(dynData, htmltext) {
    $("#" + dynData).html(" <div class='alert alert-warning alert-dismissable'> <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button><i class='icon fa fa-check'></i>" + htmltext + "</div>");
}
function createMessagesuccess(dynData, htmltext) {
    $("." + dynData).html("<center><img src='" + preloadImg + "' alt='" + htmltext + "' title='" + htmltext + "'/></center>");
}
function displayOverlay(text) {
    $("<div id='overlay'><tbody><tr><td>" + text + "</td></tr></tbody></div>").css({
        "position": "fixed",
        "top": "0px",
        "left": "0px",
        "width": "100%",
        "height": "100%",
        "background-color": "rgba(0,0,0,.5)",
        "z-index": "10000",
        "vertical-align": "middle",
        "text-align": "center",
        "color": "#fff",
        "font-size": "20px",
        "font-weight": "bold",
        "cursor": "wait"
    }).appendTo("body");

    setTimeout(function () {
        removeOverlay();
    }, 1000);
}
function OverlayLoadFile(text) {
    $("<div id='overlay'><tbody><tr><td>" + text + "</td></tr></tbody></div>").css({
        "position": "fixed",
        "top": "0px",
        "left": "0px",
        "width": "100%",
        "height": "100%",
        "background-color": "rgba(0,0,0,.5)",
        "z-index": "10000",
        "vertical-align": "middle",
        "text-align": "center",
        "color": "#fff",
        "font-size": "20px",
        "font-weight": "bold",
        "cursor": "wait"
    }).appendTo("body");
}
function removeOverlay() {
    $("#overlay").remove();
}

function BootstrapDialogalert(message) {
    BootstrapDialog.alert({
        title: 'Thông báo!',
        message: message,
        type: BootstrapDialog.TYPE_WARNING, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        closable: true, // <-- Default value is false
        draggable: true, // <-- Default value is false
        buttonLabel: 'Đóng lại', // <-- Default value is 'OK',
    });
}

function createMessage(title, message) {
    BootstrapDialog.alert({
        title: title,
        message: message,
        type: BootstrapDialog.TYPE_WARNING, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        closable: true, // <-- Default value is false
        draggable: true, // <-- Default value is false
        buttonLabel: 'Đóng lại', // <-- Default value is 'OK',
    });
}
function BootstrapDialogconfirm(dataid) {
    BootstrapDialog.confirm({
        title: 'Thông báo',
        message: 'Bạn có chắc chắn muốn xoá dữ liệu này?',
        type: BootstrapDialog.TYPE_WARNING, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        closable: true, // <-- Default value is false
        draggable: true, // <-- Default value is false
        btnCancelLabel: 'Không', // <-- Default value is 'Cancel',
        btnOKLabel: 'Có', // <-- Default value is 'OK',
        btnOKClass: 'btn-warning', // <-- If you didn't specify it, dialog type will be used,
        callback: function (result) {
            if (result) {
                fndelete(dataid);
            } else {

            }
        }
    });
}

function ConfirmCallBack(item, TrangThai, messages, lock) {
    BootstrapDialog.confirm({
        title: 'Thông báo',
        message: messages,
        type: BootstrapDialog.TYPE_WARNING, // <-- Default value is BootstrapDialog.TYPE_PRIMARY
        closable: true, // <-- Default value is false
        draggable: true, // <-- Default value is false
        btnCancelLabel: 'Không', // <-- Default value is 'Cancel',
        btnOKLabel: 'Đồng ý', // <-- Default value is 'OK',
        btnOKClass: 'btn-warning', // <-- If you didn't specify it, dialog type will be used,
        callback: function (result) {
            if (result) {
                fnCalBack(item, TrangThai, lock);
            } else {

            }
        }
    });
}
function fnCalBack(item, TrangThai, lock) {
}
function BootstrapDialogModalBody(title, divHtml) {
    BootstrapDialog.show({
        title: title,
        cssClass: 'form-dialog',
        message: function (dialogRef) {
            dialogRef.getModalBody().html(divHtml);
        }
    });
}

/*//////////////
    Hàm upload file
    Param: btnupload: id button upload
    Name        Date        Comment
    Tuandt      15/10/2013  Tạo mới
*/
function createUploadFile(btnupload) {
    var uploader = new qq.FileUploader({
        element: document.getElementById(btnupload),
        action: '/UserControls/Common/ActionUpload/UploadFile.aspx',
        sizeLimit: 1073741824,
        debug: true,
        template: '<div class="qq-uploader">' +
        '<div class="qq-upload-drop-area"><span>Xóa tập đính kèm</span></div>' +
        '<div class="qq-upload-button">Tập đính kèm</div>' +
        '<ul class="qq-upload-list"></ul>' +
        '</div>',
        onSubmit: function (id, fileName) {
            OverlayLoadFile("Đang tải File");
            // check trùng file
            var exits = false;
            //check trong trường hợp mới upload
            $("#listFileAttach li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            //check trên file đã upload
            $("#listFileAttachRemove li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });

            if (exits) {
                removeOverlay();
                createMessage("Thông báo", fileName + " Đã tồn tại.");
                return false;
            }
        },
        messages: {
            sizeError: "File ({file}) quá lớn. File upload có độ lớn không quá"
        },
        onComplete: function (id, fileName, responseJson) {
            removeOverlay();
            if (responseJson.upload) {
                $("#listFileAttach").append(getHTMLDeleteLink(responseJson));
                $("#listValueFileAttach").val(changeHiddenInput());

            } else {
                createMessage("Thông báo", responseJson.message);
            }
        }
    });
}
function createMultiUploadFile(btnupload, Name, stt) {
    var uploader = new qq.FileUploader({
        element: document.getElementById(btnupload),
        action: '/UserControls/Common/ActionUpload/UploadFile.aspx?fdUser=' + pathfolderUser,
        sizeLimit: 1073741824,
        debug: true,
        template: '<div class="qq-uploader">' +
        '<div class="qq-upload-drop-area"><span>Xóa ' + name + ' </span></div>' +
        '<div class="qq-upload-button"> Chọn ' + Name + '</div>' +
        '<ul class="qq-upload-list"></ul>' +
        '</div>',
        onSubmit: function (id, fileName) {
            OverlayLoadFile("Đang tải File");
            // check trùng file
            var exits = false;
            //check trong trường hợp mới upload
            $("#listFileAttach" + stt + " li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });
            //check trên file đã upload
            $("#listFileAttachRemove" + stt + " li").each(function (index, item) {
                if (fileName == $(this).children("span").attr("title"))
                    exits = true;
            });

            if (exits) {
                removeOverlay();
                createMessage("Thông báo", fileName + " Đã tồn tại.");
                return false;
            }
        },
        messages: {
            sizeError: "File ({file}) quá lớn. File upload có độ lớn không quá"
        },
        onComplete: function (id, fileName, responseJson) {
            removeOverlay();
            if (responseJson.upload) {
                $("#listFileAttach" + stt).append(getHTMLDeleteLinkId(responseJson, stt));
                $("#listValueFileAttach" + stt).val(changeHiddenInputId(stt));

            } else {
                createMessage("Thông báo", responseJson.message);
            }
        }
    });
}
function getHTMLDeleteLinkId(data, stt) {
    return "<li><span id=\"" + data.fileserver + "\" title=\"" + data.filename + "\">" + data.filename + "</span><a href=\"javascript:DeleteFileId('" + data.fileserver + "'," + stt + ");\"><img src=\"/UserControls/images/act_filedelete.png\" title=\"Xóa file đính kèm\" border=\"0\"></a></li>";
};

function getHTMLDeleteLink(data) {
    return "<li><span id=\"" + data.fileserver + "\" title=\"" + data.filename + "\">" + data.filename + "</span><a href=\"javascript:DeleteFile('" + data.fileserver + "');\"><img src=\"/UserControls/images/act_filedelete.png\" title=\"Xóa file đính kèm\" border=\"0\"></a></li>";
};

function changeHiddenInput() {
    var valueFile = '[';
    var total = $("#listFileAttach li").length;
    $("#listFileAttach li").each(function (i) {
        valueFile += '{"FileServer": "' + $(this).children("span").attr("id") + '"\,';
        valueFile += '"FileName": "' + $(this).children("span").attr("title") + '"\}';
        if (i + 1 < total)
            valueFile += ',';
    });
    valueFile += "]";
    return valueFile;
};
function changeHiddenInputId(stt) {
    var valueFile = '[';
    var total = $("#listFileAttach" + stt + " li").length;
    $("#listFileAttach" + stt + " li").each(function (i) {
        valueFile += '{"FileServer": "' + $(this).children("span").attr("id") + '"\,';
        valueFile += '"FileName": "' + $(this).children("span").attr("title") + '"\}';
        if (i + 1 < total)
            valueFile += ',';
    });
    valueFile += "]";
    return valueFile;
};
function DeleteFile(file) {
    $.post('/UserControls/Common/ActionUpload/DeleteFile.aspx?fdUser=' + pathfolderUser, { del: file });
    $("#listFileAttach span[id*='" + file + "']").parent().remove();
    $("#listValueFileAttach").val(changeHiddenInput());
};
function DeleteFileId(file, stt) {
    $.post('/UserControls/Common/ActionUpload/DeleteFile.aspx', { del: file });
    $("#listFileAttach" + stt + " span[id*='" + file + "']").parent().remove();
    $("#listValueFileAttach" + stt).val(changeHiddenInputId(stt));
};
function DeleteFileUpdate(file) {
    var linkDelete = $("#listValueFileAttachRemove").val();
    $.post('/UserControls/Common/ActionUpload/DeleteFile.aspx?fdUser=' + pathfolderUser, { del: file });
    $("#listValueFileAttachRemove").val(linkDelete + file + "#");
    $("#listFileAttachRemove span[id*='" + file + "']").parent().remove();
};

function createUploadAnhDaiDien(btnupload, Name) {

    var uploader = new qq.FileUploader({
        element: document.getElementById(btnupload),
        action: '/UserControls/Common/ActionUpload/UploadFile.aspx',
        sizeLimit: 1073741824,
        debug: true,
        template: '<div class="qq-uploader">' +
        '<div class="qq-upload-drop-area"><span>Xóa ' + name + ' </span></div>' +
        '<div class="qq-upload-button"> Chọn ' + Name + '</div>' +
        '<ul class="qq-upload-list"></ul>' +
        '</div>',
        onSubmit: function (id, fileName) {
            OverlayLoadFile("Đang tải File");
        },
        messages: {
            sizeError: "File ({file}) quá lớn. File upload có độ lớn không quá"
        },
        onComplete: function (id, fileName, responseJson) {
            removeOverlay();
            if (responseJson.upload) {
                $("#listFileAnh").append(changeAnhDaiDien(responseJson));
                $("#listValueAnhAttach").val(changeHiddenAnhDaiDien(responseJson));

            } else {
                createMessage("Thông báo", responseJson.message);
            }
        }
    });
}
function changeHiddenAnhDaiDien(data) {
    var valueFile = '[';
    valueFile += '{"FileServer": "' + data.fileserver + '"\,';
    valueFile += '"FileName": "' + data.filename + '"\}';
    valueFile += "]";
    return valueFile;
}
function changeAnhDaiDien(data) {
    $("#pic1").attr("src", "/UserControls/Upload/Images/" + data.fileserver);
}
function formatState(state) {
    if (!state.id) { return state.text; }
    var $state = $(
        '<span><img src="' + state.element.getAttribute('coquocgia') + '" class="img-flag" /> ' + state.text + '</span>'
    );
    return $state;
};
//new function 19/10/2016
$.urlParam = function (name) {
    var results = new RegExp('[\?&#]' + name + '=([^&#]*)').exec(window.location.hash);
    if (results == null) {
        return null;
    }
    else {
        return results[1] || 0;
    }
}


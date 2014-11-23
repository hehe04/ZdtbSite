/// <reference path="libs/jquery.min.js" />
/// <reference path="messenger/bootbox.min.js" />
/// <reference path="libs/jquery.form.js" />
/// <reference path="messenger/messenger.min.js" />
$(function () {
    initAajxform();
    initLogout();
});

function modalLoading(msg) {
    if ('undefined' == typeof (document.body.style.maxHeight)) {
        return;
    }
    if (msg == null) {
        msg = "正在提交数据，请稍候";
    }
    bootbox.dialog({
        title: $(document).attr('title'),
        message: '<img src="/Areas/ZdtbAdmin/Content/img/ajax-loader2.gif" />' + msg,
        animate: false,
        buttons: {
        }
    });
}

function modalConfirm(title, message, callback) {
    bootbox.dialog({
        message: message,
        title: title,
        buttons: {
            success: {
                label: "取消",
                className: "btn-success",
                callback: function () {
                    callback(false);
                }
            },
            main: {
                label: "确定",
                className: "btn-primary",
                callback: function () {
                    callback(true);
                }
            }
        }
    });
}

function finAlert(message, issuccess, config) {
    if ('undefined' == typeof (document.body.style.maxHeight)) {
        alert(message);
        return;
    }
    Messenger.options = {
        extraClasses: 'messenger-fixed messenger-on-top',
        theme: 'future'
    }
    var msgConfig = $.extend({
        message: message,
        type: 'error',
        hideAfter: 10,
        hideOnNavigate: true,
        showCloseButton: true
    }, config);
    if (issuccess == false) {
        Messenger().post(msgConfig);
    }
    else {
        msgConfig.type = "success";
        Messenger().post(msgConfig);
    }
}

function initLogout() {
    $(".logout-js").click(function () {
        document.cookie = "";
    });
}

function initAajxform() {
    $("form").each(function (index, ele) {
        $(ele).ajaxForm({
            beforeSubmit: function myfunction() {
                if ($(ele).valid()) {
                    modalLoading();
                } else {
                    return false;
                }
            },
            error: function () {
                bootbox.hideAll();
                finAlert("提交数据过程中出现错误，请检查数据后重试提交", false);
            },
            dataType: "json",
            success: function (data) {
                bootbox.hideAll();
                if (data.Success) {
                    finAlert(data.Msg, true);
                    if (data.RedirectUrl != null) {
                        setTimeout(function () {
                            location = data.RedirectUrl;
                        }, 2000);
                    }
                }
                else {
                    finAlert(data.Msg, false);
                }
            }
        });
    });
}

function ajaxSubmit(url, data, beforAjaxMsg) {
    $.ajax({
        url: url,
        data: data,
        beforeSend: function myfunction() {
            modalLoading(beforAjaxMsg);
        },
        error: function () {
            bootbox.hideAll();
            finAlert("提交数据过程中出现错误，请检查数据后重试提交", false);
        },
        dataType: "json",
        success: function (data) {
            bootbox.hideAll();
            if (data.Success) {
                finAlert(data.Msg, true);
                if (data.RedirectUrl != null) {
                    setTimeout(function () {
                        location = data.RedirectUrl;
                    }, 2000);
                }
            }
            else {
                finAlert(data.Msg, false);
            }
        }
    });
}
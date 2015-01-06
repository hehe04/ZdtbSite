var editors = [];
KindEditor.ready(function (K) {
    var array = document.getElementsByTagName("textarea");
    for (var i = 0; i < array.length; i++) {
        var editor = K.create("#" + array[i].id, {
            uploadJson: '/ZdtbAdmin/FileManager/Upload',
            fileManagerJson: '/ZdtbAdmin/FileManager/Index',
            height: 500,
            items: [
    'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy', 'paste',
    'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
    'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
    'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
    'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
    'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
    'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
    'anchor', 'link', 'unlink', '|', 'about'
            ],
            allowFileManager: true
        });
        editors.push(editor);
    }

});
$(function () {
    $(".btn").click(function () {
        for (var i = 0; i < editors.length; i++) {
            editors[i].sync();
        }
        //console.log(editor);
        //editor.sync();
        //return false;
    });
});
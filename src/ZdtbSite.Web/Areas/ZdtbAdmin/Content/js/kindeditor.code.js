var editor;
KindEditor.ready(function (K) {
	editor = K.create('textarea', {
		uploadJson: '@Url.Action("Upload", "FileManager")',
		fileManagerJson: '@Url.Action("Index", "FileManager")',
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
});
$(function () {
	$(".btn").click(function () {
		editor.sync();
	});
});
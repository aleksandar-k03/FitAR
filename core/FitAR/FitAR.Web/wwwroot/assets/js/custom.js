function setCustom() {
	$('body').on('click', '.aopen', function (e) {
		e.preventDefault();
		var parent = $(this).closest('.pcoded-hasmenu_a');
		var sub = parent.find('.pcoded-submenu_a');
		if (sub.hasClass('pcodedsubmenu_a_opened')) {
			$(this).removeClass('aopen_opened');
			sub.removeClass('pcodedsubmenu_a_opened');
		}
		else {
			$(this).addClass('aopen_opened');
			sub.addClass('pcodedsubmenu_a_opened');
		}
	});

}

var CKCustomEditor = new function(){
	this.editor = null;

	this.init = function () {
		$('.ck-body-wrapper').remove();
		if (this.editor != null)
			try { this.editor.setData(''); }
			catch (e) { }

		if($('.ck').length == 0)
			return;

		var id = this.id();
		$('.ck').attr('id', id);

		function MyCustomUploadAdapterPlugin( editor ) {
			editor.plugins.get( 'FileRepository' ).createUploadAdapter = ( loader ) => {
				return new MyUploadAdapter( loader );
			};
		}

		var self = this;
		ClassicEditor
			.create(document.getElementById(id), {
				extraPlugins: [ MyCustomUploadAdapterPlugin ],
				toolbar: { items: [ 'heading', '|', 'alignment', 'bold', 'italic', 'link', 'bulletedList', 'numberedList', 'fontFamily', 'fontSize', 'fontColor', 'fontBackgroundColor', '|', 'indent', 'outdent', 'horizontalLine', '|', 'imageUpload', 'blockQuote', 'insertTable', 'mediaEmbed', 'undo', 'redo', 'codeBlock', 'code' ] },
				language: 'en',
				image: { toolbar: [ 'imageTextAlternative', 'imageStyle:full', 'imageStyle:side' ] },
				table: { contentToolbar: [ 'tableColumn', 'tableRow', 'mergeTableCells' ] }
			})
			.then( editor => { self.editor = editor; console.log( editor ); } )
			.catch( error => { console.error( error ); } )
	}

	this.id = function () {
		var length = 15;
		var result           = '';
		var characters       = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
		var charactersLength = characters.length;
		for ( var i = 0; i < length; i++ ) 
			result += characters.charAt(Math.floor(Math.random() * charactersLength));
   return result;
	}

	this.getData = function () {
		return this.editor.getData();
	}
}


// cookies
window.blazorExtensions = {

	WriteCookie: function (name, value, days) {

		var expires;
		if (days) {
			var date = new Date();
			date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
			expires = "; expires=" + date.toGMTString();
		}
		else {
			expires = "";
		}
		document.cookie = name + "=" + value + expires + "; path=/";
	}
}